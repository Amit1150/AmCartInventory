using Inventory.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedBrand(modelBuilder);
            SeedCategory(modelBuilder);
            SeedVendor(modelBuilder);
            SeedProduct(modelBuilder);
            SeedPurchase(modelBuilder);
            SeedStock(modelBuilder);
            SeedProductImage(modelBuilder);
            SeedProductMetaData(modelBuilder);
        }

        public static void SeedBrand(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Arrow", IsRemoved = false, CreatedOn = now, UpdatedOn = now },
                new Brand { Id = 2, Name = "Raymond", IsRemoved = false, CreatedOn = now, UpdatedOn = now },
                new Brand { Id = 3, Name = "Levi's", IsRemoved = false, CreatedOn = now, UpdatedOn = now },
                new Brand { Id = 4, Name = "Allen Solly", IsRemoved = false, CreatedOn = now, UpdatedOn = now },
                new Brand { Id = 5, Name = "Wrangler", IsRemoved = false, CreatedOn = now, UpdatedOn = now }
            );
        }

        public static void SeedCategory(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Men", IsRemoved = false, CreatedOn = now, UpdatedOn = now },
                new Category { Id = 2, Name = "Women", IsRemoved = false, CreatedOn = now, UpdatedOn = now },
                new Category { Id = 3, Name = "Indian & Western Wear", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 2 },
                new Category { Id = 4, Name = "Western Wear", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 2 },
                new Category { Id = 5, Name = "Accessories", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 2 },
                new Category { Id = 6, Name = "Clothing", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 1 },
                new Category { Id = 7, Name = "Accessories", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 1 },

                new Category { Id = 8, Name = "Kurtas & Suits", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 3 },
                new Category { Id = 9, Name = "Kurtis & Tunics", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 3 },
                new Category { Id = 10, Name = "Dresses & Jumpsuits", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 4 },
                new Category { Id = 11, Name = "Tops, T-Shirts & Shirts", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 4 },
                new Category { Id = 12, Name = "Women Watches", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 5 },
                new Category { Id = 13, Name = "Analog", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 5 },
                new Category { Id = 14, Name = "T-Shirts", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 6 },
                new Category { Id = 15, Name = "Casual Shirts", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 6 },
                new Category { Id = 16, Name = "Watches & Wearables", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 7 },
                new Category { Id = 17, Name = "Sunglasses & Frames", IsRemoved = false, CreatedOn = now, UpdatedOn = now, ParentId = 7 }
            );
        }

        public static void SeedVendor(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { Id = 1, Name = "Pattern Dynamics", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Address = "India", Contact = "1234567890" },
                new Vendor { Id = 2, Name = "JD Corp", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Address = "India", Contact = "1234567890" },
                new Vendor { Id = 3, Name = "Lotus Knits", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Address = "India", Contact = "1234567890" },
                new Vendor { Id = 4, Name = "House of Attuendo", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Address = "India", Contact = "1234567890" },
                new Vendor { Id = 5, Name = "Sreepriya Exports Pvt Ltd", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Address = "India", Contact = "1234567890" }
            );
        }

        public static void SeedProduct(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Women Pink Embroidered Kurta", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Pink embroidered kurta with sharara and dupatta", BrandId = 1, CategoryId = 8 },
                new Product { Id = 2, Name = "Women Blue & Coral Pink Floral Print Straight Kurti", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Blue and Coral pink floral print straight kurti, has a round neck, long sleeves, straight hem, and side slits", BrandId = 2, CategoryId = 9 },
                new Product { Id = 3, Name = "Women Blue Printed A-Line Dress", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Blue printed woven A-line dress, has shoulder straps, sleeveless, concealed zip closure, and flared hem", BrandId = 3, CategoryId = 10 },
                new Product { Id = 4, Name = "Women Black Solid Victorian Crop Fitted Top", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Black solid woven victorian crop fitted top with gathers, has a sweetheart neck, long cuffed sleeves, and button closures", BrandId = 4, CategoryId = 11 },
                new Product { Id = 5, Name = "Women Rose Gold Watch", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Rose Gold - Toned bracelet style,stainless steel strap with a foldover closure", BrandId = 5, CategoryId = 12 },
                new Product { Id = 6, Name = "Women Silver-Toned Embellished Analogue Watch", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Silver-Toned regular, stainless steel strap with a foldover closure", BrandId = 1, CategoryId = 13 },
                new Product { Id = 7, Name = "Men White & Black Printed Round Neck T-shirt", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "White and Black printed T-shirt, has a round neck, and short sleeves", BrandId = 2, CategoryId = 14 },
                new Product { Id = 8, Name = "Men Orange Regular Fit Solid Casual Shirt", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Orange solid casual shirt, has a button-down collar, long sleeves, button placket, curved hem, and 1 patch pocket", BrandId = 3, CategoryId = 15 },
                new Product { Id = 9, Name = "Men Black Active Smartwatch", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = " latest smartwatch with a stylish new design and a gorgeous 1.3\" full touch colour display.", BrandId = 4, CategoryId = 16 },
                new Product { Id = 10, Name = "Men Oval Sunglasses", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "UV Protected Lens with full rim", BrandId = 5, CategoryId = 17 },
                new Product { Id = 11, Name = "Women Coral Orange Printed Straight Kurta", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Coral Orange printed straight kurta, has a mandarin collar, three-quarter sleeves, straight hem, and side slits", BrandId = 1, CategoryId = 8 },
                new Product { Id = 12, Name = "Women Rust Red Printed Tunic", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Rust Red printed Tunic, has a mandarin collar, three-quarter sleeves, and button closure", BrandId = 2, CategoryId = 9 },
                new Product { Id = 13, Name = "Women Yellow Solid Wrap Maxi Dress", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Yellow solid woven maxi dress, has shoulder straps, sleeveless, concealed zip closure, and flared hem", BrandId = 3, CategoryId = 10 },
                new Product { Id = 14, Name = "Women Sea Green Self Design Empire Top", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Sea Green self-design woven empire top, has a V-neck, and three-quarter sleeves", BrandId = 4, CategoryId = 11 },
                new Product { Id = 15, Name = "Women Charcoal Grey Watch", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = " Silver-Toned bracelet style, stainless steel strap with a foldover closure", BrandId = 5, CategoryId = 12 },
                new Product { Id = 16, Name = "Premium Women Silver-Toned Analogue Watch", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Silver-Toned bracelet style, stainless steel strap with a foldover closure", BrandId = 1, CategoryId = 13 },
                new Product { Id = 17, Name = "Men Blue Printed Round Neck T-shirt", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Blue printed T-shirt, has a round neck, and short sleeves", BrandId = 2, CategoryId = 14 },
                new Product { Id = 18, Name = "Men Navy Blue & White Slim Fit Checked Casual Shirt", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Navy Blue and White checked casual shirt, has a spread collar, short sleeves, button placket, and curved hem", BrandId = 3, CategoryId = 15 },
                new Product { Id = 19, Name = "Men Grey Explorist HR Smartwatch", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Grey smart watch, has a grey stainless steel foldover strap 40mm Explorist HR touchscreen", BrandId = 4, CategoryId = 16 },
                new Product { Id = 20, Name = "Men Aviator Sunglasses", IsRemoved = false, CreatedOn = now, UpdatedOn = now, Description = "Metallic oval full frame, has printed branding and printed detail on the inner side of both the arms, and plastic casings on the arms", BrandId = 5, CategoryId = 17 }
            );
        }

        public static void SeedPurchase(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Purchase>().HasData(
                new Purchase { Id = 1, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 1, Quantity = 100, VendorId = 1, PurchasedOn = now },
                new Purchase { Id = 2, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 2, Quantity = 100, VendorId = 2, PurchasedOn = now },
                new Purchase { Id = 3, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 3, Quantity = 100, VendorId = 3, PurchasedOn = now },
                new Purchase { Id = 4, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 4, Quantity = 100, VendorId = 4, PurchasedOn = now },
                new Purchase { Id = 5, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 5, Quantity = 100, VendorId = 5, PurchasedOn = now },
                new Purchase { Id = 6, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 6, Quantity = 100, VendorId = 1, PurchasedOn = now },
                new Purchase { Id = 7, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 7, Quantity = 100, VendorId = 2, PurchasedOn = now },
                new Purchase { Id = 8, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 8, Quantity = 100, VendorId = 3, PurchasedOn = now },
                new Purchase { Id = 9, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 9, Quantity = 100, VendorId = 4, PurchasedOn = now },
                new Purchase { Id = 10, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 10, Quantity = 100, VendorId = 5, PurchasedOn = now },
                new Purchase { Id = 11, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 11, Quantity = 100, VendorId = 1, PurchasedOn = now },
                new Purchase { Id = 12, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 12, Quantity = 100, VendorId = 2, PurchasedOn = now },
                new Purchase { Id = 13, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 13, Quantity = 100, VendorId = 3, PurchasedOn = now },
                new Purchase { Id = 14, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 14, Quantity = 100, VendorId = 4, PurchasedOn = now },
                new Purchase { Id = 15, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 15, Quantity = 100, VendorId = 5, PurchasedOn = now },
                new Purchase { Id = 16, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 16, Quantity = 100, VendorId = 1, PurchasedOn = now },
                new Purchase { Id = 17, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 17, Quantity = 100, VendorId = 2, PurchasedOn = now },
                new Purchase { Id = 18, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 18, Quantity = 100, VendorId = 3, PurchasedOn = now },
                new Purchase { Id = 19, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 19, Quantity = 100, VendorId = 4, PurchasedOn = now },
                new Purchase { Id = 20, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 20, Quantity = 100, VendorId = 5, PurchasedOn = now }
            );
        }

        public static void SeedStock(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 1, Quantity = 100 },
                new Stock { Id = 2, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 2, Quantity = 100 },
                new Stock { Id = 3, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 3, Quantity = 100 },
                new Stock { Id = 4, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 4, Quantity = 100 },
                new Stock { Id = 5, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 5, Quantity = 100 },
                new Stock { Id = 6, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 6, Quantity = 100 },
                new Stock { Id = 7, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 7, Quantity = 100 },
                new Stock { Id = 8, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 8, Quantity = 100 },
                new Stock { Id = 9, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 9, Quantity = 100 },
                new Stock { Id = 10, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 10, Quantity = 100 },
                new Stock { Id = 11, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 11, Quantity = 100 },
                new Stock { Id = 12, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 12, Quantity = 100 },
                new Stock { Id = 13, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 13, Quantity = 100 },
                new Stock { Id = 14, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 14, Quantity = 100 },
                new Stock { Id = 15, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 15, Quantity = 100 },
                new Stock { Id = 16, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 16, Quantity = 100 },
                new Stock { Id = 17, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 17, Quantity = 100 },
                new Stock { Id = 18, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 18, Quantity = 100 },
                new Stock { Id = 19, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 19, Quantity = 100 },
                new Stock { Id = 20, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 20, Quantity = 100 }
            );
        }

        public static void SeedProductImage(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;

            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 1, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 2, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 2, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 3, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 3, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 4, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 4, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 5, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 5, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 6, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 6, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 7, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 7, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 8, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 8, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 9, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 9, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 10, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 10, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 11, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 11, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 12, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 12, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 13, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 13, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 14, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 14, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 15, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 15, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 16, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 16, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 17, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 17, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 18, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 18, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 19, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 19, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" },
                new ProductImage { Id = 20, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 20, ImageURL = "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg" }
            );
        }

        public static void SeedProductMetaData(ModelBuilder modelBuilder)
        {

            var now = DateTime.UtcNow;

            modelBuilder.Entity<ProductMetadata>().HasData(
                new ProductMetadata { Id = 1, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 1, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 2, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 2, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 3, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 3, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 4, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 4, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 5, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 5, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 6, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 6, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 7, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 7, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 8, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 8, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 9, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 9, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 10, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 10, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 11, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 11, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 12, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 12, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 13, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 13, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 14, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 14, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 15, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 15, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 16, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 16, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 17, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 17, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 18, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 18, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 19, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 19, Type = "Price", Value = "100" },
                new ProductMetadata { Id = 20, IsRemoved = false, CreatedOn = now, UpdatedOn = now, ProductId = 20, Type = "Price", Value = "100" }
            );
        }
    }
}
