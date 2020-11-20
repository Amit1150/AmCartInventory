using Inventory.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core.Contracts.Repository
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProducts();
    }
}
