using System;
using GalPavyks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GalPavyks.Repository
{
    public interface IPersonsRepository<T>
    {
       // IEnumerable<Person> AllPersons { get; }
        //bool AddPersonToDb(Person data);
       // bool DeletePersonFromDb(int id);
       // List<Person> GetPersonsList();
        IQueryable<T> FindAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}