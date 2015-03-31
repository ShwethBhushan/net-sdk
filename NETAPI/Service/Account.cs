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
                return Client.Request<Resource.Account>("GET", "account");
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
