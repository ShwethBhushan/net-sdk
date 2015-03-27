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
        public Resource.Service Create(string name, string callerId, string recordingId,
            DateTime sendAt, bool sendImmediately, bool useAmd, bool sendEmail, IEnumerable<string> contacts,
            IDictionary<string, string> addOns) {
                var data = new Dictionary<string, object>();
                data["name"] = name;
                data["callerid_id"] = callerId;
                data["recording_id"] = recordingId;
                data["send_immediately"] = sendImmediately;
                data["use_amd"] = useAmd;
                data["send_email"] = sendEmail;
                data["contacts"] = contacts;
                data["add_ons"] = addOns;
                try {
                    return new Resource.Service(Client.Request("POST", "service/call", data);
                }
                catch (HttpException e) {
                    Exception = e;
                }
                return null;
        }
    }
}
