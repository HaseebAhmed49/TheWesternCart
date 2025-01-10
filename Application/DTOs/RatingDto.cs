using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RatingDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid ClothingItemId { get; set; }

        [Range(1,5)]
        public int Score { get; set; }
    }
}