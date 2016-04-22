using System;
using System.Threading;

namespace Lambda_capture
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            // numbers may not be correct - variable shared with main program thread
            			for (int i = 0; i < 10; i++) 
            			{
            				// int number = i;
            				Thread t = new Thread (() => {
            					Console.WriteLine (i);
            				});
            				t.Start ();
            			}

            // fix for above
//            for (int i = 0; i < 10; i++)
//            {
//                int number = i;
//                Thread t = new Thread(() => {
//                    Console.WriteLine(number);
//                });
//                t.Start();
//            }
        }
	}
}