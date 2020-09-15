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
using System.Linq;

namespace Pharmacy.Mobile.ViewModels
{
    public class OutputOfGoodsViewModel : BaseViewModel
    {
        private readonly APIService _writeOffInventoryDocumentsService = new APIService("WriteOffInventoryDocuments");
        private readonly APIService _inventoryIntermediateProductsService = new APIService("InventoryIntermediateProducts");
        private readonly APIService _billItemsService = new APIService("BillItems");

        public ObservableCollection<OutputOfGoodDto> Items { get; set; } = new ObservableCollection<OutputOfGoodDto>();
        public Command LoadItemsCommand { get; set; }

        public OutputOfGoodsViewModel()
        {
            Title = "Output of goods";
            Items = new ObservableCollection<OutputOfGoodDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
                var writeOffProducts = await _writeOffInventoryDocumentsService.Get<List<WriteOffInventoryDocumentDto>>(search);

                InventoryIntermediateProductsSearchObject searchIntermediate = new InventoryIntermediateProductsSearchObject() { SearchTerm = SearchTerm, FromInventoryProducts = true };
                var intermediateProducts = await _inventoryIntermediateProductsService.Get<List<InventoryIntermediateProductDto>>(searchIntermediate);

                BaseSearchObject searchBillItems = new BaseSearchObject() { SearchTerm = SearchTerm };
                var billItems = await _billItemsService.Get<List<BillItemDto>>(search);

                Items.Clear();
                foreach (var item in writeOffProducts)
                {
                    Items.Add(item);
                }

                foreach (var item in intermediateProducts)
                {
                    Items.Add(item);
                }

                foreach (var item in billItems)
                {
                    Items.Add(item);
                }

                Items.OrderByDescending(x => x.CreatedDateTime);
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