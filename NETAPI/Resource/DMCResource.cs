using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls.Resource
{
    public class DMCResource
    {
        protected static Nullable<T> GetData<T>(NameValueCollection data, string key) where T: struct {
            if (data[key] != null) {
                try {
                    return (T)Convert.ChangeType(data[key].ToString(), typeof(T));
                }
                catch {
                }
            }
            return null;
        }

        protected static string GetDataString(NameValueCollection data, string key) {
            if (!string.IsNullOrEmpty(data[key].ToString())) {
                return data[key].ToString();
            }
            else {
                return null;
            }
        }

    }
}
