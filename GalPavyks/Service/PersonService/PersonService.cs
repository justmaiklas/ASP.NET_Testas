using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using GalPavyks.Models;


using GalPavyks.Repository;

namespace GalPavyks.Service.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMyLogger _myLogger;
        public PersonService(AppDbContext _appDbContext)
        {
            if (_repositoryWrapper == null)
                _repositoryWrapper = new RepositoryWrapper(_appDbContext);
            if (_myLogger == null)
                _myLogger = new MyLogger();

        }

        public bool IsPersonModelValid(Person person)
        {
            if (person.Vardas == null || person.Pavarde == null || person.GimimoMetai == null)
                return false;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(person, null, null);
            if (!Validator.TryValidateObject(person, context, results))
            {
                //if (results.Count != 0)
                    return false;

            }

            return true;
        }

        public bool CheckIfPersonExist(Person person, ModelStateDictionary modelState)
        {
            
            var vardas = _repositoryWrapper.Person.GetByCondition(x => x.Vardas.Equals(person.Vardas));
            if (vardas.Any(p => p.Pavarde.Equals(person.Pavarde)))
            {
                _myLogger.ToFile("Error adding new person (Person Already Exists.)");
                modelState.AddModelError("Pavarde", "Person Already Exists.");
                return true;
            }
            else
            {
                
                _repositoryWrapper.Person.Create(person);
                _repositoryWrapper.Save();
                return false;
            }

            
        }

        //public void CheckIfPersonExits()
        //{
        //    if (_appDbContext.Persons.Any(p => p.Vardas == data.Vardas && p.Pavarde == data.Pavarde))
        //    {
        //        _log.ToFile("[ERROR] Person Already Exists");
        //        return false;
        //    }

        //    _log.ToFile("Adding Person");
        //    _appDbContext.Persons.Add(data);
        //    try
        //    {
        //        _appDbContext.SaveChanges();
        //        _log.ToFile("[SUCCESS] Person Added");
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        _log.ToFile("[ERROR] " + e.Message);
        //        Console.WriteLine(e.GetType()); // what is the real exception?
        //        return false;
        //    }
        //}
    }
}
