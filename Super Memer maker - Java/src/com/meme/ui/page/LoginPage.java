package com.meme.ui.page;

import com.meme.manager.AlertManager;
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
import javafx.scene.input.KeyCode;
import javafx.stage.Stage;

import java.net.URL;
import java.util.ResourceBundle;

/**
 * The login page class used for implementing methods and others for a functional login page.
 *
 * @author Subin J.
 * @author Avery Ali
 * @author Gael Bruno
 */
public class LoginPage implements PageLoader, Initializable {

    @FXML
    private TextField usernameField;

    @FXML
    private PasswordField passwordField;

    @FXML
    private Button loginButton;

    @FXML
    private Button registerButton;

    @FXML
    private Button forgotButton;

    @Override
    public void show(Stage stage) {
        Platform.runLater(() -> {
            try {
                stage.setHeight(500);
                stage.setWidth(700);
                Parent group = FXMLLoader.load(MemeWindow.class.getResource("/fxml/loginpage.fxml"));
                Scene scene = new Scene(group);
                scene.getStylesheets().add(MemeWindow.class.getResource("/css/loginpage.css").toExternalForm());
                stage.setScene(scene);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        });
    }

    @Override
    public void initialize(URL location, ResourceBundle res) {
        assert usernameField != null;
        assert passwordField != null;
        assert loginButton != null;
        assert registerButton != null;
        assert forgotButton != null;
        loginButton.setOnAction(event -> login());
        usernameField.setOnKeyPressed(keyEvent -> {
            if (keyEvent.getCode() == KeyCode.ENTER) {
                passwordField.requestFocus();
            }
        });
        passwordField.setOnKeyPressed(keyEvent -> {
            if (keyEvent.getCode() == KeyCode.ENTER) {
                login();
            }
        });
        registerButton.setOnAction(event -> PageViewManager.show(RegisterPage.class));
        forgotButton.setOnAction(event -> PageViewManager.show(ForgotPage.class));
    }

    /**
     * Logs in the user with username and password.
     */
    private void login() {
        String username = usernameField.getText();
        String password = passwordField.getText();
        if (FirebaseManager.login(username, password)) {
            AlertManager.sendAndWait("Firebase Manager", "Successfully authenticated with Google Firebase!");
            PageViewManager.show(HomePage.class);
        }
    }
}