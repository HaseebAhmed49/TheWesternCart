using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class WishListItem : BaseEntity
    {
        public Guid WishListId { get; set; }
        public WishList WishList { get; set; }
        public Guid ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }
    }
}