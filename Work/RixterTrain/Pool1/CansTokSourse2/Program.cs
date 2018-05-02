using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CansTokSourse2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта CancellationTokenSource
            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));
            // Создание второго объекта CancellationTokenSource
            var cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));
            // Создание нового объекта CancellationTokenSource,
            // отменяемого при отмене cts1 или ct2
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled"));
            // Отмена одного из объектов CancellationTokenSource (я выбрал cts2)
            cts2.Cancel();
            // Показываем, какой из объектов CancellationTokenSource был отменен
            Console.WriteLine("cts1 canceled={0}, cts2 canceled={1}, linkedCts={2}",
            cts1.IsCancellationRequested, cts2.IsCancellationRequested,
            linkedCts.IsCancellationRequested);
        }
    }
}
