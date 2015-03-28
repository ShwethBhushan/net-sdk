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
                return Client.Request<IEnumerable<object>>("GET", "callerids").AsQueryable().Select(o => new Resource.CallerId(o as IDictionary<string, object>)); // TOOD: check Json transformation!
            }
            catch (HttpException e) {
                Exception = e;
            }
        }
    }
}
