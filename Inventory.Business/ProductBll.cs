using Inventory.Core.Business;
using Inventory.Core.Repositories;
using System;

namespace Inventory.Business
{
    public class ProductBll : IProductBll
    {
        private readonly IProductRepository productRepository;
        public ProductBll(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
