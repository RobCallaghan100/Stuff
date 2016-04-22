using System;
using System.Threading;

namespace Race_conditions
{
    class MainClass
    {
         public static int i = 0; //was commented out

        // uses local variable, so no race condition
//        public static void DoWork()
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                Console.Write(i);
//            }
//        }

         // uses shared module variable, so race condition
                public static void DoWork()
                {
                    for (i = 0; i < 5; i++)
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
