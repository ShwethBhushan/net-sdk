using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args) {
            bool result = Account.Run() && CallerId.Run() && Recording.Run() && Keywords.Run();
            Console.ReadKey();
        
        }
    }
}
