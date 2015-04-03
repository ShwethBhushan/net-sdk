using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public static class Call
    {
        public static bool Run() {
            Console.WriteLine("Generating call..");
            Client client = new Client(Config.APIKey);
            var svc = new DialMyCalls.Service.Call(client);
            var call = svc.Create("Test Call", TestStorage.CallerIdId, TestStorage.RecordingId, DateTime.Now.AddMonths(1), false, false, false, new List<string>() { "5555555555" }, new Dictionary<string, string>());
            if (call != null) {
                Console.WriteLine("Ok. Checking... ");
                var svc2 = new DialMyCalls.Service.Calls(client);
                var calls = svc2.Get(null);
                if (calls != null) {
                    foreach (var call1 in calls) {
                        Console.WriteLine("CALL: " + call1.Id);
                        if (call1.Id == call.Id) {
                            Console.WriteLine("Delete...");
                            svc.Cancel(call.Id);
                            Console.WriteLine("Ok");
                        }
                    }
                    return true;
                }
                else {
                    Console.WriteLine("Error. Exception message: " + svc.Exception.Message);
                    return false;
                }
            }
            else {
                Console.WriteLine("Error. Exception message: " + svc.Exception.Message);
                return false;
            }

        }
    }
}
