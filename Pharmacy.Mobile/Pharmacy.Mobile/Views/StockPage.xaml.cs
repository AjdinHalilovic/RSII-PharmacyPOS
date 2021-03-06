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
    public partial class StockPage : ContentPage
    {
        public StockPage()
        {
            InitializeComponent();
        }

        async void AddWarehouseOfGoods(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WarehouseOfGoodsPage());
        }

        async void AddInterStorage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InterStoragePage());
        }

        async void AddWriteOff(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WriteOffPage());
        }
    }
}