package com.meme.util;

import java.security.MessageDigest;

/**
 * The utility class with encrypting and hashing functions.
 *
 * @author Subin J.
 */
public class Crypto {

    /**
     * Converts a regular string into MD5 hash.
     *
     * @param string The string being hashed.
     * @return The MD5 hash.
     */
    public static String hash(String string) {
        try {
            byte[] original = string.getBytes("UTF-8");
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] hash = md.digest(original);
            return new String(hash);
        } catch (Throwable e) {
            e.printStackTrace();
        }
        return null;
    }

}