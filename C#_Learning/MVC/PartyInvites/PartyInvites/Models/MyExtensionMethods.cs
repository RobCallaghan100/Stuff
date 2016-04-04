using System.Collections.Generic;
namespace LanguageFeatures.Models
{
    using System;

    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum,
            string categoryParam)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum,
            Func<Product, int, bool> selectorParam)
        {
            int count = 1;
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod, count))
                {
                    yield return prod;
                }
            }
        }

        static Func<Product, int, bool> categoryFilter = delegate(Product prod, int x)
        {
            return prod.Category == "Soccer";
        };

        //static Func<Product, bool> catFilter = prod => prod.Category == "Soccer";

        static Func<Product, bool> cf = prod => prod.Price == 120;

        public void X(int num)
        {
            var x = new List<Product>();

            x.Filter((prod, n) => prod.Category == "Soccer" || prod.Price == num);
        }

    }
}

public class Product
{
    public decimal Price { get; set; }
    public string Category { get; set; }
}
