using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon.Models.Pokemon> pokemon { get; set; } // Ensure it matches the table name exactly
    }
}
