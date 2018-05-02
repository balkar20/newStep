using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoTrain
{
    struct Str
    {
        public int U;
        public string G;
        public Str(int u, string g)
        {
            U = u;
            G = g;
        }
        static Str()
        {
            Console.WriteLine("Called static constr");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi");
            Str s = new Str(54, "kjkjkj");
            Console.WriteLine("Pre calll ");
            Console.WriteLine("Value = " + s.G);
            Console.WriteLine("End");
            Console.ReadLine();
            
        }
    }
}
