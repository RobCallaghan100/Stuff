namespace EssentialTools.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinqValueCalculator : IValueCalculator
    {
        private readonly IDiscountHelper _discountHelper;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            _discountHelper = discountHelper;
            System.Diagnostics.Debug.WriteLine($"Instance {++counter} created");
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discountHelper.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}