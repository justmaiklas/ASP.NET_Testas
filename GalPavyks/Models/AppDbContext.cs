using Microsoft.EntityFrameworkCore;
using GalPavyks.Models;
namespace GalPavyks.Models
{
    public class AppDbContext : DbContext
    {
       

        public DbSet<Person> Persons { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }


}
