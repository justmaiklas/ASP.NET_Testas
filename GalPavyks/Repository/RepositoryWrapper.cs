using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalPavyks.Models;

namespace GalPavyks.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private IPerson _person;
        private AppDbContext _appDbContext;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IPerson Person
        {
            get
            {
                if (_person == null)
                {
                    _person = new PersonRepository(_appDbContext);
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
