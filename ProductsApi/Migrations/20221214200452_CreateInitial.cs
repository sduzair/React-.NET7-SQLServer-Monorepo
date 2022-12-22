using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAdmin",
                columns: table => new
                {
                    ProductAdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAdmin", x => x.ProductAdminId);
                    table.ForeignKey(
                        name: "FK_ProductAdmin_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Category", "DateCreated", "DateDeleted", "DateUpdated", "Description", "DiscountPercentage", "ImageUrl", "Price", "Rating", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "Apple", "smartphones", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3498), new TimeSpan(0, 0, 0, 0, 0)), null, null, "An apple mobile which is nothing like apple", 12.96m, "https://dummyjson.com/image/i/products/1/thumbnail.jpg", 549m, 4.6900000000000004, 94, "iPhone 9" },
                    { 2, "Apple", "smartphones", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3505), new TimeSpan(0, 0, 0, 0, 0)), null, null, "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...", 17.94m, "https://dummyjson.com/image/i/products/2/thumbnail.jpg", 899m, 4.4400000000000004, 34, "iPhone X" },
                    { 3, "Samsung", "smartphones", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3508), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Samsung's new variant which goes beyond Galaxy to the Universe", 15.46m, "https://dummyjson.com/image/i/products/3/thumbnail.jpg", 1249m, 4.0899999999999999, 36, "Samsung Universe 9" },
                    { 4, "OPPO", "smartphones", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 0, 0, 0, 0)), null, null, "OPPO F19 is officially announced on April 2021.", 17.91m, "https://dummyjson.com/image/i/products/4/thumbnail.jpg", 280m, 4.2999999999999998, 123, "OPPOF19" },
                    { 5, "Huawei", "smartphones", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3516), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.", 10.58m, "https://dummyjson.com/image/i/products/5/thumbnail.jpg", 499m, 4.0899999999999999, 32, "Huawei P30" },
                    { 6, "APPle", "laptops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3519), new TimeSpan(0, 0, 0, 0, 0)), null, null, "MacBook Pro 2021 with mini-LED display may launch between September, November", 11.02m, "https://dummyjson.com/image/i/products/6/thumbnail.png", 1749m, 4.5700000000000003, 83, "MacBook Pro" },
                    { 7, "Samsung", "laptops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3522), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched", 4.15m, "https://dummyjson.com/image/i/products/7/thumbnail.jpg", 1499m, 4.25, 50, "Samsung Galaxy Book" },
                    { 8, "Microsoft Surface", "laptops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3525), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Style and speed. Stand out on HD vProductideo calls backed by Studio Mics. Capture Productideas on the vibrant touchscreen.", 10.23m, "https://dummyjson.com/image/i/products/8/thumbnail.jpg", 1499m, 4.4299999999999997, 68, "Microsoft Surface Laptop 4" },
                    { 9, "Infinix", "laptops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty", 11.83m, "https://dummyjson.com/image/i/products/9/thumbnail.jpg", 1099m, 4.54, 96, "Infinix INBOOK" },
                    { 10, "HP Pavilion", "laptops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3531), new TimeSpan(0, 0, 0, 0, 0)), null, null, "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10", 6.18m, "https://dummyjson.com/image/i/products/10/thumbnail.jpeg", 1099m, 4.4299999999999997, 89, "HP Pavilion 15-DK1056WM" },
                    { 11, "Impression of Acqua Di Gio", "fragrances", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3535), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil", 8.4m, "https://dummyjson.com/image/i/products/11/thumbnail.jpg", 13m, 4.2599999999999998, 65, "perfume Oil" },
                    { 12, "Royal_Mirage", "fragrances", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3539), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml", 15.66m, "https://dummyjson.com/image/i/products/12/thumbnail.jpg", 40m, 4.0, 52, "Brown Perfume" },
                    { 13, "Fog Scent Xpressio", "fragrances", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3541), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men", 8.14m, "https://dummyjson.com/image/i/products/13/thumbnail.webp", 13m, 4.5899999999999999, 61, "Fog Scent Xpressio Perfume" },
                    { 14, "Al Munakh", "fragrances", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3544), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil", 15.6m, "https://dummyjson.com/image/i/products/14/thumbnail.jpg", 120m, 4.21, 114, "Non-Alcoholic Concentrated Perfume Oil" },
                    { 15, "Lord - Al-Rehab", "fragrances", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality", 10.99m, "https://dummyjson.com/image/i/products/15/thumbnail.jpg", 30m, 4.7000000000000002, 105, "Eau De Perfume Spray" },
                    { 16, "L'Oreal Paris", "skincare", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3550), new TimeSpan(0, 0, 0, 0, 0)), null, null, "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic AcProductid", 13.31m, "https://dummyjson.com/image/i/products/16/thumbnail.jpg", 19m, 4.8300000000000001, 110, "Hyaluronic AcProductid Serum" },
                    { 17, "Hemani Tea", "skincare", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3553), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,", 4.09m, "https://dummyjson.com/image/i/products/17/thumbnail.jpg", 12m, 4.5199999999999996, 78, "Tree Oil 30ml" },
                    { 18, "Dermive", "skincare", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3556), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramProductides, hyaluronic acProductid & sunscreen.", 13.1m, "https://dummyjson.com/image/i/products/18/thumbnail.jpg", 40m, 4.5599999999999996, 88, "Oil Free Moisturizer 100ml" },
                    { 19, "ROREC White Rice", "skincare", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3559), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Product name: rorec collagen hyaluronic acProductid white face serum riceNet weight: 15 m", 10.68m, "https://dummyjson.com/image/i/products/19/thumbnail.jpg", 46m, 4.4199999999999999, 54, "Skin Beauty Serum." },
                    { 20, "Fair & Clear", "skincare", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3630), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no sProductide effects.", 16.99m, "https://dummyjson.com/image/i/products/20/thumbnail.jpg", 70m, 4.0599999999999996, 140, "Freckle Treatment Cream- 15gm" },
                    { 21, "Saaf & Khaas", "groceries", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Fine quality Branded Product Keep in a cool and dry place", 4.81m, "https://dummyjson.com/image/i/products/21/thumbnail.png", 20m, 4.4400000000000004, 133, "- Daal Masoor 500 grams" },
                    { 22, "Bake Parlor Big", "groceries", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3636), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Product details of Bake Parlor Big Elbow Macaroni - 400 gm", 15.58m, "https://dummyjson.com/image/i/products/22/thumbnail.jpg", 14m, 4.5700000000000003, 146, "Elbow Macaroni - 400 gm" },
                    { 23, "Baking Food Items", "groceries", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3640), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Specifications of Orange Essence Food Flavour For Cakes and Baking Food Item", 8.04m, "https://dummyjson.com/image/i/products/23/thumbnail.jpg", 14m, 4.8499999999999996, 26, "Orange Essence Food Flavou" },
                    { 24, "fauji", "groceries", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 0, 0, 0, 0)), null, null, "original fauji cereal muesli 250gm box pack original fauji cereals muesli fruit nuts flakes breakfast cereal break fast faujicereals cerels cerel foji fouji", 16.8m, "https://dummyjson.com/image/i/products/24/thumbnail.jpg", 46m, 4.9400000000000004, 113, "cereals muesli fruit nuts" },
                    { 25, "Dry Rose", "groceries", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3646), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Dry Rose Flower Powder Gulab Powder 50 Gram • Treats Wounds", 13.58m, "https://dummyjson.com/image/i/products/25/thumbnail.jpg", 70m, 4.8700000000000001, 47, "Gulab Powder 50 Gram" },
                    { 26, "Boho Decor", "home-decoration", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3649), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Boho Decor Plant Hanger For Home Wall Decoration Macrame Wall Hanging Shelf", 17.86m, "https://dummyjson.com/image/i/products/26/thumbnail.jpg", 41m, 4.0800000000000001, 131, "Plant Hanger For Home" },
                    { 27, "Flying Wooden", "home-decoration", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3653), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Package Include 6 Birds with Adhesive Tape Shape: 3D Shaped Wooden Birds Material: Wooden MDF, Laminated 3.5mm", 15.58m, "https://dummyjson.com/image/i/products/27/thumbnail.webp", 51m, 4.4100000000000001, 17, "Flying Wooden Bird" },
                    { 28, "LED Lights", "home-decoration", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3656), new TimeSpan(0, 0, 0, 0, 0)), null, null, "3D led lamp sticker Wall sticker 3d wall art light on/off button  cell operated (included)", 16.49m, "https://dummyjson.com/image/i/products/28/thumbnail.jpg", 20m, 4.8200000000000003, 54, "3D Embellishment Art Lamp" },
                    { 29, "luxury palace", "home-decoration", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3659), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Handcraft Chinese style art luxury palace hotel villa mansion home decor ceramic vase with brass fruit plate", 15.34m, "https://dummyjson.com/image/i/products/29/thumbnail.webp", 60m, 4.4400000000000004, 7, "Handcraft Chinese style" },
                    { 30, "Golden", "home-decoration", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Attractive DesignMetallic materialFour key hooksReliable & DurablePremium Quality", 2.92m, "https://dummyjson.com/image/i/products/30/thumbnail.jpg", 30m, 4.9199999999999999, 54, "Key Holder" },
                    { 31, "Furniture Bed Set", "furniture", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3664), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Mornadi Velvet Bed Base with Headboard Slats Support Classic Style Bedroom Furniture Bed Set", 17m, "https://dummyjson.com/image/i/products/31/thumbnail.jpg", 40m, 4.1600000000000001, 140, "Mornadi Velvet Bed" },
                    { 32, "Ratttan Outdoor", "furniture", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3667), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Ratttan Outdoor furniture Set Waterproof  Rattan Sofa for Coffe Cafe", 15.59m, "https://dummyjson.com/image/i/products/32/thumbnail.jpg", 50m, 4.7400000000000002, 30, "Sofa for Coffe Cafe" },
                    { 33, "Kitchen Shelf", "furniture", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3670), new TimeSpan(0, 0, 0, 0, 0)), null, null, "3 Tier Corner Shelves | 3 PCs Wall Mount Kitchen Shelf | Floating Bedroom Shelf", 17m, "https://dummyjson.com/image/i/products/33/thumbnail.jpg", 700m, 4.3099999999999996, 106, "3 Tier Corner Shelves" },
                    { 34, "Multi Purpose", "furniture", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3674), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Very good quality plastic table for multi purpose now in reasonable price", 4m, "https://dummyjson.com/image/i/products/34/thumbnail.jpg", 50m, 4.0099999999999998, 136, "Plastic Table" },
                    { 35, "AmnaMart", "furniture", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3676), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Material: Stainless Steel and Fabric  Item Size: 110 cm x 45 cm x 175 cm Package Contents: 1 Storage Wardrobe", 7.98m, "https://dummyjson.com/image/i/products/35/thumbnail.jpg", 41m, 4.0599999999999996, 68, "3 DOOR PORTABLE" },
                    { 36, "Professional Wear", "tops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3679), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Cotton SolProductid Color Professional Wear Sleeve Shirt Womens Work Blouses Wholesale Clothing Casual Plain Custom Top OEM Customized", 10.89m, "https://dummyjson.com/image/i/products/36/thumbnail.jpg", 90m, 4.2599999999999998, 39, "Sleeve Shirt Womens" },
                    { 37, "Soft Cotton", "tops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 0, 0, 0, 0)), null, null, "PACK OF 3 CAMISOLES ,VERY COMFORTABLE SOFT COTTON STUFF, COMFORTABLE IN ALL FOUR SEASONS", 12.05m, "https://dummyjson.com/image/i/products/37/thumbnail.jpg", 50m, 4.5199999999999996, 107, "ank Tops for Womens/Girls" },
                    { 38, "Soft Cotton", "tops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3684), new TimeSpan(0, 0, 0, 0, 0)), null, null, "sublimation plain kProductids tank tops wholesale", 11.12m, "https://dummyjson.com/image/i/products/38/thumbnail.jpg", 100m, 4.7999999999999998, 20, "sublimation plain kProductids tank" },
                    { 39, "Top Sweater", "tops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3687), new TimeSpan(0, 0, 0, 0, 0)), null, null, "2021 Custom Winter Fall Zebra Knit Crop Top Women Sweaters Wool Mohair Cos Customize Crew Neck Women' S Crop Top Sweater", 17.2m, "https://dummyjson.com/image/i/products/39/thumbnail.jpg", 600m, 4.5499999999999998, 55, "Women Sweaters Wool" },
                    { 40, "Top Sweater", "tops", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, 0, 0, 0, 0)), null, null, "women winter clothes thick fleece hoodie top with sweat pantjogger women sweatsuit set joggers pants two piece pants set", 13.39m, "https://dummyjson.com/image/i/products/40/thumbnail.jpg", 57m, 4.9100000000000001, 84, "women winter clothes" },
                    { 41, "RED MICKY MOUSE..", "womens-dresses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3693), new TimeSpan(0, 0, 0, 0, 0)), null, null, "NIGHT SUIT RED MICKY MOUSE..  For Girls. Fantastic Suits.", 15.05m, "https://dummyjson.com/image/i/products/41/thumbnail.webp", 55m, 4.6500000000000004, 21, "NIGHT SUIT" },
                    { 42, "Digital Printed", "womens-dresses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3697), new TimeSpan(0, 0, 0, 0, 0)), null, null, "FABRIC: LILEIN CHEST: 21 LENGHT: 37 TROUSER: (38) :ARABIC LILEIN", 15.37m, "https://dummyjson.com/image/i/products/42/thumbnail.jpg", 80m, 4.0499999999999998, 148, "Stiched Kurta plus trouser" },
                    { 43, "Ghazi Fabric", "womens-dresses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3700), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Ghazi fabric long frock gold printed ready to wear stitched collection (G992)", 15.55m, "https://dummyjson.com/image/i/products/43/thumbnail.jpg", 600m, 4.3099999999999996, 150, "frock gold printed" },
                    { 44, "Ghazi Fabric", "womens-dresses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This classy shirt for women gives you a gorgeous look on everyday wear and specially for semi-casual wears.", 16.88m, "https://dummyjson.com/image/i/products/44/thumbnail.jpg", 79m, 4.0300000000000002, 2, "Ladies Multicolored Dress" },
                    { 45, "IELGY", "womens-dresses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3705), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Ready to wear, Unique design according to modern standard fashion, Best fitting ,Imported stuff", 5.07m, "https://dummyjson.com/image/i/products/45/thumbnail.jpg", 50m, 4.6699999999999999, 96, "Malai Maxi Dress" },
                    { 46, "IELGY fashion", "womens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3708), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Close: Lace, Style with bottom: Increased insProductide, Sole Material: Rubber", 16.96m, "https://dummyjson.com/image/i/products/46/thumbnail.jpg", 40m, 4.1399999999999997, 72, "women's shoes" },
                    { 47, "Synthetic Leather", "womens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3712), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Synthetic Leather Casual Sneaker shoes for Women/girls Sneakers For Women", 10.37m, "https://dummyjson.com/image/i/products/47/thumbnail.jpeg", 120m, 4.1900000000000004, 50, "Sneaker shoes" },
                    { 48, "Sandals Flip Flops", "womens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3715), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Features: Flip-flops, MProductid Heel, Comfortable, Striped Heel, AntiskProductid, Striped", 10.83m, "https://dummyjson.com/image/i/products/48/thumbnail.jpg", 40m, 4.0199999999999996, 25, "Women Strip Heel" },
                    { 49, "Maasai Sandals", "womens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3718), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Womens Chappals & Shoe Ladies Metallic Tong Thong Sandal Flat Summer 2020 Maasai Sandals", 2.62m, "https://dummyjson.com/image/i/products/49/thumbnail.jpg", 23m, 4.7199999999999998, 107, "Chappals & Shoe Ladies Metallic" },
                    { 50, "Arrivals Genuine", "womens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, 0, 0, 0, 0)), null, null, "2020 New Arrivals Genuine Leather Fashion Trend Platform Summer Women Shoes", 16.87m, "https://dummyjson.com/image/i/products/50/thumbnail.jpg", 36m, 4.3300000000000001, 46, "Women Shoes" },
                    { 51, "Vintage Apparel", "mens-shirts", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Many store is creating new designs and trend every month and every year. Daraz.pk have a beautiful range of men fashion brands", 12.76m, "https://dummyjson.com/image/i/products/51/thumbnail.jpg", 23m, 4.2599999999999998, 132, "half sleeves T shirts" },
                    { 52, "FREE FIRE", "mens-shirts", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3727), new TimeSpan(0, 0, 0, 0, 0)), null, null, "quality and professional print - It doesn't just look high quality, it is high quality.", 14.72m, "https://dummyjson.com/image/i/products/52/thumbnail.jpg", 10m, 4.5199999999999996, 128, "FREE FIRE T Shirt" },
                    { 53, "Vintage Apparel", "mens-shirts", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3730), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Brand: vintage Apparel ,Export quality", 7.54m, "https://dummyjson.com/image/i/products/53/thumbnail.jpg", 35m, 4.8899999999999997, 6, "printed high quality T shirts" },
                    { 54, "The Warehouse", "mens-shirts", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3733), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Product Description Features: 100% Ultra soft Polyester Jersey. Vibrant & colorful printing on front. Feels soft as cotton without ever cracking", 16.44m, "https://dummyjson.com/image/i/products/54/thumbnail.jpg", 46m, 4.6200000000000001, 136, "Pubg Printed Graphic T-Shirt" },
                    { 55, "The Warehouse", "mens-shirts", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3735), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Fabric Jercy, Size: M & L Wear Stylish Dual Stiched", 15.97m, "https://dummyjson.com/image/i/products/55/thumbnail.jpg", 66m, 4.9000000000000004, 122, "Money Heist Printed Summer T Shirts" },
                    { 56, "Sneakers", "mens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Gender: Men , Colors: Same as DisplayedCondition: 100% Brand New", 12.57m, "https://dummyjson.com/image/i/products/56/thumbnail.jpg", 40m, 4.3799999999999999, 6, "Sneakers Joggers Shoes" },
                    { 57, "Rubber", "mens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Men Shoes - Loafers for men - Rubber Shoes - Nylon Shoes - Shoes for men - Moccassion - Pure Nylon (Rubber) Expot Quality.", 10.91m, "https://dummyjson.com/image/i/products/57/thumbnail.jpg", 47m, 4.9100000000000001, 20, "Loafers for men" },
                    { 58, "The Warehouse", "mens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3745), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Pattern Type: SolProductid, Material: PU, Toe Shape: Pointed Toe ,Outsole Material: Rubber", 12m, "https://dummyjson.com/image/i/products/58/thumbnail.jpg", 57m, 4.4100000000000001, 68, "formal offices shoes" },
                    { 59, "Sneakers", "mens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3748), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Comfortable stretch cloth, lightweight body; ,rubber sole, anti-skProductid wear;", 8.71m, "https://dummyjson.com/image/i/products/59/thumbnail.jpg", 20m, 4.3300000000000001, 137, "Spring and summershoes" },
                    { 60, "Sneakers", "mens-shoes", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 0, 0, 0, 0)), null, null, "High Quality ,Stylish design ,Comfortable wear ,FAshion ,Durable", 7.55m, "https://dummyjson.com/image/i/products/60/thumbnail.jpg", 58m, 4.5499999999999998, 129, "Stylish Casual Jeans Shoes" },
                    { 61, "Naviforce", "mens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3754), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Style:Sport ,Clasp:Buckles ,Water Resistance Depth:3Bar", 7.14m, "https://dummyjson.com/image/i/products/61/thumbnail.jpg", 120m, 4.6299999999999999, 91, "Leather Straps Wristwatch" },
                    { 62, "SKMEI 9117", "mens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3756), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Watch Crown With Environmental IPS Bronze Electroplating; Display system of 12 hours", 3.15m, "https://dummyjson.com/image/i/products/62/thumbnail.jpg", 46m, 4.0499999999999998, 95, "Waterproof Leather Brand Watch" },
                    { 63, "SKMEI 9117", "mens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3759), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Men Silver Chain Royal Blue Premium Watch Latest Analog Watch", 2.56m, "https://dummyjson.com/image/i/products/63/thumbnail.webp", 50m, 4.8899999999999997, 142, "Royal Blue Premium Watch" },
                    { 64, "Strap Skeleton", "mens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Leather Strap Skeleton Watch for Men - Stylish and Latest Design", 10.2m, "https://dummyjson.com/image/i/products/64/thumbnail.jpg", 46m, 4.9800000000000004, 61, "Leather Strap Skeleton Watch" },
                    { 65, "Stainless", "mens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3765), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Stylish Watch For Man (Luxury) Classy Men's Stainless Steel Wrist Watch - Box Packed", 17.79m, "https://dummyjson.com/image/i/products/65/thumbnail.webp", 47m, 4.79, 94, "Stainless Steel Wrist Watch" },
                    { 66, "Eastern Watches", "womens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3804), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Elegant design, Stylish ,Unique & Trendy,Comfortable wear", 3.23m, "https://dummyjson.com/image/i/products/66/thumbnail.jpg", 35m, 4.79, 24, "Steel Analog Couple Watches" },
                    { 67, "Eastern Watches", "womens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3807), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Buy this awesome  The product is originally manufactured by the company and it's a top selling product with a very reasonable", 16.69m, "https://dummyjson.com/image/i/products/67/thumbnail.jpg", 60m, 4.0300000000000002, 46, "Fashion Magnetic Wrist Watch" },
                    { 68, "Luxury Digital", "womens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3811), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Stylish Luxury Digital Watch For Girls / Women - Led Smart Ladies Watches For Girls", 9.03m, "https://dummyjson.com/image/i/products/68/thumbnail.webp", 57m, 4.5499999999999998, 77, "Stylish Luxury Digital Watch" },
                    { 69, "Watch Pearls", "womens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3814), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Product details of Golden Watch Pearls Bracelet Watch For Girls - Golden Chain Ladies Bracelate Watch for Women", 17.55m, "https://dummyjson.com/image/i/products/69/thumbnail.jpg", 47m, 4.7699999999999996, 89, "Golden Watch Pearls Bracelet Watch" },
                    { 70, "Bracelet", "womens-watches", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3817), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Fashion Skmei 1830 Shell Dial Stainless Steel Women Wrist Watch Lady Bracelet Watch Quartz Watches Ladies", 8.98m, "https://dummyjson.com/image/i/products/70/thumbnail.jpg", 35m, 4.0800000000000001, 111, "Stainless Steel Women" },
                    { 71, "LouisWill", "womens-bags", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3821), new TimeSpan(0, 0, 0, 0, 0)), null, null, "LouisWill Women Shoulder Bags Long Clutches Cross Body Bags Phone Bags PU Leather Hand Bags Large Capacity Card Holders Zipper Coin Purses Fashion Crossbody Bags for Girls Ladies", 14.65m, "https://dummyjson.com/image/i/products/71/thumbnail.jpg", 46m, 4.71, 17, "Women Shoulder Bags" },
                    { 72, "LouisWill", "womens-bags", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3824), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This fashion is designed to add a charming effect to your casual outfit. This Bag is made of synthetic leather.", 17.5m, "https://dummyjson.com/image/i/products/72/thumbnail.webp", 23m, 4.9100000000000001, 27, "Handbag For Girls" },
                    { 73, "Bracelet", "womens-bags", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3828), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This fashion is designed to add a charming effect to your casual outfit. This Bag is made of synthetic leather.", 10.39m, "https://dummyjson.com/image/i/products/73/thumbnail.jpg", 44m, 4.1799999999999997, 101, "Fancy hand clutch" },
                    { 74, "Copenhagen Luxe", "womens-bags", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 0, 0, 0, 0)), null, null, "It features an attractive design that makes it a must have accessory in your collection. We sell different kind of bags for boys, kProductids, women, girls and also for unisex.", 11.19m, "https://dummyjson.com/image/i/products/74/thumbnail.jpg", 57m, 4.0099999999999998, 43, "Leather Hand Bag" },
                    { 75, "Steal Frame", "womens-bags", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3834), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Seven Pocket Women Bag Handbags Lady Shoulder Crossbody Bag Female Purse Seven Pocket Bag", 14.87m, "https://dummyjson.com/image/i/products/75/thumbnail.jpg", 68m, 4.9299999999999997, 13, "Seven Pocket Women Bag" },
                    { 76, "Darojay", "womens-jewellery", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3837), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Jewelry Type:RingsCertificate Type:NonePlating:Silver PlatedShapeattern:noneStyle:CLASSICReligious", 13.57m, "https://dummyjson.com/image/i/products/76/thumbnail.jpg", 70m, 4.6100000000000003, 51, "Silver Ring Set Women" },
                    { 77, "Copenhagen Luxe", "womens-jewellery", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3841), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Brand: The Greetings Flower Colour: RedRing Colour: GoldenSize: Adjustable", 3.22m, "https://dummyjson.com/image/i/products/77/thumbnail.jpg", 100m, 4.21, 149, "Rose Ring" },
                    { 78, "Fashion Jewellery", "womens-jewellery", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3844), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Fashion Jewellery 3Pcs Adjustable Pearl Rhinestone Korean Style Open Rings For Women", 8.02m, "https://dummyjson.com/image/i/products/78/thumbnail.jpg", 30m, 4.6900000000000004, 9, "Rhinestone Korean Style Open Rings" },
                    { 79, "Fashion Jewellery", "womens-jewellery", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Elegant Female Pearl Earrings Set Zircon Pearl Earings Women Party Accessories 9 Pairs/Set", 12.8m, "https://dummyjson.com/image/i/products/79/thumbnail.jpg", 30m, 4.7400000000000002, 16, "Elegant Female Pearl Earrings" },
                    { 80, "Cuff Butterfly", "womens-jewellery", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3849), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Pair Of Ear Cuff Butterfly Long Chain Pin Tassel Earrings - Silver ( Long Life Quality Product)", 17.75m, "https://dummyjson.com/image/i/products/80/thumbnail.jpg", 45m, 4.5899999999999999, 9, "Chain Pin Tassel Earrings" },
                    { 81, "Designer Sun Glasses", "sunglasses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3853), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A pair of sunglasses can protect your eyes from being hurt. For car driving, vacation travel, outdoor activities, social gatherings,", 10.1m, "https://dummyjson.com/image/i/products/81/thumbnail.jpg", 19m, 4.9400000000000004, 78, "Round Silver Frame Sun Glasses" },
                    { 82, "Designer Sun Glasses", "sunglasses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3856), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Orignal Metal Kabir Singh design 2020 Sunglasses Men Brand Designer Sun Glasses Kabir Singh Square Sunglass", 15.6m, "https://dummyjson.com/image/i/products/82/thumbnail.jpg", 50m, 4.6200000000000001, 78, "Kabir Singh Square Sunglass" },
                    { 83, "mastar watch", "sunglasses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3859), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Wiley X Night Vision Yellow Glasses for RProductiders - Night Vision Anti Fog Driving Glasses - Free Night Glass Cover - Shield Eyes From Dust and Virus- For Night Sport Matches", 6.33m, "https://dummyjson.com/image/i/products/83/thumbnail.jpg", 30m, 4.9699999999999998, 115, "Wiley X Night Vision Yellow Glasses" },
                    { 84, "mastar watch", "sunglasses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3861), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Fashion Oversized Square Sunglasses Retro Gradient Big Frame Sunglasses For Women One Piece Gafas Shade Mirror Clear Lens 17059", 13.89m, "https://dummyjson.com/image/i/products/84/thumbnail.jpg", 28m, 4.6399999999999997, 64, "Square Sunglasses" },
                    { 85, "LouisWill", "sunglasses", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3864), new TimeSpan(0, 0, 0, 0, 0)), null, null, "LouisWill Men Sunglasses Polarized Sunglasses UV400 Sunglasses Day Night Dual Use Safety Driving Night Vision Eyewear AL-MG Frame Sun Glasses with Free Box for Drivers", 11.27m, "https://dummyjson.com/image/i/products/85/thumbnail.jpg", 50m, 4.9800000000000004, 92, "LouisWill Men Sunglasses" },
                    { 86, "Car Aux", "automotive", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3867), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Bluetooth Aux Bluetooth Car Aux Car Bluetooth Transmitter Aux Audio Receiver Handfree Car Bluetooth Music Receiver Universal 3.5mm Streaming A2DP Wireless Auto AUX Audio Adapter With Mic For Phone MP3", 10.56m, "https://dummyjson.com/image/i/products/86/thumbnail.jpg", 25m, 4.5700000000000003, 22, "Bluetooth Aux" },
                    { 87, "W1209 DC12V", "automotive", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3869), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Both Heat and Cool Purpose, Temperature control range; -50 to +110, Temperature measurement accuracy; 0.1, Control accuracy; 0.1", 11.3m, "https://dummyjson.com/image/i/products/87/thumbnail.jpg", 40m, 4.54, 37, "t Temperature Controller Incubator Controller" },
                    { 88, "TC Reusable", "automotive", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3873), new TimeSpan(0, 0, 0, 0, 0)), null, null, "TC Reusable Silicone Magic Washing Gloves with Scrubber, Cleaning Brush Scrubber Gloves Heat Resistant Pair for Cleaning of Kitchen, Dishes, Vegetables and Fruits, Bathroom, Car Wash, Pet Care and Multipurpose", 3.19m, "https://dummyjson.com/image/i/products/88/thumbnail.jpg", 29m, 4.9800000000000004, 42, "TC Reusable Silicone Magic Washing Gloves" },
                    { 89, "TC Reusable", "automotive", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3876), new TimeSpan(0, 0, 0, 0, 0)), null, null, "best Quality CHarger , Highly Recommended to all best Quality CHarger , Highly Recommended to all", 17.53m, "https://dummyjson.com/image/i/products/89/thumbnail.jpg", 40m, 4.2000000000000002, 79, "Qualcomm original Car Charger" },
                    { 90, "Neon LED Light", "automotive", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3879), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Universal fitment and easy to install no special wires, can be easily installed and removed. Fits most standard tyre air stem valves of road, mountain bicycles, motocycles and cars.Bright led will turn on w", 11.08m, "https://dummyjson.com/image/i/products/90/thumbnail.jpg", 35m, 4.0999999999999996, 63, "Cycle Bike Glow" },
                    { 91, "METRO 70cc Motorcycle - MR70", "motorcycle", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Engine Type:Wet sump, Single Cylinder, Four Stroke, Two Valves, Air Cooled with SOHC (Single Over Head Cam) Chain Drive Bore & Stroke:47.0 x 49.5 MM", 13.63m, "https://dummyjson.com/image/i/products/91/thumbnail.jpg", 569m, 4.04, 115, "Black Motorbike" },
                    { 92, "BRAVE BULL", "motorcycle", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3884), new TimeSpan(0, 0, 0, 0, 0)), null, null, "HOT SALE IN EUROPE electric racing motorcycle electric motorcycle for sale adult electric motorcycles", 14.4m, "https://dummyjson.com/image/i/products/92/thumbnail.jpg", 920m, 4.1900000000000004, 22, "HOT SALE IN EUROPE electric racing motorcycle" },
                    { 93, "shock absorber", "motorcycle", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3887), new TimeSpan(0, 0, 0, 0, 0)), null, null, "150cc 4-Stroke Motorcycle Automatic Motor Gas Motorcycles Scooter motorcycles 150cc scooter", 3.34m, "https://dummyjson.com/image/i/products/93/thumbnail.jpg", 1050m, 4.8399999999999999, 127, "Automatic Motor Gas Motorcycles" },
                    { 94, "JIEPOLLY", "motorcycle", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3890), new TimeSpan(0, 0, 0, 0, 0)), null, null, "new arrivals Fashion motocross goggles motorcycle motocross racing motorcycle", 3.85m, "https://dummyjson.com/image/i/products/94/thumbnail.webp", 900m, 4.0599999999999996, 109, "new arrivals Fashion motocross goggles" },
                    { 95, "Xiangle", "motorcycle", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3893), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Wholesale cargo lashing Belt Tie Down end Ratchet strap customized strap 25mm motorcycle 1500kgs with rubber handle", 17.67m, "https://dummyjson.com/image/i/products/95/thumbnail.jpg", 930m, 4.21, 144, "Wholesale cargo lashing Belt" },
                    { 96, "lightingbrilliance", "lighting", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3896), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Wholesale slim hanging decorative kProductid room lighting ceiling kitchen chandeliers pendant light modern", 14.89m, "https://dummyjson.com/image/i/products/96/thumbnail.jpg", 30m, 4.8300000000000001, 96, "lighting ceiling kitchen" },
                    { 97, "Ifei Home", "lighting", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3898), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Metal Ceramic Flower Chandelier Home Lighting American Vintage Hanging Lighting Pendant Lamp", 10.94m, "https://dummyjson.com/image/i/products/97/thumbnail.jpg", 35m, 4.9299999999999997, 146, "Metal Ceramic Flower" },
                    { 98, "DADAWU", "lighting", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3901), new TimeSpan(0, 0, 0, 0, 0)), null, null, "3 lights lndenpant kitchen islang dining room pendant rice paper chandelier contemporary led pendant light modern chandelier", 5.92m, "https://dummyjson.com/image/i/products/98/thumbnail.jpg", 34m, 4.9900000000000002, 44, "3 lights lndenpant kitchen islang" },
                    { 99, "Ifei Home", "lighting", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3904), new TimeSpan(0, 0, 0, 0, 0)), null, null, "American Vintage Wood Pendant Light Farmhouse Antique Hanging Lamp Lampara Colgante", 8.84m, "https://dummyjson.com/image/i/products/99/thumbnail.jpg", 46m, 4.3200000000000003, 138, "American Vintage Wood Pendant Light" },
                    { 100, "YIOSI", "lighting", new DateTimeOffset(new DateTime(2022, 12, 14, 20, 4, 52, 222, DateTimeKind.Unspecified).AddTicks(3907), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Crystal chandelier maria theresa for 12 light", 16m, "https://dummyjson.com/image/i/products/100/thumbnail.jpg", 47m, 4.7400000000000002, 133, "Crystal chandelier maria theresa for 12 light" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdmin_UserId",
                table: "ProductAdmin",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ProductAdmin");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
