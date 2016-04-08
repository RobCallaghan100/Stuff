using System.Web.Mvc;

namespace BeeGame.Controllers
{
    using Models;

    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var test = new Test();
            //test.X = 10;
            return View(test);
        }

        [HttpPost()]
        public ActionResult Index(Test test)
        {
            var x = test.X + 1;

            ModelState.Clear();

            test.X = x;
            return View(test);
        }
    }
}