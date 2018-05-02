using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание задания Task (оно пока не выполняется)
            Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000000000);
            // Можно начать выполнение задания через некоторое время
            t.Start();
            // Можно ожидать завершения задания в явном виде
            //t.Wait(); // ПРИМЕЧАНИЕ. Существует перегруженная версия,
                      // принимающая тайм-аут/CancellationToken
                      // Получение результата (свойство Result вызывает метод Wait)
            Console.WriteLine("The Sum is: " + t.Result); // Значение Int32
        }

        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            Thread.Sleep(1000);
            //for (; n > 0; n--)
            //    checked { sum += n; } // при больших n выдается System.OverflowException
            //return sum;
            return 13;
        }
    }
}
