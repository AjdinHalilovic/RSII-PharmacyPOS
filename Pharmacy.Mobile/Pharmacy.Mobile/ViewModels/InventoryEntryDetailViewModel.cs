using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Mobile.Models;
using Xamarin.Forms;

namespace Pharmacy.Mobile.ViewModels
{
    public class InventoryEntryDetailViewModel : BaseViewModel
    {
        private readonly APIService _inventoryEntryProductsService = new APIService("InventoryEntryProducts");
        private int _inventoryEntryId = 0;
        public ObservableCollection<InventoryEntryProductDto> Items { get; set; } = new ObservableCollection<InventoryEntryProductDto>();
        public Command LoadItemsCommand { get; set; }

        public InventoryEntryDetailViewModel(int inventoryEntryId, string inventoryEntryNumber)
        {
            Title = "Inventory entry - "+ inventoryEntryNumber;
            _inventoryEntryId = inventoryEntryId;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }



        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var inventoryEntryProducts = await _inventoryEntryProductsService.Get<List<InventoryEntryProductDto>>(new InventoryEntryProductSearchObject() { InventoryEntryId = _inventoryEntryId });

                Items.Clear();
                foreach (var item in inventoryEntryProducts)
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
