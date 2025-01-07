using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}