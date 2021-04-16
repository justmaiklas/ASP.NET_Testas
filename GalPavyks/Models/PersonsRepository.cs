using System;
using System.Collections.Generic;
using System.Linq;


namespace GalPavyks.Models
{
    public interface IPersonsRepository
    {
        bool AddPersonToDb(Person data);
        bool DeletePersonFromDb(int id);

    }
    public class PersonsRepository : IPersonsRepository
    {
        private readonly PersonDbContext _appDbContext;
        private readonly IMyLogger Log;
        public IEnumerable<Person> AllPersons => _appDbContext.Persons;
        public PersonsRepository(PersonDbContext appDbContext, IMyLogger log)
        {
            _appDbContext = appDbContext;
            Log = log;
        }
        public bool AddPersonToDb(Person data)

        {
            if (_appDbContext.Persons.Any(p => p.Vardas == data.Vardas && p.Pavarde == data.Pavarde))
            {
                Log.ToFile("[ERROR] Person Already Exists");
                return false;
            }

            Log.ToFile("Adding Person");
            _appDbContext.Persons.Add(data);
            try
            {
                _appDbContext.SaveChanges();
                Log.ToFile("[SUCCESS] Person Added");
                return true;
            }
            catch (Exception e)
            {
                Log.ToFile("[ERROR] " + e.Message);
                Console.WriteLine(e.GetType()); // what is the real exception?
                return false;
            }
        }

        public bool DeletePersonFromDb(int id)
        {
            Log.ToFile("Deleting Person from DB which Id is:" + id);
            _appDbContext.Remove((_appDbContext.Persons.Single(p => p.Id == id)));
            try
            {
                _appDbContext.SaveChanges();
                Log.ToFile("[SUCCESS] Person Deleted");
                return true;
            }
            catch (Exception e)
            {
                Log.ToFile("[ERROR] " + e.Message);
                Console.WriteLine(e.GetType()); // what is the real exception?
                return false;
            }
        }
    }
}
