package com.meme.ui.page;

import com.meme.manager.AlertManager;
import com.meme.manager.MemeManager;
import com.meme.manager.PageViewManager;
import com.meme.manager.ProcessManager;
import com.meme.ui.MemeWindow;
import com.meme.util.PageLoader;
import javafx.application.Platform;
import javafx.beans.property.BooleanProperty;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.css.PseudoClass;
import javafx.embed.swing.SwingFXUtils;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.geometry.Pos;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseButton;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;

public class HomePage implements PageLoader, Initializable {

    /**
     * The pseudo class for image view border.
     */
    private static final PseudoClass IMG_VIEW_BORDER = PseudoClass.getPseudoClass("border");

    @FXML
    private VBox memePane;

    @FXML
    private Button wallButton;

    @FXML
    private Button customButton;

    @FXML
    private Button chooseButton;

    @FXML
    private Button helpButton;
    
    @FXML
    private Button logoutButton;

    /**
     * The selected boolean property.
     */
    private BooleanProperty selected;

    @Override
    public void show(Stage stage) {
        Platform.runLater(() -> {
            try {
                stage.setWidth(1200);
                stage.setHeight(700);
                Parent group = FXMLLoader.load(MemeWindow.class.getResource("/fxml/homepage.fxml"));
                Scene scene = new Scene(group);
                scene.setFill(null);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/homepage.css").toExternalForm());
                stage.setScene(scene);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        });
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        assert memePane != null;
        assert customButton != null;
        assert chooseButton != null;
        assert wallButton != null;
        assert helpButton != null;
        assert logoutButton != null;
        wallButton.setOnAction(event -> PageViewManager.show(MemeWallPage.class));
        customButton.setOnAction(event -> ProcessManager.submit(this::useCustomImage));
        chooseButton.setOnAction(event -> PageViewManager.show(CreationPage.class));
        helpButton.setOnAction(event -> PageViewManager.show(HelpPage.class));
        logoutButton.setOnAction(event -> PageViewManager.show(LoginPage.class));
        load();
    }

    /**
     * Loads the image view display.
     */
    private void load() {
        List<Image> imageList = MemeManager.getImages();
        for (Image image : imageList) {
            if (image == null) {
                continue;
            }
            ImageView view = new ImageView();
            view.setFitHeight(450);
            view.setPreserveRatio(true);
            view.setImage(image);

            VBox wrapper = new VBox(view);
            wrapper.setMaxWidth(500);
            wrapper.setAlignment(Pos.CENTER);
            wrapper.getStyleClass().add("image-view-wrapper");

            BooleanProperty property = new SimpleBooleanProperty() {
                @Override
                protected void invalidated() {
                    wrapper.pseudoClassStateChanged(IMG_VIEW_BORDER, get());
                }
            };
            view.setOnMouseClicked(event -> {
                if (event.getButton() != MouseButton.PRIMARY) {
                    return;
                }
                boolean current = property.get();
                if (selected != null) {
                    if (selected != property) {
                        selected.set(false);
                    }
                }
                property.set(!current);
                chooseButton.setDisable(current);
                selected = property;
                MemeManager.select(image);
            });
            Platform.runLater(() -> {
                if (memePane != null) {
                    memePane.getChildren().add(wrapper);
                }
            });
        }
    }

    /**
     * Allows the user to upload an image and use that instead of the
     * ones we have available.
     */
    public void useCustomImage() {
        File file = MemeWindow.load();
        if (file == null || !file.exists()) {
            AlertManager.sendAndWait("Custom Image", "Unable to read the file selected.");
            return;
        }
        try {
            BufferedImage img = ImageIO.read(file);
            Image image = SwingFXUtils.toFXImage(img, null);
            MemeManager.select(image);
            PageViewManager.show(CreationPage.class);
        } catch (Throwable t) {
            t.printStackTrace();
        }
    }

}