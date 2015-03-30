using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Contacts : Base
    {
        public Contacts(Client client) : base(client) {}

        public IEnumerable<Resource.Contact> Get(string groupId, Pagination pagination = null) {
            var endpoint = "contacts";
            if (!string.IsNullOrEmpty(groupId)) {
                endpoint += "/" + groupId;
            }
            try {
                return Client.RequestList<Resource.Contact>("GET", endpoint, null, pagination);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
