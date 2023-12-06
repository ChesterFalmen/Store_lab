using Microsoft.EntityFrameworkCore;
using Store.Data.Models;

namespace Store.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Смартфони" },
                new Category { Id = 2, Name = "Ноутбуки" },
                new Category { Id = 3, Name = "Стаціонарні ПК" },
                new Category { Id = 4, Name = "Годинники" }
                );

            modelBuilder.Entity<Producer>().HasData(
                new Producer { Id = 1, Name = "Apple", Country = "USA" },
                new Producer { Id = 2, Name = "HP", Country = "USA" },
                new Producer { Id = 3, Name = "Samsung", Country = "Korea" },
                new Producer { Id = 4, Name = "Xiaomi", Country = "China" },
                new Producer { Id = 5, Name = "DELL", Country = "USA" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, ProducerId = 1, Name = "iPhone", Model = "X", Count = 2, Price = 600 },
                new Product { Id = 2, CategoryId = 1, ProducerId = 1, Name = "iPhone", Model = "15", Count = 5, Price = 1300 },
                new Product { Id = 3, CategoryId = 2, ProducerId = 2, Name = "ElitBook", Model = null, Count = 2, Price = 2100 },
                new Product { Id = 4, CategoryId = 3, ProducerId = 5, Name = "OPTIPLEX", Model = "PLUS", Count = 7, Price = 1100 },
                new Product { Id = 5, CategoryId = 4, ProducerId = 1, Name = "Apple Watch", Model = "5 series", Count = 10, Price = 600 }
                );

            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<Product>()
               .HasOne(x => x.Producer)
               .WithMany(x => x.Products)
               .HasForeignKey("ProducerId")
               .IsRequired();

            modelBuilder
              .Entity<Product>()
              .HasOne(x => x.Category)
              .WithMany(x => x.Products)
              .HasForeignKey("CategoryId")
              .IsRequired();
        }
    }
}
