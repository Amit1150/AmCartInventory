using Inventory.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Core.Dto
{
    public class ProductDto
    {
        public ProductDto(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.ProductImages = product.ProductImages.Select(x => x.ImageURL).ToArray();
            this.ProductMetadata = product.ProductMetadataList.ToList().Select(x => new ProductMetadataDto { Type = x.Type, Value = x.Value });
            this.Quantity = product.Stocks.First().Quantity;
            this.Categories = new List<CategoryDto> { new CategoryDto { Id = product.CategoryId, Level = 3, Name = product.Category.Name } };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string[] ProductImages { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<ProductMetadataDto> ProductMetadata { get; set; }
    }
}