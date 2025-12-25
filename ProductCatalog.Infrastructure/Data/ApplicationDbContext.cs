using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;

namespace ProductCatalog.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.Property(e => e.Price)
                .HasPrecision(18, 2);

            entity.Property(e => e.StockQuantity)
                .IsRequired();

            entity.Property(e => e.Rating)
                .IsRequired()
                .HasDefaultValue(0);

            entity.Property(e => e.ImageUrl)
                .IsRequired();

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.CreatedAt)
                .IsRequired();

            // Indexes for search performance
            entity.HasIndex(e => e.Name);
            entity.HasIndex(e => e.Category);
            entity.HasIndex(e => e.Price);
            
            // Composite index for combined Category + Price filtering (common in e-commerce)
            entity.HasIndex(e => new { e.Category, e.Price });
            
            // Composite index for Category + Rating (for "best rated in category" queries)
            entity.HasIndex(e => new { e.Category, e.Rating });

            entity.HasData(GenerateSeedProducts());
        });
    }

    private static Product[] GenerateSeedProducts()
    {
        var products = new List<Product>();
        var random = new Random(42); // Fixed seed for consistency
        var categories = new[] { "Electronics", "Clothing", "Books", "Home", "Sports", "Toys", "Food", "Beauty" };
        var adjectives = new[] { "Premium", "Classic", "Modern", "Vintage", "Deluxe", "Essential", "Pro", "Smart" };
        var baseCreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        for (int i = 1; i <= 100; i++)
        {
            var category = categories[random.Next(categories.Length)];
            var adjective = adjectives[random.Next(adjectives.Length)];

            products.Add(new Product
            {
                Id = i,
                Name = $"{adjective} {category} Product {i}",
                Description = $"High-quality {category.ToLower()} product with excellent features. Perfect for everyday use and special occasions.",
                Price = Math.Round((decimal)(random.NextDouble() * 900 + 10), 2), // $10 - $910
                StockQuantity = random.Next(0, 500),
                ImageUrl = $"https://via.placeholder.com/300x300?text=Product+{i}",
                Rating = random.Next(1, 6), // 1-5 stars
                Category = category,
                CreatedAt = baseCreatedDate.AddDays(random.Next(0, 365)),
                UpdatedAt = null
            });
        }

        return products.ToArray();
    }
}

