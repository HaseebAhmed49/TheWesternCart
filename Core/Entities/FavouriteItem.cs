using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class FavouriteItem: BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }        
    }
}