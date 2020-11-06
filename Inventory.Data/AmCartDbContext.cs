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
        }

        public DbSet<Product> Product { get; set; }
    }
}
