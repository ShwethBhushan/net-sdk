using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public static class CallerId
    {
        public static bool Run() {
            var client = new DialMyCalls.Client(Config.APIKey);
            var svc = new DialMyCalls.Service.CallerId(client);
            Console.WriteLine("Creating CallerId...");
            svc.Add("444444444", "MyCallerId", true);
            var svc2 = new DialMyCalls.Service.CallerIds(client);
            Console.WriteLine("OK. Enumerating CallerId:");
            var callerIds = svc2.Get();
            if (callerIds != null) {
                foreach (var callerId in callerIds) {
                    Console.WriteLine("Caller Id ID:    " + callerId.Id);
                    Console.WriteLine("          Name:  " + callerId.Name);
                    Console.WriteLine("          Phone: " + callerId.Phone);
                    if (callerId.Name == "MyCallerId") {
                        TestStorage.CallerIdId = callerId.Id;
                    }
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
