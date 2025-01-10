using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FavouriteItemDto
    {
        public string UserDtoId { get; set; }
        public UserDto UserDto { get; set; }
        public Guid ClothingItemDtoId { get; set; }
        public ClothingItemDto ClothingItemDto { get; set; }
    }
}