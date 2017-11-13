package com.meme.manager;

import com.google.firebase.FirebaseApp;
import com.google.firebase.FirebaseOptions;
import com.google.firebase.auth.FirebaseCredentials;
import com.google.firebase.database.*;
import com.meme.ui.page.LoginPage;
import com.meme.util.Crypto;

import java.io.File;
import java.io.FileInputStream;
import java.util.HashMap;
import java.util.Map;

/**
 * The class used for establishing connection with Google Firebase.
 *
 * @author Subin
 */
public class FirebaseManager {

    /**
     * The object lock variable.
     */
    private static final Object LOCK = new Object();

    /**
     * The map of the user details
     */
    private static Map<String, Object> usermap;

    /**
     * The database reference.
     */
    private static DatabaseReference dbReference;

    /**
     * Initializes the connection to firebase.
     */
    public static void init() {
        try {
            File file = new File("./data/firebase.json");
            if (!file.exists()) {
                AlertManager.sendError("Firebase Manager", "Error locating the firebase json configuration file.");
                return;
            }
            FileInputStream fis = new FileInputStream(file);
            FirebaseOptions options = new FirebaseOptions.Builder()
                    .setCredential(FirebaseCredentials.fromCertificate(fis))
                    .setDatabaseUrl("https://memegenerator-186e1.firebaseio.com/")
                    .build();
            FirebaseApp firebase = FirebaseApp.initializeApp(options);
            dbReference = FirebaseDatabase.getInstance(firebase).getReference("");
        } catch (Throwable e) {
            e.printStackTrace();
            System.exit(-1);
        }
    }

    /**
     * Checks if the user can login into the firebase with correct credentials.
     *
     * @param username The username.
     * @param password The password.
     */
    public static boolean login(String username, String password) {
        if (username == null || username.length() < 1) {
            AlertManager.sendError("Firebase Manager", "Please enter your username!");
            return false;
        }
        if (password == null || password.length() < 1) {
            AlertManager.sendError("Firebase Manager", "Please enter your password!");
            return false;
        }
        Object data = readFirebase("users/" + username);
        boolean exists = checkUserExists(data);
        if (!exists) {
            AlertManager.sendError("Firebase Manager", "Username does not exist in the database!");
            return false;
        }
        HashMap<String, Object> map = (HashMap<String, Object>) data;
        if (map.size() < 1) {
            AlertManager.sendError("Firebase Manager", "No data exists for the user!");
            return false;
        }
        password = Crypto.hash(password);
        String hash = (String) map.get("password");
        if (!hash.equals(password)) {
            AlertManager.sendError("Firebase Manager", "You've entered an invalid password!");
            return false;
        }
        map.put("username", username);
        usermap = map;
        return true;
    }

    /**
     * Registers an account on the firebase database.
     *
     * @param name        The user's name.
     * @param username    The username.
     * @param password    The password.
     * @param confirmPass The password confirmation.
     */
    public static boolean register(String name, String username, String password, String confirmPass) {
        if (name == null || name.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please enter your name!");
            return false;
        }
        if (username == null || username.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please enter your username!");
            return false;
        }
        if (password == null || password.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please enter your password!");
            return false;
        }
        if (confirmPass == null || confirmPass.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please re-confirm your password!");
            return false;
        }
        if (!password.equals(confirmPass)) {
            AlertManager.sendError("Firebase Manager", "Your passwords did not match!");
            return false;
        }
        if (checkUserExists(username)) {
            AlertManager.sendError("Firebase Manager", "User already exists!");
            return false;
        }
        password = Crypto.hash(password);
        HashMap<String, Object> map = new HashMap<>();
        map.put("password", password);
        map.put("name", name);
        writeFirebase("users/" + username, map);
        map.put("username", username);
        usermap = map;
        return true;
    }

    /**
     * Resets the password for a user.
     *
     * @param name        The name of the user.
     * @param username    The username.
     * @param password    The new password.
     * @param confirmPass The new password confirmation.
     * @return
     */
    public static boolean reset(String name, String username, String password, String confirmPass) {
        if (name == null || name.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please enter your name!");
            return false;
        }
        if (username == null || username.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please enter your username!");
            return false;
        }
        if (password == null || password.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please enter your password!");
            return false;
        }
        if (confirmPass == null || confirmPass.isEmpty()) {
            AlertManager.sendError("Firebase Manager", "Please re-confirm your password!");
            return false;
        }
        if (!password.equals(confirmPass)) {
            AlertManager.sendError("Firebase Manager", "Your passwords did not match!");
            return false;
        }
        HashMap<String, Object> data = (HashMap<String, Object>) readFirebase("users/" + username);
        boolean exists = checkUserExists(data);
        if (!exists) {
            AlertManager.sendError("Firebase Manager", "Username does not exist in the database!");
            return false;
        }
        String currName = (String) data.get("name");
        if (currName == null) {
            AlertManager.sendError("Firebase Manager", "Current name existing is invalid!");
            return false;
        }
        if (!currName.equals(name)) {
            AlertManager.sendError("Firebase Manager", "Your name doesn't match the name on the database!");
            return false;
        }
        password = Crypto.hash(password);
        data.put("password", password);
        writeFirebase("users/" + username, data);
        AlertManager.sendAndWait("Password Reset", "Your password has successfully been reset!");
        PageViewManager.show(LoginPage.class);
        data.put("username", username);
        usermap = data;
        return true;
    }

    /**
     * Checks if the username already exists in the database.
     *
     * @param username The username.
     * @return The boolean value if username exists on firebase.
     */
    public static boolean checkUserExists(String username) {
        Object value = readFirebase("users/" + username);
        return value != null;
    }

    /**
     * Checks if the user already exists on the database.
     *
     * @param data The firebase data.
     * @return The boolean value if username exists on firebase.
     */
    public static boolean checkUserExists(Object data) {
        return data != null;
    }

    /**
     * Reads the path from the firebase database and waits until the database replys back.
     *
     * @param path The firebase path.
     * @return The object data returned as a result from firebase.
     */
    public static Object readFirebase(String path) {
        try {
            final Object[] result = {null};
            synchronized (LOCK) {
                dbReference.child(path).addListenerForSingleValueEvent(new ValueEventListener() {
                    @Override
                    public void onDataChange(DataSnapshot snapshot) {
                        Object value = snapshot.getValue();
                        result[0] = value;
                        synchronized (LOCK) {
                            LOCK.notify();
                        }
                    }

                    @Override
                    public void onCancelled(DatabaseError error) {
                        synchronized (LOCK) {
                            LOCK.notify();
                        }
                    }
                });
                LOCK.wait();
            }
            return result[0];
        } catch (Throwable e) {
            e.printStackTrace();
        }
        return null;
    }

    /**
     * Writes data to the firebase database.
     *
     * @param path The path to write the data to in firebase.
     * @param map  The data in a hashmap.
     */
    public static void writeFirebase(String path, Map<String, Object> map) {
        try {
            synchronized (LOCK) {
                dbReference.child(path).setValue(map).addOnSuccessListener(aVoid -> {
                    synchronized (LOCK) {
                        LOCK.notify();
                    }
                });
                LOCK.wait();
            }
        } catch (Throwable e) {
            e.printStackTrace();
        }
    }

    /**
     * Gets the information of the current user from the map.
     *
     * @param key The key value (ex. name, password (md5 hash)
     * @return The user value.
     */
    public static Object getUserMapInfo(String key) {
        if (usermap == null) {
            return null;
        }
        return usermap.get(key);
    }

}