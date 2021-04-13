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

        public IActionResult TableTestasView()
        {
            
            //Init klase Person, duoti pasirinktis paramentus, padaryt 3 kartus, susideti i lista.
            var persons = new Persons();
            
            var personListViewModel = new PersonListViewModel
            {
                Persons = persons.AllPersons
            };

            return View(personListViewModel); 
        }

        public IActionResult AddPersonView()
        {
            var persons = new Persons();
           
            System.Diagnostics.Debug.WriteLine("AddPersonView");
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonView(Person person)
        {
            System.Diagnostics.Debug.WriteLine("Submit clicked "+ String.IsNullOrEmpty(person.Vardas));
            
                var persons = new Persons();
                persons.AddPerson(person);
                return View();
            
            
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
