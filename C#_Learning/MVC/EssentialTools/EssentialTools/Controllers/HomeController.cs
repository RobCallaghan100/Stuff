using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    using Models;
    using Ninject;

    public class HomeController : Controller
    {
        private readonly IValueCalculator _calculator;

        private Product[] _products =
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 275M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
            new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
        };

        public HomeController(IValueCalculator calculator)
        {
            _calculator = calculator;
        }

        // GET: Home
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(_calculator) {Products = _products};

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}