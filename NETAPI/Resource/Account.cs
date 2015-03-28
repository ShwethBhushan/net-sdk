using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class Account : DMCResource
    {
        public decimal? CreditsAvailable { get; private set; }
        public DateTime? CreatedAt { get; private set; }

        public Account(IDictionary<string, object> data) {
            CreditsAvailable = GetData<decimal>(data, "credits_available");
            CreatedAt = GetData<DateTime>(data, "created_at");
        }

        
    }
}
