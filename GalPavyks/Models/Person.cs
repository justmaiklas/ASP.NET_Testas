﻿//Konstruktoriaus reikes

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace GalPavyks.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsAdultAttribute : ValidationAttribute
    {
        public IsAdultAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt.Date <= DateTime.Now.AddYears(-18).Date)
            {
                return true;
            }
            return false;
        }
    }


 
    public class Person
    {
    
        public int Id { get; set; }
        [Display(Name = "Vardas")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Vardas { get; set; }
        [Display(Name = "Pavardė")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Pavarde { get; set; }
        [Display(Name = "Gimimo metai")]
        [IsAdult(ErrorMessage = "Person is not adult yet"),DataType(DataType.Date)]
        
        [Required]
        public DateTime Gimimo_metai { get; set; }



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
            person.Gimimo_metai = ToAddPerson.Gimimo_metai;
            PersonsList.Add(ToAddPerson);
        }

        public IEnumerable<Person> AllPersons => PersonsList;
    }
    public class PersonListViewModel
    {
        public IEnumerable<Person> Persons{ get; set; }
    }
}

