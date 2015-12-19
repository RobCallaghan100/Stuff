namespace Euler2
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            long maxNumber = 4000000;

            var begin = DateTime.UtcNow;
//            var result = FirstAttempt(maxNumber);

//            var result = getFibonacciEvenNumbersSum(0, 1, 4000000, 0);

            var result = onlyUseEvens(maxNumber); // 4000000

            var finish = DateTime.UtcNow;
            var timeTaken = finish - begin;

            Console.WriteLine("Sum of even numbers: {0}. Time taken: {1}", result, timeTaken.TotalMilliseconds);
            Console.ReadLine();
        }

        private static long onlyUseEvens(long maxNumber)
        {
            long fib3 = 2;
            long fib6 = 0;

            long result = 2;
            long summed = 0;

            while (result < maxNumber)
            {
                summed += result;

                result = 4*fib3 + fib6;
                fib6 = fib3;
                fib3 = result;
            }

            return summed;
        }

        private static long getFibonacciEvenNumbersSum(long a, long b, long maxNumber, long sum)
        {
            long currentNum = 0;
            
            currentNum = a + b;
            a = b;
            b = currentNum;

            if (currentNum > maxNumber)
            {
                return sum;
            }

            if ((currentNum % 2) == 0)
            {
                sum = sum + currentNum;
            }

            return getFibonacciEvenNumbersSum(a, b, maxNumber, sum); // change
        }

        private static long FirstAttempt(long maxNumber)
        {
            long currentFibonacciNumber = 0;
            long firstNum = 0;
            long secondNum = 1;
            long sumOfEvenFibonnaciNumbers = 0;

            while (currentFibonacciNumber <= maxNumber)
            {
                currentFibonacciNumber = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = currentFibonacciNumber;

                if ((currentFibonacciNumber%2) == 0)
                {
                    sumOfEvenFibonnaciNumbers += currentFibonacciNumber;
                }
            }

            return sumOfEvenFibonnaciNumbers;
        }
    }
}
