using Microsoft.EntityFrameworkCore;
using Njd.Bakery.Repository.EfModels;

namespace Njd.Bakery.Repository
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductClassification> ProductClassifications { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(t => new { t.ProductId, t.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.ProductIngredients)
                .HasForeignKey(pt => pt.IngredientId);

            modelBuilder.Entity<Product>(ep =>
            {
                ep.Property(p => p.TotalBatchCalories).HasColumnType("decimal(9, 4)");
                ep.Property(p => p.TotalBatchCarbs).HasColumnType("decimal(9, 4)");
                ep.Property(p => p.TotalBatchFat).HasColumnType("decimal(9, 4)");
                ep.Property(p => p.TotalBatchFiber).HasColumnType("decimal(9, 4)");
                ep.Property(p => p.TotalBatchProtein).HasColumnType("decimal(9, 4)");
                ep.Property(p => p.TotalBatchSugar).HasColumnType("decimal(9, 4)");
            });

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Snack Bars" },
                new ProductCategory { Id = 2, Name = "Cakes" },
                new ProductCategory { Id = 3, Name = "Breads" },
                new ProductCategory { Id = 4, Name = "Cookies" },
                new ProductCategory { Id = 5, Name = "Dessert Bars" },
                new ProductCategory { Id = 6, Name = "Misc" },
                new ProductCategory { Id = 7, Name = "Muffins" });

            modelBuilder.Entity<ProductClassification>().HasData(
                new ProductCategory { Id = 1, Name = "Simple Dessert" },
                new ProductCategory { Id = 2, Name = "Involved Dessert" },
                new ProductCategory { Id = 3, Name = "Snack" },
                new ProductCategory { Id = 4, Name = "Bread" });
        }
    }
}
