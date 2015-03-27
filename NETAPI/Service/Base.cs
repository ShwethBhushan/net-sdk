using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Base
    {
        public Client Client { get; private set; }
        public HttpException Exception { get; protected set; }
        public Base(Client client) {
            Client = client;
        }
    }
}
