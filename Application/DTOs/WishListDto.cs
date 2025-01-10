using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class WishListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<WishListItemDto> Items { get; set; }
    }
}