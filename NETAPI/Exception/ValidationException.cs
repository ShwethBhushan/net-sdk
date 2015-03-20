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
        public ValidationException()
            : base((int)(HttpStatusCode.BadRequest), "Validation Exception") {
        }
    }
}
