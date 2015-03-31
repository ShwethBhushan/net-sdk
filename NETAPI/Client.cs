using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using DialMyCalls.Resource;
using Newtonsoft.Json.Linq;

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
       
        /*
         * @throws \Exception
         *
         * @param string     $method     HTTP method [GET / POST / PUT / DELETE].
         * @param string     $endpoint   API endpoint.
         * @param array      $data       The request body.
         * @param Pagination $pagination Set pagination values.
         *
         * @return boolean|array
         */
        public T Request<T>(string method, string endpoint, IDictionary<string, object> data = null, Pagination pagination = null) where T: class
        {
            var request = WebRequest.CreateHttp(ApiUrl + endpoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            byte[] encodedByte = System.Text.ASCIIEncoding.ASCII.GetBytes(ApiKey + ":");
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(encodedByte));
            if (pagination != null) {
                request.Headers.Add("Range", string.Format("records={0}-{1}", pagination.Start, pagination.End));
            }
            if (data != null) {
                string sb = JsonConvert.SerializeObject(data);
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
                    RequestResult jsonResult = JsonConvert.DeserializeObject(strsb, typeof(RequestResult)) as RequestResult;
                    var resData = DeserializeToDictionary(jsonResult.results.ToString());
                    return (T)Activator.CreateInstance(typeof(T), new object[] { resData });
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

        public IEnumerable<T> RequestList<T>(string method, string endpoint, IDictionary<string, object> data = null, Pagination pagination = null) where T : DMCResource {
            var requestResult = Request<IEnumerable<object>>(method, endpoint, data, pagination); // TODO: remake serialization
            var result = new List<T> ();
            if (requestResult != null) {
                foreach (var o in requestResult) {
                    var typedO = (T)Activator.CreateInstance(typeof(T), new object[] { o as IDictionary<string, object> });
                    result.Add(typedO);
                }
            }
            return result;
        }

        private Dictionary<string, object> DeserializeToDictionary(string jo) {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
            var values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values) {
                if (d.Value is JObject) {
                    values2.Add(d.Key, DeserializeToDictionary(d.Value.ToString()));
                }
                else {
                    values2.Add(d.Key, d.Value);
                }
            }
            return values2;
        }

        private const string API_URL = @"https://{0}@api.dialmycalls.com/2.0/";
        private string IntApiKey;

        private class RequestResult
        {
            public object results;
        }
    }
}
