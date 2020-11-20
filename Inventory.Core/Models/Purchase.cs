namespace Inventory.Core.Models
{
    public class Purchase : BaseEntity, IEntity
    {         
        public int ProductId {get; set;}      
        public int VendorId {get; set;}
        public int Quantity { get; set; }
        public DateTime PurchasedOn { get; set; }  

        [ForeignKey("ProductId")]
        public virtual Product Product {get; set;}    
        
        [ForeignKey("VendorId")] 
        public virtual Vendor Vendor {get; set;}    
    }
}
