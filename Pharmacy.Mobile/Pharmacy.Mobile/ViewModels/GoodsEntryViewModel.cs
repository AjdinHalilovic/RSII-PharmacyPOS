using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Pharmacy.Mobile.Models;
using Pharmacy.Mobile.Views;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Models;

namespace Pharmacy.Mobile.ViewModels
{
    public class GoodsEntryViewModel : BaseViewModel
    {
        private readonly APIService _inventoryEntriesService = new APIService("InventoryEntries");

        public ObservableCollection<InventoryEntryDto> Items { get; set; } = new ObservableCollection<InventoryEntryDto>();
        public Command LoadItemsCommand { get; set; }

        public GoodsEntryViewModel()
        {
            Title = "Goods entry";
            Items = new ObservableCollection<InventoryEntryDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }


        string _searchTerm = string.Empty;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetProperty(ref _searchTerm, value);
                if (value != null)
                {
                    LoadItemsCommand.Execute(null);
                }

            }
        }


        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                BaseSearchObject search = new BaseSearchObject() { SearchTerm = SearchTerm };
                var list = await _inventoryEntriesService.Get<List<InventoryEntryDto>>(search);

                Items.Clear();
                foreach (var item in list)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}