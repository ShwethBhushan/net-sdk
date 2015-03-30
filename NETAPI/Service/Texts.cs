using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Texts : Base
    {
        public Texts(Client client)
            : base(client) {
        }

        public IEnumerable<Resource.Service> Get(Pagination pagination) {
            try {
                return Client.RequestList<Resource.Service>("GET", "service/texts", null, pagination);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
