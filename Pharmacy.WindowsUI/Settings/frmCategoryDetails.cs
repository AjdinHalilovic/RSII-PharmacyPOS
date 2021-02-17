using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
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

namespace Pharmacy.WindowsUI.Settings
{
    public partial class frmCategoryDetails : Form
    {
        private readonly APIService _aPIServiceCategories = new APIService("Categories");

        private int? _id = null;
        public frmCategoryDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmCategoryDetails_LoadAsync(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var category = await _aPIServiceCategories.GetById<Category>(_id);
                txtName.Text = category.Name;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                var existingCategory = await _aPIServiceCategories.Get<IEnumerable<BaseDto>>(new CategorySearchObject { EqualSearchTerm = txtName.Text });
                if (existingCategory.Any() && !_id.HasValue)
                {
                    MessageBox.Show("Substance already exists!", "Error");
                    return;
                }
            }
            if (ValidateChildren())
            {
                try
                {
                    BaseInsertRequest request = new BaseInsertRequest()
                    {
                        Name = txtName.Text,
                    };

                    Category category = null;

                    if (!_id.HasValue)
                    {
                        category = await _aPIServiceCategories.Insert<Category>(request);
                    }
                    else
                    {
                        category = await _aPIServiceCategories.Update<Category>(_id.Value, request);
                    }

                    if (category != null)
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
    }
}
