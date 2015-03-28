using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class Contact : DMCResource
    {
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Extension { get; private set; }
        public string Extra1 { get; private set; }
        public IEnumerable<string> Groups { get; private set; }      
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Contact(IDictionary<string, object> data) {
            Id = GetDataString(data, "id");
            FirstName = GetDataString(data, "firstname");
            LastName = GetDataString(data, "lastname");
            Email = GetDataString(data, "email");
            Phone = GetDataString(data, "phone");
            Extension = GetDataString(data, "extension");
            Extra1 = GetDataString(data, "extra1");
            Groups = GetDataObj<IEnumerable<string>>(data, "groups");
            CreatedAt = GetData<DateTime>(data, "created_at");
            UpdatedAt = GetData<DateTime>(data, "updated_at");
        }
    }
}
