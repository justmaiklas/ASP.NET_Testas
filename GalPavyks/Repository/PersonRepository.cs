using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalPavyks.Models;

namespace GalPavyks.Repository
{
    public class PersonRepository : PersonsRepository<Person>, IPerson 
    {
        public PersonRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
