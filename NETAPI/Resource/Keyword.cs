using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class Keyword : DMCResource  
    {
        public string Id { get; private set; }
        public string Keyword { get; private set; }
        public string Status { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Keyword(NameValueCollection data) {
            Id = GetDataString(data, "id");
            Keyword = GetDataString(data, "keyword");
            Status = GetDataString(data, "Status");
            CreatedAt = GetData<DateTime>(data, "created_at");
            UpdatedAt = GetData<DateTime>(data, "updated_at");
        }


    }
}
