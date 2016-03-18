using System;

namespace TipCalculator
{
    public class TipCalculator
    {
        public decimal Calculate(decimal billAmount, decimal tip)
        {
            if (tip < 0)
            {
                throw new Exception("Tip should be zero or higher");
            }

            return billAmount + Math.Round((tip/100)*billAmount, 2);
        }
    }
}