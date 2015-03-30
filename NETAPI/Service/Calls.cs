using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls.Resource;

namespace DialMyCalls.Service
{
    public class Calls : Base
    {
        public Calls(Client client) : base(client) { }

        public IEnumerable<Resource.Service> Get(Pagination pagination) {
            try {
                return Client.RequestList<Resource.Service>("GET", @"service/calls", null, pagination);
            }
            catch (System.Web.HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
