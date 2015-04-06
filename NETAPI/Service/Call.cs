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
            DateTime sendAt, bool sendImmediately, bool useAmd, bool sendEmail, IEnumerable<Resource.ContactInfo> contacts,
            IDictionary<string, string> addOns) {
                var data = new Dictionary<string, object>() {
                    { "name",  name },
                    { "callerid_id", callerIdId },
                    { "recording_id",  recordingId },
                    { "send_at", sendAt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ") },
                    { "send_immediately", sendImmediately },
                    { "use_amd", useAmd },
                    { "send_email",  sendEmail },
                    { "contacts", contacts },
                    { "add_ons", addOns }
                };
                try {
                    return Client.Request<Resource.Service>("POST", @"service/call", data);
                }
                catch (HttpException e) {
                    Exception = e;
                }
                return null;
        }

        public Resource.Service Get(string id) {
            try {
                return Client.Request<Resource.Service>("GET", @"service/call/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Service Cancel(string id) {
            try {
                return Client.Request<Resource.Service>("DELETE", @"service/call/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public IEnumerable<Resource.CallRecipient> GetRecipients(string id) {
            try {
                return Client.RequestList<Resource.CallRecipient>("GET", @"service/call/" + id + @"/recipients") ;
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
