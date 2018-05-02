using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Semaphores1
{
    class Sem
    {
        Semaphore mysem;

        public Sem(Semaphore semaphore)
        {
            mysem = semaphore;
        }

        public bool WaitSmth()
        {
            return mysem.WaitOne();
        }

        public int Release()
        {
            return mysem.Release();
        }

    }
    class Program
    {
        static Sem sem = new Sem(new Semaphore(2, 3));
        static void Main(string[] args)
        {
            Thread tr1 = new Thread(Thread1);
            Thread tr2 = new Thread(Thread2);
            Thread tr3 = new Thread(Thread3);
            Thread tr4 = new Thread(Thread4);
            tr1.Start();
            tr2.Start();
            tr3.Start();
            tr4.Start();
        }
        static void Thread1()
        {
            sem.WaitSmth();
            Console.WriteLine("Thread1 start");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1 end");
            sem.Release();
        }

        static void Thread2()
        {
            sem.WaitSmth();
            Console.WriteLine("Thread2 start");
            Thread.Sleep(5000);
            Console.WriteLine("Thread2 end");
            sem.Release();
        }

        static void Thread3()
        {
            //sem.WaitSmth();
            Console.WriteLine("Thread3 start");
            Thread.Sleep(5000);
            Console.WriteLine("Thread3 end");
            sem.Release();
        }

        static void Thread4()
        {
            //sem.WaitSmth();
            Console.WriteLine("Thread4 start");
            Thread.Sleep(5000);
            Console.WriteLine("Thread4 end");
            sem.Release();
        }
    }
}
