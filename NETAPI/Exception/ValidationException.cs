using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace DialMyCalls.Exception
{
    public class ValidationException : HttpException
    {
        public ValidationException(string message)
            : base((int)(HttpStatusCode.BadRequest), message) {
        }
    }
}
