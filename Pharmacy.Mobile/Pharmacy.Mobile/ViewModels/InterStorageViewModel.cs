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
    public class InterStorageViewModel : BaseViewModel
    {
        private readonly APIService _productsService = new APIService("Products");
        private readonly APIService _inventoryIntermediatesService = new APIService("InventoryIntermediates");
        private readonly APIService _inventoriesService = new APIService("Inventories");

        public ObservableCollection<InventoryEntryProductDto> Items { get; set; } = new ObservableCollection<InventoryEntryProductDto>();
        public ObservableCollection<ProductDto> ProductList { get; set; } = new ObservableCollection<ProductDto>();
        public ObservableCollection<InventoryDto> InventoryList { get; set; } = new ObservableCollection<InventoryDto>();

        public Command LoadItemsCommand { get; set; }
        public Command AddProductToListCommand { get; set; }

        public InterStorageViewModel()
        {
            Title = "New inter storage";
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

        InventoryDto _selectedInventory = null;
        public InventoryDto SelectedInventory
        {
            get { return _selectedInventory; }
            set
            {
                SetProperty(ref _selectedInventory, value);
            }
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
                if (InventoryList.Count == 0)
                {
                    var inventoriesList = await _inventoriesService.Get<List<InventoryDto>>(null);

                    foreach (var inventory in inventoriesList)
                    {
                        InventoryList.Add(inventory);
                    }
                }

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
                    ProductCode = SelectedProduct.Code,
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

        public async Task<bool> SaveInterStorage()
        {
            if (SelectedInventory != null && EntryDateTime.HasValue && Items.Count > 0)
            {
                try
                {
                    var insertRequest = new InventoryIntermediateUpsertRequest()
                    {
                        ToInventoryId = SelectedInventory.Id,
                        CreatedDateTime = EntryDateTime.GetValueOrDefault(),
                        IntermediateProducts = Items.Select(x => new InventoryIntermediateProduct() { ProductId = x.ProductId, Quantity = x.Quantity, Product = new Product() {Code = x.ProductCode } }).ToList()
                    };

                    var inventoryEntry = await _inventoryIntermediatesService.Insert<InventoryIntermediateUpsertRequest>(insertRequest);
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