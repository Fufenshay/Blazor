using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Description)
                .HasMaxLength(500);

            entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.CreatedAt)
                .HasDefaultValueSql("NOW()");

            entity.Property(p => p.UpdatedAt)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAddOrUpdate();

            entity.Property(p => p.ImageUrl)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Ноутбук",
                Description = "Мощный ноутбук",
                Price = 999.99m,
                StockQuantity = 10
            },
            new Product
            {
                Id = 2,
                Name = "Смартфон",
                Description = "Флагманский смартфон",
                Price = 799.99m,
                StockQuantity = 15
            }
        );
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Product &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var product = (Product)entry.Entity;
            product.UpdatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                product.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}