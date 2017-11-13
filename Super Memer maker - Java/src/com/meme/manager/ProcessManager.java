package com.meme.manager;

import com.meme.ui.MemeWindow;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * The class used for managing thread service and tasks.
 *
 * @author Subin Jacob
 */
public class ProcessManager {

    /**
     * The executor service for processing tasks simultaneously.
     */
    private static final ExecutorService SERVICE = Executors.newCachedThreadPool();

    /**
     * The queue of tasks.
     */
    private static final Deque<Runnable> TASKS_QUEUE = new ArrayDeque<>();

    /**
     * Initializes the task manager.
     */
    public static void init() {
        submit(createSimpleWorker());
    }

    /**
     * Submits the task worker to the service.
     *
     * @param taskWorker The task worker.
     */
    public static void submit(Runnable taskWorker) {
        SERVICE.submit(taskWorker);
    }

    /**
     * Creates a new simple task worker.
     *
     * @return The task worker.
     */
    public static Runnable createSimpleWorker() {
        return () -> {
            while (true) {
                try {
                    while (MemeWindow.stage() == null) {
                        //Waits for the application to be fully loaded before starting.
                        Thread.sleep(2500);
                    }
                    synchronized (TASKS_QUEUE) {
                        if (TASKS_QUEUE.isEmpty()) {
                            Thread.sleep(2000);
                            continue;
                        }
                        Runnable task = TASKS_QUEUE.poll();
                        if (task != null) {
                            task.run();
                        }
                        Thread.sleep(1000);
                    }
                } catch (Throwable e) {
                    e.printStackTrace();
                }
            }
        };
    }

}