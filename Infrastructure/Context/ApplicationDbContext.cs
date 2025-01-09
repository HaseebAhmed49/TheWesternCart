using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Configurations;
using Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, AppRole, string,
    IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FavouriteItem> FavoriteItems { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<LikeDislike> LikesDislikes { get; set; }
        public DbSet<DelieveryMethod> DeliveryMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderItemHistory> OrderItemHistories { get; set; }
        public DbSet<WishList> Wishlists { get; set; }
        public DbSet<WishListItem> WishlistItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ClothingItemConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
            modelBuilder.ApplyConfiguration(new LikeDislikeConfiguration());
            modelBuilder.ApplyConfiguration(new DelieveryMethodConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new WishListConfiguration());
            modelBuilder.ApplyConfiguration(new WishListItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemHistoryConfiguration());

            // SeedDataInitializer.ContextSeed(modelBuilder);
        }
            
    }
}