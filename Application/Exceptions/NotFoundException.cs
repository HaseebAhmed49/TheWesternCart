using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message)
            : base(message, null, HttpStatusCode.NotFound)
        {
        }
        
    }
}