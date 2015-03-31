using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class CallerId : Base
    {


        public CallerId(Client client)
            : base(client) {

        }

        public Resource.CallerId Add(string phone, string name, bool verify = true) {
            try {
                var data = new Dictionary<string, object>() {
                    { "phone", phone },
                    { "name", name }
                };
                var endpoint = verify ? "verify/callerid" : "callerid";
                return Client.Request<Resource.CallerId>("POST", endpoint, data);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;    
        }
    }
}
