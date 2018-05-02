using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CancelationTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts1 =new CancellationTokenSource();
            var cts2 =new CancellationTokenSource();
            var cts3 =new CancellationTokenSource();

            var cts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token, cts3.Token);

            var task = new Task(() =>
            {
                Console.WriteLine("Waitiing");
                cts.Token.WaitHandle.WaitOne();
                Console.WriteLine("Canceled");
                throw new OperationCanceledException(cts.Token);
            });
            task.Start();
            cts3.Cancel();

            Console.WriteLine("all done");
            Console.ReadLine();
        }
    }
}
