//Konstruktoriaus reikes

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GalPavyks.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsAdultAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
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
        [IsAdult(ErrorMessage = "Person is not adult yet")]
        [DataType(DataType.Date)]
        
        [Required]
        public DateTime? GimimoMetai { get; set; } = DateTime.Now.AddYears(-18).Date;
        //public Entity AdditionalInfo { get; set; }
    }
    public class PersonListViewModel //GALIMA PABANDYT ATSIKRATYT SITOS KLASES, gal (tiksliai nezinau ar gera praktika)..
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}

