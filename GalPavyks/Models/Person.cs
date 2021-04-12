//Konstruktoriaus reikes

using System.Collections.Generic;

namespace GalPavyks.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int Metai { get; set; }


    }
    public class PersonRepository
    {
        public IEnumerable<Person> AllPersons =>
        new List<Person>
            {
            new Person{Id=1, Vardas="Ona",Pavarde="Onaite",Metai=56},
            new Person{Id=2, Vardas="Jonas",Pavarde="Jonaitis",Metai=32},
            new Person{Id=3, Vardas="Petras",Pavarde="Petraitis",Metai=14}
        };
    }
    public class PersonListViewModel
    {
        public IEnumerable<Person> Persons{ get; set; }
    }
}

