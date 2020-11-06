using Inventory.Core.Business;
using Inventory.Core.Dto;
using Inventory.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Business
{
    public class ProductBll : IProductBll
    {
        private readonly IProductRepository productRepository;
        public ProductBll(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var data = await productRepository.GetProducts();
            return data.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
