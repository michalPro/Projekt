using SimpleProject.DataAccess.Models;
using System.Data.Entity;

namespace SimpleProject.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=ApplicationContext")
        {
        }

        public DbSet<Car> Car { get; set; }

    }
}
