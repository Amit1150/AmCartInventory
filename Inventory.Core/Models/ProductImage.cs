using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class ProductImage : BaseEntity, IEntity
    {
        public int ProductId {get; set;}
        public string ImageURL {get; set;}
        
        [ForeignKey("ProductId")]
        public virtual Product Product {get; set;}
    }
}
