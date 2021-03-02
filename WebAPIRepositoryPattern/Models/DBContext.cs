using Microsoft.EntityFrameworkCore;

namespace WebAPIRepositoryPattern.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options){}

        DbSet<Employee> Employee { get; set; }
    }
}
