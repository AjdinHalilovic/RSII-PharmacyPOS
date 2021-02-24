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
using Pharmacy.Core.Models.Settins;

namespace Pharmacy.Mobile.ViewModels
{
    public class RSII24022021ViewModel : BaseViewModel
    {
        private readonly APIService _billssService = new APIService("Bills");
        private readonly APIService _personsService = new APIService("Persons");
        private readonly APIService _RSII24022021Service = new APIService("RSII24022021");

        public ObservableCollection<BillDto> Items { get; set; } = new ObservableCollection<BillDto>();
        public ObservableCollection<PersonDto> PersonsList { get; set; } = new ObservableCollection<PersonDto>();
        public ObservableCollection<RSII24022021Dto> RSII24022021List { get; set; } = new ObservableCollection<RSII24022021Dto>();

        public Command LoadItemsCommand { get; set; }

        public RSII24022021ViewModel()
        {
            Title = "RSII24022021";
            Items = new ObservableCollection<BillDto>();
            PersonsList = new ObservableCollection<PersonDto>();
            RSII24022021List = new ObservableCollection<RSII24022021Dto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadRSII24022021Command());

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


        DateTime? _dateTimeFrom = DateTime.Now.AddDays(-1);
        public DateTime? DateTimeFrom
        {
            get { return _dateTimeFrom; }
            set
            {
                SetProperty(ref _dateTimeFrom, value);
                if (value != null)
                {
                    LoadItemsCommand.Execute(null);
                }
            }
        }
        DateTime? _dateTimeTo = DateTime.Now;
        public DateTime? DateTimeTo
        {
            get { return _dateTimeTo; }
            set
            {
                SetProperty(ref _dateTimeTo, value);
                if (value != null)
                {
                    LoadItemsCommand.Execute(null);
                }
            }
        }

        bool _maliciozan = true;
        public bool Maliciozan
        {
            get { return _maliciozan; }
            set
            {
                SetProperty(ref _maliciozan, value);
                if (value != null)
                {
                    LoadItemsCommand.Execute(null);
                }
            }
        }


        public async Task<bool> CancelMaliciozne()
        {
            if (RSII24022021List.Count > 0)
            {
                try
                {
                    var insertRequest = new RSII24022021UpsertRequest()
                    {
                        Ids = RSII24022021List.Select(x=> x.Id).ToList(),
                        Maliciozan = true
                    };

                    var inventoryEntry = await _RSII24022021Service.Update<bool>(0,insertRequest);


                    RSII24022021SearchObject search = new RSII24022021SearchObject()
                    {
                        PersonId = SelectedPerson?.FullName == "Select person" ? null : SelectedPerson?.Id,
                        DateTimeFrom = DateTimeFrom,
                        DateTimeTo = DateTimeTo,
                        Maliciozan = Maliciozan
                    };
                    var bills = await _RSII24022021Service.Get<List<RSII24022021Dto>>(search);

                    RSII24022021List.Clear();
                    foreach (var item in bills)
                    {
                        RSII24022021List.Add(item);
                    }

                    RSII24022021List.OrderByDescending(x => x.CreatedDateTime);

                    return true;
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }

        public async Task ExecuteLoadRSII24022021Command()
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


                RSII24022021SearchObject search = new RSII24022021SearchObject()
                {
                    PersonId = SelectedPerson?.FullName == "Select person" ? null : SelectedPerson?.Id,
                    DateTimeFrom = DateTimeFrom,
                    DateTimeTo = DateTimeTo,
                    Maliciozan = Maliciozan
                };
                var bills = await _RSII24022021Service.Get<List<RSII24022021Dto>>(search);

                RSII24022021List.Clear();
                foreach (var item in bills)
                {
                    RSII24022021List.Add(item);
                }

                RSII24022021List.OrderByDescending(x => x.CreatedDateTime);
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