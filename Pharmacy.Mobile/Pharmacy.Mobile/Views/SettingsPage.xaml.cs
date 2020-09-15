using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pharmacy.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void OnLogout(object sender, EventArgs e)
        {
            Application.Current.Properties["Token"] = "";
            var prevPage = await Navigation.PopAsync();
            Application.Current.MainPage = new LoginPage();
            //Navigation.InsertPageBefore(new LoginPage(), prevPage);
            //await Navigation.PopAsync();
        }
    }
}