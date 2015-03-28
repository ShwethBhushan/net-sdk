using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class TextRecipient : Recipient
    {
        public TextRecipient(IDictionary<string, object> data) : base(data) { } 
    }
}
