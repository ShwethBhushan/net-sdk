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
        protected static Nullable<T> GetData<T>(IDictionary<string, object> data, string key) where T: struct {
            if (data[key] != null) {
                try {
                    return (T)Convert.ChangeType(data[key].ToString(), typeof(T));
                }
                catch {
                }
            }
            return null;
        }

        protected static T GetDataObj<T>(IDictionary<string, object> data, string key) where T: class {
            return data[key] as T;
        }

        protected static string GetDataString(IDictionary<string, object> data, string key) {
            if (!string.IsNullOrEmpty(data[key].ToString())) {
                return data[key].ToString();
            }
            else {
                return null;
            }
        }

        protected static Nullable<bool> GetDataBool(IDictionary<string, object> data, string key) {
            string strVal = data[key].ToString();
            if (!string.IsNullOrEmpty(strVal)) {
                if (FindWordsIn(strVal, WordsTRUE)) {
                    return true;
                }
                else if (FindWordsIn(strVal, WordsFALSE)) {
                    return false;
                }
            }
            return null;
        }

        private static bool FindWordsIn(string val, string[] words) {
            return (words.FirstOrDefault(f => f == val.ToLower()) != null);
        }

        protected static string[] WordsTRUE = { "1", "true", "on", "yes" };
        protected static string[] WordsFALSE = { "0", "false", "off", "no" };
    }
}
