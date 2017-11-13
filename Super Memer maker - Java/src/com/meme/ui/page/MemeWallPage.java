package com.meme.ui.page;

import com.meme.manager.AlertManager;
import com.meme.manager.FirebaseManager;
import com.meme.manager.PageViewManager;
import com.meme.manager.ProcessManager;
import com.meme.ui.MemeWindow;
import com.meme.util.PageLoader;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.geometry.Pos;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.VBox;
import javafx.scene.text.Text;
import javafx.stage.Stage;

import java.net.URL;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.ResourceBundle;

/**
 * The meme wall page for loading the page and initializing all the components in it.
 *
 * @author Subin J.
 */
public class MemeWallPage implements PageLoader, Initializable {

    @FXML
    private VBox memePane;

    @FXML
    private Button backButton;

    @Override
    public void show(Stage stage) {
        Platform.runLater(() -> {
            try {
                Parent group = FXMLLoader.load(MemeWindow.class.getResource("/fxml/memewallpage.fxml"));
                Scene scene = new Scene(group);
                scene.setFill(null);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/memewallpage.css").toExternalForm());
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
        ProcessManager.submit(this::load);
    }

    /**
     * Loads the images from firebase onto the stage.
     */
    private void load() {
        HashMap<String, Map<String, Object>> map = (HashMap) FirebaseManager.readFirebase("posts/");
        if (map == null || map.size() == 0) {
            AlertManager.sendError("Firebase Database", "Invalid data retrieved from firebase database.");
            return;
        }
        String uname = (String) FirebaseManager.getUserMapInfo("name");
        for (String key : map.keySet()) {
            if (key == null) {
                continue;
            }
            Map<String, Object> m = map.get(key);
            if (m == null) {
                continue;
            }
            String url = (String) m.get("url");
            String name = (String) m.get("name");
            long time = (long) m.get("time");
            //---------------------------//

            Date date = new Date(time);
            Text text = new Text();
            text.setId("postText");
            text.setText(name + " posted on " + date.toLocaleString());

            VBox textWrapper = new VBox();
            textWrapper.setId("textWrapper");
            textWrapper.setAlignment(Pos.CENTER);
            textWrapper.getChildren().add(text);
            textWrapper.setPrefHeight(30);
            //---------------------------//

            VBox postWrapper = new VBox();
            postWrapper.setSpacing(3);
            postWrapper.setAlignment(Pos.CENTER);

            Image image = new Image(url);
            ImageView view = new ImageView(image);
            view.setFitHeight(450);
            view.setPreserveRatio(true);
            //---------------------------//

            postWrapper.getChildren().addAll(textWrapper, view);

            if (uname != null && uname.equals(name)) {
                Button remove = new Button("Remove Post");
                remove.setOnAction(event -> ProcessManager.submit(() -> {
                    FirebaseManager.writeFirebase("posts/"+key, null);
                    Platform.runLater(() -> memePane.getChildren().remove(postWrapper));
                }));
                postWrapper.getChildren().add(remove);
            }

            Platform.runLater(() -> {
                if (memePane != null) {
                    memePane.getChildren().add(postWrapper);
                }
            });
        }
    }

}