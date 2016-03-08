using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler3
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arrResult;
            Console.Write("Enter a number to find prime factor: ");
            long n = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(DateTime.UtcNow + "\n");

            long count = Maths.GetPrimeFactors(n, out arrResult);
            for (long i = 0; i < count; i++)
            {
                Console.Write("{0,4:n}", arrResult[i]);
                if (i != count - 1)
                    Console.Write(" * ");
            }
            Console.WriteLine();
            Console.ReadLine();

            //            // 13195 are 5, 7, 13 and 29
            //            long number = 300000;
            //
            //            GetPrimeFactors(number);
        }

        private static async void GetPrimeFactors(long number)
        {
            Console.WriteLine(DateTime.UtcNow + "\n");

            var primeFactor = new PrimeFactor();
            var primeFactors = await primeFactor.GetPrimeFactors(number);

            foreach (var pf in primeFactors)
            {
                Console.WriteLine(pf + "\n");
            }

            Console.WriteLine(DateTime.UtcNow + "\n");

            Console.ReadLine();
        }
    }
}
