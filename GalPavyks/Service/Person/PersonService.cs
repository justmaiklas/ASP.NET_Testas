using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalPavyks.Models;
using GalPavyks.Repository;

namespace GalPavyks.Service.Person
{
    public class PersonService
    {
        public PersonService(IMyLogger iMyLogger)
        {

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
