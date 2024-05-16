import java.util.concurrent.atomic.AtomicInteger;

public class ThreadSpecificStorage {
    static ThreadLocal<Integer> threadLocalValue = ThreadLocal.withInitial(() -> {
        // Викликається раз на потік для ініціалізації значення
        return (int) Thread.currentThread().getId();
    });

    public static void main(String[] args) {
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.length; i++) {
            threads[i] = new Thread(ThreadSpecificStorage::threadMethod);
            threads[i].start();
        }

        for (Thread t : threads) {
            try {
                t.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    static void threadMethod() {
        System.out.println("Потік " + Thread.currentThread().getId() + ": Локальне значення потоку = " + threadLocalValue.get());

        threadLocalValue.set((int) Thread.currentThread().getId() * 100);

        System.out.println("Потік " + Thread.currentThread().getId() + ": Змінене локальне значення потоку = " + threadLocalValue.get());
    }
}
