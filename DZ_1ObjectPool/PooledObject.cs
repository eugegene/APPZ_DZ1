﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_ObjectPool
{
    public class PooledObject
    {
        private static int nextID = 0;
        public int ID { get; private set; }

        public PooledObject()
        {
            ID = System.Threading.Interlocked.Increment(ref nextID);
            Initialize();
        }
        public void Operation()
        {
            Console.WriteLine($"Об'єкт {ID} отримано");
        }

        public void Initialize()
        {
            Console.WriteLine($"Об'єкт {ID} ініціалізовано");
        }
    }
}