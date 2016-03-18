using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1_2
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(ThreadMethod);
            t.IsBackground = false; // if true, then program finishes immediately
            t.Start();

           // Console.ReadLine();
        }

        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
