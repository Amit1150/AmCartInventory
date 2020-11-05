using System;

namespace Inventory.Core.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        bool IsRemoved { get; set; }
    }
}
