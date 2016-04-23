using System;
using System.Threading;

namespace Race_conditions
{
    class MainClass
    {
        public static int i = 0;
        public static object LockObj = new object();

        public static void DoWork()
        {
            for (i = 0; i < 5; i++) // use int i in loop
            {
                Console.Write(i);
            }
        }

        public static void Main(string[] args)
        {
            // start thread to display 5 stars
            Thread t = new Thread(DoWork);
            t.Start();

            // display 5 additional stars
            DoWork();
        }
    }
}
