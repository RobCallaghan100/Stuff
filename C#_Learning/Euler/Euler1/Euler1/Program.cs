using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler1
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.UtcNow;
            int numberToFindMultiplesOf = 1000000000;

            Console.WriteLine();


            //Task t1 = Task.Factory.StartNew(() =>
            //{
            //    int localSum = 0;

            //    for (int i = 0; i < numberToFindMultiplesOf; i++)
            //    {
            //        if (i % 3 == 0 || i % 5 == 0)
            //        {
            //            localSum += i;
            //        }
            //    }

            //    sum = localSum;
            //});

            //t1.Wait();

            //Task<int> t3 = Task.Factory.StartNew(() =>
            //{
            //    int localSum = 0;

            //    for (int i = 0; i < numberToFindMultiplesOf; i+=3)
            //    {
            //        if (i % 3 == 0)
            //        {
            //            localSum += i;
            //        }
            //    }

            //    return localSum;

            //});

            //Task<int> t5 = Task.Factory.StartNew(() =>
            //{
            //    int localSum = 0;

            //    for (int i = 0; i < numberToFindMultiplesOf; i+=5)
            //    {
            //        if (i % 5 == 0)
            //        {
            //            localSum += i;
            //        }
            //    }

            //    return localSum;
            //});

            //Task<int> t15 = Task.Factory.StartNew(() =>
            //{
            //    int localSum = 0;

            //    for (int i = 0; i < numberToFindMultiplesOf; i+=15)
            //    {
            //        if (i % 15 == 0)
            //        {
            //            localSum += i;
            //        }
            //    }

            //    return localSum;
            //});

            List<Task> tasks = new List<Task>();

            tasks.Add(GetFactors(3, numberToFindMultiplesOf));
            tasks.Add(GetFactors(5, numberToFindMultiplesOf));
            tasks.Add(GetFactors(15, numberToFindMultiplesOf));

            var array = tasks.ToArray();
            Task.WaitAll(array);

            int t3 = ((Task<int>) tasks[0]).Result;
            int t5 = ((Task<int>) tasks[1]).Result;
            int t15 = ((Task<int>) tasks[2]).Result;

            int sum = t3 + t5 - t15;
            
            var finish = DateTime.UtcNow;
            var timeTaken = finish - start;

            Console.WriteLine("Sum is: {0} of Multiple:{1}. Time taken(ms):{2}",
                sum, numberToFindMultiplesOf, timeTaken.TotalSeconds); // 1000000000,  8.79s, 631,780,268
            Console.ReadLine();
        }

        private static Task<int> GetFactors(int factor, int numberToFindMultiplesOf)
        {
            return Task.Factory.StartNew(
                            () =>
                            {
                                int localSum = 0;

                                for (int i = 0; i < numberToFindMultiplesOf; i += factor)
                                {
                                    if (i % factor == 0)
                                    {
                                        localSum += i;
                                    }
                                }

                                return localSum;
                            });
        }
    }
}
