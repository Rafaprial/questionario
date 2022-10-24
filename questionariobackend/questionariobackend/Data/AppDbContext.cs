using Microsoft.EntityFrameworkCore;
using questionariobackend.Model;

namespace questionariobackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        // public DbSet<Post> Posts { get; set; }

        public DbSet<Questions> Question { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
