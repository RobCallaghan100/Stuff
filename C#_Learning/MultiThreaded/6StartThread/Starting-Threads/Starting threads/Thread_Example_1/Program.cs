using System;
using System.Threading;

namespace Thread_Example_1
{
    class MainClass
    {
        private const int REPETITIONS = 1000;

        public static void DoWork()
        {
            for (int i = 0; i < REPETITIONS; i++)
            {
                Console.Write("B");

            }
        }

        public static void Main(string[] args)
        {
            // start new thread
            //			Thread t1 = new Thread (new ThreadStart(DoWork));
            //			t1.Start ();

            #region start new thread without specifying ThreadStart 
//            Thread t2 = new Thread(DoWork);
//            t2.Start();
            #endregion

            #region start new thread without specifying ThreadStart
            //			Thread t3 = new Thread ( () => { DoWork(); });
            //			t3.Start ();
            var t3 = new Thread(() => { DoWork(); });
            t3.Start();
            #endregion

            // continue simultaneous work
            for (int i = 0; i < REPETITIONS; i++)
            {
                Console.Write("A");
            }
        }
    }
}
