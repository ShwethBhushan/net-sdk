using DialMyCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class Keywords
    {
        public static bool Run() {
            Console.WriteLine("Getting Keywords...");
            Client client = new Client(Config.APIKey);
            var svc = new DialMyCalls.Service.Keywords(client);
            var kwds = svc.Get();
            if (kwds != null) {
                Console.WriteLine("Ok. Keywords:");
                foreach (var kw in kwds) {
                    Console.WriteLine("Word: " + kw.KeywordString + "  Id: " + kw.Id + "  Status: " + kw.Status + "  Created at: " + kw.CreatedAt + "   Updated at: " + kw.UpdatedAt);
                }
                Console.WriteLine("---");
                return true;
            }
            else {
                Console.WriteLine("ERROR. Exception message: " + svc.Exception);
                return false;
            }
        }
    }
}
