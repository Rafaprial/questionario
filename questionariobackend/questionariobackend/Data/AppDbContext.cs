using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using questionariobackend.Model;
using System.Collections.Generic;

namespace questionariobackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
