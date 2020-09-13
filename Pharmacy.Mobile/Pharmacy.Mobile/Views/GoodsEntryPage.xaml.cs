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
    public partial class GoodsEntryPage : ContentPage
    {
        GoodsEntryViewModel viewModel;

        public GoodsEntryPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new GoodsEntryViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (InventoryEntryDto)layout.BindingContext;
            await Navigation.PushAsync(new InventoryEntryDetailPage(new InventoryEntryDetailViewModel(item.Id, item.EntryNumber)));
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}