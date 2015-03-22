using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class CallRecipient : DMCResource
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Extension { get; private set; }
        public string Status { get; private set; }
        public int? Duration { get; private set; }
        public IEnumerable<object> AddOn { get; private set; } // TODO: Check type
        public int? Attempts { get; private set; }
        public bool? Successful { get; private set; }
        public DateTime? CalledAt { get; private set; }

        public CallRecipient(NameValueCollection data) {
            FirstName = GetDataString(data, "firstname");
            LastName = GetDataString(data, "lastname");
            Email = GetDataString(data, "email");
            Phone = GetDataString(data, "phone");
            Extension = GetDataString(data, "extension");
            Status = GetDataString(data, "status");
            Duration = GetData<int>(data, "duration");
            AddOn = null; // TODO : check the type and make appropriate call
            Attempts = GetData<int>(data, "attempts");
            Successful = GetData<bool>(data, "successful");
            CalledAt = GetData<DateTime>(data, "called_at");
        }
    }
}
