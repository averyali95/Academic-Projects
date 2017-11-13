package com.meme.manager;

import com.cloudinary.Cloudinary;
import com.cloudinary.utils.ObjectUtils;

import java.io.File;
import java.util.HashMap;
import java.util.Map;

/**
 * The managing class for  image uploading and hosting.
 *
 * @author Subin Jacob
 */
public class CloudinaryManager {

    /**
     * The cloudinary object.
     */
    private static Cloudinary cloudinary;

    /**
     * Initializes the cloudinary manager.
     */
    public static void init() {
        Map config = new HashMap<String, String>();
        config.put("cloud_name", "dsovcps1y");
        config.put("api_key", "935164164915971");
        config.put("api_secret", "VGftOVg8j5UtbQo1wMNS3f8qylM");
        cloudinary = new Cloudinary(config);
    }

    /**
     * Uploads an image to the cloudinary hosting.
     *
     * @param file The image file.
     */
    public static String upload(File file) {
        try {
            Map result = cloudinary.uploader().upload(file, ObjectUtils.emptyMap());
            if (result == null) {
                return null;
            }
            return (String) result.get("url");
        } catch (Throwable e) {
            e.printStackTrace();
        }
        return null;
    }

}