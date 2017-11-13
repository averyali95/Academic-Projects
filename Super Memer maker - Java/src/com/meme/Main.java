package com.meme;

import com.meme.manager.CloudinaryManager;
import com.meme.manager.FirebaseManager;
import com.meme.manager.MemeManager;
import com.meme.manager.ProcessManager;
import com.meme.ui.MemeWindow;

/**
 * The main class used for executing the program.
 *
 * @author Subin Jacob
 * @author Avery Ali
 * @author Gael Bruno
 */
public class Main {

    /**
     * The main method used for launching the program.
     *
     * @param args The JVM arguments
     */
    public static void main(String[] args) {
        FirebaseManager.init();
        MemeManager.init();
        ProcessManager.init();
        CloudinaryManager.init();
        MemeWindow.initWindow();
    }

}