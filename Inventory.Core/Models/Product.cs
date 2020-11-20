using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class Product : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description {get; set;}
        public int BrandId {get; set;}
        public int CategoryId {get; set;}
        
        [ForeignKey("BrandId")]
        public virtual Brand Brand {get; set;}
        
        [ForeignKey("CategoryId")]
        public virtual Category Category {get; set;}
    }
}
