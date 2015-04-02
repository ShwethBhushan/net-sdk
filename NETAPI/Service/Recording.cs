using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DialMyCalls.Service
{
    public class Recording : Base
    {
        public Recording(Client client)
            : base(client) {
        }

        public Resource.Recording AddTts(string name, string gender, string language, string text) {
            try {
                return Client.Request<Resource.Recording>("POST", @"recording/tts", new Dictionary<string, object>() { 
                    {"name" , name},
                    {"gender", gender},
                    {"language",language},
                    {"text",text}
                });
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Recording AddUrl(string name, string url) {
            try {
                return Client.Request<Resource.Recording>("POST", @"recording/url", new Dictionary<string, object>() { 
                    {"name" , name},
                    {"url", url}
                });
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Recording Get(string id) {
            try {
                return Client.Request<Resource.Recording>("GET", @"recording/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Recording Update(string id, string name) {
            try {
                return Client.Request<Resource.Recording>("UPDATE", @"recording/" + id, new Dictionary<string, object>() { {"name" , name} });
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }

        public Resource.Recording Delete(string id) {
            try {
                return Client.Request<Resource.Recording>("DELETE", @"recording/" + id);
            }
            catch (HttpException e) {
                Exception = e;
            }
            return null;
        }
    }
}
