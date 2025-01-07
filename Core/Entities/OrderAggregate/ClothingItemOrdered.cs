using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class ClothingItemOrdered
    {
        public ClothingItemOrdered()
        {
        }
        public ClothingItemOrdered(Guid clothingItemId, string clothingItemName, string pictureUrl)
        {
            ClothingItemId = clothingItemId;
            ClothingItemName = clothingItemName;
            PictureUrl = pictureUrl;
        }
        public Guid ClothingItemId { get; set; }
        public string ClothingItemName { get; set; }
        public string PictureUrl { get; set; }
    }
}