using System;

namespace TipCalculator
{
    public class TipCalculator
    {
        public decimal Calculate(decimal billAmount, decimal tip)
        {
            return billAmount + Math.Round((tip/100)*billAmount, 2);
        }
    }
}