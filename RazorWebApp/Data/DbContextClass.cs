using Microsoft.EntityFrameworkCore;
using RazorWebApp.Model;

namespace RazorWebApp.Data
{
    public class DbContextClass : DbContext
    {
        //now Connect database and models table so we make bridge here in dbcontext class
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {

        }


        //All table of database
        public DbSet<Category> category { get; set; }
    }
}
