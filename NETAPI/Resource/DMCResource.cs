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

        protected static Nullable<bool> GetDataBool(NameValueCollection data, string key) {
            if (FindWordsIn(data[key], WordsTRUE)) {
                return true;
            }
            else if (FindWordsIn(data[key], WordsFALSE)) {
                return false;
            }
            else {
                return null;
            }
        }

        private static bool FindWordsIn(string val, string[] words) {
            return (words.FirstOrDefault(f => f == val.ToLower()) != null);
        }

        protected const string[] WordsTRUE = { "1", "true", "on", "yes" };
        protected const string[] WordsFALSE = { "0", "false", "off", "no" };
    }
}
