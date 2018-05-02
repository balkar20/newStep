using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace TaskFactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread tr1 = new Thread(Op);
            try
            {
                tr1.Start();
                Thread.Sleep(1500);
                tr1.Abort();
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e + "Thread aborted!");
            }

        }

        static void Op()
        {
            try
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine(".");
                    }
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine("Exception Cathed");
                    throw;
                }
            }
            catch
            {
                Console.WriteLine("Cathed two !");
                throw;
            }
            
            
        }
    }
}
