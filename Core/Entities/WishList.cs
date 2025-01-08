using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class WishList : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public ICollection<WishListItem> Items { get; set; }
    }
}