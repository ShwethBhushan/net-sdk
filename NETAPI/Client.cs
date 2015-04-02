using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using DialMyCalls.Resource;
using System.Web.Script.Serialization;

namespace DialMyCalls
{
    public class Client
    {
        public string ApiUrl { get; private set; }

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
       
        public T Request<T>(string method, string endpoint, IDictionary<string, object> data = null, Pagination pagination = null) where T: DMCResource {
            var serzr = new JavaScriptSerializer();
            var resData = IntRequest(method, endpoint, data, pagination);
            var dict = serzr.Deserialize<RequestResultDict>(resData).results;
            return (T)Activator.CreateInstance(typeof(T), new object[] { dict });
        }

        public IEnumerable<T> RequestList<T>(string method, string endpoint, IDictionary<string, object> data = null, Pagination pagination = null) where T : DMCResource {
            var serzr = new JavaScriptSerializer();
            var resData = IntRequest(method, endpoint, data, pagination);
            var list = serzr.Deserialize<RequestResultList>(resData).results;
            var result = new List<T>();
            if (list != null) {
                foreach (var o in list) {
                    var typedO = (T)Activator.CreateInstance(typeof(T), new object[] { o as IDictionary<string, object> });
                    result.Add(typedO);
                }
            }
            return result;
        }

        private string IntRequest(string method, string endpoint, IDictionary<string, object> data = null, Pagination pagination = null) 
        {
            var request = WebRequest.CreateHttp(ApiUrl + endpoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            byte[] encodedByte = System.Text.ASCIIEncoding.ASCII.GetBytes(ApiKey + ":");
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(encodedByte));
            if (pagination != null) {
                request.Headers.Add("Range", string.Format("records={0}-{1}", pagination.Start, pagination.End));
            }
            var serializer = new JavaScriptSerializer();
            if (data != null) {
                string sb = serializer.Serialize(data);
                request.Method = method;
                Byte[] bt = Encoding.UTF8.GetBytes(sb);
                Stream st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();
            }
            try {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                    Stream stream1 = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream1);
                    string strsb = sr.ReadToEnd();
                    return strsb;
                }
            }
            catch (HttpException e) {
                switch (e.GetHttpCode()) {
                    case 400:
                        throw new Exception.ValidationException(e.Message);
                    case 401:
                        throw new Exception.AuthenticationException();
                    case 402:
                        throw new Exception.PaymentRequiredException();
                    case 404:
                        throw new Exception.NotFoundException();
                    case 500:
                        throw new Exception.ServerException();
                }
            }
            return null;
        }

        private const string API_URL = @"https://{0}@api.dialmycalls.com/2.0/";
        private string IntApiKey;

        private class RequestResultDict
        {
            public Dictionary<string, object> results;
        }

        private class RequestResultList
        {
            public List<Dictionary<string, object>> results;
        }
    
    
    }
}
