using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using System.Net.Http;

namespace Pharmacy.WindowsUI
{
    public class APIService
    {
        public static string _token { get; set; }
        public static string _branchIdentifier { get; set; }
        public static bool _isAdmin { get; set; }
        public static string _userFullName { get; set; }
        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithOAuthBearerToken(_token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();
                MessageBox.Show(message);
                return default(T);
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithOAuthBearerToken(_token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();
                MessageBox.Show(message);
                return default(T);
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                return await url.WithOAuthBearerToken(_token).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();
                MessageBox.Show(message);
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithOAuthBearerToken(_token).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();
                MessageBox.Show(message);
                return default(T);
            }

        }


        public async Task<HttpResponseMessage> Delete(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithOAuthBearerToken(_token).DeleteAsync();
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();
                MessageBox.Show(message);
                return default(HttpResponseMessage);
            }
        }
    }
}
