using Microsoft.EntityFrameworkCore;

namespace BlogProjectApi.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-61LIS6H;database=BlogProjectApiDb;integrated security = true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
