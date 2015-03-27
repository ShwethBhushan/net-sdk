using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class VanityNumber : DMCResource
    {
        public string Id { get; private set; }
        public string Phone { get; private set; }
        public string Status { get; private set; }
        public float? MinutesUsed { get; private set; }
        public float? MinutesAllowed { get; private set; }
        public int? VoicemailsNew { get; private set; }
        public int? VoicemailsOld { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public VanityNumber(NameValueCollection data) {
            Id = GetDataString(data, "id");
            Phone = GetDataString(data, "phone");
            Status = GetDataString(data, "status");
            MinutesUsed = GetData<float>(data, "minutes_used");
            MinutesAllowed = GetData<float>(data, "minutes_allowed");
            VoicemailsNew = GetData<int>(data, "voicemails_new");
            VoicemailsOld = GetData<int>(data, "voicemails_old");
            CreatedAt = GetData<DateTime>(data, "created_at");
            UpdatedAt = GetData<DateTime>(data, "updated_at");
        }

    }
}
