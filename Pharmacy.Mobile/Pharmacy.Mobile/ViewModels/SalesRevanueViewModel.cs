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
using Pharmacy.Core.Models.Users;

namespace Pharmacy.Mobile.ViewModels
{
    public class SalesRevanueViewModel : BaseViewModel
    {
        private readonly APIService _billssService = new APIService("Bills");
        private readonly APIService _personsService = new APIService("Persons");

        public ObservableCollection<BillDto> Items { get; set; } = new ObservableCollection<BillDto>();
        public ObservableCollection<PersonDto> PersonsList { get; set; } = new ObservableCollection<PersonDto>();

        public Command LoadItemsCommand { get; set; }

        public SalesRevanueViewModel()
        {
            Title = "Sales revanue";
            Items = new ObservableCollection<BillDto>();
            PersonsList = new ObservableCollection<PersonDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        PersonDto _selectedPerson = null;
        public PersonDto SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                SetProperty(ref _selectedPerson, value);
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
                if (PersonsList.Count == 0)
                {
                    var personsList = await _personsService.Get<List<PersonDto>>(null);

                    PersonsList.Add(new PersonDto() { FullName = "Select person", Id = 0 });

                    foreach (var person in personsList)
                    {
                        PersonsList.Add(person);
                    }
                }


                BillSearchObject search = new BillSearchObject() { SearchTerm = SearchTerm, UserId = SelectedPerson?.FullName == "Select person" ? null : SelectedPerson?.Id };
                var bills = await _billssService.Get<List<BillDto>>(search);

                Items.Clear();
                foreach (var item in bills)
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