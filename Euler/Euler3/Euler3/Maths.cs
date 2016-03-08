using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler3
{
    public class Maths
    {
        const long MAX_SIZE = 25000;

        static bool IsPrimeNumber(long num)
        {
            bool bPrime = true;
            long factor = num / 2;

            long i = 0;

            for (i = 2; i <= factor; i++)
            {
                if ((num % i) == 0)
                    bPrime = false;
            }
            return bPrime;
        }

        public static long GetPrimeFactors(long num, out long[] arrResult)
        {
            long count = 0;
            long[] arr = new long[MAX_SIZE];
            arrResult = new long[MAX_SIZE];
            long i = 0;
            long idx = 0;

            for (i = 2; i <= num; i++)
            {
                if (IsPrimeNumber(i) == true)
                    arr[count++] = i;
            }

            while (true)
            {
                if (IsPrimeNumber(num) == true)
                {
                    arrResult[idx++] = num;
                    break;
                }

                for (i = count - 1; i >= 0; i--)
                {
                    if ((num % arr[i]) == 0)
                    {
                        arrResult[idx++] = arr[i];
                        num = num / arr[i];
                        break;
                    }
                }
            }
            return idx;
        }
    }
}
