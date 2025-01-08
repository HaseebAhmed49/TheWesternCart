using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException(string message)
        : base(message, null, HttpStatusCode.Unauthorized)
        {
        }
    }
}