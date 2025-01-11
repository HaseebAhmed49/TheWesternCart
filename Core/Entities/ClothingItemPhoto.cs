using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class ClothingItemPhoto: BaseEntity
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        
        public Guid ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; } 
    }
}