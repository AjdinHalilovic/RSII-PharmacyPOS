using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pharmacy.Core.Helpers
{
    public class WebAPIHelper
    {
        public HttpClient client { get; set; }
        public string route { get; set; }

        public WebAPIHelper(string uri, string route)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
            this.route = route;
        }

        public HttpResponseMessage GetResponse()
        {
            return client.GetAsync(route).Result;
        }

        public HttpResponseMessage GetResponse(string parametar)
        {
            return client.GetAsync(route + "/" + parametar).Result;

        }
        public HttpResponseMessage GetActionResponse(string action, string parametar)
        {
            return client.GetAsync(route + "/" + action + "/" + parametar).Result;

        }

        public HttpResponseMessage PostResponse(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return client.PostAsync(route, stringContent).Result;
        }

        public HttpResponseMessage PutResponse(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return client.PutAsync(route, stringContent).Result;
        }
    }
}
