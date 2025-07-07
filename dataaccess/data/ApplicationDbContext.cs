using Closer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Closer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
