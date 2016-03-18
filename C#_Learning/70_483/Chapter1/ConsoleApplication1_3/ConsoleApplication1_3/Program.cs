using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1_3
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();

            Console.ReadLine();
        }

        private static void ThreadMethod(object obj)
        {
            for (int i = 0; i < (int) obj; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);

                Thread.Sleep(0);
            }
        }
    }
}
