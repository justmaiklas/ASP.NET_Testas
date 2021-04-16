﻿//Konstruktoriaus reikes

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace GalPavyks.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsAdultAttribute : ValidationAttribute
    {
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
        [Display(Name = "Id")]
      
       // [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")] //Range veikia
       // [Required]
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
        [IsAdult(ErrorMessage = "Person is not adult yet"), DataType(DataType.Date)]

        [Required]
        public DateTime Gimimo_metai { get; set; }
    }
    public class PersonListViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}

