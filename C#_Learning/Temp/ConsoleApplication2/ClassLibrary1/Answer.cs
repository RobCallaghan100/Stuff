using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace ClassLibrary1
{
    public class Answer
    {
        public static bool Exists(int[] ints, int k)
        {
            var intList = ints.ToList();

            return intList.Contains(k);
        }
    }

    [TestFixture]
    public class AnswerTests
    {
        //        int[] ints = { -9, 14, 37, 102 };
        //        Console.WriteLine(Answer.Exists(ints, 102)); // true
        //Console.WriteLine(Answer.Exists(ints, 36)); // false

        [TestCase(102, true)]
        [TestCase(36, false)]
        public void Test1(int k, bool val)
        {
            int[] ints = { -9, 14, 37, 102 };

            var answer = Answer.Exists(ints, k);
            Assert.That(answer, Is.EqualTo(val));
        }

    }
}
