using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Domain.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Dropshiping.BackEnd.DataAccess
{
    public class DropshipingDbContext : DbContext
    {
        public DropshipingDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("decimal(18,4)");

            // Subcategory
            modelBuilder.Entity<Subcategory>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Subcategory>()
                .Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            // Category
            modelBuilder.Entity<Category>()
                .Property (x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            // User
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .IsRequired();


            // Configure relationships 
            modelBuilder.Entity<Subcategory>()
                .HasMany(p => p.Products)
                .WithOne(s => s.Subcategory)
                .HasForeignKey(s => s.SubcategoryId);

            modelBuilder.Entity<Category>()
                        .HasMany(s => s.Subcategories)
                        .WithOne(c => c.Category)
                        .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Catalog>()
                .HasMany(c => c.Categories)
                .WithOne(cat => cat.Catalog)
                .HasForeignKey(cat => cat.CatalogId);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Products)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            //Seed Catalog
            //modelBuilder.Entity<Catalog>().HasData(
            //    new Catalog { Name = "Main Catalog" }
            //    );

            //Seed Categories
            //modelBuilder.Entity<Category>().HasData(
            //    new Category
            //    {
            //        Name = "technology",
            //        Description = "technology",
            //        CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //    },
            //    new Category
            //    {
            //        Name = "jewellery",
            //        Description = "jewellery",
            //        CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //    },
            //    new Category
            //    {
            //        Name = "menswear",
            //        Description = "menswear",
            //        CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //    },
            //    new Category
            //    {
            //        Name = "womenswear",
            //        Description = "womenswear",
            //        CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //    },
            //    new Category
            //    {
            //        Name = "books",
            //        Description = "books",
            //        CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //    },
            //     new Category
            //     {
            //         Name = "kidsaccessories",
            //         Description = "kidsaccessories",
            //         CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //     },
            //     new Category
            //     {
            //         Name = "beauty",
            //         Description = "beauty",
            //         CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //     },
            //     new Category
            //     {
            //         Name = "autoaccessories",
            //         Description = "Automobile Accessories",
            //         CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",
            //     },
            //     new Category
            //     {
            //         Name = "sports",
            //         Description = "sports",
            //         CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",

            //     },
            //     new Category
            //     {
            //         Name = "homeandgarden",
            //         Description = "homeandgarden",
            //         CatalogId = "e1115783 - 229b - 4a71 - ac1f - 3424e82dae0c",
            //     }
            //    );

            ////Seed Subcategories
            //modelBuilder.Entity<Subcategory>().HasData(
            //    new Subcategory
            //    {
            //        Name = "Personal Computers",
            //        Description = "Get PCs, the latest components, PC accesories and everything else related to PCs.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Smartphones",
            //        Description = "Discover the latest smartphones from top brands like Apple, Samsung, and more.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Office Electronics",
            //        Description = "Get office electronics like printers, scanners, and projectors to help you run your business.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Gaming Consoles & Accessories",
            //        Description = "Find the latest gaming consoles and accessories from top brands like Playstation, Xbox, and Nintendo.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "HandHeld entertainment",
            //        Description = "Tablets, and other stuff.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Audio & Video Equipment",
            //        Description = "Shop for speakers, headphones, TVs, projectors, and other audio & video equipment.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Wearable Technology",
            //        Description = "Explore the latest wearable tech devices like smartwatches, fitness trackers, and more.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Virtual Reality",
            //        Description = "Explore virtual reality technology and accessories to enhance your gaming and entertainment experiences.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Cameras & Photography",
            //        Description = "Shop for cameras, lenses, and other photography equipment for amateurs and professionals.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    },
            //    new Subcategory
            //    {
            //        Name = "Accessories & Parts",
            //        Description = "Find accessories and replacement parts for your electronics, including chargers, cables, and batteries.",
            //        CategoryId = "a472f899-c454-4b0b-8689-79d95b024c87"
            //    }
            //    );
        }
    }
}
