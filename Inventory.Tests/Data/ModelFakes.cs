using Bogus;
using Inventory.Core.Models;
using System;
using System.Linq;

namespace Inventory.Tests.Data
{
    public static class ModelFakes
    {
        public static Faker<Brand> BrandFake { get; set; }
        public static Faker<Category> CategoryFake { get; set; }
        public static Faker<Vendor> VendorFake { get; set; }
        public static Faker<Product> ProductFake { get; set; }
        public static Faker<Purchase> PurchaseFake { get; set; }
        public static Faker<Stock> StockFake { get; set; }
        public static Faker<ProductImage> ProductImageFake { get; set; }
        public static Faker<ProductMetadata> ProductMetadataFake { get; set; }

        static ModelFakes()
        {
            BuildBrandFaker();
            BuildCategoryFaker();
            BuildProductImageFaker();
            BuildProductFaker();
            BuildVendorFaker();
            BuildPurchaseFaker();
            BuildStockFaker();
            BuildProductMetadataFaker();
        }

        private static void BuildBrandFaker()
        {
            BrandFake = new Faker<Brand>()
                .RuleFor(m => m.Name, r => r.Company.CompanyName())
                .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.IsRemoved, false);
        }

        private static void BuildCategoryFaker()
        {
            CategoryFake = new Faker<Category>()
                .RuleFor(m => m.Name, r => r.Name.Random.String(5))
                .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.IsRemoved, false);
        }

        private static void BuildVendorFaker()
        {
            VendorFake = new Faker<Vendor>()
                .RuleFor(m => m.Name, r => r.Name.Random.String(5))
                .RuleFor(m => m.Address, r => r.Address.StreetAddress())
                .RuleFor(m => m.Contact, r => r.Phone.PhoneNumber())
                .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.IsRemoved, false);
        }

        private static void BuildPurchaseFaker()
        {
            PurchaseFake = new Faker<Purchase>()
               .RuleFor(m => m.Quantity, r => r.Random.Int(50, 1000))
               .RuleFor(m => m.Product, r => ProductFake.Generate(1).First())
               .RuleFor(m => m.Vendor, r => VendorFake.Generate(1).First())
               .RuleFor(m => m.PurchasedOn, r => r.Date.Past())
               .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.IsRemoved, false);
        }

        private static void BuildStockFaker()
        {
            StockFake = new Faker<Stock>()
               .RuleFor(m => m.Quantity, r => r.Random.Int(50, 1000))
               //.RuleFor(m => m.Product, r => ProductFake.Generate(1).First())
               .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.IsRemoved, false);
        }

        private static void BuildProductImageFaker()
        {
            ProductImageFake = new Faker<ProductImage>()
               .RuleFor(m => m.ImageURL, r => r.Lorem.Text())
               .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.IsRemoved, false);
        }

        private static void BuildProductMetadataFaker()
        {
            ProductMetadataFake = new Faker<ProductMetadata>()
               .RuleFor(m => m.Type, r => r.Name.Random.AlphaNumeric(5))
               .RuleFor(m => m.Value, r => r.Lorem.Slug(5))
               .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
               .RuleFor(bp => bp.IsRemoved, false);
        }

        public static void BuildProductFaker()
        {
            ProductFake = new Faker<Product>()
                .RuleFor(bp => bp.Name, f => f.Name.JobTitle())
                .RuleFor(bp => bp.CreatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.UpdatedOn, f => f.Date.Past())
                .RuleFor(bp => bp.IsRemoved, false)
                .RuleFor(bp => bp.Description, f => f.Random.AlphaNumeric(10))
                .RuleFor(bp => bp.ProductImages, f => ProductImageFake.Generate(3).ToList())
                .RuleFor(bp => bp.Brand, f => BrandFake.Generate(1).First())
                .RuleFor(bp => bp.Category, f => CategoryFake.Generate(1).First())
                .RuleFor(bp => bp.Stocks, f => StockFake.Generate(1).ToList())
                .RuleFor(bp => bp.ProductMetadataList, f => ProductMetadataFake.Generate(10).ToList());
        }
    }
}
