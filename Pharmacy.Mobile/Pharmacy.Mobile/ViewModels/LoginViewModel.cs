using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Pharmacy.Mobile.Models;
using Pharmacy.Mobile.Views;
using System.Windows.Input;
using Pharmacy.Core.Models.Access;
using Flurl.Http;

namespace Pharmacy.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Users");
#if DEBUG
        private string _apiUrl = "http://localhost:58643";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {

            LoginRequest request = new LoginRequest()
            {
                Username = Username,
                Password = Password
            };

            var url = $"{_apiUrl}/Users/Login/Token";


            try
            {
                TokenResponse response = await url.PostJsonAsync(request).ReceiveJson<TokenResponse>();
                APIService._token = response.AccessToken;
                APIService._userFullName = response.UserFullName;
                Application.Current.MainPage = new MainPage();
            }
            catch (FlurlHttpException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
            }
        }
    }
}