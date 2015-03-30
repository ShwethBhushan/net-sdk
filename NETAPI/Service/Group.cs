using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Group : Base
    {
        public Group(Client client)
            : base(client) {
        }

        public Resource.Group Add(string name) {
            try {
                var data = new Dictionary<string, object>() {
                    { "name", name }
                };
                return Client.Request<Resource.Group>("POST", "group", data);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Group Get(string id) {
            try {
                return Client.Request<Resource.Group>("GET", @"group/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Group Update(string id, string name) {
            try {
                var data = new Dictionary<string, object>() {
                    { "name", name }
                };
                return Client.Request<Resource.Group>("PUT", @"group/" + id, data);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Group Delete(string id) {
            try {
                return Client.Request<Resource.Group>("DELETE", @"group/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
