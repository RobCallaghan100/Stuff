using System;

namespace TipCalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter bill");
                var billString = Console.ReadLine();
                var bill = decimal.Parse(billString);

                Console.WriteLine("Enter tip");
                var tipString = Console.ReadLine();
                var tip = decimal.Parse(tipString);

                var tipCalculator = new TipCalculator.TipCalculator();

                var result = tipCalculator.Calculate(bill, tip);

                Console.WriteLine($"Bill amount: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem! {0}", ex.Message);
            }

            Console.ReadLine();
        }
    }
}
