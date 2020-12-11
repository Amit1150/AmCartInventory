using Inventory.Business;
using Inventory.Core.Models;
using Inventory.Data;
using Inventory.Data.Repository;
using Inventory.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Inventory.Tests.Business
{
    public class ProductBllTest
    {
        private async Task<AmCartDbContext> GetContext()
        {
            int PRODUCT_COUNT = 10;
            string dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<AmCartDbContext>()
                    .UseInMemoryDatabase(databaseName: dbName)
                    .Options;

            var context = new AmCartDbContext(options);
            List<Product> products = new List<Product>();

            for (var i = 0; i < PRODUCT_COUNT; i++)
            {
                var productFake = ModelFakes.ProductFake.Generate();
                context.Product.Add(productFake);
                products.Add(productFake);
            }
            await context.SaveChangesAsync();
            return context;
        }

        [Fact]
        public async Task Get_All_Products()
        {
            // Arrange
            var context = await GetContext();
            var productRepositoryMock = new Mock<ProductRepository>(context);
            var productBll = new ProductBll(productRepositoryMock.Object);

            // Act
            var data  = await productBll.GetProducts();

            // Assert
            var totalProductsInDb = await context.Product.CountAsync();
            Assert.Equal(totalProductsInDb, data.Count());
        }
    }
}
