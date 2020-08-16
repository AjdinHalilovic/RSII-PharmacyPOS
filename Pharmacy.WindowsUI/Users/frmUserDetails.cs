using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models.Users;
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

namespace Pharmacy.WindowsUI.Users
{
    public partial class frmUserDetails : Form
    {
        APIService _aPIServiceUsers = new APIService("Users");
        APIService _aPIServicePersons = new APIService("Persons");
        APIService _aPIServiceRoles = new APIService("Roles");
        APIService _aPIServiceUserRoles = new APIService("UserRoles");
        APIService _aPIServiceCities = new APIService("Cities");
        APIService _aPIServiceCountries = new APIService("Countries");
        private int? _id = null;
        public frmUserDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var roleList = clbRoles.CheckedItems.Cast<Role>().Select(x => x.Id).ToList();

                try
                {
                    UserUpsertRequest request = new UserUpsertRequest()
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = dtpDateOfBirth.Value,
                        CountryId = int.Parse(comboCountryId.SelectedValue.ToString()),
                        CityId = int.Parse(comboCityId.SelectedValue.ToString()),
                        Address = txtAddress.Text,
                        Note = txtNote.Text,
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmPassword.Text,
                        Roles = roleList
                    };

                    Person person = null;

                    if (!_id.HasValue)
                    {
                        person = await _aPIServicePersons.Insert<Person>(request);
                    }
                    else
                    {
                        person = await _aPIServicePersons.Update<Person>(_id.Value, request);
                    }

                    if (person != null)
                    {
                        MessageBox.Show("Successfully saved!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                    throw;
                }
            }
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadCountries();
            await LoadCities();

            var roles = await _aPIServiceRoles.Get<List<Role>>(null);
            if (_id.HasValue)
            {
                var userRoles = await _aPIServiceUserRoles.Get<List<UserRole>>(new RolesSearchObject() { UserId = _id });
                var selectedRoles = await _aPIServiceRoles.Get<List<Role>>(new RolesSearchObject() { ListIds = userRoles.Select(x => x.RoleId).ToArray() });

                roles = roles.Where(x => !selectedRoles.Select(y => y.Id).Contains(x.Id)).ToList();
                selectedRoles.ToList().ForEach(x => clbRoles.Items.Add(x,true));
            }
            roles.ToList().ForEach(x => clbRoles.Items.Add(x));

            //clbRoles.DataSource = roles;
            clbRoles.DisplayMember = "Name";

            if (_id.HasValue)
            {
                User user = await _aPIServiceUsers.GetById<User>(_id);
                Person person = await _aPIServicePersons.GetById<Person>(_id);
                txtId.Text = _id.GetValueOrDefault().ToString();
                txtFirstName.Text = person.FirstName;
                txtLastName.Text = person.LastName;
                dtpDateOfBirth.Value = person.DateOfBirth ?? new DateTime();
                comboCountryId.SelectedValue = person.CountryId ?? 0;
                comboCityId.SelectedValue = person.CityId ?? 0;
                txtAddress.Text = person.Address;
                txtNote.Text = person.Note;

                txtEmail.Text = user.Email;
                txtUsername.Text = user.Username;
                txtPhone.Text = user.Phone;
            }
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

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFirstName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtLastName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void dtpDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dtpDateOfBirth.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(dtpDateOfBirth, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(dtpDateOfBirth, null);
            }
        }

        private void comboCountryId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboCountryId.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(comboCountryId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(comboCountryId, null);
            }
        }

        private void comboCityId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboCityId.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(comboCityId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(comboCityId, null);
            }
        }

        private async void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtUsername, Resources.Validation_RequiredField);
            }
            else if (!string.IsNullOrEmpty(txtId.Text) && (await _aPIServiceUsers.Get<List<User>>(new UsersSearchObject() { Username = txtUsername.Text, NotId = int.Parse(txtId.Text) })).Any())
            {
                e.Cancel = true;
                errorProvider.SetError(txtUsername, Resources.UsernameAlreadyExists);
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else if (!string.IsNullOrEmpty(txtId.Text) && (await _aPIServiceUsers.Get<List<User>>(new UsersSearchObject() { Email = txtEmail.Text, NotId = int.Parse(txtId.Text) })).Any())
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.EmailAlreadyExists);
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else if (txtPassword.Text.Length < 6)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.PasswordMinLen6);
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, Resources.Validation_RequiredField);
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, Resources.PasswordsDoNotMatch);
            }
            else
            {
                errorProvider.SetError(txtConfirmPassword, null);
            }
        }

        private void clbRoles_Validating(object sender, CancelEventArgs e)
        {
            if (clbRoles.CheckedItems.Cast<Role>().Select(x => x.Id).ToList().Count == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(clbRoles, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(clbRoles, null);
            }
        }

        
    }
}
