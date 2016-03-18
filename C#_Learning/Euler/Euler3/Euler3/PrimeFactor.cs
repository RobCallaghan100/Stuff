namespace Euler3
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PrimeFactor
    {

        public async Task<IEnumerable<long>> GetPrimeFactors(long number)
        {
            var tasks = new List<Task<IEnumerable<long>>>
            {
                GetFactors(number),
                GetPrimes(number)
            };

            await Task.WhenAll(tasks);

            var factors = tasks[0].Result;
            var primes = tasks[1].Result;

            return factors.Intersect(primes);
        }

        private async Task<IEnumerable<long>> GetFactors(long number)
        {
            return GetFactor(number);
        }

        public static IEnumerable<long> GetFactor(long number)
        {
            for (long i = 2; i <= (number/2); i++)
            {
                if ((number % i) == 0)
                {
                    yield return i;
                }
            }
        }

        private static async Task<IEnumerable<long>> GetPrimes(long number)
        {
            return GetPrime(number);
        }

        public static IEnumerable<long> GetPrime(long number)
        {
            yield return 2;

            for (var i = 3; i < number; i += 2)
            {
                var isPrime = true;
                for (var j = 3; j <= ((i - 1)/2); j++)
                {
                    if ((i%j) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    yield return i;
                }
            }
        }

        public static bool IsPrimeNumber(long number)
        {
            for (var i = 2; i <= (number + 1)/2; i++)
            {
                if ((number%i) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
