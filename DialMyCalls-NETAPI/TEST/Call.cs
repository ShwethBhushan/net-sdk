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
            svc.Create("Test Call", callerIdId, recordingId, DateTime.Now.AddMonths(1), false, false, false, new List<string>() { "5555555555" }, new Dictionary<string, string>()); 

        }
    }
}
