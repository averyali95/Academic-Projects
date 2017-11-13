package com.meme.manager;

import com.meme.Constants;
import com.meme.ui.MemeWindow;
import com.meme.ui.page.DownloadPage;
import com.meme.ui.page.LoginPage;
import javafx.embed.swing.SwingFXUtils;
import javafx.scene.image.Image;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.net.URI;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

/**
 * The managing class for all the memes.
 *
 * @author Subin Jacob
 * @author Avery Ali
 * @author Gael Bruno
 */
public class MemeManager {

    /**
     * The list of images.
     */
    private static final List<Image> IMAGES = new ArrayList<>();

    /**
     * The static list of the meme links.
     */
    private static final List<String> MEME_LINKS = new ArrayList<>();

    /**
     * The lock object.
     */
    private static final Object LOCK = new Object();

    /**
     * The index of the meme selection.
     */
    private static Image selection;

    /**
     * Initializes the meme manager.
     */
    public static void init() {
        try {
            URL fontUrl = DownloadPage.class.getResource("/impact.ttf");
            if (fontUrl == null) {
                AlertManager.sendError("Meme Manager", "Invalid URL path for the font.");
                return;
            }
            Font font = Font.createFont(Font.TRUETYPE_FONT, fontUrl.openStream());
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(font);

            URL url = DownloadPage.class.getResource("/txt/memes_list.txt");
            if (url == null) {
                AlertManager.sendError("Meme Manager", "Invalid URL path for the list of meme links.");
                return;
            }
            URI uri = url.toURI();
            File file = new File(uri);
            if (!file.exists()) {
                AlertManager.sendError("Meme Manager", "The mem link file is invalid or doesn't exist.");
                return;
            }
            BufferedReader reader = new BufferedReader(new FileReader(file));
            String line;
            while ((line = reader.readLine()) != null) {
                if (line.isEmpty() || line.length() < 10) {
                    continue;
                }
                MEME_LINKS.add(line);
            }
            reader.close();
            check();
        } catch (Throwable e) {
            e.printStackTrace();
        }
    }

    /**
     * Checks the meme folder if images exists or not.
     */
    private static void check() {
        try {
            File folder = new File(Constants.CONFIG_PATH + "/memes/");
            if (!folder.exists()) {
                folder.mkdirs();
            }
            File[] files = folder.listFiles();
            if (files != null && files.length < MEME_LINKS.size()) {
                DownloadPage.setProgressText("Initializing images download...");
                DownloadManager.downloadList(MEME_LINKS);
                ProcessManager.submit(DownloadManager.createDownloadWorker());
                return;
            }
            ProcessManager.submit(createImageWorker());
        } catch (Throwable e) {
            e.printStackTrace();
        }
    }

    /**
     * Writes an image to a file.
     *
     * @param image The image to be written to a file.
     */
    public static void writeImage(File file, BufferedImage image) {
        synchronized (LOCK) {
            ProcessManager.submit(() -> {
                try {
                    ImageIO.write(image, "png", file);
                } catch (Throwable e) {
                    e.printStackTrace();
                }
                synchronized (LOCK) {
                    LOCK.notify();
                }
            });
            try {
                LOCK.wait();
            } catch (Throwable e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * Creates a thread worker for reading the images and adding them to the list.
     *
     * @return The thread worker.
     */
    static Runnable createImageWorker() {
        return () -> {
            try {
                while (MemeWindow.stage() == null) {
                    //Waits for the application to be fully loaded before starting.
                    Thread.sleep(2500);
                }
                File folder = new File(Constants.CONFIG_PATH + "/memes/");
                if (!folder.exists()) {
                    return;
                }
                File[] files = folder.listFiles();
                if (files == null || files.length == 0) {
                    return;
                }
                int count = 0;
                DownloadPage.setProgressBar(0.0);
                for (File file : files) {
                    if (file == null) {
                        continue;
                    }
                    BufferedImage image = ImageIO.read(file);
                    if (image == null) {
                        continue;
                    }
                    Image fxImage = SwingFXUtils.toFXImage(image, null);
                    count++;
                    IMAGES.add(fxImage);
                    DownloadPage.setProgressText("Reading Image #" + count);

                    double total = files.length;
                    double progress = count / total;
                    DownloadPage.setProgressBar(progress);

                    Thread.sleep(150);
                }

                DownloadPage.setProgressText("Completed reading images...");
                Thread.sleep(750);

                PageViewManager.show(LoginPage.class);
            } catch (Throwable e) {
                e.printStackTrace();
            }
        };
    }

    /**
     * Sets the image selection.
     *
     * @param img The image selection.
     */
    public static void select(Image img) {
        selection = img;
    }

    /**
     * Gets the image selection.
     * @return The image selected.
     */
    public static Image selection() {
        return selection;
    }

    /**
     * Gets the list of all the meme images.
     *
     * @return The list of all the meme images.
     */
    public static List<Image> getImages() {
        return IMAGES;
    }

    /**
     * Gets the list of all of the meme links available.
     *
     * @return The list of all the link to memes.
     */
    static List<String> getMemesLink() {
        return MEME_LINKS;
    }

}