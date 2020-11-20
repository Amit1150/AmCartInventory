using Inventory.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core.Contracts.Business
{
    public interface IProductBll
    {
        Task<IEnumerable<ProductDto>> GetProducts(); 
    }
}
