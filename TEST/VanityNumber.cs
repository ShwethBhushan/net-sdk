using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public static class VanityNumber
    {
        public static bool Run(Client client) {
            var svc = new DialMyCalls.Service.VanityNumber(client);
            var svc2 = new DialMyCalls.Service.VanityNumbers(client);
            var VanityNumbers = svc2.Get();
            if (VanityNumbers != null) {
                Console.WriteLine("Ok. Enumerating Vanity Numbers...");
                foreach (var VanityNumber1 in VanityNumbers) {
                    Console.WriteLine("VanityNumber: {0}", VanityNumber1.Phone);
                    svc.Delete(VanityNumber1.Id);

                }
                Console.WriteLine("----");
                return true;
            }
            else {
                Console.WriteLine("Error. Exception message: " + svc2.Exception.Message);
                return false;
            }
        }
    }
}
