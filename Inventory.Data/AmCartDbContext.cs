using Inventory.Core.Models;
using Inventory.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Inventory.Data
{
    public class AmCartDbContext: DbContext
    {
        static AmCartDbContext()
        {
            Database.SetInitializer<AmCartDbContext>(null);
        }

        public AmCartDbContext()
            : base("Name=AmCartDbContext")
        {
        }

        public DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
