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
using System.Linq;

namespace Pharmacy.Mobile.ViewModels
{
    public class WarehouseOfGoodsViewModel : BaseViewModel
    {
        private readonly APIService _productsService = new APIService("Products");
        private readonly APIService _inventoryEntriesService = new APIService("InventoryEntries");

        public ObservableCollection<InventoryEntryProductDto> Items { get; set; } = new ObservableCollection<InventoryEntryProductDto>();
        public ObservableCollection<ProductDto> ProductList { get; set; } = new ObservableCollection<ProductDto>();
        public Command LoadItemsCommand { get; set; }
        public Command AddProductToListCommand { get; set; }

        public WarehouseOfGoodsViewModel()
        {
            Title = "Warehouse of goods";
            Items = new ObservableCollection<InventoryEntryProductDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddProductToListCommand = new Command(() => ExecuteAddProductToListCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        ProductDto _selectedProduct = null;
        public ProductDto SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                SetProperty(ref _selectedProduct, value);
            }
        }
        int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                SetProperty(ref _quantity, value);
            }
        }

        string _entryNumber = string.Empty;
        public string EntryNumber
        {
            get { return _entryNumber; }
            set
            {
                SetProperty(ref _entryNumber, value);
            }
        }

        DateTime? _entryDateTime = DateTime.Now;
        public DateTime? EntryDateTime
        {
            get { return _entryDateTime; }
            set
            {
                SetProperty(ref _entryDateTime, value);
            }
        }




        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var list = await _productsService.Get<List<ProductDto>>(null);

                ProductList.Clear();
                foreach (var item in list)
                {
                    ProductList.Add(item);
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

        public void ExecuteAddProductToListCommand()
        {
            if (SelectedProduct != null && Quantity != 0)
            {
                InventoryEntryProductDto product = new InventoryEntryProductDto()
                {
                    ProductId = SelectedProduct.Id,
                    Product = SelectedProduct.Name,
                    Quantity = Quantity
                };

                var existProduct = Items.FirstOrDefault(x => x.ProductId == SelectedProduct.Id);
                if (existProduct != null)
                {
                    product.Quantity += existProduct.Quantity;
                    Items.Remove(existProduct);
                }

                Items.Add(product);

                SelectedProduct = null;
                Quantity = 0;
            }

        }
        public void RemoveProductFromList(InventoryEntryProductDto product)
        {
            Items.Remove(product);
        }

        public async Task<bool> SaveEntry()
        {
            if (!string.IsNullOrEmpty(EntryNumber) && EntryDateTime.HasValue && Items.Count > 0)
            {
                try
                {
                    var insertRequest = new InventoryEntryUpsertRequest()
                    {
                        EntryNumber = EntryNumber,
                        EntryDateTime = EntryDateTime.GetValueOrDefault(),
                        EntryProducts = Items.Select(x => new InventoryEntryProduct() { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
                    };

                    var inventoryEntry = await _inventoryEntriesService.Insert<InventoryEntryUpsertRequest>(insertRequest);
                    return true;
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }
    }
}