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
    public partial class frmAttributeDetails : Form
    {
        private readonly APIService _aPIServiceAttributes = new APIService("Attributes");

        private int? _id = null;
        public frmAttributeDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmCategoryDetails_LoadAsync(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var attribute = await _aPIServiceAttributes.GetById<Pharmacy.Core.Entities.Base.Attribute>(_id);
                txtName.Text = attribute.Name;
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

                    Pharmacy.Core.Entities.Base.Attribute attribute = null;

                    if (!_id.HasValue)
                    {
                        attribute = await _aPIServiceAttributes.Insert<Pharmacy.Core.Entities.Base.Attribute>(request);
                    }
                    else
                    {
                        attribute = await _aPIServiceAttributes.Update<Pharmacy.Core.Entities.Base.Attribute>(_id.Value, request);
                    }

                    if (attribute != null)
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
