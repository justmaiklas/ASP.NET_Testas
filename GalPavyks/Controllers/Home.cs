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
    //Plurale solid principles
    //Pagal SOLID principus ir design patterns

    //1) pasidaryt programos layerius - controlleris - service - repository
    //  kreipiasi i servisa -- servisas praso repository gauti duomenis -- repository grazina, servisas validuoja, ir t.t.
    // ir grazina i kontroleri arba success ir naujo asmens modeli arba klaidos pranesima (gali buti tipo bad request)
    // http status codes 
    // 1.1) aptvarkyti metodus, surasyt komentarus kur galetu but paprasciau/tvarkingiau

    //pasigooglint
    //pasidometi .net core dependency injectionu
    //2) prisideti loginima i faila, txt ilogger panaudojimas, log4net ir pan.
    
    //tutorialo apie TDD, test driven development
    //3) pasirasyti 1-2 laisvos formos automatinius testus, naudojant ms tests, nUnit, xUnit.

    //4) prisideti bazine klase Entity, turincia CreatedOn, UpdatedOn datetime tipo laukus,
    //4.1) pasidaryti update person, kuris leistu patikslinti asmens gimimo data, i duombaze saugoti tik gimiimo data su laiku (00:00:00:000z)



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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TableTestasView()
        {
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
