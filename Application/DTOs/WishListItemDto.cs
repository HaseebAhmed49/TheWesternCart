using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class WishListItemDto
    {
        public Guid Id { get; set; }
        public string ClothingItemName { get; set; }
        public Guid ClothingItemId { get; set; }
        public string PictureUrl { get; set; }
    }
}