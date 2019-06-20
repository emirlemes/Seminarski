using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Util
{
    public class APIHelper
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

        public async Task<HttpResponseMessage> GetResponse(string parameter = "")
        {
            return await client.GetAsync(route + "/" + parameter);
        }

        public async Task<HttpResponseMessage> GetActionResponse(string action, string parameter = "")
        {
            return await client.GetAsync(route + "/" + action + "/" + parameter);
        }
        public async Task<HttpResponseMessage> PostResponse(Object newObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(newObject),
                Encoding.UTF8, "application/json");
            return await client.PostAsync(route, jsonObject);
        }

        public async Task<HttpResponseMessage> PostActionResponse(string action, Object newObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(newObject),
                Encoding.UTF8, "application/json");
            return await client.PostAsync(route + "/" + action, jsonObject);
        }

        public HttpResponseMessage PutResponse(int id, Object existingObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(existingObject),
                Encoding.UTF8, "application/json");
            return client.PutAsync(route + "/" + id, jsonObject).Result;
        }

        public HttpResponseMessage PutActionResponse(string action, int id, Object existingObject)
        {
            StringContent jsonObject = new StringContent(JsonConvert.SerializeObject(existingObject),
               Encoding.UTF8, "application/json");
            return client.PutAsync(route + "/" + action + "/" + id, jsonObject).Result;
        }
    }
}
