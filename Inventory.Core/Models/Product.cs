using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class Product : BaseEntity, IEntity
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
            ProductMetadataList = new List<ProductMetadata>();
            Stocks = new List<Stock>();
        }

        public string Name { get; set; }
        public string Description {get; set;}
        public int BrandId {get; set;}
        public int CategoryId {get; set;}
        
        [ForeignKey("BrandId")]
        public virtual Brand Brand {get; set;}
        
        [ForeignKey("CategoryId")]
        public virtual Category Category {get; set;}

        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductMetadata> ProductMetadataList { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
