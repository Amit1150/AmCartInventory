using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Core.Models
{
    public class Vendor : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Address {get; set;}
        public string Contact {get; set;}      
    }
}
