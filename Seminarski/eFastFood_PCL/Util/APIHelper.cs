using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_UI.Util
{
    class APIHelper
    {
        private HttpClient client { get; set; }
        private string route { get; set; }

        public APIHelper(string uri, string route)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
            this.route = route;
        }

        public HttpResponseMessage GetResponse(string parameter = "")
        {
            return client.GetAsync(route + "/" + parameter).Result;
        }

        public HttpResponseMessage GetActionResponse(string action, string parameter = "")
        {
            return client.GetAsync(route + "/" + action + "/" + parameter).Result;
        }
        public HttpResponseMessage PostResponse(Object newObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(newObject),
                Encoding.UTF8, "application/json");
            return client.PostAsync(route, jsonObject).Result;
        }

        public HttpResponseMessage PostActionResponse(string action, Object newObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(newObject),
                Encoding.UTF8, "application/json");
            return client.PostAsync(route + "/" + action, jsonObject).Result;
        }

        public HttpResponseMessage PutResponse(int id, Object existingObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(existingObject),
                Encoding.UTF8, "application/json");
            return client.PostAsync(route + "/" + id, jsonObject).Result;
        }

        public HttpResponseMessage PutActionResponse(string action, int id, Object existingObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(existingObject),
               Encoding.UTF8, "application/json");
            return client.PostAsync(route + "/" + action + "/" + id, jsonObject).Result;
        }
    }
}
