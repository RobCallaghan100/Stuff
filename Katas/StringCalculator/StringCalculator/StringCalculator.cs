using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (IsNumbersEmpty(numbers))
            {
                return 0;
            }

            if (IsSingleNumber(numbers))
            {
                return int.Parse(numbers);
            }

            var splitNumbers = numbers.Split(',');

            return splitNumbers.Sum(sn => int.Parse(sn));
        }

        private static bool IsSingleNumber(string numbers)
        {
            return numbers.Length == 1;
        }

        private static bool IsNumbersEmpty(string numbers)
        {
            return numbers == string.Empty;
        }
    }
}
