using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_ObjectPool
{
    public class ObjectPool
    {
        private List<PooledObject> pool;
        private int maxSize;

        public ObjectPool(int maxSize)
        {
            this.maxSize = maxSize;
            pool = new List<PooledObject>();
        }

        public PooledObject AcquireObject()
        {
            Console.WriteLine("Спроба отримати об'єкт з пулу...");
            if (pool.Count > 0)
            {
                PooledObject obj = pool[0];
                pool.RemoveAt(0);
                Console.WriteLine("Об'єкт отримано з пулу. Розмір пулу: " + pool.Count);
                return obj;
            }
            else
            {
                if (pool.Count < maxSize)
                {
                    PooledObject newObj = new PooledObject();
                    Console.WriteLine("Створено новий об'єкт. Розмір пулу: " + pool.Count);
                    return newObj;
                }
                else
                {
                    Console.WriteLine("Пул заповнено. Неможливо створити нові об'єкти.");
                    return null;
                }
            }
        }

        public void ReleaseObject(PooledObject obj)
        {
            if (pool.Count < maxSize) 
            {
                pool.Add(obj);
                Console.WriteLine("Об'єкт повернено до пулу. Розмір пулу: " + pool.Count);
            }
            else
            {
                Console.WriteLine("Пул заповнено. Непомжливо додати більше об'єктів");
            }
        }

        public int GetPoolSize()
        {
            return pool.Count;
        }
    }
}
