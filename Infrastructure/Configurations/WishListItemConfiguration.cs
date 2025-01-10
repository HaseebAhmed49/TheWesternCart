using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class WishListItemConfiguration : IEntityTypeConfiguration<WishListItem>
    {
        public void Configure(EntityTypeBuilder<WishListItem> builder)
        {
            builder
                .HasOne(wi => wi.ClothingItem)
                .WithMany()
                .HasForeignKey(wi => wi.ClothingItemId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(wi => wi.WishList)
                .WithMany(w => w.Items)
                .HasForeignKey(wi => wi.WishListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
