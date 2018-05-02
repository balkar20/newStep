using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks2
{
    class Program
    {
        private const int V = 1000;

        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var task = new Task((() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Canceled!");
                        throw  new OperationCanceledException();
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }), token);

            var task2 = new Task(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("task2 working");
            });
            task2.Start();

            token.Register((() => { Console.WriteLine("Continue!"); }));

            Console.WriteLine("Enter smth for start!");
            Console.ReadLine();
            task.Start();

            Console.ReadLine();
            Console.WriteLine("cancellibg task!");
            cts.Cancel();

            Console.WriteLine("All Done");
            Console.ReadKey();
        }

        private static void PrintSmth(int x)
        {
            Console.WriteLine("Hello task {0}" + x);
        }
    }
}
