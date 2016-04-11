using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Recurse(0);

            //var result = Factorial(3);
           // var result = DoStuff(4);

//            int[] arr = {1, 5, 8, 12, 17, 19};
//            var result = BinarySearch(arr, 16, 0, arr.Length - 1);

            var x = 144;
            var result = FindSquareRoot(x, 1, x);


            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int FindSquareRoot(int square, int min, int max)
        {
            var mid = ((max - min)/2) + (min);
            var midSquare = mid*mid;
            
            if (midSquare > square)
            {
                return FindSquareRoot(square, min, mid);
            }
            else if (midSquare < square)
            {
                return FindSquareRoot(square, mid, max);
            }

            return mid;
        }


        private static int BinarySearch(int[] array, int n, int startIndex, int endIndex)
        {
            // {1, 5, 8, 12, 16, 19};-16
            var midIndex = (startIndex + endIndex)/2;
            var midValue = array[midIndex];

            if (endIndex < startIndex)
            {
                return -1;
            }

            if (midValue == n)
            {
                return midIndex;
            }
            else if (midValue < n)
            {
                startIndex = midIndex;
                return BinarySearch(array, n, startIndex-1, endIndex);
            }
            else
            {
                endIndex = midIndex;
                return BinarySearch(array, n, startIndex+1, endIndex);
            }
        }

        private static int DoStuff(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n + DoStuff(n - 1);
        }

        private static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        private static void Recurse(int i)
        {
            if (i == 10)
            {
                return;
            }

            Console.WriteLine(i);
            Recurse(i + 1);
        }
    }
}
