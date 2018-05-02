using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwait1
{
    class Program
    {
        internal sealed class Type1 { }
        internal sealed class Type2 { }
        private static async Task<Type1> Method1Async()
        {
            /* Асинхронная операция, возвращающая объект Type1 */
        }
        private static async Task<Type2> Method2Async()
        {
            /* Асинхронная операция, возвращающая объект Type2 */
        }
        static void Main(string[] args)
        {

        }

        private static async Task<String> MyMethodAsync(Int32 argument)
        {
            Int32 local = argument;
            try
            {
                Type1 result1 = await Method1Async();
                for (Int32 x = 0; x < 3; x++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            return "Done";
        }

    }
}
