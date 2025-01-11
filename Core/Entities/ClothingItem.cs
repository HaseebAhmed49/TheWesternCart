using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities.Enums;

namespace Core.Entities
{
    public class ClothingItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Gender Gender { get; set; }
        public Size Size { get; set; }
        public Category Category { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<FavouriteItem> FavouriteItems { get; set; }
        public decimal? Discount { get; set; }
        public bool IsInStock { get; set; }
        public Guid ClothingBrandId { get; set; }
        public ClothingBrand ClothingBrand { get; set; }

        public ICollection<ClothingItemPhoto?> ClothingItemPhotos { get; set; } = new List<ClothingItemPhoto?>();    
    }
}