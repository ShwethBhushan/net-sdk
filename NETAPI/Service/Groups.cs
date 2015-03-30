using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Groups : Base
    {
        public Groups(Client client)
            : base(client) {
        }

        public IEnumerable<Resource.Group> Get(Pagination pagination) {
            try {
                return Client.RequestList<Resource.Group>("GET", "groups", null, pagination);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
