package com.meme.ui.page;

import com.meme.manager.FirebaseManager;
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
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.net.URL;
import java.util.ResourceBundle;

/**
 * The forgot password page for possibly resetting a user's password.
 *
 * @author Subin Jacob
 */
public class ForgotPage implements PageLoader, Initializable {

    @FXML
    private TextField nameField;

    @FXML
    private TextField usernameField;

    @FXML
    private PasswordField passwordField;

    @FXML
    private PasswordField confirmPassField;

    @FXML
    private Button submitButton;

    @FXML
    private Button cancelButton;

    @Override
    public void show(Stage stage) {
        Platform.runLater(() -> {
            try {
                stage.setHeight(525);
                Parent group = FXMLLoader.load(MemeWindow.class.getResource("/fxml/forgotpasspage.fxml"));
                Scene scene = new Scene(group);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/forgotpasspage.css").toExternalForm());
                stage.setScene(scene);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        });
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        assert nameField != null;
        assert usernameField != null;
        assert passwordField != null;
        assert confirmPassField != null;
        assert submitButton != null;
        assert cancelButton != null;
        submitButton.setOnAction(event -> {
            String name = nameField.getText();
            String username = usernameField.getText();
            String password = passwordField.getText();
            String confirmPassword = confirmPassField.getText();
            FirebaseManager.reset(name, username, password, confirmPassword);
        });
        cancelButton.setOnAction(event -> PageViewManager.show(LoginPage.class));
    }

}