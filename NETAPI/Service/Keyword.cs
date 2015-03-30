using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Keyword : Base
    {
        public Keyword(Client client)
            : base(client) {
        }

        public Resource.Keyword Get(string id) {
            try {
                return Client.Request<Resource.Keyword>("GET", @"keyword/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Keyword Delete(string id) {
            try {
                return Client.Request<Resource.Keyword>("DELETE", @"keyword/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
