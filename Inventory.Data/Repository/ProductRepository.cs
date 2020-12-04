using Inventory.Core.Contracts.Repository;
using Inventory.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data.Repository
{
    public class ProductRepository : Repository<Product, AmCartDbContext>, IProductRepository
    {
        public ProductRepository(AmCartDbContext context)
           : base(context)
        {

        }

        public async Task<IList<Product>> GetProducts()
        {
            var products = this.context.Product
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductMetadataList)
                .Include(x => x.Stocks)
                .Where(x => !x.IsRemoved)
                .ToList();
            return products;
        }
    }
}
