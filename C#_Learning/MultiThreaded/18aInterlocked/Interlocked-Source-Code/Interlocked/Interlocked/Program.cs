using System;
using System.Threading;
using System.Diagnostics;

namespace Interlocked
{
    class MainClass
    {
        // number of repetitions
        private const int REPETITIONS = 100000;

        // number of threads
        private const int THREADS = 10;

        // thread array
        public static Thread[] thread = new Thread[THREADS];

        // shared counter
        public static int counter = 0;

        private static object syncObject = new object();

        // thread work method - no locking
        public static void DoWork()
        {
            {
                for (int i = 0; i < REPETITIONS; i++)
                {
                    counter++;
                }
            }
        }

        public static void Main(string[] args)
        {
            // launch all threads
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < THREADS; i++)
            {
                thread[i] = new Thread(DoWork);
                thread[i].Start();
            }

            // wait for all threads to complete
            for (int i = 0; i < THREADS; i++)
            {
                thread[i].Join();
            }

            // display shared counter
            sw.Stop();
            Console.WriteLine("The counter value is: {0}", counter);
            Console.WriteLine("Elapsed milliseconds: {0}", sw.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
