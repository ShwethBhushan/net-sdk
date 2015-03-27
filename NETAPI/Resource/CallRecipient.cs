using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class CallRecipient : Recipient
    {
        public string Extension { get; private set; }
        public int? Duration { get; private set; }
        public IEnumerable<object> AddOn { get; private set; } // TODO: Check type
        public int? Attempts { get; private set; }
        public DateTime? CalledAt { get; private set; }

        public CallRecipient(NameValueCollection data) : base(data) {
            Extension = GetDataString(data, "extension");
            Duration = GetData<int>(data, "duration");
            AddOn = null; // TODO : check the type and make appropriate call
            Attempts = GetData<int>(data, "attempts");
            CalledAt = GetData<DateTime>(data, "called_at");
        }
    }
}
