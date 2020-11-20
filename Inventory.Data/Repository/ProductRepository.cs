using Inventory.Core.Contracts.Repository;
using Inventory.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await this.GetAll();
        }
    }
}
