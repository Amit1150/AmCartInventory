using Inventory.Core.Business;
using Inventory.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBll productBll;
        public ProductController(IProductBll productBll)
        {
            this.productBll = productBll;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var data = await productBll.GetProducts();
            return data;
        }
    }
}