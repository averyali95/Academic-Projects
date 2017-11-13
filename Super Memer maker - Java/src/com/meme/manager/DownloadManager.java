package com.meme.manager;

import com.meme.Constants;
import com.meme.ui.MemeWindow;
import com.meme.ui.page.DownloadPage;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.List;

/**
 * The managing class for handling all the file downloads.
 *
 * @author Subin J.
 * @author Avery Ali
 * @author Gael Bruno
 */
public class DownloadManager {

    /**
     * The queue of the downloads.
     */
    private static final Deque<String> DOWNLOAD_QUEUE = new ArrayDeque<>();

    /**
     * The counter for the downloads.
     */
    private static int DOWNLOAD_COUNT = 0;

    /**
     * Downloads all the links in a list into a path.
     */
    public static void downloadList(List<String> list) {
        list.stream().filter(string -> (string != null)).forEach(DownloadManager::submit);
    }

    /**
     * Submits a URL string for the application to download.
     */
    public static void submit(String url) {
        DOWNLOAD_QUEUE.push(url);
    }

    /**
     * Creates a task worker for the download tasks.
     *
     * @return The task worker.
     */
    static Runnable createDownloadWorker() {
        return () -> {
            while (true) {
                try {
                    while (MemeWindow.stage() == null) {
                        //Waits for the application to be fully loaded before starting.
                        Thread.sleep(2500);
                    }
                    synchronized (DOWNLOAD_QUEUE) {
                        if (DOWNLOAD_QUEUE.isEmpty()) {
                            DownloadPage.setProgressText("All images were downloaded...");
                            ProcessManager.submit(MemeManager.createImageWorker());
                            return;
                        }

                        DOWNLOAD_COUNT++;
                        DownloadPage.setProgressText("Downloading Image #" + DOWNLOAD_COUNT);
                        String url = DOWNLOAD_QUEUE.poll();
                        BufferedImage image = parseImage(url);
                        if (image != null) {
                            File path = new File(Constants.CONFIG_PATH + "/memes/meme_" + DOWNLOAD_COUNT + ".jpg");
                            ImageIO.write(image, "jpeg", path);
                        }

                        double total = MemeManager.getMemesLink().size();
                        double progress = DOWNLOAD_COUNT / total;
                        DownloadPage.setProgressBar(progress);
                        Thread.sleep(150);
                    }
                } catch (Throwable t) {
                    t.printStackTrace();
                }
            }
        };
    }

    /**
     * Parses the image object from the link with advanced user-agent properties for http connection.
     *
     * @param link The http link.
     * @return The image object.
     */
    private static BufferedImage parseImage(String link) {
        try {
            URL url = new URL(link);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestProperty("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_5) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.65 Safari/537.31");
            return ImageIO.read(conn.getInputStream());
        } catch (Throwable t) {
            t.printStackTrace();
        }
        return null;
    }
}