//Konstruktoriaus reikes

using System;
using System.Collections.Generic;
using System.Linq;

namespace GalPavyks.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int Metai { get; set; }


    }
    public class Persons
    {
       static List<Person> PersonsList = new List<Person>();

        public void AddTest()
        {
            Person person = new Person();
            person.Vardas = "Jonas";
            person.Pavarde = "Jonaitis";
            person.Id = 1;
            person.Metai = 27;
            PersonsList.Add(person);
            PersonsList.Append(person);

        }
        public void AddPerson(Person ToAddPerson)
        {
            System.Diagnostics.Debug.WriteLine("AddPerson(): "+ToAddPerson.Vardas);
            Person person = new Person();
            person.Vardas = ToAddPerson.Vardas;
            person.Pavarde = ToAddPerson.Pavarde;
            person.Id = ToAddPerson.Id;
            person.Metai = ToAddPerson.Metai;
            PersonsList.Add(ToAddPerson);
        }

        public IEnumerable<Person> AllPersons => PersonsList;
    }
    public class PersonListViewModel
    {
        public IEnumerable<Person> Persons{ get; set; }
    }
}

