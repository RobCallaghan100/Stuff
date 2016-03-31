using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int id = 1)
        {
            return HttpUtility.HtmlEncode($"Hello {name}, NumTimes is: {id}");
        }
    }
}