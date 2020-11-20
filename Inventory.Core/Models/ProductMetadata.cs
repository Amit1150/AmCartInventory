using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class ProductMetadata : BaseEntity, IEntity
    {      
        public int ProductId {get; set;}
        public string Type { get; set; }
        public string Value {get; set;}

        [ForeignKey("ProductId")]
        public virtual Product Product {get; set;}
    }
}
