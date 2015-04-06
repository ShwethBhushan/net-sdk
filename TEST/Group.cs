using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public class Group
    {
        public static bool Run(Client client) {
            var svc = new DialMyCalls.Service.Group(client);
            var svc2 = new DialMyCalls.Service.Groups(client);
            TestStorage.Groups = new List<string>();
            bool toAdd = true;
            var Groups = svc2.Get(null);
            if (Groups != null) {
                Console.WriteLine("Ok. Enumerating groups...");
                foreach (var Group1 in Groups) {
                    Console.WriteLine("Group: {0}", Group1.Name);
                    TestStorage.Groups.Add(Group1.Id);
                    if (Group1.Name.Contains("MyGroup")) {
                        toAdd = false;
                    }
                }
                Console.WriteLine("----");
            }
            else {
                Console.WriteLine("Error. Exception message: " + svc2.Exception.Message);
                return false;
            }
            if (toAdd) {
                Console.WriteLine("Adding Group...");
                var Group = svc.Add("MyGroup");
                if (Group == null) {
                    Console.WriteLine("Error. Exception message: " + svc.Exception.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
