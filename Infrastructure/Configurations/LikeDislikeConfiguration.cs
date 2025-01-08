using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LikeDislikeConfiguration : IEntityTypeConfiguration<LikeDislike>
    {
        public void Configure(EntityTypeBuilder<LikeDislike> builder)
        {
            builder.HasOne(likeDislike => likeDislike.User)
                .WithMany(user => user.LikesDislikes)
                .HasForeignKey(likeDislike => likeDislike.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(likeDislike => likeDislike.Comment)
                .WithMany(c => c.LikesDislikes)
                .HasForeignKey(likeDislike => likeDislike.CommentId);
        }       
    }
}