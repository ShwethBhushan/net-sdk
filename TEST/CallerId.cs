using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public static class CallerId
    {
        public static bool Run(Client client) {
            var svc = new DialMyCalls.Service.CallerId(client);
            Console.WriteLine("Creating CallerId...");
            var callerId = svc.Add("4444444444", "MyCallerId", true);
            TestStorage.CallerIdId = callerId.Id;
            var svc2 = new DialMyCalls.Service.CallerIds(client);
            Console.WriteLine("OK. Enumerating CallerId:");
            var callerIds = svc2.Get();
            if (callerIds != null) {
                foreach (var callerId1 in callerIds) {
                    Console.WriteLine("Caller Id ID:    " + callerId1.Id);
                    Console.WriteLine("          Name:  " + callerId1.Name);
                    Console.WriteLine("          Phone: " + callerId1.Phone);
                }
                Console.WriteLine("---");
                return true;
            }
            else {
                Console.WriteLine("Error. Exception Message: " + svc2.Exception.Message);
                return false;
            }
        }
    }
}
