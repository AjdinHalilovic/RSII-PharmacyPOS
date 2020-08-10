using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;

namespace Pharmacy.WindowsUI
{
    public class APIService
    {
        public static string _token { get; set; }
        private string _route = null;
        public APIService(string route)
        {
            _route = route;
            _token = "test";
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
            catch (Exception ex)
            {
                    MessageBox.Show("Niste authentificirani");
                //if (ex.== System.Net.HttpStatusCode.Unauthorized)
                //{
                //}
                throw;
            }
        }
    }
}
