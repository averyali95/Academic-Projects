package com.meme.manager;

import com.meme.ui.MemeWindow;
import com.meme.util.PageLoader;
import javafx.stage.Stage;

/**
 * The class managing all the pages for loading and etc.
 *
 * @author Subin Jacob
 * @author Avery Ali
 * @author Gael Bruno
 */
public class PageViewManager {

    /**
     * Shows the page onto the jframe.
     *
     * @param clazz The class of the page being loaded in.
     */
    public static void show(Class<? extends PageLoader> clazz) {
        try {
            Stage stage = MemeWindow.stage();
            if (stage == null) {
                AlertManager.sendError("Page View Manager", "Invalid JavaFX stage instance!");
                return;
            }
            if (clazz == null) {
                AlertManager.sendError("Page View Manager", "Attempted to load invalid page!");
                return;
            }
            PageLoader loader = clazz.newInstance();
            loader.show(stage);
        } catch (Throwable e) {
            e.printStackTrace();
        }
    }

}