using GalPavyks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace GalPavyks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonDbContext _personDbContext;

        public HomeController(ILogger<HomeController> logger, PersonDbContext ctx)
        {
            _logger = logger;
            _personDbContext = ctx;
        }

        public IActionResult Index()
        {
            //var persons = new Persons();
            //persons.AddTest();
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TableTestasView()
        {
            
            //Init klase Person, duoti pasirinktis paramentus, padaryt 3 kartus, susideti i lista.
           
            
            var personListViewModel = new PersonListViewModel
            {
                Persons = _personDbContext.Persons.ToList()

            };

            return View(personListViewModel); 
        }

        public IActionResult AddPerson() {
            System.Diagnostics.Debug.WriteLine("AddPersonView");
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            System.Diagnostics.Debug.WriteLine("Submit clicked "+ String.IsNullOrEmpty(person.Vardas));
           
                var persons = new PersonActions(_personDbContext);
                if (ModelState.IsValid)
                {
                    if (!persons.AddPerson(person))
                    {
                        ModelState.AddModelError("Pavarde", "Person Already Exists.");
                    }

                }

            return View();

        }
        public IActionResult DeletePerson(int id)
        {
            System.Diagnostics.Debug.WriteLine("Delete clicked " + id);
            var persons = new PersonActions(_personDbContext);
            persons.DeletePerson(id);
            var personListViewModel = new PersonListViewModel
            {
                Persons = _personDbContext.Persons.ToList()
            };
            return View("TableTestasView",personListViewModel);



        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
