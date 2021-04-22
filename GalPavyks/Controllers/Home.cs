using GalPavyks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using GalPavyks.Repository;

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
    //3) pasirasyti 1-2 laisvos formos automatinius testus, naudojant ms tests, nUnit, xUnit. xUnit (Labiausiai naudoja)

    //4) prisideti bazine klase Entity, turincia CreatedOn, UpdatedOn datetime tipo laukus,
    //4.1) pasidaryti update person, kuris leistu patikslinti asmens gimimo data, i duombaze saugoti tik gimiimo data su laiku (00:00:00:000z)



    public class HomeController : Controller
    {
       
        private readonly IMyLogger _log;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HomeController(IRepositoryWrapper repositoryWrapper, IMyLogger log)
        {

            _log = log;
            _repositoryWrapper = repositoryWrapper;

        }

        public IActionResult Index()
        {
            _log.ToFile("The Index page has been accessed");
            return View();
        }

        public IActionResult Privacy()
        {
            _log.ToFile("The Privacy page has been accessed");

            return View();
        }

        public IActionResult PersonsList()
        {
            _log.ToFile("The PersonsList page has been accessed");
            var personsList = new PersonListViewModel
            {
                Persons = _repositoryWrapper.Person.FindAll().ToList()
            };
            _log.ToFile("Persons count: "+ personsList.Persons.Count());

            return View("PersonsList",personsList); 
        }

        public IActionResult PersonDetails(int id)
        {
            var person = _repositoryWrapper.Person.GetByCondition(p => p.Id.Equals(id)).Single();
            return View(person);
        }

        public IActionResult AddPerson() {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _log.ToFile("Submit clicked (Add Person)");
           
                
                if (ModelState.IsValid)
                {
                    var vardas= _repositoryWrapper.Person.GetByCondition(x => x.Vardas.Equals(person.Vardas));
                    
                if (vardas.Any(p => p.Pavarde.Equals(person.Pavarde)))
                    {
                    _log.ToFile("Error adding new person (Person Already Exists.)");
                    ModelState.AddModelError("Pavarde", "Person Already Exists.");
                }
                else
                {
                    
                    _repositoryWrapper.Person.Create(person);
                    _repositoryWrapper.Save();
                }
                    //if (!personsAction.AddPersonToDb(person))
                    //{
                    //_log.ToFile("Error adding new person (Person Already Exists.)");
                    //ModelState.AddModelError("Pavarde", "Person Already Exists.");
                    //}

                }

            return View();

        }
        public IActionResult DeletePerson(int id)
        {
            _log.ToFile("Delete clicked. Deleting Person with id: " +id);
            var person = _repositoryWrapper.Person.GetByCondition(x => x.Id.Equals(id)).Single();
            _repositoryWrapper.Person.Delete(person);
            _repositoryWrapper.Save();

            var personListViewModel = new PersonListViewModel
            {
                Persons = _repositoryWrapper.Person.FindAll()
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
