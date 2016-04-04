namespace EssentialTools.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private readonly IValueCalculator _calc;

        public IEnumerable<Product> Products { get; set; } 

        public ShoppingCart(IValueCalculator calc)
        {
            _calc = calc;
        }

        public decimal CalculateProductTotal()
        {
            return _calc.ValueProducts(Products);
        }
    }
}