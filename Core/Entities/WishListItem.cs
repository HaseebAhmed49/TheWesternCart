using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class WishListItem : BaseEntity
    {
        public Guid WishlistId { get; set; }
        public WishList Wishlist { get; set; }
        public Guid ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }
    }
        
}