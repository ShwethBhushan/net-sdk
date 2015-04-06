using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    /// <summary>
    /// The class is used for parameters of CreateCall
    /// </summary>
    public class ContactInfo
    {
        public string phone { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }
}
