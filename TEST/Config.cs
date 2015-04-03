using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TEST
{
    public static class Config
    {
        public static string APIKey {
            get {
                var s = ConfigurationManager.AppSettings["APIKey"];
                return s != null ? s.ToString() : string.Empty;
            }
        }
    }
}
