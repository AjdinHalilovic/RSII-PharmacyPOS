using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Models.Settins;
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
        private readonly APIService _aPIServiceAttributeOptions = new APIService("AttributeOptions");

        private int? _id = null;
        public frmAttributeDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmCategoryDetails_LoadAsync(object sender, EventArgs e)
        {
            dgvAttributeOptions.AllowUserToAddRows = false;
            if (_id.HasValue)
            {
                var attributeOptionss = (await _aPIServiceAttributeOptions.Get<List<AttributeOption>>(new AttributeOptionSearchObject() { AttributeId = _id })).ToList();
                foreach (var item in attributeOptionss)
                {
                    dgvAttributeOptions.Rows.Add(item.Id, item.Value);
                }

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
            var existingAttribute = await _aPIServiceAttributes.Get<IEnumerable<BaseDto>>(new BaseSearchObject { EqualSearchTerm = txtName.Text });
            if (existingAttribute.Any())
            {
                MessageBox.Show("Attribute already exists!", "Error");
                return;
            }
            if (ValidateChildren())
            {
                try
                {
                    var attributeOptionsList = new List<AttributeOption>();
                    foreach (DataGridViewRow row in dgvAttributeOptions.Rows)
                    {
                        var productAttribute = new AttributeOption()
                        {
                            Id = (int)row.Cells[0].Value,
                            AttributeId = 0,
                            Value = row.Cells[1].Value.ToString()
                        };
                        attributeOptionsList.Add(productAttribute);
                    }

                    AttributeUpsertRequest request = new AttributeUpsertRequest()
                    {
                        Name = txtName.Text,
                        AttributeOptions = attributeOptionsList
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
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void dgvAttributeOptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvAttributeOptions.Rows[e.RowIndex];

            if (e.ColumnIndex == 2)
            {
                dgvAttributeOptions.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnAddAttributeValue_Click(object sender, EventArgs e)
        {
            var value = txtValue.Text;

            if (string.IsNullOrEmpty(value))
            {
                errorProvider.SetError(txtValue, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtValue, null);
            }
           

            if (!string.IsNullOrEmpty(value))
            {
                dgvAttributeOptions.Rows.Add(0, value);

                txtValue.Text = string.Empty;
            }
        }
    }
}
