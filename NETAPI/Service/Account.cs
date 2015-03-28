using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Account : Base
    {
        public Account(Client client) : base(client) {} 

        public Resource.Account Get() {
            try {
                var response = Client.Request<IDictionary<string, object>>("GET", "account");
                return new Resource.Account(response);    
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
