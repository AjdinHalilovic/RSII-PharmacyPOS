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
    public class WriteOffViewModel : BaseViewModel
    {
        private readonly APIService _productsService = new APIService("Products");
        private readonly APIService _writeOffInventoriesService = new APIService("WriteOffInventoryDocuments");

        public ObservableCollection<InventoryEntryProductDto> Items { get; set; } = new ObservableCollection<InventoryEntryProductDto>();
        public ObservableCollection<ProductDto> ProductList { get; set; } = new ObservableCollection<ProductDto>();
        public Command LoadItemsCommand { get; set; }

        public WriteOffViewModel()
        {
            Title = "New write off";
            Items = new ObservableCollection<InventoryEntryProductDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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

        string _reason = string.Empty;
        public string Reason
        {
            get { return _reason; }
            set
            {
                SetProperty(ref _reason, value);
            }
        }

        DateTime? _writeOffDateTime = DateTime.Now;
        public DateTime? WriteOffDateTime
        {
            get { return _writeOffDateTime; }
            set
            {
                SetProperty(ref _writeOffDateTime, value);
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

       
        

        public async Task<bool> SaveEntry()
        {
            if (!string.IsNullOrEmpty(Reason) && WriteOffDateTime.HasValue && Quantity > 0 && SelectedProduct != null)
            {
                try
                {
                    var insertRequest = new InventoryWriteOffUpsertRequest()
                    {
                        ProductId = SelectedProduct.Id,
                        Quantity = Quantity,
                        Reason = Reason,
                        WriteOffDateTime = WriteOffDateTime.GetValueOrDefault()
                    };

                    var inventoryWriteOff = await _writeOffInventoriesService.Insert<InventoryWriteOffUpsertRequest>(insertRequest);
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