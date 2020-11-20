using Inventory.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Data.Configurations
{
    public class ProductMetadataConfiguration : IEntityTypeConfiguration<ProductMetadata>
    {
        public void Configure(EntityTypeBuilder<ProductMetadata> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
