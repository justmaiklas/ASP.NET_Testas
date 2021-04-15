using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace GalPavyks.Models
{
    public class PersonDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Person> Persons { get; set; }
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}
        public PersonDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }
    }

    public class PersonsRepository
    {
        private readonly PersonDbContext _appDbContext;

        public PersonsRepository(PersonDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Person> AllPersons => _appDbContext.Persons;

        public bool AddPersonToDb(Person data)

        {
            if (_appDbContext.Persons.Any(p => p.Vardas == data.Vardas && p.Pavarde == data.Pavarde))
            {
                return false;
            }

            Console.WriteLine("Kreipiamasi i ITP17334 Person-DB duomenu baze");
            _appDbContext.Persons.Add(data);
            try
            {
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType()); // what is the real exception?
                return false;
            }
        }

        public bool DeletePersonFromDb(int id)
        {
            Console.WriteLine("Deleting Person from DB which Id is:" + id);
            _appDbContext.Remove((_appDbContext.Persons.Single(p => p.Id == id)));
            try
            {
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType()); // what is the real exception?
                return false;
            }
        }
    }
}
