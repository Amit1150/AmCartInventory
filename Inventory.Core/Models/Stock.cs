using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class Stock : BaseEntity, IEntity
    {
        public int ProductId {get; set;}
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product {get; set;}
    }
}
