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
        private readonly IMyLogger Log;
        private readonly PersonDbContext _personDbContext;

        public HomeController(ILogger<HomeController> logger, PersonDbContext ctx, IMyLogger _log)
        {
            _logger = logger;
            _personDbContext = ctx;
            Log = _log;

        }

        public IActionResult Index()
        {
            Log.ToFile("The Index page has been accessed");
            return View();
        }

        public IActionResult Privacy()
        {
            Log.ToFile("The Privacy page has been accessed");

            return View();
        }

        public IActionResult PersonsList()
        {
            Log.ToFile("The PersonsList page has been accessed");
            var personsList = new PersonListViewModel
            {
                Persons = _personDbContext.Persons.ToList()
            };
            Log.ToFile("Persons count: "+ personsList.Persons.Count());

            return View(personsList); 
        }

        public IActionResult AddPerson() {
            System.Diagnostics.Debug.WriteLine("AddPersonView");
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            Log.ToFile("Submit clicked (Add Person)");
           
                var personsAction = new PersonsRepository(_personDbContext,Log);
                if (ModelState.IsValid)
                {
                    if (!personsAction.AddPersonToDb(person))
                    {
                    Log.ToFile("Error adding new person (Person Already Exists.)");
                    ModelState.AddModelError("Pavarde", "Person Already Exists.");
                    }

                }

            return View();

        }
        public IActionResult DeletePerson(int id)
        {
            Log.ToFile("Delete clicked. Deleting Person with id: " + id);
            System.Diagnostics.Debug.WriteLine("Delete clicked " + id);
            var personsAction = new PersonsRepository(_personDbContext, Log);
            personsAction.DeletePersonFromDb(id);
            var personListViewModel = new PersonListViewModel
            {
                Persons = _personDbContext.Persons.ToList()
            };
            return View("PersonsList",personListViewModel);



        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
