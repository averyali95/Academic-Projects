package com.meme.util;

import javafx.stage.Stage;

/**
 * The class used for instancing different pages of the window.
 *
 * @author Subin Jacob
 * @author Avery Ali
 * @author Gael Bruno
 */
public interface PageLoader {

    /**
     * Shows the page onto the window.
     *
     * @param stage
     */
    void show(Stage stage);

}