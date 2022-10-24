using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

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
