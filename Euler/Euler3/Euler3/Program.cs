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
            const long numm = 600851475143;
            long newnumm = numm;
            long largestFact = 0;

            int counter = 2;
            while (counter * counter <= newnumm)
            {
                if (newnumm % counter == 0)
                {
                    newnumm = newnumm / counter;
                    largestFact = counter;
                }
                else
                {
                    counter = (counter == 2) ? 3 : counter + 2;
                }
            }
            if (newnumm > largestFact)
            { // the remainder is a prime number
                largestFact = newnumm;
            }

            Console.WriteLine(largestFact);
            Console.ReadLine();

            //            // 13195 are 5, 7, 13 and 29
            //            long number = 600851475143;// 300000 600851475143
            //
            //            Console.WriteLine(DateTime.UtcNow);
            //
            //            foreach (var pf in GetPrimeFactors2(number).AsParallel())
            //            {
            //                Console.WriteLine(pf);
            //            }
            //
            //            Console.WriteLine(DateTime.UtcNow);
            //            Console.ReadLine();
            //            //GetPrimeFactors(number);
        }

        private static IEnumerable<long> GetPrimeFactors2(long number)
        {
            foreach (var factor in PrimeFactor.GetFactor(number).AsParallel())
            {
                if (PrimeFactor.IsPrimeNumber(factor))
                {
                    yield return factor;
                }
            }
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
