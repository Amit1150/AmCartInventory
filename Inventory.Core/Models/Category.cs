using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }       
        public int? ParentId {get; set;}

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory {get; set;}
    }
}
