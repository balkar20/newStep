using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RixterTrain
{
    interface IInter
    {
        int GetSmth();
        void Change();
    }
    struct  My: IInter
    {
        public int O;

        public My(int val)
        {
            O = val;
        }
        public int GetSmth()
        {
            return O;
        }

        public void Change()
        {
            O = 56565;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ljklk";
            
            IInter my = new My(45);
            IInter newmy = my;

            newmy.Change();

            Console.WriteLine("my  = ");
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
