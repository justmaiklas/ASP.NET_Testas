using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GalPavyks.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }


    }

    public class PersonsRepository
    {
        private readonly AppDbContext _appDbContext;

        //public PersonsRepository(AppDbContext appDbContext)
        //{
        //    _appDbContext = appDbContext;
        //}
        public PersonsRepository()
        {
        }
        public IEnumerable<Person> AllPersons
        {
             
            get
            {
                return _appDbContext.Persons;
            }
        }

        public void AddPersonToDb(Person data)

        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;initial catalog=Persons-DB;Integrated Security=SSPI");
            SqlCommand insert = new SqlCommand("insert into Persons( Vardas, Pavarde,Gimimo_data) values(@Vardas, @Pavarde, @Gimimo_data)", conn);
           // insert.Parameters.AddWithValue("@Id", data.Id);
            insert.Parameters.AddWithValue("@Vardas", data.Vardas);
            insert.Parameters.AddWithValue("@Pavarde", data.Pavarde);
            insert.Parameters.AddWithValue("@Gimimo_data", data.Gimimo_metai);
            try
            {
                conn.Open();
                insert.ExecuteNonQuery();
                Console.WriteLine("Adding done !"); 
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
              
                conn.Close();
            }

        }
    }
}