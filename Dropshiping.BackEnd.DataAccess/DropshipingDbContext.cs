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

        // Tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Orderitem> Orderitems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<Raiting> Raitings { get; set; }
        

        // OnModel
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

            modelBuilder.Entity<Order>()
                .Property(x => x.TotalPrice)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Product>()
                .Property(x => x.Discount)
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

            // Configure relations ........

            // For Image
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductImage)
                .WithOne()
                .HasForeignKey<Product>(p => p.ImageId);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.CategoryImage)
                .WithOne()
                .HasForeignKey<Category>(c => c.ImageId);

            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.SubcategoryImage)
                .WithOne()
                .HasForeignKey<Subcategory>(s => s.ImageId);

            // For nesting category,sub,product

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Subcategories)
                        .WithOne(s => s.Category)
                        .HasForeignKey(s => s.CategoryId); 

            modelBuilder.Entity<Subcategory>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Subcategory)
                .HasForeignKey(p => p.SubcategoryId);

            // For Produc/User business wise

            modelBuilder.Entity<Region>()
                .HasMany(p => p.Products)
                .WithOne(r => r.Region)
                .HasForeignKey(p => p.RegoinId);

            modelBuilder.Entity<Product>()
                .HasMany(ps => ps.ProductSizes)
                .WithOne(p => p.Product)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(ps => ps.SizeId);

            modelBuilder.Entity<Orderitem>()
                .HasOne(oi => oi.ProductSize)
                .WithMany(ps => ps.Orderitems)
                .HasForeignKey(oi => oi.ProductSizeId);

            modelBuilder.Entity<Order>()
                .HasMany(oi => oi.Orderitems)
                .WithOne(o => o.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<UserOrder>()
                .HasOne(uo => uo.Order)
                .WithMany(o => o.Userorders)
                .HasForeignKey(uo => uo.OrderId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserOrders)
                .WithOne(uo => uo.User)
                .HasForeignKey(uo => uo.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Raitings)
                .WithOne(ra => ra.User)
                .HasForeignKey(ra => ra.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Cards)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
