using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutoResEvent1
{
    internal sealed class SimpleWaitLock : IDisposable
    {
        private readonly AutoResetEvent m_available;
        public SimpleWaitLock()
        {
            m_available = new AutoResetEvent(true); // Изначально свободен
        }
        public void Enter()
        {
            // Блокирование на уровне ядра до освобождения ресурса
            m_available.WaitOne();
        }
        public void Leave()
        {
            // Позволяем другому потоку обратиться к ресурсу
            m_available.Set();
        }
        public void Dispose() { m_available.Dispose(); }
    }
    class Program
    {
        static SimpleWaitLock swl = new SimpleWaitLock();
        static void Main(string[] args)
        {
            Thread tr1 = new Thread(Thread1);
            Thread tr2 = new Thread(Thread2);
            tr1.Start();
            tr2.Start();
        }

        static void Thread1()
        {
            swl.Enter();
            Console.WriteLine("Thread1 start");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1 end");
            swl.Leave();
        }

        static void Thread2()
        {
            swl.Enter();
            Console.WriteLine("Thread2 start");
            Thread.Sleep(5000);
            Console.WriteLine("Thread2 end");
        }

    }
}
