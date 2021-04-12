using GalPavyks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace GalPavyks.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TableTestas()
        {
            //Init klase Person, duoti pasirinktis paramentus, padaryt 3 kartus, susideti i lista.
            var personListViewModel = new PersonListViewModel
            {
                Persons = new List<Person>
                {
                    new Person{Id=1, Vardas="Ona",Pavarde="Onaite",Metai=56},
                    new Person{Id=2, Vardas="Jonas",Pavarde="Jonaitis",Metai=32},
                    new Person{Id=3, Vardas="Petras",Pavarde="Petraitis",Metai=14}
                }
            };

            return View(personListViewModel); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
