using System.Text;

namespace DZ1_ObjectPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

            ObjectPool pool = new ObjectPool(3);
            Console.WriteLine("Вміст пулу: " + pool.GetPoolSize().ToString());
            Console.WriteLine("Розмір пулу: " + pool.getMaxSize());

            PooledObject obj1 = new PooledObject();
            obj1.Operation();
            PooledObject obj2 = new PooledObject();
            obj2.Operation();

            PooledObject obj3 = new PooledObject();
            obj3.Operation();

            pool.ReleaseObject(obj2);
            pool.ReleaseObject(obj1);
            pool.ReleaseObject(obj3);

            pool.AcquireObject();
            pool.GetPoolSize().ToString();
            pool.AcquireObject();
            pool.GetPoolSize().ToString();
            pool.AcquireObject();
            pool.GetPoolSize().ToString();
            pool.AcquireObject();
            pool.GetPoolSize().ToString();

            pool.ReleaseObject(obj1);
            pool.ReleaseObject(obj2);
            pool.ReleaseObject(obj3);
            Console.WriteLine("Розмір пулу: " + pool.getMaxSize());
        }
    }
}