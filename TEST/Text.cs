using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public static class Text
    {
        public static bool Run(Client client) {
            var svc = new DialMyCalls.Service.Text(client);
            if (TestStorage.Contacts == null || TestStorage.Contacts.Count < 1) {
                Console.WriteLine("Please add at least one Contact");
                return false;
            }
            if (string.IsNullOrEmpty(TestStorage.KeywordId)) {
                Console.WriteLine("Keyword Id should not be empty");
                return false;
            }
            Console.WriteLine("Text create...");
            var txt = svc.Create("MyText", TestStorage.KeywordId, new List<string>() { "this is my message" }, DateTime.Now.AddMonths(1), false, "", TestStorage.Contacts);
            if (txt != null) {
                Console.WriteLine("Ok. Check...");
                var svc2 = new DialMyCalls.Service.Texts(client);
                var texts = svc2.Get(null);
                if (texts != null) {
                    foreach (var txt1 in texts) {
                        Console.WriteLine("Text: ID: " + txt1.Id + "  Name: " + txt1.Name);
                        if (txt1.Id == txt.Id) {
                            svc.Cancel(txt.Id);
                        }
                    }
                    Console.WriteLine("----");
                    return true;
                }
                else {
                    Console.WriteLine("Error. Exception: " + svc2.Exception.Message);
                    return false;
                }
            }
            else {
                Console.WriteLine("Error. Exception: " + svc.Exception.Message);
                return false;
            }
        }
    }
}
