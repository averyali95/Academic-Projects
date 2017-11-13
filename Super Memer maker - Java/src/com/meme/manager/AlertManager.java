package com.meme.manager;

import com.meme.ui.MemeWindow;
import javafx.application.Platform;
import javafx.scene.control.Alert;
import javafx.scene.image.ImageView;
import javafx.stage.Stage;

/**
 * The managing class for sending notification and dialogs using alerts.
 *
 * @author Subin Jacob
 */
public class AlertManager {

    /**
     * Sends a normal alert with a text and tile, but waits till user
     * presses an action to continue the next operations.
     *
     * @param title The alert title.
     * @param text  The alert text.
     */
    public static void sendAndWait(String title, String text) {
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle(title);
        alert.setContentText(text);
        alert.setResizable(false);
        setAlertIcon(alert);
        if (title.equals("Meme Creation")) {
            Platform.runLater(alert::showAndWait);
        } else {
            alert.showAndWait();
        }
    }

    /**
     * Send an error alert with a text and title.
     *
     * @param title The alert title.
     * @param text  The alert text.
     */
    public static void sendError(String title, String text) {
        Alert alert = new Alert(Alert.AlertType.ERROR);
        alert.setTitle(title);
        alert.setContentText(text);
        alert.setResizable(false);
        setAlertIcon(alert);
        alert.showAndWait();
    }

    /**
     * Sets the alert's stage window's icon.
     *
     * @param alert The alert.
     */
    private static void setAlertIcon(Alert alert) {
        alert.setGraphic(new ImageView(MemeWindow.getIcon()));
        Stage stage = (Stage) alert.getDialogPane().getScene().getWindow();
        MemeWindow.setStageIcon(stage);
    }

}