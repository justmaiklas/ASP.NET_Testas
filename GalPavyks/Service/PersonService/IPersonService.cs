using GalPavyks.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GalPavyks.Service.PersonService
{
    public interface IPersonService
    {
        bool CheckIfPersonExist(Person person, ModelStateDictionary model);
        bool IsPersonModelValid(Person person);
        bool IsPersonAdult(Person person, ModelStateDictionary model);
        Person GetPersonById(int id);
        bool DeletePerson(int id);
        bool UpdatePerson(Person person);
    }
}