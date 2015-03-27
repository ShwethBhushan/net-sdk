using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialMyCalls
{
    public class Client
    {
        public Client(string apiKey) {
            ApiKey = apiKey;  
        }

        public string ApiKey {
            get {
                return IntApiKey;
            }
            set {
                IntApiKey = value;
                ApiUrl = string.Format(API_URL, IntApiKey);
            }
        }

        public string ApiUrl { get; private set; }

        private const string API_URL = @"https://{0}@api.dialmycalls.com/2.0/";

        private string IntApiKey;

    }
}
