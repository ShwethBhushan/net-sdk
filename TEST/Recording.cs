using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public static class Recording
    {
        public static bool Run() {
            var client = new DialMyCalls.Client(Config.APIKey);
            Console.WriteLine("Create recording");
            var svc = new DialMyCalls.Service.Recording(client);
            var rec = svc.AddTts("My Recording", "Male", "English", "Please keep your message");
            if (rec != null) {
                Console.WriteLine("Ok. Get recordings...");
                var svc2 = new DialMyCalls.Service.Recordings(client);
                var recs = svc2.Get();
                if (recs != null) {
                    foreach (var rec1 in recs) {
                        Console.WriteLine("Recording ID: " + rec1.Id);
                        Console.WriteLine("          Name: " + rec1.Name);
                        Console.WriteLine("          Processed: " + rec1.Processed);
                        Console.WriteLine("          Seconds: " + rec1.Seconds);
                        if (rec1.Name == "My Recording") {
                            TestStorage.RecordingId = rec1.Id;
                        }
                    }
                    Console.WriteLine("----");
                    return true;
                }
                else {
                    Console.WriteLine("Error. Exception message: " + svc2.Exception.Message);
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
