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
            Console.WriteLine("Adding Group...");
            var Group = svc.Add("MyGroup");
            if (Group != null) {
                TestStorage.Groups = new List<string>();
                TestStorage.Groups.Add(Group.Id);
                var svc2 = new DialMyCalls.Service.Groups(client);
                var Groups = svc2.Get(null);
                if (Groups != null) {
                    Console.WriteLine("Ok. Enumerating contracts...");
                    foreach (var Group1 in Groups) {
                        Console.WriteLine("Group: Name: {0}  Id: {1}", Group1.Name, Group1.Id);
                        if (Group1.Id != Group.Id) {
                            svc.Delete(Group1.Id);
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
