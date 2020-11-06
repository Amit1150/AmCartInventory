using Inventory.Core.Models;
using Inventory.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories
{
    public class ProductRepository : Repository<Product, AmCartDbContext>, IProductRepository
    {
        public ProductRepository(AmCartDbContext context)
           : base(context)
        {

        }

        public async Task<IList<Product>> GetProducts()
        {
            return await this.GetAll();
        }
    }
}
