using System.Diagnostics;
using Demo_ASP_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogError($"Attention, utilisation de l'Action Index du controller Home à {DateTime.Now.ToShortTimeString()}");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string DemoParams(int id)
        {
            return $"Mon chiffre porte-bonheur est le : {id}";
        }

        [Route("Home/Addition/{nb1}/{nb2}")]
        [Route("{nb1}/plus/{nb2}")]
        public int Addition(int nb1, int nb2)
        {
            return nb1 + nb2;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
