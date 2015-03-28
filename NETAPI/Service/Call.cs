using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Call : Base
    {
        public Call(Client client) : base(client) {} 

        public Resource.Service Create(string name, string callerIdId, string recordingId,
            DateTime sendAt, bool sendImmediately, bool useAmd, bool sendEmail, IEnumerable<string> contacts,
            IDictionary<string, string> addOns) {
                var data = new Dictionary<string, object>() {
                    { "name",  name },
                    { "callerid_id", callerIdId },
                    { "recording_id",  recordingId },
                    { "send_immediately", sendImmediately },
                    { "use_amd", useAmd },
                    { "send_email",  sendEmail },
                    { "contacts", contacts },
                    { "add_ons", addOns }
                };
                try {
                    return new Resource.Service(Client.Request<IDictionary<string, object>>("POST", "service/call", data));
                }
                catch (HttpException e) {
                    Exception = e;
                }
                return null;
        }
    }
}
