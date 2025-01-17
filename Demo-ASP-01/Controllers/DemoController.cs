using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_01.Controllers
{
    public class DemoController : Controller
    {
        [ViewData]
        public string Title { get;set; }
        public IActionResult Index()
        {
            Title = "Accueil";
            return View();

            //Dans le cas où le nom de la vue ne correspond pas au nom de l'action
            //return View("IndexOld");
        }

        [Route("Demo/Table/{nb}")]
        public IActionResult Table(int nb)
        {
            Title = $"Table de {nb}";
            ViewData["table"] = nb;
            return View();
        }

    }
}
