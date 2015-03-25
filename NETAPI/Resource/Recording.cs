using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class Recording : DMCResource
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int? Seconds { get; private set; }
        public string Url { get; private set; }
        public bool? Processed { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Recording(NameValueCollection data) {
            Id = GetDataString(data, "id");
            Name = GetDataString(data, "name");
            Type = GetDataString(data, "type");
            Seconds = GetData<int>(data, "seconds");
            Url = GetDataString(data, "url");
            Processed = false; // TODO: processing filter var
            CreatedAt = GetData<DateTime>(data, "created_at");
            UpdatedAt = GetData<DateTime>(data, "updated_at");
        }
    }
}
