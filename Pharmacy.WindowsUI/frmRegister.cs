using Flurl.Http;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Access;
using Pharmacy.WindowsUI.Properties;
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
            if (ValidateChildren())
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
                    MessageBox.Show("Error");
                }
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

        private void txtPharmacyName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPharmacyName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPharmacyName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPharmacyName, null);
            }
        }

        private void txtPharmacyUniqueIdentifier_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPharmacyUniqueIdentifier.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPharmacyUniqueIdentifier, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPharmacyUniqueIdentifier, null);
            }
        }

        private void comboCountryId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboCountryId.SelectedValue?.ToString()) || comboCountryId.SelectedValue?.ToString() == "0")
            {
                e.Cancel = true;
                errorProvider1.SetError(comboCountryId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(comboCountryId, null);
            }
        }

        private void comboCityId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboCityId.SelectedValue?.ToString()) || comboCityId.SelectedValue?.ToString() == "0")
            {
                e.Cancel = true;
                errorProvider1.SetError(comboCityId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(comboCityId, null);
            }
        }

        private void txtBranchIDentifier_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBranchIDentifier.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBranchIDentifier, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtBranchIDentifier, null);
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, Resources.Validation_RequiredField);
            }
            else if(txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, Resources.PasswordsDoNotMatch);
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
    }
}
