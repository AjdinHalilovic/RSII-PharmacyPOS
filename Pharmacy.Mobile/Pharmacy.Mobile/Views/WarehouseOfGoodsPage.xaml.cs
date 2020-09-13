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
    public partial class WarehouseOfGoodsPage : ContentPage
    {
        WarehouseOfGoodsViewModel viewModel;

        public WarehouseOfGoodsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WarehouseOfGoodsViewModel();
        }

        void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var product = (InventoryEntryProductDto)layout.BindingContext;
            viewModel.RemoveProductFromList(product);
        }

        async void SaveEntry(object sender, EventArgs e)
        {
            if (await viewModel.SaveEntry())
            {
                await DisplayAlert("Successfully saved!", "", "OK");
                await Navigation.PopAsync();
            }
        }

        void AddProductToList(object sender, EventArgs e)
        {
            viewModel.AddProductToListCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}