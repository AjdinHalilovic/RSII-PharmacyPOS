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
using Pharmacy.Core.Models.Settins;

namespace Pharmacy.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Users");
        private readonly APIService _RSII24022021service = new APIService("RSII24022021");
#if DEBUG
        private string _apiUrl = "http://localhost:58643";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            //seed 3 records of RSII24022021

            var rSII24022021url = $"{_apiUrl}/rsii24022021";

            rSII24022021url.PostJsonAsync(new LoginRequest { Username = "admin", Password = "wrongpass" }).ReceiveJson<bool>();
            rSII24022021url.PostJsonAsync(new LoginRequest { Username = "desktopSeller", Password = "testwrong" }).ReceiveJson<bool>();
            rSII24022021url.PostJsonAsync(new LoginRequest { Username = "admin2", Password = "testwrong" }).ReceiveJson<bool>();
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
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Username i password su obavezni", "OK");
                return;
            }

            LoginRequest request = new LoginRequest()
            {
                Username = Username,
                Password = Password
            };

            var url = $"{_apiUrl}/Users/Login/Token";


            try
            {
                var rSII24022021url = $"{_apiUrl}/rsii24022021";
                await rSII24022021url.PostJsonAsync(request).ReceiveJson<bool>();

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