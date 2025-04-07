using gexateq_test_BE.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace gexateq_test_BE.Database
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _configuration { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
