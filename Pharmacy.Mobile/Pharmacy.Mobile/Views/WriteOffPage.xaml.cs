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
using Pharmacy.Core.Entities.Base.DTO;

namespace Pharmacy.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class WriteOffPage : ContentPage
    {
        WriteOffViewModel viewModel;

        public WriteOffPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WriteOffViewModel();
        }

       

        async void SaveEntry(object sender, EventArgs e)
        {
            if (await viewModel.SaveEntry())
            {
                await DisplayAlert("Successfully saved!", "", "OK");
                await Navigation.PopAsync();
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.ExecuteLoadItemsCommand();
        }
    }
}