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

namespace Pharmacy.Mobile.ViewModels
{
    public class WarehouseViewModel : BaseViewModel
    {
        private readonly APIService _productsService = new APIService("Products");
        private readonly APIService _categoriesService = new APIService("Categories");

        public ObservableCollection<ProductDto> Items { get; set; } = new ObservableCollection<ProductDto>();
        public ObservableCollection<Category> CategoriesList { get; set; } = new ObservableCollection<Category>();
        public Command LoadItemsCommand { get; set; }

        public WarehouseViewModel()
        {
            Title = "Warehouse";
            Items = new ObservableCollection<ProductDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        Category _selectedCategory = null;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                SetProperty(ref _selectedCategory, value);
                if (value != null)
                {
                    LoadItemsCommand.Execute(null);
                }

            }
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
                if (CategoriesList.Count == 0)
                {
                    var vrsteProizvodaList = await _categoriesService.Get<List<Category>>(null);

                    CategoriesList.Add(new Category() { Name = "Select category", Id = 0});

                    foreach (var vrsteProizvoda in vrsteProizvodaList)
                    {
                        CategoriesList.Add(vrsteProizvoda);
                    }
                }


                ProductSearchObject search = new ProductSearchObject() { CategoryId = SelectedCategory?.Name == "Select category" ? (int?)null : SelectedCategory?.Id, SearchTerm = SearchTerm };
                var list = await _productsService.Get<List<ProductDto>>(search);

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