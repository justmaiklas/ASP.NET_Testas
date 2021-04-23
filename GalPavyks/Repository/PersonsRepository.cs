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

        public PersonsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            if (_logger == null)
                _logger = new MyLogger();

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
    }
}
