using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class CallerIds : Base
    {
        public CallerIds(Client client)
            : base(client) {
        }

        public IEnumerable<Resource.CallerId> Get() {
            try {
                return Client.RequestList<Resource.CallerId>("GET", "callerids");
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
