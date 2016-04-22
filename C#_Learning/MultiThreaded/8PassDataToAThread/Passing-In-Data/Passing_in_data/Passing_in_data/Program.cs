using System;
using System.Threading;

namespace Passing_in_data
{
	class MainClass
	{
		private const int REPETITIONS = 1000;

		public static void DoWork(object obj) 
		{
			char c = (char)obj;
			for (int i = 0; i < REPETITIONS; i++) 
			{
				Console.Write (c);

			}
		}

		public static void DoWork2(char c) 
		{
			for (int i = 0; i < REPETITIONS; i++) 
			{
				Console.Write (c);

			}
		}

		public static void Main (string[] args)
		{
			#region start new thread with ParameterizedThreadStart delegate
//			Thread t1 = new Thread (DoWork);
//			t1.Start ('B');
//
//			// continue simultaneous work
//			DoWork ('A');
			#endregion

			#region start new thread with lambda expression
			//Thread t2 = new Thread ( () => { DoWork2('B'); } );
		    var t2 = new Thread(() => { DoWork2('B'); });
			t2.Start ();

			// continue simultaneous work
			DoWork2 ('A');
			#endregion

		}
	}
}