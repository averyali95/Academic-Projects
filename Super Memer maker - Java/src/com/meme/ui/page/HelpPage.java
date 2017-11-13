package com.meme.ui.page;

import com.meme.manager.PageViewManager;
import com.meme.ui.MemeWindow;
import com.meme.util.PageLoader;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

import java.net.URL;
import java.util.ResourceBundle;

public class HelpPage implements PageLoader, Initializable {

    @FXML
    private Button backButton;

    @Override
    public void show(Stage stage) {
        Platform.runLater(() -> {
            try {
                Parent group = FXMLLoader.load(MemeWindow.class.getResource("/fxml/helppage.fxml"));
                Scene scene = new Scene(group);
                scene.setFill(null);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/helppage.css").toExternalForm());
                stage.setScene(scene);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        });
    }


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        assert backButton != null;
        backButton.setOnAction(event -> PageViewManager.show(HomePage.class));
    }

}
