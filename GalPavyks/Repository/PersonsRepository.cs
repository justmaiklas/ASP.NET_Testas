using System;
using System.Linq;
using System.Linq.Expressions;
using GalPavyks.Models;
using Microsoft.EntityFrameworkCore;


namespace GalPavyks.Repository
{

    public abstract class PersonsRepository<T> : IPersonsRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private IMyLogger _logger;

        public PersonsRepository(AppDbContext appDbContext, IMyLogger myLogger)
        {
            _appDbContext = appDbContext;
            _logger = myLogger;

        }

        public IQueryable<T> FindAll()
        {
            _logger.ToConsole("Fetching Persons List");
            return _appDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> GetByCondition(Expression<Func<T,bool>> expression)
        {
            _logger.ToConsole("Fetching Persons by condition: " + expression.ToString());

            return _appDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _logger.ToConsole("Creating New Entity ");

            _appDbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _logger.ToConsole("Updating Entity");

            _appDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _logger.ToConsole("Deleting Entity");

            _appDbContext.Set<T>().Remove(entity);
        }
        // public void DeletePersonById(int id)
        //{
           
        //    _appDbContext.Set<Person>().Where(p => p.Id == id);
        //}
        //public bool AddPersonToDb(Person data)

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

        //public bool DeletePersonFromDb(int id)
        //{
        //    _log.ToFile("Deleting Person from DB which Id is:" + id);
        //    _appDbContext.Remove((_appDbContext.Persons.Single(p => p.Id == id)));
        //    try
        //    {
        //        _appDbContext.SaveChanges();
        //        _log.ToFile("[SUCCESS] Person Deleted");
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
