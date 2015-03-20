using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

namespace DialMyCalls.Exception
{
    public class NotFoundException : HttpException
    {
        public NotFoundException()
            : base((int)(HttpStatusCode.NotFound), "Not Found Exception") {
        }
    }
}
