using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class Rating: BaseEntity
    {
        public int Score { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }

        public Guid ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }        
    }
}