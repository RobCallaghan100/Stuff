using System.Web.Mvc;

namespace BeeGame.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        private BeeGame _beeGame;

        public HomeController()
        {
            _beeGame = new BeeGame();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_beeGame);
        }

        [HttpPost()]    
        public ActionResult Index(BeeGame beeGame)
        {
            beeGame.Hit();
            return View(beeGame);
        }
    }
}