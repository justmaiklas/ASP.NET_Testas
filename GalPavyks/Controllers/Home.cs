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
        private readonly PersonRepository _personRepository;
        public HomeController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult TableTestas()
        {
            //Init klase Person, duoti pasirinktis paramentus, padaryt 3 kartus, susideti i lista.
            PersonListViewModel PersonListViewModel = new PersonListViewModel();
            PersonListViewModel.Persons = _personRepository.AllPersons;



            return View(PersonListViewModel); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
