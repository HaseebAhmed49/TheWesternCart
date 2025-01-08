using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<FavouriteItem>
    {
        public void Configure(EntityTypeBuilder<FavouriteItem> builder)
        {
            builder.HasOne(favorite => favorite.User)
                .WithMany(user => user.FavoriteItems)
                .HasForeignKey(favorite => favorite.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(favorite => favorite.ClothingItem)
                .WithMany(ci => ci.FavouriteItems)
                .HasForeignKey(favorite => favorite.ClothingItemId);
        }
            
    }
}