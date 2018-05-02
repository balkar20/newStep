using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Synchronize1
{
    internal class SomeClass : IDisposable
    {
        private readonly Mutex m_lock = new Mutex();
        public void Method1()
        {
            m_lock.WaitOne();
            Console.WriteLine("Waiting for somthink from M1....");
            Thread.Sleep(2000);
            Method2(); // Метод Method2, рекурсивно получающий право на блокировку
            Console.WriteLine("Before release M1:");
            m_lock.ReleaseMutex();
            Console.WriteLine("end M1:");
        }
        public void Method2()
        {
            m_lock.WaitOne();
            Console.WriteLine("Waiting for somthink from M2....");
            Thread.Sleep(2000);
            m_lock.ReleaseMutex();
            Console.WriteLine("end M2:");
        }
        public void Dispose() { m_lock.Dispose(); }
    }



    class Program
    {
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();

            Thread t1 = new Thread(sc.Method1);
            Console.WriteLine("Before start t1....");
            t1.Start();
            Thread t2 = new Thread(sc.Method2);
            Thread.Sleep(300);
            Console.WriteLine("Before start t2...");
            t2.Start();
        }
    }
}
