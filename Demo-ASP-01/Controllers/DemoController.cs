using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_01.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();

            //Dans le cas où le nom de la vue ne correspond pas au nom de l'action
            //return View("IndexOld");
        }
    }
}
