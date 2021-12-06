using Microsoft.EntityFrameworkCore;
using SimpleAPI.Domain.Models;

namespace SimpleAPI.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
