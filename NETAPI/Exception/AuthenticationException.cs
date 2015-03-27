using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

namespace DialMyCalls.Exception
{
    public class AuthenticationException : HttpException
    {
        public AuthenticationException()
            : base((int)(HttpStatusCode.Unauthorized), "Failed authentication") {
        }

    }
}
