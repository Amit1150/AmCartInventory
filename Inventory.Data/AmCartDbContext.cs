using Inventory.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Inventory.Data
{
    public class AmCartDbContext : DbContext
    {
        public AmCartDbContext(DbContextOptions<AmCartDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductMetadata> ProductMetadata { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
    }
}
