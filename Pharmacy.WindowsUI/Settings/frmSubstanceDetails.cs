using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Models;
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
    public partial class frmSubstanceDetails : Form
    {
        private readonly APIService _aPIServiceSubstances = new APIService("Substances");

        private int? _id = null;
        public frmSubstanceDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmCategoryDetails_LoadAsync(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var substance = await _aPIServiceSubstances.GetById<Substance>(_id);
                txtName.Text = substance.Name;
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
            if (ValidateChildren())
            {
                try
                {
                    BaseInsertRequest request = new BaseInsertRequest()
                    {
                        Name = txtName.Text,
                    };

                    Substance substance = null;

                    if (!_id.HasValue)
                    {
                        substance = await _aPIServiceSubstances.Insert<Substance>(request);
                    }
                    else
                    {
                        substance = await _aPIServiceSubstances.Update<Substance>(_id.Value, request);
                    }

                    if (substance != null)
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
