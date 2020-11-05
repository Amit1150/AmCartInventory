using Inventory.Core.Models;
using Inventory.Core.Repositories;

namespace Inventory.Data.Repositories
{
    public class ProductRepository : Repository<Product, AmCartDbContext>, IProductRepository
    {
        public ProductRepository(AmCartDbContext context)
           : base(context)
        {

        }
    }
}
