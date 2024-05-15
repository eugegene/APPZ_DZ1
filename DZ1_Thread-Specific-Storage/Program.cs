using System.Text;

namespace DZ1_Thread_Specific_Storage
{
    class Program
    {

        static ThreadLocal<int> threadLocalValue = new ThreadLocal<int>(() =>
        {
            // Викликатиметься раз на потік для ініціалізації значення
            return Thread.CurrentThread.ManagedThreadId;
        });

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ThreadMethod);
                threads[i].Start();
            }

            foreach (Thread t in  threads)
            {
                t.Join();
            }
            Console.ReadLine();
        }

        static void ThreadMethod()
        {
            Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId}: Значення локального потоку = {threadLocalValue.Value}");

            threadLocalValue.Value = Thread.CurrentThread.ManagedThreadId * 100;

            Console.WriteLine($"Потік {{Thread.CurrentThread.ManagedThreadId}}: Змінене значення локального потоку = {threadLocalValue.Value}");
        }
    }
}
