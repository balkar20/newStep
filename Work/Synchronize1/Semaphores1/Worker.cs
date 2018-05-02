using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Semaphores1
{
    class Worker
    {
        private List<int> list = new List<int>{1,2,3,4,5,6,7,8,9,10 };
        private Semaphore sem;
        public Worker(Semaphore sem)
        {
            this.sem = sem;
        }

        public void Work()
        {
            sem.WaitOne();
            
        }
    }
}
