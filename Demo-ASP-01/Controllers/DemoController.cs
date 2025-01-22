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
            //// Pour démontrer l'utilisation de variable de type dynamic
            //DemoDynamic();
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

        [Route("Demo/DynamicTable/{nb}")]
        public IActionResult DynamicTable(int nb)
        {
            Title = $"Table de {nb}";
            ViewBag.table = nb;
            return View("Table");
        }

        [NonAction]
        public void DemoDynamic()
        {
            dynamic varDynamic;
            varDynamic = "Ceci est une valeur de type string";
            Console.WriteLine(varDynamic.Substring(0,5));
            varDynamic = true;
            if(varDynamic) Console.WriteLine($"C'est vrai!");
            varDynamic = 3.141529;
            Console.WriteLine(varDynamic * 30);
        }

        [Route("Demo/SaveData/{data}")]
        public IActionResult SaveData(string data)
        {
            TempData["data"] = data;
            return View();
        }

        public IActionResult ShowData()
        {
            if (TempData.ContainsKey("data"))
            {
                TempData.Keep("data");
            }
            return View();
        }
    }
}
