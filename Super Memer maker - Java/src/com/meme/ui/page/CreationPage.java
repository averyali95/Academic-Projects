package com.meme.ui.page;

import com.meme.manager.*;
import com.meme.ui.MemeWindow;
import com.meme.util.PageLoader;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.StackPane;
import javafx.scene.text.Font;
import javafx.scene.text.Text;
import javafx.stage.Stage;

import java.awt.image.BufferedImage;
import java.io.File;
import java.net.URL;
import java.util.HashMap;
import java.util.Map;
import java.util.ResourceBundle;

/**
 * The meme creating sub page
 *
 * @author Subin
 */
public class CreationPage implements PageLoader, Initializable {

    @FXML
    private BorderPane rootPane;

    @FXML
    private TextField topTextField;

    @FXML
    private TextField botTextField;

    @FXML
    private StackPane displayPane;

    @FXML
    private Button saveButton;

    @FXML
    private Button shareButton;

    @FXML
    private Button cancelButton;

    @FXML
    private Text topText;

    @FXML
    private Text botText;

    @FXML
    private ImageView imageView;

    /**
     * The last image save.
     */
    private File lastSave;

    /**
     * Gets the formatted string from the text field.
     *
     * @param field The text field.
     * @return The formatted string.
     */
    private static String getFormattedString(TextField field) {
        String text = field.getText();
        if (text == null || text.length() < 1) {
            return null;
        }
        text = text.toUpperCase();
        return text;
    }

    @Override
    public void show(Stage stage) {
        Platform.runLater(() -> {
            try {
                Parent group = FXMLLoader.load(MemeWindow.class.getResource("/fxml/creationpage.fxml"));
                Scene scene = new Scene(group);
                scene.setFill(null);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/creationpage.css").toExternalForm());
                stage.setScene(scene);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        });
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        assert rootPane != null;
        assert topTextField != null;
        assert botTextField != null;
        assert displayPane != null;
        assert saveButton != null;
        assert shareButton != null;
        assert cancelButton != null;
        assert topText != null;
        assert botText != null;
        assert imageView != null;
        saveButton.setOnAction(event -> ProcessManager.submit(this::save));
        shareButton.setOnAction(event -> share());
        cancelButton.setOnAction(event -> PageViewManager.show(HomePage.class));
        topTextField.setOnKeyReleased(event -> Platform.runLater(() -> topText.setText(getFormattedString(topTextField))));
        botTextField.setOnKeyReleased(event -> Platform.runLater(() -> botText.setText(getFormattedString(botTextField))));
        Platform.runLater(() -> saveButton.requestFocus());

        Image image = MemeManager.selection();
        if (image == null) {
            AlertManager.sendError("Creating Meme", "The image is invalid to be used.");
            return;
        }
        imageView.setImage(image);

        int width = (int) imageView.getLayoutBounds().getWidth();
        displayPane.setMaxWidth(width);
        topText.setWrappingWidth(width - 20);
        botText.setWrappingWidth(width - 20);

        int size = (int) Math.ceil(width * 0.070);
        Font font = new Font("Impact", size);
        topText.setFont(font);
        botText.setFont(font);
    }

    /**
     * Creates the meme with the text and etc.
     */
    private void save() {
        BufferedImage image = MemeWindow.captureNodeImage(displayPane);
        if (image == null) {
            AlertManager.sendError("Meme Creation", "Unable to generate an image from the node.");
            return;
        }
        File path = MemeWindow.save();
        MemeManager.writeImage(path, image);
        lastSave = path;
        AlertManager.sendAndWait("Meme Creation", "Successfully created and saved the meme.");
    }

    /**
     * Shares the meme to the wall.
     */
    private void share() {
        if (lastSave == null || !lastSave.exists()) {
            AlertManager.sendError("Image Share", "Unable to locate the saved meme file. Please save the image first.");
            return;
        }
        String url = CloudinaryManager.upload(lastSave);
        if (url == null) {
            AlertManager.sendError("Image Share", "Unable to get the image link of the image uploaded.");
            return;
        }
        String name = (String) FirebaseManager.getUserMapInfo("name");
        if (name == null) {
            AlertManager.sendError("Image Share", "Unable to find the name of the current user.");
            return;
        }
        Map<String, Object> map = new HashMap<>();
        map.put("name", name);
        map.put("url", url);
        map.put("time", System.currentTimeMillis());
        FirebaseManager.writeFirebase("posts/" + url.hashCode(), map);
        AlertManager.sendAndWait("Meme Creation", "Successfully uploaded the image to Cloudinary and saved to Firebase database.");
    }

}