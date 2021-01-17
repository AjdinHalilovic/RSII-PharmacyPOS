using Flurl.Http;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.WindowsUI
{
    public partial class frmRegister : Form
    {
        private readonly APIService _aPIServiceUsers = new APIService("Users");
        private readonly APIService _aPIServicePharmacies = new APIService("Pharmacies");
        private readonly APIService _aPIServiceCities = new APIService("Cities");
        private readonly APIService _aPIServiceCountries = new APIService("Countries");

        public frmRegister()
        {
            InitializeComponent();
        }


        private void lblCancelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private async void btnSignUp_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                PharmacyRegisterRequest pharmacyRegisterRequest = new PharmacyRegisterRequest()
                {
                    PharmacyName = txtPharmacyName.Text,
                    PharmacyUniqueIdentifier = txtPharmacyUniqueIdentifier.Text,
                    CountryId = int.Parse(comboCountryId.SelectedValue.ToString()),
                    CityId = int.Parse(comboCityId.SelectedValue.ToString()),
                    Address = txtAddress.Text,
                    BranchIdentifier = txtBranchIDentifier.Text,
                    CentralBranch = chkBoxCentral.Checked,
                    UseCentralBranchData = chkBoxUseCentralData.Checked,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtConfirmPassword.Text
                };

                var url = $"{Properties.Settings.Default.APIUrl}/Register/Pharmacy";
                PharmacyRegisterRequest response = await url.PostJsonAsync(pharmacyRegisterRequest).ReceiveJson<PharmacyRegisterRequest>();
                
                this.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void frmRegister_Load(object sender, EventArgs e)
        {
            await LoadCountries();
            await LoadCities();
        }

        private async Task LoadCountries()
        {
            var result = await _aPIServiceCountries.Get<List<Country>>(null);
            result.Insert(0, new Country() { Name = "Select country" });
            comboCountryId.ValueMember = "Id";
            comboCountryId.DisplayMember = "Name";
            comboCountryId.DataSource = result;
        }

        private async Task LoadCities()
        {
            var result = await _aPIServiceCities.Get<List<City>>(null);
            result.Insert(0, new City() { Name = "Select city" });
            comboCityId.ValueMember = "Id";
            comboCityId.DisplayMember = "Name";
            comboCityId.DataSource = result;
        }
    }
}
