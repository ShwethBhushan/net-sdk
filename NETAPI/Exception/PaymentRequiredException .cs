using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace DialMyCalls.Exception
{
    public class PaymentRequiredException : HttpException
    {
        public PaymentRequiredException()
            : base((int)(HttpStatusCode.PaymentRequired), "Payment Required Exception") {
        }
    }
}
