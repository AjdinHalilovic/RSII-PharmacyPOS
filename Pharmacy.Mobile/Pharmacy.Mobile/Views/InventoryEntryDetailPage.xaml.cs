using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Pharmacy.Mobile.Models;
using Pharmacy.Mobile.ViewModels;

namespace Pharmacy.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class InventoryEntryDetailPage : ContentPage
    {
        InventoryEntryDetailViewModel viewModel;

        public InventoryEntryDetailPage(InventoryEntryDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public InventoryEntryDetailPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.ExecuteLoadItemsCommand();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}