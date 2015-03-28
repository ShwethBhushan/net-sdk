using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class Recipient : DMCResource
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Status { get; private set; }
        public bool? Successful { get; private set; }

        public Recipient(IDictionary<string, object> data) {
            FirstName = GetDataString(data, "firstname");
            LastName = GetDataString(data, "lastname");
            Email = GetDataString(data, "email");
            Phone = GetDataString(data, "phone");
            Status = GetDataString(data, "status");
            Successful = GetData<bool>(data, "successful");
        }

    }
}
