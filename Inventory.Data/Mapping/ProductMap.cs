using Inventory.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
