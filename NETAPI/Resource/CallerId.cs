using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class CallerId : DMCResource
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public bool? IsApproved { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public CallerId(NameValueCollection data) {
            Id = GetDataString(data, "id");
            Name = GetDataString(data, "name");
            Phone = GetDataString(data, "phone");
            IsApproved = GetData<bool>(data, "approved");
            CreatedAt = GetData<DateTime>(data, "created_at");
            UpdatedAt = GetData<DateTime>(data, "updated_at");
        }
    }
}
