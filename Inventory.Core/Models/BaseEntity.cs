using System;

namespace Inventory.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsRemoved { get; set; }
    }
}
