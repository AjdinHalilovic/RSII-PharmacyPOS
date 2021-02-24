using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Pharmacy.Mobile.Models;
using Pharmacy.Mobile.Views;
using Pharmacy.Mobile.ViewModels;

namespace Pharmacy.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RSII24022021Page : ContentPage
    {
        RSII24022021ViewModel viewModel;

        public RSII24022021Page()
        {
            InitializeComponent();

            BindingContext = viewModel = new RSII24022021ViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            //var layout = (BindableObject)sender;
            //var item = (Item)layout.BindingContext;
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }
        
        async void CancellMaliciozne(object sender, EventArgs e)
        {
            if (await viewModel.CancelMaliciozne())
            {
                await DisplayAlert("Successfully cancelled!", "", "OK");
                await Navigation.PopAsync();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}