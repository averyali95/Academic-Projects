package com.meme.ui.page;

import com.meme.ui.MemeWindow;
import com.meme.util.PageLoader;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.ProgressBar;
import javafx.stage.Stage;

import java.net.URL;
import java.util.ResourceBundle;

/**
 * The download page of the application.
 *
 * @author Subin Jacob
 * @author Avery Ali
 * @author Gael Bruno
 */
public class DownloadPage implements PageLoader, Initializable {

    /**
     * The download page instance.
     */
    private static DownloadPage instance;

    /**
     * The static object of the progress bar for downloading.
     */
    @FXML
    private ProgressBar progressBar;

    /**
     * The static object of the label for downloading.
     */
    @FXML
    private Label progressLabel;

    /**
     * Creates a new instance of the download page.
     */
    public DownloadPage() {
        instance = this;
    }

    /**
     * Sets the progress label text.
     *
     * @param text The label text.
     */
    public static void setProgressText(String text) {
        if (instance != null && instance.progressLabel != null && text != null) {
            Platform.runLater(() -> instance.progressLabel.setText(text));
        }
    }

    /**
     * Sets the progress bar completion.
     *
     * @param value The progress value.
     */
    public static void setProgressBar(double value) {
        if (instance != null && instance.progressBar != null) {
            Platform.runLater(() -> instance.progressBar.setProgress(value));
        }
    }

    @Override
    public void show(Stage stage) {
        instance = this;
        Platform.runLater(() -> {
            try {
                Parent root = FXMLLoader.load(MemeWindow.class.getResource("/fxml/downloadpage.fxml"));
                Scene scene = new Scene(root);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/downloadpage.css").toExternalForm());
                stage.setScene(scene);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        });
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        assert instance != null;
        assert progressBar != null;
        assert progressLabel != null;
    }
}
