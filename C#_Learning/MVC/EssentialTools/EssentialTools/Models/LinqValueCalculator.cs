namespace EssentialTools.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinqValueCalculator : IValueCalculator
    {
        private readonly IDiscountHelper _discountHelper;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            _discountHelper = discountHelper;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discountHelper.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}