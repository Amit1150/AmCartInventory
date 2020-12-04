using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMetadata_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PurchasedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452), false, "Arrow", new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452) },
                    { 2, new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452), false, "Raymond", new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452) },
                    { 3, new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452), false, "Levi's", new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452) },
                    { 4, new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452), false, "Allen Solly", new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452) },
                    { 5, new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452), false, "Wrangler", new DateTime(2020, 12, 4, 8, 4, 59, 90, DateTimeKind.Utc).AddTicks(8452) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "Name", "ParentId", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Men", null, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 2, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Women", null, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) }
                });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "Id", "Address", "Contact", "CreatedOn", "IsRemoved", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "India", "1234567890", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457), false, "Pattern Dynamics", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457) },
                    { 2, "India", "1234567890", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457), false, "JD Corp", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457) },
                    { 3, "India", "1234567890", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457), false, "Lotus Knits", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457) },
                    { 4, "India", "1234567890", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457), false, "House of Attuendo", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457) },
                    { 5, "India", "1234567890", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457), false, "Sreepriya Exports Pvt Ltd", new DateTime(2020, 12, 4, 8, 4, 59, 93, DateTimeKind.Utc).AddTicks(2457) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "Name", "ParentId", "UpdatedOn" },
                values: new object[,]
                {
                    { 6, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Clothing", 1, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 7, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Accessories", 1, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 3, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Indian & Western Wear", 2, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 4, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Western Wear", 2, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 5, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Accessories", 2, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "Name", "ParentId", "UpdatedOn" },
                values: new object[,]
                {
                    { 14, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "T-Shirts", 6, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 15, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Casual Shirts", 6, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 16, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Watches & Wearables", 7, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 17, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Sunglasses & Frames", 7, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 8, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Kurtas & Suits", 3, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 9, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Kurtis & Tunics", 3, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 10, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Dresses & Jumpsuits", 4, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 11, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Tops, T-Shirts & Shirts", 4, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 12, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Women Watches", 5, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) },
                    { 13, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022), false, "Analog", 5, new DateTime(2020, 12, 4, 8, 4, 59, 92, DateTimeKind.Utc).AddTicks(8022) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedOn", "Description", "IsRemoved", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 7, 2, 14, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "White and Black printed T-shirt, has a round neck, and short sleeves", false, "Men White & Black Printed Round Neck T-shirt", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 15, 5, 12, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), " Silver-Toned bracelet style, stainless steel strap with a foldover closure", false, "Women Charcoal Grey Watch", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 5, 5, 12, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Rose Gold - Toned bracelet style,stainless steel strap with a foldover closure", false, "Women Rose Gold Watch", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 14, 4, 11, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Sea Green self-design woven empire top, has a V-neck, and three-quarter sleeves", false, "Women Sea Green Self Design Empire Top", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 4, 4, 11, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Black solid woven victorian crop fitted top with gathers, has a sweetheart neck, long cuffed sleeves, and button closures", false, "Women Black Solid Victorian Crop Fitted Top", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 13, 3, 10, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Yellow solid woven maxi dress, has shoulder straps, sleeveless, concealed zip closure, and flared hem", false, "Women Yellow Solid Wrap Maxi Dress", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 3, 3, 10, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Blue printed woven A-line dress, has shoulder straps, sleeveless, concealed zip closure, and flared hem", false, "Women Blue Printed A-Line Dress", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 12, 2, 9, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Rust Red printed Tunic, has a mandarin collar, three-quarter sleeves, and button closure", false, "Women Rust Red Printed Tunic", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 2, 2, 9, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Blue and Coral pink floral print straight kurti, has a round neck, long sleeves, straight hem, and side slits", false, "Women Blue & Coral Pink Floral Print Straight Kurti", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 11, 1, 8, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Coral Orange printed straight kurta, has a mandarin collar, three-quarter sleeves, straight hem, and side slits", false, "Women Coral Orange Printed Straight Kurta", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 1, 1, 8, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Pink embroidered kurta with sharara and dupatta", false, "Women Pink Embroidered Kurta", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 20, 5, 17, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Metallic oval full frame, has printed branding and printed detail on the inner side of both the arms, and plastic casings on the arms", false, "Men Aviator Sunglasses", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 10, 5, 17, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "UV Protected Lens with full rim", false, "Men Oval Sunglasses", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 19, 4, 16, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Grey smart watch, has a grey stainless steel foldover strap 40mm Explorist HR touchscreen", false, "Men Grey Explorist HR Smartwatch", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 9, 4, 16, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), " latest smartwatch with a stylish new design and a gorgeous 1.3\" full touch colour display.", false, "Men Black Active Smartwatch", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 18, 3, 15, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Navy Blue and White checked casual shirt, has a spread collar, short sleeves, button placket, and curved hem", false, "Men Navy Blue & White Slim Fit Checked Casual Shirt", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 8, 3, 15, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Orange solid casual shirt, has a button-down collar, long sleeves, button placket, curved hem, and 1 patch pocket", false, "Men Orange Regular Fit Solid Casual Shirt", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 17, 2, 14, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Blue printed T-shirt, has a round neck, and short sleeves", false, "Men Blue Printed Round Neck T-shirt", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 6, 1, 13, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Silver-Toned regular, stainless steel strap with a foldover closure", false, "Women Silver-Toned Embellished Analogue Watch", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) },
                    { 16, 1, 13, new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508), "Silver-Toned bracelet style, stainless steel strap with a foldover closure", false, "Premium Women Silver-Toned Analogue Watch", new DateTime(2020, 12, 4, 8, 4, 59, 94, DateTimeKind.Utc).AddTicks(2508) }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedOn", "ImageURL", "IsRemoved", "ProductId", "UpdatedOn" },
                values: new object[,]
                {
                    { 7, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 7, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 2, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 2, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 3, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 3, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 11, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 11, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 1, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 1, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 20, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 20, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 13, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 13, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 10, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 10, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 6, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 6, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 15, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 15, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 19, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 19, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 9, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 9, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 4, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 4, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 12, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 12, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 18, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 18, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 14, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 14, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 8, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 8, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 16, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 16, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 5, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 5, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) },
                    { 17, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874), "https://m.media-amazon.com/images/I/41ImsZy3u5L.__AC_SY200_.jpg", false, 17, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(874) }
                });

            migrationBuilder.InsertData(
                table: "ProductMetadata",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "ProductId", "Type", "UpdatedOn", "Value" },
                values: new object[,]
                {
                    { 12, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 12, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 2, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 2, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 7, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 7, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 11, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 11, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 16, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 16, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 15, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 15, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 3, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 3, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 1, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 1, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 14, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 14, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 20, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 20, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 17, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 17, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 10, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 10, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 8, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 8, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 19, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 19, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 6, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 6, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 9, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 9, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 4, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 4, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 5, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 5, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 18, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 18, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" },
                    { 13, new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), false, 13, "Price", new DateTime(2020, 12, 4, 8, 4, 59, 97, DateTimeKind.Utc).AddTicks(9648), "100" }
                });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "ProductId", "PurchasedOn", "Quantity", "UpdatedOn", "VendorId" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 3, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 3 },
                    { 5, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 5, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 5 },
                    { 4, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 4, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 4 },
                    { 13, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 13, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 3 },
                    { 12, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 12, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 2 },
                    { 15, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 15, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 5 },
                    { 16, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 16, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 1 },
                    { 7, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 7, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 2 },
                    { 17, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 17, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 2 },
                    { 8, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 8, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 3 },
                    { 18, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 18, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 3 },
                    { 6, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 6, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 1 },
                    { 2, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 2, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 2 },
                    { 9, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 9, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 4 },
                    { 10, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 10, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 5 },
                    { 20, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 20, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 5 },
                    { 1, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 1, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 1 },
                    { 11, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 11, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 1 },
                    { 19, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 19, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 4 },
                    { 14, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), false, 14, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 100, new DateTime(2020, 12, 4, 8, 4, 59, 95, DateTimeKind.Utc).AddTicks(4699), 4 }
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CreatedOn", "IsRemoved", "ProductId", "Quantity", "UpdatedOn" },
                values: new object[,]
                {
                    { 15, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 15, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 6, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 6, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 5, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 5, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 11, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 11, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 4, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 4, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 13, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 13, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 3, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 3, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 12, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 12, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 2, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 2, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 1, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 1, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 20, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 20, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 10, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 10, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 19, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 19, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 9, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 9, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 18, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 18, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 8, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 8, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 17, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 17, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 7, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 7, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 14, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 14, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) },
                    { 16, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979), false, 16, 100, new DateTime(2020, 12, 4, 8, 4, 59, 96, DateTimeKind.Utc).AddTicks(2979) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMetadata_ProductId",
                table: "ProductMetadata",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProductId",
                table: "Purchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_VendorId",
                table: "Purchase",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductMetadata");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
