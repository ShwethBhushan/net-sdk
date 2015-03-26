using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class Service : DMCResource
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool? IsPendingCancel { get; private set; }
        public float? CreditCost { get; private set; }
        public DateTime? SendAt { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Service(NameValueCollection data) {
            Id = GetDataString(data, "id");
            Name = GetDataString(data, "name");
            IsPendingCancel = GetDataBool(data, "pending_cancel");
            CreditCost = GetData<float>(data, "creadit_cost");
            SendAt = GetData<DateTime>(data, "send_at");
            CreatedAt = GetData<DateTime>(data, "created_at");
            UpdatedAt = GetData<DateTime>(data, "updated_at");
        }
    }
}
