using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalPavyks.Models;
using Microsoft.Extensions.Logging;

namespace GalPavyks.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private IPerson _person;
        private readonly AppDbContext _appDbContext;
        private IMyLogger _myLogger;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IMyLogger MyLogger
        {
            get
            {
                if (_myLogger == null)
                {

                    _myLogger = new MyLogger();
                }

                return _myLogger;
            }
        }
        public IPerson Person
        {
            get
            {
                if (_person == null)
                {
                    _person = new PersonRepository(_appDbContext,MyLogger);
                }

                return _person;
            }
        }
        
        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
