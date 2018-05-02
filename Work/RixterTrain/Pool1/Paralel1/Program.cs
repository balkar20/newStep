using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Paralel1
{
    class Program
    {
        private static Timer s_timer;

        static void Main(string[] args)
        {
            Console.WriteLine("Checking status every 2 seconds");
            // Создание таймера, который никогда не срабатывает. Это гарантирует,
            // что ссылка на него будет храниться в s_timer,
            // До активизации Status потоком из пула
            s_timer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);
            // Теперь, когда s_timer присвоено значение, можно разрешить таймеру
            // срабатывать; мы знаем, что вызов Change в Status не выдаст
            // исключение NullReferenceException
            s_timer.Change(0, Timeout.Infinite);
            Console.ReadLine(); // Предотвращение завершения процесса
        }

        // Сигнатура этого метода должна соответствовать
        // сигнатуре делегата TimerCallback
        private static void Status(Object state)
        {
            // Этот метод выполняется потоком из пула
            Console.WriteLine("In Status at {0}", DateTime.Now);
            Thread.Sleep(1000); // Имитация другой работы (1 секунда)
                                // Заставляем таймер снова вызвать метод через 2 секунды
            s_timer.Change(2000, Timeout.Infinite);
            // Когда метод возвращает управление, поток
            // возвращается в пул и ожидает следующего задания
        }
    }
}
