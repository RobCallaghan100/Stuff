namespace EssentialTools.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        private readonly decimal _discount;

        public DefaultDiscountHelper(decimal discountParam)
        {
            this._discount = discountParam;
        }

        public decimal DiscountSize { get; set; }

        public decimal ApplyDiscount(decimal total)
        {
            return (total - (_discount/100m*total));
        }
    }
}