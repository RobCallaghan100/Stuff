using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using Domain.Abstract;

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult List()
        {
            return View(_productRepository.Products);
        }
    }
}