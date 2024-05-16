﻿using System;
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
        public int getMaxSize() {  return maxSize; }

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
                Console.WriteLine($"Об'єкт {obj.ID} отримано з пулу. Кількість об'єктів в пулі: {pool.Count}");
                return obj;
            }
            else
            {
                PooledObject newObj = new PooledObject();
                maxSize++;
                Console.WriteLine($"Створено новий об'єкт. Розмір пулу збільшено. Кількість об'єктів в пулі: {pool.Count}");
                return newObj;
            }
        }

        public void ReleaseObject(PooledObject obj)
        {
            if (pool.Count < maxSize) 
            {
                pool.Add(obj);
                Console.WriteLine($"Об'єкт {obj.ID} повернено до пулу. Кількість об'єктів в пулі: {pool.Count}");
            }
            else
            {
                Console.WriteLine("Пул заповнено. Неможливо повернути більше об'єктів");
            }
        }

        public int GetPoolSize()
        {
            return pool.Count;
        }
    }
}