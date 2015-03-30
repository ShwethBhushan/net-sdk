using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Recordings : Base
    {
        public Recordings(Client client)
            : base(client) {
        }

        public IEnumerable<Resource.Recording> Get(Pagination pagination) {
            try {
                return Client.RequestList<Resource.Recording>("GET", "recordings", null, pagination);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
