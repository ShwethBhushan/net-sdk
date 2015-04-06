using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    public static class Contact
    {
        public static bool Run(Client client) {
            var svc = new DialMyCalls.Service.Contact(client);
            var svc2 = new DialMyCalls.Service.Contacts(client);
            TestStorage.Contacts = new List<DialMyCalls.Resource.ContactInfo>();
            bool toAdd = true;
            var contacts = svc2.Get(null);
            if (contacts != null) {
                Console.WriteLine("Ok. Enumerating contacts...");
                foreach (var contact1 in contacts) {
                    Console.WriteLine("Contact: First name: {0}  Last name: {1}  Phone: {2}  Email: {3}", contact1.FirstName, contact1.LastName, contact1.Phone, contact1.Email);
                    TestStorage.Contacts.Add(new DialMyCalls.Resource.ContactInfo() {
                        phone = contact1.Phone,
                        firstname = contact1.FirstName,
                        lastname = contact1.LastName,
                        email = contact1.Email
                    });
                    if (contact1.Phone.Contains("4445555555")) {
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
                Console.WriteLine("Adding contact...");
                TestStorage.Contacts.Add(new DialMyCalls.Resource.ContactInfo() {
                    phone = "4445555555",
                    firstname = "John",
                    lastname = "Doe",
                    email = "john.doe@mail.com"
                });
                var contact = svc.Add("John", "Doe", "4445555555", "", "john.doe@mail.com", "", TestStorage.Groups);
                if (contact == null) {
                    Console.WriteLine("Error. Exception message: " + svc.Exception.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
