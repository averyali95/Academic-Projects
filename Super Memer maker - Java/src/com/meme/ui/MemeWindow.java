package com.meme.ui;

import com.meme.Constants;
import com.meme.manager.AlertManager;
import com.meme.manager.PageViewManager;
import com.meme.manager.ProcessManager;
import com.meme.ui.page.DownloadPage;
import javafx.application.Application;
import javafx.application.Platform;
import javafx.embed.swing.SwingFXUtils;
import javafx.scene.Node;
import javafx.scene.SnapshotParameters;
import javafx.scene.image.Image;
import javafx.scene.image.WritableImage;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.awt.image.BufferedImage;
import java.io.File;

/**
 * The main class for generating the window application.
 *
 * @author Subin Jacob
 * @author Avery Ali
 * @author Gael Bruno
 */
public class MemeWindow extends Application {

    /**
     * The object lock variable.
     */
    private static final Object LOCK = new Object();

    /**
     * The javafx application stage frame.
     */
    private static Stage stage;

    /**
     * The stage's icon.
     */
    private static Image icon;

    /**
     * Opens the frame window.
     */
    public static void initWindow() {
        launch();
    }

    /**
     * Sets the main application stage's icon.
     *
     * @param stage The application stage.
     */
    public static void setStageIcon(Stage stage) {
        try {
            stage.getIcons().add(icon);
        } catch (Throwable t) {
            t.printStackTrace();
        }
    }

    /**
     * Sets the title of the JFrame.
     *
     * @param text The title text.
     */
    public static void setTitle(String text) {
        if (stage != null) {
            Platform.runLater(() -> stage.setTitle(text));
        }
    }

    /**
     * Shows the directory chooser dialog for saving a meme.
     *
     * @return The path to save the image.
     */
    public static File save() {
        final File[] file = {new File(Constants.CONFIG_PATH)};
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Save Meme");
        chooser.setInitialDirectory(file[0]);
        chooser.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("PNG", "*.png"),
                new FileChooser.ExtensionFilter("JPG", "*.jpg"),
                new FileChooser.ExtensionFilter("JPEG", "*.jpeg"),
                new FileChooser.ExtensionFilter("GIF", "*.gif")
        );
        synchronized (LOCK) {
            Platform.runLater(() -> {
                file[0] = chooser.showSaveDialog(stage);
                synchronized (LOCK) {
                    LOCK.notify();
                }
            });
            try {
                LOCK.wait();
            } catch (Throwable t) {
                t.printStackTrace();
            }
        }
        return file[0];
    }

    /**
     * Loads an image file into the program.
     * @return The image file.
     */
    public static File load() {
        final File[] file = {new File(Constants.USER_PATH)};
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Use your own picture");
        chooser.setInitialDirectory(file[0]);
        chooser.getExtensionFilters().add(new FileChooser.ExtensionFilter("Image Files", "*.png", "*.jpg", "*.jpeg", "*.gif"));
        synchronized (LOCK) {
            Platform.runLater(() -> {
                file[0] = chooser.showOpenDialog(stage);
                synchronized (LOCK) {
                    LOCK.notify();
                }
            });
            try {
                LOCK.wait();
            } catch (Throwable t) {
                t.printStackTrace();
            }
        }
        return file[0];
    }

    /**
     * Captures an image from a JavaFX node.
     *
     * @param node The javafx node
     */
    public static BufferedImage captureNodeImage(Node node) {
        try {
            final BufferedImage[] imgs = new BufferedImage[1];
            synchronized (LOCK) {
                Platform.runLater(() -> {
                    WritableImage image = node.snapshot(new SnapshotParameters(), null);
                    if (image == null) {
                        AlertManager.sendError("Meme Creation", "Unable to create a writable image from a node.");
                        return;
                    }
                    ProcessManager.submit(() -> {
                        BufferedImage img = SwingFXUtils.fromFXImage(image, null);
                        if (img == null) {
                            AlertManager.sendError("Meme Creation", "Unable to create a image from the FX image.");
                            return;
                        }
                        imgs[0] = img;
                        synchronized (LOCK) {
                            LOCK.notify();
                        }
                    });
                });
                LOCK.wait();
            }
            return imgs[0];
        } catch (Throwable e) {
            e.printStackTrace();
        }
        return null;
    }

    /**
     * Gets the stage icon.
     *
     * @return The stage icon.
     */
    public static Image getIcon() {
        return icon;
    }

    /**
     * Gets the javafx stage instance.
     *
     * @return The stage instance.
     */
    public static Stage stage() {
        return stage;
    }

    @Override
    public void start(Stage mainStage) {
        icon = new Image("./image/icon.png");
        mainStage.setTitle("[" + Constants.NAME + "] " + Constants.VERSION);
        mainStage.setOnCloseRequest(event -> {
            try {
                stop();
                System.exit(-1);
            } catch (Throwable e) {
                e.printStackTrace();
            }
        });
        mainStage.setResizable(false);
        mainStage.setWidth(750);
        mainStage.setHeight(422);
        setStageIcon(mainStage);
        mainStage.show();
        stage = mainStage;
        PageViewManager.show(DownloadPage.class);
    }

}
