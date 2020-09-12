using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using System.Net.Http;
using Xamarin.Forms;

namespace Pharmacy.Mobile
{
    public class APIService
    {
        public static string _token { get; set; }
        public static string _userFullName { get; set; }
        private string _route = null;

#if DEBUG
        private string _apiUrl = "http://localhost:58643";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithOAuthBearerToken(_token).GetJsonAsync<T>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(_token).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                return await url.WithOAuthBearerToken(_token).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithOAuthBearerToken(_token).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                return default(T);
            }

        }


        public async Task<HttpResponseMessage> Delete(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(_token).DeleteAsync();
        }
    }
}
