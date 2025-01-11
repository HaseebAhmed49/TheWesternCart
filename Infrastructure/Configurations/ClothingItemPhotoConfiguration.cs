using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ClothingItemPhotoConfiguration : IEntityTypeConfiguration<ClothingItemPhoto>
    {
        public void Configure(EntityTypeBuilder<ClothingItemPhoto> builder)
        {
            builder.HasOne(x => x.ClothingItem).WithMany(x => x.ClothingItemPhotos)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}