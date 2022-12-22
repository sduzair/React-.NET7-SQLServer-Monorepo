using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProductsAPI.Data;

public class ApiDbContext : IdentityDbContext<User>
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var insertedEntries = ChangeTracker.Entries()
                     .Where(x => x.State == EntityState.Added)
                     .Select(x => x.Entity);

        foreach (var insertedEntry in insertedEntries)
        {
            //If the inserted object is an Auditable. 
            if (insertedEntry is IAuditable auditableEntity)
            {
				auditableEntity.DateCreated = DateTimeOffset.UtcNow;
            }
        }

        var modifiedEntries = ChangeTracker.Entries()
               .Where(x => x.State == EntityState.Modified)
               .Select(x => x.Entity);

        foreach (var modifiedEntry in modifiedEntries)
        {
            //If the inserted object is an Auditable. 
            if (modifiedEntry is IAuditable auditableEntity)
            {
                auditableEntity.DateUpdated = DateTimeOffset.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

	// add products to database
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
		 new Product
		 {
			 ProductId = 1,
		 	Title = "iPhone 9",
		 	Description = "An apple mobile which is nothing like apple",
		 	Price = 549m,
		 	DiscountPercentage = 12.96m,
		 	Rating = 4.69,
		 	Stock = 94,
			 Brand = "Apple",
		 	Category = "smartphones",
		 	ImageUrl = "https://dummyjson.com/image/i/products/1/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 2,
		 	Title = "iPhone X",
		 	Description = "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
		 	Price = 899m,
		 	DiscountPercentage = 17.94m,
		 	Rating = 4.44,
		 	Stock = 34,
		 	Brand = "Apple",
		 	Category = "smartphones",
		 	ImageUrl = "https://dummyjson.com/image/i/products/2/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 3,
		 	Title = "Samsung Universe 9",
		 	Description = "Samsung's new variant which goes beyond Galaxy to the Universe",
		 	Price = 1249m,
		 	DiscountPercentage = 15.46m,
		 	Rating = 4.09,
		 	Stock = 36,
		 	Brand = "Samsung",
		 	Category = "smartphones",
		 	ImageUrl = "https://dummyjson.com/image/i/products/3/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 4,
		 	Title = "OPPOF19",
		 	Description = "OPPO F19 is officially announced on April 2021.",
		 	Price = 280m,
		 	DiscountPercentage = 17.91m,
		 	Rating = 4.3,
		 	Stock = 123,
		 	Brand = "OPPO",
		 	Category = "smartphones",
		 	ImageUrl = "https://dummyjson.com/image/i/products/4/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 5,
		 	Title = "Huawei P30",
		 	Description = "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.",
		 	Price = 499m,
		 	DiscountPercentage = 10.58m,
		 	Rating = 4.09,
		 	Stock = 32,
		 	Brand = "Huawei",
		 	Category = "smartphones",
		 	ImageUrl = "https://dummyjson.com/image/i/products/5/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 6,
		 	Title = "MacBook Pro",
		 	Description = "MacBook Pro 2021 with mini-LED display may launch between September, November",
		 	Price = 1749m,
		 	DiscountPercentage = 11.02m,
		 	Rating = 4.57,
		 	Stock = 83,
		 	Brand = "APPle",
		 	Category = "laptops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/6/thumbnail.png",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 7,
		 	Title = "Samsung Galaxy Book",
		 	Description = "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched",
		 	Price = 1499m,
		 	DiscountPercentage = 4.15m,
		 	Rating = 4.25,
		 	Stock = 50,
		 	Brand = "Samsung",
		 	Category = "laptops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/7/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 8,
		 	Title = "Microsoft Surface Laptop 4",
		 	Description = "Style and speed. Stand out on HD vProductideo calls backed by Studio Mics. Capture Productideas on the vibrant touchscreen.",
		 	Price = 1499m,
		 	DiscountPercentage = 10.23m,
		 	Rating = 4.43,
		 	Stock = 68,
		 	Brand = "Microsoft Surface",
		 	Category = "laptops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/8/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 9,
		 	Title = "Infinix INBOOK",
		 	Description = "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty",
		 	Price = 1099m,
		 	DiscountPercentage = 11.83m,
		 	Rating = 4.54,
		 	Stock = 96,
		 	Brand = "Infinix",
		 	Category = "laptops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/9/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 10,
		 	Title = "HP Pavilion 15-DK1056WM",
		 	Description = "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10",
		 	Price = 1099m,
		 	DiscountPercentage = 6.18m,
		 	Rating = 4.43,
		 	Stock = 89,
		 	Brand = "HP Pavilion",
		 	Category = "laptops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/10/thumbnail.jpeg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 11,
		 	Title = "perfume Oil",
		 	Description = "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil",
		 	Price = 13m,
		 	DiscountPercentage = 8.4m,
		 	Rating = 4.26,
		 	Stock = 65,
		 	Brand = "Impression of Acqua Di Gio",
		 	Category = "fragrances",
		 	ImageUrl = "https://dummyjson.com/image/i/products/11/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 12,
		 	Title = "Brown Perfume",
		 	Description = "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml",
		 	Price = 40m,
		 	DiscountPercentage = 15.66m,
		 	Rating = 4,
		 	Stock = 52,
		 	Brand = "Royal_Mirage",
		 	Category = "fragrances",
		 	ImageUrl = "https://dummyjson.com/image/i/products/12/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 13,
		 	Title = "Fog Scent Xpressio Perfume",
		 	Description = "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men",
		 	Price = 13m,
		 	DiscountPercentage = 8.14m,
		 	Rating = 4.59,
		 	Stock = 61,
		 	Brand = "Fog Scent Xpressio",
		 	Category = "fragrances",
		 	ImageUrl = "https://dummyjson.com/image/i/products/13/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 14,
		 	Title = "Non-Alcoholic Concentrated Perfume Oil",
		 	Description = "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil",
		 	Price = 120m,
		 	DiscountPercentage = 15.6m,
		 	Rating = 4.21,
		 	Stock = 114,
		 	Brand = "Al Munakh",
		 	Category = "fragrances",
		 	ImageUrl = "https://dummyjson.com/image/i/products/14/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 15,
		 	Title = "Eau De Perfume Spray",
		 	Description = "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality",
		 	Price = 30m,
		 	DiscountPercentage = 10.99m,
		 	Rating = 4.7,
		 	Stock = 105,
		 	Brand = "Lord - Al-Rehab",
		 	Category = "fragrances",
		 	ImageUrl = "https://dummyjson.com/image/i/products/15/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 16,
		 	Title = "Hyaluronic AcProductid Serum",
		 	Description = "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic AcProductid",
		 	Price = 19m,
		 	DiscountPercentage = 13.31m,
		 	Rating = 4.83,
		 	Stock = 110,
		 	Brand = "L'Oreal Paris",
		 	Category = "skincare",
		 	ImageUrl = "https://dummyjson.com/image/i/products/16/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 17,
		 	Title = "Tree Oil 30ml",
		 	Description = "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,",
		 	Price = 12m,
		 	DiscountPercentage = 4.09m,
		 	Rating = 4.52,
		 	Stock = 78,
		 	Brand = "Hemani Tea",
		 	Category = "skincare",
		 	ImageUrl = "https://dummyjson.com/image/i/products/17/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 18,
		 	Title = "Oil Free Moisturizer 100ml",
		 	Description = "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramProductides, hyaluronic acProductid & sunscreen.",
		 	Price = 40m,
		 	DiscountPercentage = 13.1m,
		 	Rating = 4.56,
		 	Stock = 88,
		 	Brand = "Dermive",
		 	Category = "skincare",
		 	ImageUrl = "https://dummyjson.com/image/i/products/18/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 19,
		 	Title = "Skin Beauty Serum.",
		 	Description = "Product name: rorec collagen hyaluronic acProductid white face serum riceNet weight: 15 m",
		 	Price = 46m,
		 	DiscountPercentage = 10.68m,
		 	Rating = 4.42,
		 	Stock = 54,
		 	Brand = "ROREC White Rice",
		 	Category = "skincare",
		 	ImageUrl = "https://dummyjson.com/image/i/products/19/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 20,
		 	Title = "Freckle Treatment Cream- 15gm",
		 	Description = "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no sProductide effects.",
		 	Price = 70m,
		 	DiscountPercentage = 16.99m,
		 	Rating = 4.06,
		 	Stock = 140,
		 	Brand = "Fair & Clear",
		 	Category = "skincare",
		 	ImageUrl = "https://dummyjson.com/image/i/products/20/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow


		 },
		 new Product
		 {

		 	ProductId = 21,
		 	Title = "- Daal Masoor 500 grams",
		 	Description = "Fine quality Branded Product Keep in a cool and dry place",
		 	Price = 20m,
		 	DiscountPercentage = 4.81m,
		 	Rating = 4.44,
		 	Stock = 133,
		 	Brand = "Saaf & Khaas",
		 	Category = "groceries",
		 	ImageUrl = "https://dummyjson.com/image/i/products/21/thumbnail.png",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 22,
		 	Title = "Elbow Macaroni - 400 gm",
		 	Description = "Product details of Bake Parlor Big Elbow Macaroni - 400 gm",
		 	Price = 14m,
		 	DiscountPercentage = 15.58m,
		 	Rating = 4.57,
		 	Stock = 146,
		 	Brand = "Bake Parlor Big",
		 	Category = "groceries",
		 	ImageUrl = "https://dummyjson.com/image/i/products/22/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 23,
		 	Title = "Orange Essence Food Flavou",
		 	Description = "Specifications of Orange Essence Food Flavour For Cakes and Baking Food Item",
		 	Price = 14m,
		 	DiscountPercentage = 8.04m,
		 	Rating = 4.85,
		 	Stock = 26,
		 	Brand = "Baking Food Items",
		 	Category = "groceries",
		 	ImageUrl = "https://dummyjson.com/image/i/products/23/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 24,
		 	Title = "cereals muesli fruit nuts",
		 	Description = "original fauji cereal muesli 250gm box pack original fauji cereals muesli fruit nuts flakes breakfast cereal break fast faujicereals cerels cerel foji fouji",
		 	Price = 46m,
		 	DiscountPercentage = 16.8m,
		 	Rating = 4.94,
		 	Stock = 113,
		 	Brand = "fauji",
		 	Category = "groceries",
		 	ImageUrl = "https://dummyjson.com/image/i/products/24/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 25,
		 	Title = "Gulab Powder 50 Gram",
		 	Description = "Dry Rose Flower Powder Gulab Powder 50 Gram • Treats Wounds",
		 	Price = 70m,
		 	DiscountPercentage = 13.58m,
		 	Rating = 4.87,
		 	Stock = 47,
		 	Brand = "Dry Rose",
		 	Category = "groceries",
		 	ImageUrl = "https://dummyjson.com/image/i/products/25/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 26,
		 	Title = "Plant Hanger For Home",
		 	Description = "Boho Decor Plant Hanger For Home Wall Decoration Macrame Wall Hanging Shelf",
		 	Price = 41m,
		 	DiscountPercentage = 17.86m,
		 	Rating = 4.08,
		 	Stock = 131,
		 	Brand = "Boho Decor",
		 	Category = "home-decoration",
		 	ImageUrl = "https://dummyjson.com/image/i/products/26/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 27,
		 	Title = "Flying Wooden Bird",
		 	Description = "Package Include 6 Birds with Adhesive Tape Shape: 3D Shaped Wooden Birds Material: Wooden MDF, Laminated 3.5mm",
		 	Price = 51m,
		 	DiscountPercentage = 15.58m,
		 	Rating = 4.41,
		 	Stock = 17,
		 	Brand = "Flying Wooden",
		 	Category = "home-decoration",
		 	ImageUrl = "https://dummyjson.com/image/i/products/27/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 28,
		 	Title = "3D Embellishment Art Lamp",
		 	Description = "3D led lamp sticker Wall sticker 3d wall art light on/off button  cell operated (included)",
		 	Price = 20m,
		 	DiscountPercentage = 16.49m,
		 	Rating = 4.82,
		 	Stock = 54,
		 	Brand = "LED Lights",
		 	Category = "home-decoration",
		 	ImageUrl = "https://dummyjson.com/image/i/products/28/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 29,
		 	Title = "Handcraft Chinese style",
		 	Description = "Handcraft Chinese style art luxury palace hotel villa mansion home decor ceramic vase with brass fruit plate",
		 	Price = 60m,
		 	DiscountPercentage = 15.34m,
		 	Rating = 4.44,
		 	Stock = 7,
		 	Brand = "luxury palace",
		 	Category = "home-decoration",
		 	ImageUrl = "https://dummyjson.com/image/i/products/29/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 30,
		 	Title = "Key Holder",
		 	Description = "Attractive DesignMetallic materialFour key hooksReliable & DurablePremium Quality",
		 	Price = 30m,
		 	DiscountPercentage = 2.92m,
		 	Rating = 4.92,
		 	Stock = 54,
		 	Brand = "Golden",
		 	Category = "home-decoration",
		 	ImageUrl = "https://dummyjson.com/image/i/products/30/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow


		 },
		 new Product
		 {

		 	ProductId = 31,
		 	Title = "Mornadi Velvet Bed",
		 	Description = "Mornadi Velvet Bed Base with Headboard Slats Support Classic Style Bedroom Furniture Bed Set",
		 	Price = 40m,
		 	DiscountPercentage = 17m,
		 	Rating = 4.16,
		 	Stock = 140,
		 	Brand = "Furniture Bed Set",
		 	Category = "furniture",
		 	ImageUrl = "https://dummyjson.com/image/i/products/31/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 32,
		 	Title = "Sofa for Coffe Cafe",
		 	Description = "Ratttan Outdoor furniture Set Waterproof  Rattan Sofa for Coffe Cafe",
		 	Price = 50m,
		 	DiscountPercentage = 15.59m,
		 	Rating = 4.74,
		 	Stock = 30,
		 	Brand = "Ratttan Outdoor",
		 	Category = "furniture",
		 	ImageUrl = "https://dummyjson.com/image/i/products/32/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 33,
		 	Title = "3 Tier Corner Shelves",
		 	Description = "3 Tier Corner Shelves | 3 PCs Wall Mount Kitchen Shelf | Floating Bedroom Shelf",
		 	Price = 700m,
		 	DiscountPercentage = 17m,
		 	Rating = 4.31,
		 	Stock = 106,
		 	Brand = "Kitchen Shelf",
		 	Category = "furniture",
		 	ImageUrl = "https://dummyjson.com/image/i/products/33/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 34,
		 	Title = "Plastic Table",
		 	Description = "Very good quality plastic table for multi purpose now in reasonable price",
		 	Price = 50m,
		 	DiscountPercentage = 4m,
		 	Rating = 4.01,
		 	Stock = 136,
		 	Brand = "Multi Purpose",
		 	Category = "furniture",
		 	ImageUrl = "https://dummyjson.com/image/i/products/34/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 35,
		 	Title = "3 DOOR PORTABLE",
		 	Description = "Material: Stainless Steel and Fabric  Item Size: 110 cm x 45 cm x 175 cm Package Contents: 1 Storage Wardrobe",
		 	Price = 41m,
		 	DiscountPercentage = 7.98m,
		 	Rating = 4.06,
		 	Stock = 68,
		 	Brand = "AmnaMart",
		 	Category = "furniture",
		 	ImageUrl = "https://dummyjson.com/image/i/products/35/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 36,
		 	Title = "Sleeve Shirt Womens",
		 	Description = "Cotton SolProductid Color Professional Wear Sleeve Shirt Womens Work Blouses Wholesale Clothing Casual Plain Custom Top OEM Customized",
		 	Price = 90m,
		 	DiscountPercentage = 10.89m,
		 	Rating = 4.26,
		 	Stock = 39,
		 	Brand = "Professional Wear",
		 	Category = "tops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/36/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow

		 },
		 new Product
		 {

		 	ProductId = 37,
		 	Title = "ank Tops for Womens/Girls",
		 	Description = "PACK OF 3 CAMISOLES ,VERY COMFORTABLE SOFT COTTON STUFF, COMFORTABLE IN ALL FOUR SEASONS",
		 	Price = 50m,
		 	DiscountPercentage = 12.05m,
		 	Rating = 4.52,
		 	Stock = 107,
		 	Brand = "Soft Cotton",
		 	Category = "tops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/37/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 38,
		 	Title = "sublimation plain kProductids tank",
		 	Description = "sublimation plain kProductids tank tops wholesale",
		 	Price = 100m,
		 	DiscountPercentage = 11.12m,
		 	Rating = 4.8,
		 	Stock = 20,
		 	Brand = "Soft Cotton",
		 	Category = "tops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/38/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 39,
		 	Title = "Women Sweaters Wool",
		 	Description = "2021 Custom Winter Fall Zebra Knit Crop Top Women Sweaters Wool Mohair Cos Customize Crew Neck Women' S Crop Top Sweater",
		 	Price = 600m,
		 	DiscountPercentage = 17.2m,
		 	Rating = 4.55,
		 	Stock = 55,
		 	Brand = "Top Sweater",
		 	Category = "tops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/39/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 40,
		 	Title = "women winter clothes",
		 	Description = "women winter clothes thick fleece hoodie top with sweat pantjogger women sweatsuit set joggers pants two piece pants set",
		 	Price = 57m,
		 	DiscountPercentage = 13.39m,
		 	Rating = 4.91,
		 	Stock = 84,
		 	Brand = "Top Sweater",
		 	Category = "tops",
		 	ImageUrl = "https://dummyjson.com/image/i/products/40/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 41,
		 	Title = "NIGHT SUIT",
		 	Description = "NIGHT SUIT RED MICKY MOUSE..  For Girls. Fantastic Suits.",
		 	Price = 55m,
		 	DiscountPercentage = 15.05m,
		 	Rating = 4.65,
		 	Stock = 21,
		 	Brand = "RED MICKY MOUSE..",
		 	Category = "womens-dresses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/41/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 42,
		 	Title = "Stiched Kurta plus trouser",
		 	Description = "FABRIC: LILEIN CHEST: 21 LENGHT: 37 TROUSER: (38) :ARABIC LILEIN",
		 	Price = 80m,
		 	DiscountPercentage = 15.37m,
		 	Rating = 4.05,
		 	Stock = 148,
		 	Brand = "Digital Printed",
		 	Category = "womens-dresses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/42/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 43,
		 	Title = "frock gold printed",
		 	Description = "Ghazi fabric long frock gold printed ready to wear stitched collection (G992)",
		 	Price = 600m,
		 	DiscountPercentage = 15.55m,
		 	Rating = 4.31,
		 	Stock = 150,
		 	Brand = "Ghazi Fabric",
		 	Category = "womens-dresses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/43/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 44,
		 	Title = "Ladies Multicolored Dress",
		 	Description = "This classy shirt for women gives you a gorgeous look on everyday wear and specially for semi-casual wears.",
		 	Price = 79m,
		 	DiscountPercentage = 16.88m,
		 	Rating = 4.03,
		 	Stock = 2,
		 	Brand = "Ghazi Fabric",
		 	Category = "womens-dresses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/44/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 45,
		 	Title = "Malai Maxi Dress",
		 	Description = "Ready to wear, Unique design according to modern standard fashion, Best fitting ,Imported stuff",
		 	Price = 50m,
		 	DiscountPercentage = 5.07m,
		 	Rating = 4.67,
		 	Stock = 96,
		 	Brand = "IELGY",
		 	Category = "womens-dresses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/45/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 46,
		 	Title = "women's shoes",
		 	Description = "Close: Lace, Style with bottom: Increased insProductide, Sole Material: Rubber",
		 	Price = 40m,
		 	DiscountPercentage = 16.96m,
		 	Rating = 4.14,
		 	Stock = 72,
		 	Brand = "IELGY fashion",
		 	Category = "womens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/46/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow

		 },
		 new Product
		 {

		 	ProductId = 47,
		 	Title = "Sneaker shoes",
		 	Description = "Synthetic Leather Casual Sneaker shoes for Women/girls Sneakers For Women",
		 	Price = 120m,
		 	DiscountPercentage = 10.37m,
		 	Rating = 4.19,
		 	Stock = 50,
		 	Brand = "Synthetic Leather",
		 	Category = "womens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/47/thumbnail.jpeg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 48,
		 	Title = "Women Strip Heel",
		 	Description = "Features: Flip-flops, MProductid Heel, Comfortable, Striped Heel, AntiskProductid, Striped",
		 	Price = 40m,
		 	DiscountPercentage = 10.83m,
		 	Rating = 4.02,
		 	Stock = 25,
		 	Brand = "Sandals Flip Flops",
		 	Category = "womens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/48/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 49,
		 	Title = "Chappals & Shoe Ladies Metallic",
		 	Description = "Womens Chappals & Shoe Ladies Metallic Tong Thong Sandal Flat Summer 2020 Maasai Sandals",
		 	Price = 23m,
		 	DiscountPercentage = 2.62m,
		 	Rating = 4.72,
		 	Stock = 107,
		 	Brand = "Maasai Sandals",
		 	Category = "womens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/49/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 50,
		 	Title = "Women Shoes",
		 	Description = "2020 New Arrivals Genuine Leather Fashion Trend Platform Summer Women Shoes",
		 	Price = 36m,
		 	DiscountPercentage = 16.87m,
		 	Rating = 4.33,
		 	Stock = 46,
		 	Brand = "Arrivals Genuine",
		 	Category = "womens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/50/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 51,
		 	Title = "half sleeves T shirts",
		 	Description = "Many store is creating new designs and trend every month and every year. Daraz.pk have a beautiful range of men fashion brands",
		 	Price = 23m,
		 	DiscountPercentage = 12.76m,
		 	Rating = 4.26,
		 	Stock = 132,
		 	Brand = "Vintage Apparel",
		 	Category = "mens-shirts",
		 	ImageUrl = "https://dummyjson.com/image/i/products/51/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 52,
		 	Title = "FREE FIRE T Shirt",
		 	Description = "quality and professional print - It doesn't just look high quality, it is high quality.",
		 	Price = 10m,
		 	DiscountPercentage = 14.72m,
		 	Rating = 4.52,
		 	Stock = 128,
		 	Brand = "FREE FIRE",
		 	Category = "mens-shirts",
		 	ImageUrl = "https://dummyjson.com/image/i/products/52/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 53,
		 	Title = "printed high quality T shirts",
		 	Description = "Brand: vintage Apparel ,Export quality",
		 	Price = 35m,
		 	DiscountPercentage = 7.54m,
		 	Rating = 4.89,
		 	Stock = 6,
		 	Brand = "Vintage Apparel",
		 	Category = "mens-shirts",
		 	ImageUrl = "https://dummyjson.com/image/i/products/53/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow

		 },
		 new Product
		 {

		 	ProductId = 54,
		 	Title = "Pubg Printed Graphic T-Shirt",
		 	Description = "Product Description Features: 100% Ultra soft Polyester Jersey. Vibrant & colorful printing on front. Feels soft as cotton without ever cracking",
		 	Price = 46m,
		 	DiscountPercentage = 16.44m,
		 	Rating = 4.62,
		 	Stock = 136,
		 	Brand = "The Warehouse",
		 	Category = "mens-shirts",
		 	ImageUrl = "https://dummyjson.com/image/i/products/54/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 55,
		 	Title = "Money Heist Printed Summer T Shirts",
		 	Description = "Fabric Jercy, Size: M & L Wear Stylish Dual Stiched",
		 	Price = 66m,
		 	DiscountPercentage = 15.97m,
		 	Rating = 4.9,
		 	Stock = 122,
		 	Brand = "The Warehouse",
		 	Category = "mens-shirts",
		 	ImageUrl = "https://dummyjson.com/image/i/products/55/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 56,
		 	Title = "Sneakers Joggers Shoes",
		 	Description = "Gender: Men , Colors: Same as DisplayedCondition: 100% Brand New",
		 	Price = 40m,
		 	DiscountPercentage = 12.57m,
		 	Rating = 4.38,
		 	Stock = 6,
		 	Brand = "Sneakers",
		 	Category = "mens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/56/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 57,
		 	Title = "Loafers for men",
		 	Description = "Men Shoes - Loafers for men - Rubber Shoes - Nylon Shoes - Shoes for men - Moccassion - Pure Nylon (Rubber) Expot Quality.",
		 	Price = 47m,
		 	DiscountPercentage = 10.91m,
		 	Rating = 4.91,
		 	Stock = 20,
		 	Brand = "Rubber",
		 	Category = "mens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/57/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 58,
		 	Title = "formal offices shoes",
		 	Description = "Pattern Type: SolProductid, Material: PU, Toe Shape: Pointed Toe ,Outsole Material: Rubber",
		 	Price = 57m,
		 	DiscountPercentage = 12m,
		 	Rating = 4.41,
		 	Stock = 68,
		 	Brand = "The Warehouse",
		 	Category = "mens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/58/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 59,
		 	Title = "Spring and summershoes",
		 	Description = "Comfortable stretch cloth, lightweight body; ,rubber sole, anti-skProductid wear;",
		 	Price = 20m,
		 	DiscountPercentage = 8.71m,
		 	Rating = 4.33,
		 	Stock = 137,
		 	Brand = "Sneakers",
		 	Category = "mens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/59/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 60,
		 	Title = "Stylish Casual Jeans Shoes",
		 	Description = "High Quality ,Stylish design ,Comfortable wear ,FAshion ,Durable",
		 	Price = 58m,
		 	DiscountPercentage = 7.55m,
		 	Rating = 4.55,
		 	Stock = 129,
		 	Brand = "Sneakers",
		 	Category = "mens-shoes",
		 	ImageUrl = "https://dummyjson.com/image/i/products/60/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 61,
		 	Title = "Leather Straps Wristwatch",
		 	Description = "Style:Sport ,Clasp:Buckles ,Water Resistance Depth:3Bar",
		 	Price = 120m,
		 	DiscountPercentage = 7.14m,
		 	Rating = 4.63,
		 	Stock = 91,
		 	Brand = "Naviforce",
		 	Category = "mens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/61/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 62,
		 	Title = "Waterproof Leather Brand Watch",
		 	Description = "Watch Crown With Environmental IPS Bronze Electroplating; Display system of 12 hours",
		 	Price = 46m,
		 	DiscountPercentage = 3.15m,
		 	Rating = 4.05,
		 	Stock = 95,
		 	Brand = "SKMEI 9117",
		 	Category = "mens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/62/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 63,
		 	Title = "Royal Blue Premium Watch",
		 	Description = "Men Silver Chain Royal Blue Premium Watch Latest Analog Watch",
		 	Price = 50m,
		 	DiscountPercentage = 2.56m,
		 	Rating = 4.89,
		 	Stock = 142,
		 	Brand = "SKMEI 9117",
		 	Category = "mens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/63/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 64,
		 	Title = "Leather Strap Skeleton Watch",
		 	Description = "Leather Strap Skeleton Watch for Men - Stylish and Latest Design",
		 	Price = 46m,
		 	DiscountPercentage = 10.2m,
		 	Rating = 4.98,
		 	Stock = 61,
		 	Brand = "Strap Skeleton",
		 	Category = "mens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/64/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 65,
		 	Title = "Stainless Steel Wrist Watch",
		 	Description = "Stylish Watch For Man (Luxury) Classy Men's Stainless Steel Wrist Watch - Box Packed",
		 	Price = 47m,
		 	DiscountPercentage = 17.79m,
		 	Rating = 4.79,
		 	Stock = 94,
		 	Brand = "Stainless",
		 	Category = "mens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/65/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 66,
		 	Title = "Steel Analog Couple Watches",
		 	Description = "Elegant design, Stylish ,Unique & Trendy,Comfortable wear",
		 	Price = 35m,
		 	DiscountPercentage = 3.23m,
		 	Rating = 4.79,
		 	Stock = 24,
		 	Brand = "Eastern Watches",
		 	Category = "womens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/66/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 67,
		 	Title = "Fashion Magnetic Wrist Watch",
		 	Description = "Buy this awesome  The product is originally manufactured by the company and it's a top selling product with a very reasonable",
		 	Price = 60m,
		 	DiscountPercentage = 16.69m,
		 	Rating = 4.03,
		 	Stock = 46,
		 	Brand = "Eastern Watches",
		 	Category = "womens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/67/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 68,
		 	Title = "Stylish Luxury Digital Watch",
		 	Description = "Stylish Luxury Digital Watch For Girls / Women - Led Smart Ladies Watches For Girls",
		 	Price = 57m,
		 	DiscountPercentage = 9.03m,
		 	Rating = 4.55,
		 	Stock = 77,
		 	Brand = "Luxury Digital",
		 	Category = "womens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/68/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 69,
		 	Title = "Golden Watch Pearls Bracelet Watch",
		 	Description = "Product details of Golden Watch Pearls Bracelet Watch For Girls - Golden Chain Ladies Bracelate Watch for Women",
		 	Price = 47m,
		 	DiscountPercentage = 17.55m,
		 	Rating = 4.77,
		 	Stock = 89,
		 	Brand = "Watch Pearls",
		 	Category = "womens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/69/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 70,
		 	Title = "Stainless Steel Women",
		 	Description = "Fashion Skmei 1830 Shell Dial Stainless Steel Women Wrist Watch Lady Bracelet Watch Quartz Watches Ladies",
		 	Price = 35m,
		 	DiscountPercentage = 8.98m,
		 	Rating = 4.08,
		 	Stock = 111,
		 	Brand = "Bracelet",
		 	Category = "womens-watches",
		 	ImageUrl = "https://dummyjson.com/image/i/products/70/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 71,
		 	Title = "Women Shoulder Bags",
		 	Description = "LouisWill Women Shoulder Bags Long Clutches Cross Body Bags Phone Bags PU Leather Hand Bags Large Capacity Card Holders Zipper Coin Purses Fashion Crossbody Bags for Girls Ladies",
		 	Price = 46m,
		 	DiscountPercentage = 14.65m,
		 	Rating = 4.71,
		 	Stock = 17,
		 	Brand = "LouisWill",
		 	Category = "womens-bags",
		 	ImageUrl = "https://dummyjson.com/image/i/products/71/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 72,
		 	Title = "Handbag For Girls",
		 	Description = "This fashion is designed to add a charming effect to your casual outfit. This Bag is made of synthetic leather.",
		 	Price = 23m,
		 	DiscountPercentage = 17.5m,
		 	Rating = 4.91,
		 	Stock = 27,
		 	Brand = "LouisWill",
		 	Category = "womens-bags",
		 	ImageUrl = "https://dummyjson.com/image/i/products/72/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 73,
		 	Title = "Fancy hand clutch",
		 	Description = "This fashion is designed to add a charming effect to your casual outfit. This Bag is made of synthetic leather.",
		 	Price = 44m,
		 	DiscountPercentage = 10.39m,
		 	Rating = 4.18,
		 	Stock = 101,
		 	Brand = "Bracelet",
		 	Category = "womens-bags",
		 	ImageUrl = "https://dummyjson.com/image/i/products/73/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 74,
		 	Title = "Leather Hand Bag",
		 	Description = "It features an attractive design that makes it a must have accessory in your collection. We sell different kind of bags for boys, kProductids, women, girls and also for unisex.",
		 	Price = 57m,
		 	DiscountPercentage = 11.19m,
		 	Rating = 4.01,
		 	Stock = 43,
		 	Brand = "Copenhagen Luxe",
		 	Category = "womens-bags",
		 	ImageUrl = "https://dummyjson.com/image/i/products/74/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 75,
		 	Title = "Seven Pocket Women Bag",
		 	Description = "Seven Pocket Women Bag Handbags Lady Shoulder Crossbody Bag Female Purse Seven Pocket Bag",
		 	Price = 68m,
		 	DiscountPercentage = 14.87m,
		 	Rating = 4.93,
		 	Stock = 13,
		 	Brand = "Steal Frame",
		 	Category = "womens-bags",
		 	ImageUrl = "https://dummyjson.com/image/i/products/75/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 76,
		 	Title = "Silver Ring Set Women",
		 	Description = "Jewelry Type:RingsCertificate Type:NonePlating:Silver PlatedShapeattern:noneStyle:CLASSICReligious",
		 	Price = 70m,
		 	DiscountPercentage = 13.57m,
		 	Rating = 4.61,
		 	Stock = 51,
		 	Brand = "Darojay",
		 	Category = "womens-jewellery",
		 	ImageUrl = "https://dummyjson.com/image/i/products/76/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 77,
		 	Title = "Rose Ring",
		 	Description = "Brand: The Greetings Flower Colour: RedRing Colour: GoldenSize: Adjustable",
		 	Price = 100m,
		 	DiscountPercentage = 3.22m,
		 	Rating = 4.21,
		 	Stock = 149,
		 	Brand = "Copenhagen Luxe",
		 	Category = "womens-jewellery",
		 	ImageUrl = "https://dummyjson.com/image/i/products/77/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 78,
		 	Title = "Rhinestone Korean Style Open Rings",
		 	Description = "Fashion Jewellery 3Pcs Adjustable Pearl Rhinestone Korean Style Open Rings For Women",
		 	Price = 30m,
		 	DiscountPercentage = 8.02m,
		 	Rating = 4.69,
		 	Stock = 9,
		 	Brand = "Fashion Jewellery",
		 	Category = "womens-jewellery",
		 	ImageUrl = "https://dummyjson.com/image/i/products/78/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 79,
		 	Title = "Elegant Female Pearl Earrings",
		 	Description = "Elegant Female Pearl Earrings Set Zircon Pearl Earings Women Party Accessories 9 Pairs/Set",
		 	Price = 30m,
		 	DiscountPercentage = 12.8m,
		 	Rating = 4.74,
		 	Stock = 16,
		 	Brand = "Fashion Jewellery",
		 	Category = "womens-jewellery",
		 	ImageUrl = "https://dummyjson.com/image/i/products/79/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 80,
		 	Title = "Chain Pin Tassel Earrings",
		 	Description = "Pair Of Ear Cuff Butterfly Long Chain Pin Tassel Earrings - Silver ( Long Life Quality Product)",
		 	Price = 45m,
		 	DiscountPercentage = 17.75m,
		 	Rating = 4.59,
		 	Stock = 9,
		 	Brand = "Cuff Butterfly",
		 	Category = "womens-jewellery",
		 	ImageUrl = "https://dummyjson.com/image/i/products/80/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 81,
		 	Title = "Round Silver Frame Sun Glasses",
		 	Description = "A pair of sunglasses can protect your eyes from being hurt. For car driving, vacation travel, outdoor activities, social gatherings,",
		 	Price = 19m,
		 	DiscountPercentage = 10.1m,
		 	Rating = 4.94,
		 	Stock = 78,
		 	Brand = "Designer Sun Glasses",
		 	Category = "sunglasses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/81/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 82,
		 	Title = "Kabir Singh Square Sunglass",
		 	Description = "Orignal Metal Kabir Singh design 2020 Sunglasses Men Brand Designer Sun Glasses Kabir Singh Square Sunglass",
		 	Price = 50m,
		 	DiscountPercentage = 15.6m,
		 	Rating = 4.62,
		 	Stock = 78,
		 	Brand = "Designer Sun Glasses",
		 	Category = "sunglasses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/82/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 83,
		 	Title = "Wiley X Night Vision Yellow Glasses",
		 	Description = "Wiley X Night Vision Yellow Glasses for RProductiders - Night Vision Anti Fog Driving Glasses - Free Night Glass Cover - Shield Eyes From Dust and Virus- For Night Sport Matches",
		 	Price = 30m,
		 	DiscountPercentage = 6.33m,
		 	Rating = 4.97,
		 	Stock = 115,
		 	Brand = "mastar watch",
		 	Category = "sunglasses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/83/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 84,
		 	Title = "Square Sunglasses",
		 	Description = "Fashion Oversized Square Sunglasses Retro Gradient Big Frame Sunglasses For Women One Piece Gafas Shade Mirror Clear Lens 17059",
		 	Price = 28m,
		 	DiscountPercentage = 13.89m,
		 	Rating = 4.64,
		 	Stock = 64,
		 	Brand = "mastar watch",
		 	Category = "sunglasses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/84/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 85,
		 	Title = "LouisWill Men Sunglasses",
		 	Description = "LouisWill Men Sunglasses Polarized Sunglasses UV400 Sunglasses Day Night Dual Use Safety Driving Night Vision Eyewear AL-MG Frame Sun Glasses with Free Box for Drivers",
		 	Price = 50m,
		 	DiscountPercentage = 11.27m,
		 	Rating = 4.98,
		 	Stock = 92,
		 	Brand = "LouisWill",
		 	Category = "sunglasses",
		 	ImageUrl = "https://dummyjson.com/image/i/products/85/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 86,
		 	Title = "Bluetooth Aux",
		 	Description = "Bluetooth Aux Bluetooth Car Aux Car Bluetooth Transmitter Aux Audio Receiver Handfree Car Bluetooth Music Receiver Universal 3.5mm Streaming A2DP Wireless Auto AUX Audio Adapter With Mic For Phone MP3",
		 	Price = 25m,
		 	DiscountPercentage = 10.56m,
		 	Rating = 4.57,
		 	Stock = 22,
		 	Brand = "Car Aux",
		 	Category = "automotive",
		 	ImageUrl = "https://dummyjson.com/image/i/products/86/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 87,
		 	Title = "t Temperature Controller Incubator Controller",
		 	Description = "Both Heat and Cool Purpose, Temperature control range; -50 to +110, Temperature measurement accuracy; 0.1, Control accuracy; 0.1",
		 	Price = 40m,
		 	DiscountPercentage = 11.3m,
		 	Rating = 4.54,
		 	Stock = 37,
		 	Brand = "W1209 DC12V",
		 	Category = "automotive",
		 	ImageUrl = "https://dummyjson.com/image/i/products/87/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 88,
		 	Title = "TC Reusable Silicone Magic Washing Gloves",
		 	Description = "TC Reusable Silicone Magic Washing Gloves with Scrubber, Cleaning Brush Scrubber Gloves Heat Resistant Pair for Cleaning of Kitchen, Dishes, Vegetables and Fruits, Bathroom, Car Wash, Pet Care and Multipurpose",
		 	Price = 29m,
		 	DiscountPercentage = 3.19m,
		 	Rating = 4.98,
		 	Stock = 42,
		 	Brand = "TC Reusable",
		 	Category = "automotive",
		 	ImageUrl = "https://dummyjson.com/image/i/products/88/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 89,
		 	Title = "Qualcomm original Car Charger",
		 	Description = "best Quality CHarger , Highly Recommended to all best Quality CHarger , Highly Recommended to all",
		 	Price = 40m,
		 	DiscountPercentage = 17.53m,
		 	Rating = 4.2,
		 	Stock = 79,
		 	Brand = "TC Reusable",
		 	Category = "automotive",
		 	ImageUrl = "https://dummyjson.com/image/i/products/89/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 90,
		 	Title = "Cycle Bike Glow",
		 	Description = "Universal fitment and easy to install no special wires, can be easily installed and removed. Fits most standard tyre air stem valves of road, mountain bicycles, motocycles and cars.Bright led will turn on w",
		 	Price = 35m,
		 	DiscountPercentage = 11.08m,
		 	Rating = 4.1,
		 	Stock = 63,
		 	Brand = "Neon LED Light",
		 	Category = "automotive",
		 	ImageUrl = "https://dummyjson.com/image/i/products/90/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 91,
		 	Title = "Black Motorbike",
		 	Description = "Engine Type:Wet sump, Single Cylinder, Four Stroke, Two Valves, Air Cooled with SOHC (Single Over Head Cam) Chain Drive Bore & Stroke:47.0 x 49.5 MM",
		 	Price = 569m,
		 	DiscountPercentage = 13.63m,
		 	Rating = 4.04,
		 	Stock = 115,
		 	Brand = "METRO 70cc Motorcycle - MR70",
		 	Category = "motorcycle",
		 	ImageUrl = "https://dummyjson.com/image/i/products/91/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 92,
		 	Title = "HOT SALE IN EUROPE electric racing motorcycle",
		 	Description = "HOT SALE IN EUROPE electric racing motorcycle electric motorcycle for sale adult electric motorcycles",
		 	Price = 920m,
		 	DiscountPercentage = 14.4m,
		 	Rating = 4.19,
		 	Stock = 22,
		 	Brand = "BRAVE BULL",
		 	Category = "motorcycle",
		 	ImageUrl = "https://dummyjson.com/image/i/products/92/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 93,
		 	Title = "Automatic Motor Gas Motorcycles",
		 	Description = "150cc 4-Stroke Motorcycle Automatic Motor Gas Motorcycles Scooter motorcycles 150cc scooter",
		 	Price = 1050m,
		 	DiscountPercentage = 3.34m,
		 	Rating = 4.84,
		 	Stock = 127,
		 	Brand = "shock absorber",
		 	Category = "motorcycle",
		 	ImageUrl = "https://dummyjson.com/image/i/products/93/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 94,
		 	Title = "new arrivals Fashion motocross goggles",
		 	Description = "new arrivals Fashion motocross goggles motorcycle motocross racing motorcycle",
		 	Price = 900m,
		 	DiscountPercentage = 3.85m,
		 	Rating = 4.06,
		 	Stock = 109,
		 	Brand = "JIEPOLLY",
		 	Category = "motorcycle",
		 	ImageUrl = "https://dummyjson.com/image/i/products/94/thumbnail.webp",
			 DateCreated = DateTimeOffset.UtcNow

		 },
		 new Product
		 {

		 	ProductId = 95,
		 	Title = "Wholesale cargo lashing Belt",
		 	Description = "Wholesale cargo lashing Belt Tie Down end Ratchet strap customized strap 25mm motorcycle 1500kgs with rubber handle",
		 	Price = 930m,
		 	DiscountPercentage = 17.67m,
		 	Rating = 4.21,
		 	Stock = 144,
		 	Brand = "Xiangle",
		 	Category = "motorcycle",
		 	ImageUrl = "https://dummyjson.com/image/i/products/95/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 96,
		 	Title = "lighting ceiling kitchen",
		 	Description = "Wholesale slim hanging decorative kProductid room lighting ceiling kitchen chandeliers pendant light modern",
		 	Price = 30m,
		 	DiscountPercentage = 14.89m,
		 	Rating = 4.83,
		 	Stock = 96,
		 	Brand = "lightingbrilliance",
		 	Category = "lighting",
		 	ImageUrl = "https://dummyjson.com/image/i/products/96/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 97,
		 	Title = "Metal Ceramic Flower",
		 	Description = "Metal Ceramic Flower Chandelier Home Lighting American Vintage Hanging Lighting Pendant Lamp",
		 	Price = 35m,
		 	DiscountPercentage = 10.94m,
		 	Rating = 4.93,
		 	Stock = 146,
		 	Brand = "Ifei Home",
		 	Category = "lighting",
		 	ImageUrl = "https://dummyjson.com/image/i/products/97/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow
		 },
		 new Product
		 {

		 	ProductId = 98,
		 	Title = "3 lights lndenpant kitchen islang",
		 	Description = "3 lights lndenpant kitchen islang dining room pendant rice paper chandelier contemporary led pendant light modern chandelier",
		 	Price = 34m,
		 	DiscountPercentage = 5.92m,
		 	Rating = 4.99,
		 	Stock = 44,
		 	Brand = "DADAWU",
		 	Category = "lighting",
		 	ImageUrl = "https://dummyjson.com/image/i/products/98/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 99,
		 	Title = "American Vintage Wood Pendant Light",
		 	Description = "American Vintage Wood Pendant Light Farmhouse Antique Hanging Lamp Lampara Colgante",
		 	Price = 46m,
		 	DiscountPercentage = 8.84m,
		 	Rating = 4.32,
		 	Stock = 138,
		 	Brand = "Ifei Home",
		 	Category = "lighting",
		 	ImageUrl = "https://dummyjson.com/image/i/products/99/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 },
		 new Product
		 {

		 	ProductId = 100,
		 	Title = "Crystal chandelier maria theresa for 12 light",
		 	Description = "Crystal chandelier maria theresa for 12 light",
		 	Price = 47m,
		 	DiscountPercentage = 16m,
		 	Rating = 4.74,
		 	Stock = 133,
		 	Brand = "YIOSI",
		 	Category = "lighting",
		 	ImageUrl = "https://dummyjson.com/image/i/products/100/thumbnail.jpg",
			 DateCreated = DateTimeOffset.UtcNow



		 }
		);
    }
}