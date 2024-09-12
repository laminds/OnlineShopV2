 using Microsoft.EntityFrameworkCore;
using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Infrastructure.Data
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Category> Category {  get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Discount> Discount { get; set; }

        public DbSet<ProductReviewList> ProductReview {  get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK_dbo.Users");
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.HasKey(e => e.SliderId).HasName("PK_dbo.Slider");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_dbo.Category");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK_dbo.Product");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK_dbo.Orders");
            });  
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId).HasName("PK_dbo.OrderItem");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.discountId).HasName("PK_dbo.Discount");
            });

            modelBuilder.Entity<ProductReviewList>(entity =>
            {
                entity.HasKey(e => e.ProductReviewId).HasName("PK_dbo.ProductReview");
            });
        }
    }
}
