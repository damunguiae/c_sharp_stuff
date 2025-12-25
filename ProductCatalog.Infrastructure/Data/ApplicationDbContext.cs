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


            entity.Property(e => e.CreatedAt)
                .IsRequired();

            entity.HasIndex(e => e.Name);
        });
    }
}