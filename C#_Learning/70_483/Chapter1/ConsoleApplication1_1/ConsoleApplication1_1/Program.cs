using System;

namespace ConsoleApplication1_1
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread do some work");
                Thread.Sleep(0);
            }

            t.Join();
            Console.ReadLine();
        }

        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
