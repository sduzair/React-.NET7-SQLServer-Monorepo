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
                Title = "Apple",
                Description = "A delicious apple",
                Price = 1.99m,
                DiscountPercentage = 0.00m,
                Rating = 4.5,
                Stock = 10,
                Brand = "Apple",
                Category = "Fruit",
                ImageUrl = "https://images.unsplash.com/photo-1593642533141-8d4b8d1f0f0c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YXBwbGUlMjBjb2xvfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DateCreated = DateTimeOffset.UtcNow,
            },
            new Product
            {
                ProductId = 2,
                Title = "Banana",
                Description = "A delicious banana",
                Price = 0.99m,
                DiscountPercentage = 0.00m,
                Rating = 4.5,
                Stock = 10,
                Brand = "Banana",
                Category = "Fruit",
                ImageUrl = "https://images.unsplash.com/photo-1593642533141-8d4b8d1f0f0c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YXBwbGUlMjBjb2xvfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DateCreated = DateTimeOffset.UtcNow,
            },
            new Product
            {
                ProductId = 3,
                Title = "Orange",
                Description = "A delicious orange",
                Price = 1.99m,
                DiscountPercentage = 0.00m,
                Rating = 4.5,
                Stock = 10,
                Brand = "Orange",
                Category = "Fruit",
                ImageUrl = "https://images.unsplash.com/photo-1593642533141-8d4b8d1f0f0c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YXBwbGUlMjBjb2xvfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DateCreated = DateTimeOffset.UtcNow,
            },
            new Product
            {
                ProductId = 4,
                Title = "Strawberry",
                Description = "A delicious strawberry",
                Price = 1.99m,
                DiscountPercentage = 0.00m,
                Rating = 4.5,
                Stock = 10,
                Brand = "Strawberry",
                Category = "Fruit",
                ImageUrl = "https://images.unsplash.com/photo-1593642533141-8d4b8d1f0f0c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YXBwbGUlMjBjb2xvfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DateCreated = DateTimeOffset.UtcNow,
            },
            new Product
            {
                ProductId = 5,
                Title = "Pineapple",
                Description = "A delicious pineapple",
                Price = 1.99m,
                DiscountPercentage = 0.00m,
                Rating = 4.5,
                Stock = 10,
                Brand = "Pineapple",
                Category = "Fruit",
                ImageUrl = "https://images.unsplash.com/photo-1593642533141-8d4b8d1f0f0c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YXBwbGUlMjBjb2xvfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DateCreated = DateTimeOffset.UtcNow,
            }
        );
    }
}