﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pharmacy.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        async void GetSalesRevanue(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SalesRevanuePage());
        }
        async void GetGoodsEntry(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GoodsEntryPage());
        }
        async void GetOutputOfGoods(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OutputOfGoodsPage());
        }
        async void GetWarehouse(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WarehousePage());
        }
        async void GetRSII24022021(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RSII24022021Page());
        }
    }
}