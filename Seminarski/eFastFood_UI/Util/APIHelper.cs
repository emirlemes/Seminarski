using System;
using System.Net.Http;

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
            return client.PostAsJsonAsync(route, newObject).Result;
        }

        public HttpResponseMessage PostActionResponse(string action, Object newObject)
        {
            return client.PostAsJsonAsync(route + "/" + action, newObject).Result;
        }

        public HttpResponseMessage PutResponse(int id, Object existingObject)
        {
            return client.PutAsJsonAsync(route + "/" + id, existingObject).Result;
        }

        public HttpResponseMessage PutActionResponse(string action, int id, Object existingObject)
        {
            return client.PutAsJsonAsync(route + "/" + action + "/" + id, existingObject).Result;
        }

        public HttpResponseMessage DeleteResponse(string parameter = "")
        {
            return client.DeleteAsync(route + "/" + parameter).Result;
        }
    }
}
