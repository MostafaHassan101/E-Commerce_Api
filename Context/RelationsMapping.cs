﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public static class RelationsMapping
    {
        public static void MapRelations(this ModelBuilder modelBuilder)
        {
            /// Product Relations
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category);
            
            modelBuilder.Entity<Product>()
				.HasOne(p => p.Brand);

            modelBuilder.Entity<Product>()
				.HasMany(p => p.ProductColors)
				.WithOne(pc => pc.Product)
                .HasForeignKey(a => a.ProductId)
				.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(i => i.Product)
                .HasForeignKey( p => p.ProductId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductReview)
                .WithOne(r => r.Product)
                .OnDelete(DeleteBehavior.Cascade);
            /// Product Images
            //modelBuilder.Entity<ProductImage>()
            //    .HasOne(i => i.Product)
            //    .WithMany(p => p.ProductImages);

            /// Category Relations
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.ProductCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Brands)
            //    .WithMany(b => b.Categories);
              

            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(c => c.ParentCategory)
                //.HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            /// Brand Relations
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
				.OnDelete(DeleteBehavior.Cascade);


    //        modelBuilder.Entity<Category>()
    //            .HasMany(c => c.Brands)
				//.WithMany(b => b.Categories);

            /// Order Relations
            modelBuilder.Entity<Order>()
				.HasOne(o => o.User);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

            /// OrderItem Relations
            modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Product);
            modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Order);

            /// ProductColor Relations
            modelBuilder.Entity<ProductColor>()
                .HasOne(a => a.Product)
                .WithMany(b => b.ProductColors)
				.OnDelete(DeleteBehavior.NoAction);

            /// WhishList Relations
            modelBuilder.Entity<WishList>()
                .HasOne(w => w.User);


            modelBuilder.Entity<WishList>()
				.HasMany(w => w.Products)
				.WithOne(p => p.WishList)
				.HasForeignKey(p => p.WishListId)
				.OnDelete(DeleteBehavior.NoAction);

			/// ProductReview Relations
             modelBuilder.Entity<ProductReview>()
                .HasOne(r => r.User);
             modelBuilder.Entity<ProductReview>()
                .HasOne(r => r.Product);

            /// User Relations
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
				.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
				.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.WishList)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
