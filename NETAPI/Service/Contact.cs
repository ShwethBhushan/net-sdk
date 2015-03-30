using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Contact : Base
    {
        public Contact(Client client) : base(client) { }

        public Resource.Contact Add(string firstName, string lastName, string phone, string extension, string email, string extra1, IEnumerable<string> groups) {
            var data = new Dictionary<string, object>() {
                { "firstname", firstName },
                { "lastname", lastName },
                { "phone", phone },
                { "extension", extension },
                { "email", email },
                { "extra1", extra1 },
                { "groups", groups }
            };
            try {
                return Client.Request<Resource.Contact>("POST", "contact", data);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

    }
}
