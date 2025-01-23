using Demo_ASP_01.Handlers;
using Demo_ASP_01.Models;
using Demo_ASP_01.Models.Demo;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_01.Controllers
{
    public class DemoController : Controller
    {
        [ViewData]
        public string Title { get;set; }
        private static Dictionary<int,PersonneDetails> _users = new Dictionary<int, PersonneDetails>() {
            { 1, new PersonneDetails() { LastName = "Willis", FirstName = "Bruce", BirthDate = new DateOnly(1954,5,13)} },
            { 2, new PersonneDetails() { LastName = "Bassinger", FirstName = "Kim", BirthDate = new DateOnly(1966,6,6)} }
        };

        private static List<MessageDetails> _messages = new List<MessageDetails>() {
            new MessageDetails(){
                Sender = _users[1],
                Receiver = _users[2],
                SendedDate = DateTime.Now.AddHours(-5),
                IsReceived = true,
                Content = "Coucou Kim! J'ai un nouveau film, veux-tu en faire parti?"
            },
            new MessageDetails(){
                Sender = _users[2],
                Receiver = _users[1],
                SendedDate = DateTime.Now.AddHours(-3),
                IsReceived = true,
                Content = "Salut Bruce! Tu sais bien que je ne veux plus faire de film d'action..."
            },
            new MessageDetails(){
                Sender = _users[1],
                Receiver = _users[2],
                SendedDate = DateTime.Now.AddHours(-1),
                IsReceived = false,
                Content = "Dommage, il y avait un beau cachet!"
            },
        };
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

        public IActionResult ModelsDemoProfil(int id)
        {
            if (!_users.ContainsKey(id)) return RedirectToAction(nameof(Index));
            PersonneDetails model = _users[id];
            return View(model);
        }

        public IActionResult ModelsDemoConversation()
        {
            IEnumerable<MessageDetails> model = _messages;
            if (model is null || model.Count() == 0) return RedirectToAction(nameof(Index));
            return View(model);
        }

        /// <summary>
        /// Permet d'afficher le formulaire vide
        /// </summary>
        /// <returns>IActionResult : Vue HTML/CSS du formulaire</returns>
        [HttpGet("Demo/Forms")]
        public IActionResult FormsDemo()
        {
            return View();
        }

        /// <summary>
        /// Permet de traiter les données du formulaire valider par l'utilisateur
        /// </summary>
        /// <param name="form">Les données du fomulaire</param>
        /// <returns>IActionResult : Redirige vers l'Index du DemoController</returns>
        [HttpPost("Demo/Forms")]
        public IActionResult FormsDemo(FormsDemoForm form)
        {
            try
            {
                /*ValidationHandler.Required(ModelState, form.LastName, nameof(form.LastName));*/
                ModelState.Required(form.LastName, nameof(form.LastName));
                ModelState.Required(form.FirstName, nameof(form.FirstName));
                ModelState.Required(form.BirthDate, nameof(form.BirthDate));
                ModelState.MinLenght(form.LastName, nameof(form.LastName), 2);
                ModelState.MinLenght(form.FirstName, nameof(form.FirstName), 2);
                ModelState.MaxLenght(form.LastName, nameof(form.LastName), 64);
                ModelState.MaxLenght(form.FirstName, nameof(form.FirstName), 64);
                if (!ModelState.IsValid) throw new ArgumentException();
                PersonneDetails data = new PersonneDetails()
                {
                    LastName = form.LastName,
                    FirstName = form.FirstName,
                    BirthDate = form.BirthDate
                };
                _users.Add(_users.Keys.Max() + 1, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
