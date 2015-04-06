using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Text : Base
    {
        public Text(Client client)
            : base(client) {
        }

        public Resource.Service Create(string name, string keywordId, IEnumerable<string> messages, DateTime sendAt, bool sendImmediately, string sendEmail, IEnumerable<Resource.ContactInfo> contacts) {
            string sendAtStr = sendAt.ToString("o");
            var data = new Dictionary<string, object>() {
                { "name", name },
                { "keyword_id", keywordId },
                { "messages", messages },
                { "send_at", sendAtStr },
                { "send_immediately", sendImmediately },
                { "send_email", sendEmail },
                { "contacts", contacts }
            };
            try {
                return Client.Request<Resource.Service>("POST", "service/text", data);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Service Get(string id) {
            try {
                return Client.Request<Resource.Service>("GET", @"service/text/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }


        public Resource.Service Cancel(string id) {
            try {
                return Client.Request<Resource.Service>("DELETE", @"service/text/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public IEnumerable<Resource.CallRecipient> GetRecipients(string id, Pagination pagination = null) {
            try {
                return Client.RequestList<Resource.CallRecipient>("GET", @"service/text/" + id + @"/recipients", null, pagination);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
