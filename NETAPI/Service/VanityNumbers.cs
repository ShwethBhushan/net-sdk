using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class VanityNumbers : Base
    {
        public VanityNumbers(Client client)
            : base(client) {
        }

        public IEnumerable<Resource.VanityNumber> Get() {
            try {
                return Client.RequestList<Resource.VanityNumber>("GET", "vanitynumbers");
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
