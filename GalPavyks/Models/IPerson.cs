using System;
using GalPavyks.Repository;

namespace GalPavyks.Models
{
    public interface IPerson : IPersonsRepository<Person>
    {
        
    }
}