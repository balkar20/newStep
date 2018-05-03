using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<Int32>(cts.Token,
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
                // Задание создает и запускает 3 дочерних задания
                var childTasks = new[]
                {
                    tf.StartNew(() => Sum(cts.Token, 10000)),
                    tf.StartNew(() => Sum(cts.Token, 20000)),
                    tf.StartNew(() => Sum(cts.Token, Int32.MaxValue)) // Исключение
                                                                      // OverflowException
                };
                // Если дочернее задание становится источником исключения,
                // отменяем все дочерние задания
                for (Int32 task = 0; task < childTasks.Length; task++)
                    childTasks[task].ContinueWith(
                        t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                // После завершения дочерних заданий получаем максимальное
                // возвращенное значение и передаем его другому заданию
                // для вывода
                tf.ContinueWhenAll(childTasks,
                        completedTasks => completedTasks.Where(
                            t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result),
                        CancellationToken.None)
                    .ContinueWith(t => Console.WriteLine("The maximum is: " + t.Result),
                        TaskContinuationOptions.ExecuteSynchronously);
            });

            // После завершения дочерних заданий выводим,
            // в том числе, и необработанные исключения
            parent.ContinueWith(p => {
                // Текст помещен в StringBuilder и однократно вызван
                // метод Console.WriteLine просто потому, что это задание
                // может выполняться параллельно с предыдущим,
                // и я не хочу путаницы в выводимом результате
                StringBuilder sb = new StringBuilder(
                    "The following exception(s) occurred:" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                    sb.AppendLine(" " + e.GetType().ToString());
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);
            // Запуск родительского задания, которое может запускать дочерние
            parent.Start();
        }

        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                // Следующая строка приводит к исключению OperationCanceledException
                // при вызове метода Cancel для объекта CancellationTokenSource,
                // на который ссылается маркер
                ct.ThrowIfCancellationRequested();
                checked { sum += n; } // при больших n появляется
                                      // исключение System.OverflowException
            }
            return sum;
        }
    }
}
