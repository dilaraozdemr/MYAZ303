using Microsoft.EntityFrameworkCore;

namespace YazılımGercekleme.Models
{
    public class SportDbContext:DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> options):base(options)
        {
            
        }
        public DbSet<Sport> Sports { get; set; }
    }
}
