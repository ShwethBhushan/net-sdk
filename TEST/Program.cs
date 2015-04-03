using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialMyCalls;

namespace TEST
{
    class Program
    {
        static void Main(string[] args) {
            var client = new Client(Config.APIKey);
            Account.Run(client);
            CallerId.Run(client);
            Recording.Run(client);
            Keyword.Run(client);
            Contact.Run(client);
            Group.Run(client);
            VanityNumber.Run(client);
            Call.Run(client);
            Text.Run(client);
            Console.ReadKey();
        }
    }
}
