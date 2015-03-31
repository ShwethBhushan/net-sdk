using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public static class Account
    {
        public static bool Run() {
            Console.WriteLine("Getting Account for key...");
            Client client = new Client(Config.APIKey);
            var svc = new DialMyCalls.Service.Account(client);
            var acc = svc.Get();
            if (acc != null) {
                Console.WriteLine("Ok. Creaits available: " + acc.CreditsAvailable + "  Credited at: " + acc.CreatedAt.ToString());
                return true;
            }
            else {
                Console.WriteLine("ERROR. Exception message: " + svc.Exception);
                return false;
            }
        }
    }
}
