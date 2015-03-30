using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class VanityNumber
    {
        public class VanityNumber : Base
        {
            public VanityNumber(Client client)
                : base(client) {
            }

            public Resource.VanityNumber Get(string id) {
                try {
                    return Client.Request<Resource.VanityNumber>("GET", @"vanitynumber/" + id);
                }
                catch (HttpException e) {
                    Exception = e;
                }
                return null;
            }

            public Resource.VanityNumber Delete(string id) {
                try {
                    return Client.Request<Resource.VanityNumber>("DELETE", @"vanitynumber/" + id);
                }
                catch (HttpException e) {
                    Exception = e;
                }
                return null;
            }
        }
    }
}
