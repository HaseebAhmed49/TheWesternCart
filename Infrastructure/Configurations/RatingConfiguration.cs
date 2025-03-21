using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(rating => rating.User)
                .WithMany(user => user.Ratings)
                .HasForeignKey(rating => rating.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(rating => rating.ClothingItem)
                .WithMany(ci => ci.Ratings)
                .HasForeignKey(rating => rating.ClothingItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }        
    }
}