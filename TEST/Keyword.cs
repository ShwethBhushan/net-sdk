using DialMyCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public static class Keyword
    {
        public static bool Run(Client client) {
            Console.WriteLine("Getting Keywords...");
            var svc2 = new DialMyCalls.Service.Keywords(client);
            var kwds = svc2.Get();
            if (kwds != null) {
                Console.WriteLine("Ok. Keywords:");
                foreach (var kw1 in kwds) {
                    Console.WriteLine("Keyword string: " + kw1.KeywordString + "  Id: " + kw1.Id + "  Status: " + kw1.Status + "  Created at: " + kw1.CreatedAt + "   Updated at: " + kw1.UpdatedAt);
                }
                Console.WriteLine("---");
                return true;
            }
            else {
                Console.WriteLine("ERROR. Exception message: " + svc2.Exception);
                return false;
            }
        }
    }
}
