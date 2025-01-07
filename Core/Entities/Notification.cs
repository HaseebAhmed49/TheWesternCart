using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class Notification: BaseEntity
    {
        public string Text { get; set; }
        public bool IsRead { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }       
    }
}