using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class ClothingBrand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ClothingItem> ClothingItems { get; set; }
    }
}