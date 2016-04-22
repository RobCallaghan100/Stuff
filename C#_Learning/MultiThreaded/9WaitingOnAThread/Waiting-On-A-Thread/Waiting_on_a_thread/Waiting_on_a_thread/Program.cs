using System;
using System.Threading;

namespace Waiting_on_a_thread
{
	class MainClass
	{
		public static bool finished = false;

		public static void DoWork() 
		{
			// do lots of complicated work

			// signal that the thread is finished
			if (!finished) 
			{
                //finished = true; // wasre first
                Console.WriteLine ("Finished!");
                finished = true;
            }
		}

		public static void Main (string[] args)
		{
			// set up thread
			Thread t = new Thread (DoWork);
			t.Start ();

			// call DoWork on main program thread
			DoWork ();
		}
	}
}
