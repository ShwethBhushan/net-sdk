using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Keywords : Base
    {
        public Keywords(Client client)
            : base(client) {
        }

        public IEnumerable<Resource.Keyword> Get() {
            try {
                return Client.RequestList<Resource.Keyword>("GET", "keywords");
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
