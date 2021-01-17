using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;
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

namespace Pharmacy.WindowsUI.Billing
{
    public partial class frmProductDetails : Form
    {
        APIService _aPIServiceProducts = new APIService("Products");
        APIService _aPIServiceMeasurementUnits = new APIService("MeasurementUnits");
        APIService _aPIServiceAttributes = new APIService("Attributes");
        APIService _aPIServiceAttributeOptions = new APIService("AttributeOptions");
        APIService _aPIServiceCategories = new APIService("Categories");
        APIService _aPIServiceProductCategories = new APIService("ProductCategories");
        APIService _aPIServiceProductAttributes = new APIService("ProductAttributes");
        APIService _aPIServiceSubstances = new APIService("Substances");
        APIService _aPIServiceProductSubstances = new APIService("ProductSubstances");

        private int? _id = null;
        public frmProductDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var categoriesList = clbCategories.CheckedItems.Cast<Category>().Select(x => x.Id).ToList();
                var substancesList = clbSubstances.CheckedItems.Cast<Substance>().Select(x => x.Id).ToList();
                var productAttributesList = new List<ProductAttribute>();
                foreach (DataGridViewRow row in dgvProductAttributes.Rows)
                {
                    var productAttribute = new ProductAttribute()
                    {
                        Id = (int)row.Cells[0].Value,
                        ProductId = 0,
                        AttributeId = (int)row.Cells[1].Value,
                        AttributeOptionId = (int)row.Cells[3].Value
                    };
                    productAttributesList.Add(productAttribute);
                }
                try
                {
                    ProductUpsertRequest request = new ProductUpsertRequest()
                    {
                        Name = txtName.Text,
                        Code = txtCode.Text,
                        MeasurementUnitId = int.Parse(comboMeasurementUnitId.SelectedValue.ToString()),
                        Price = decimal.Parse(txtPrice.Text.Replace(".", ",")),
                        Description = txtDescription.Text,
                        Categories = categoriesList,
                        Substances = substancesList,
                        ProductAttributes = productAttributesList
                    };

                    Product product = null;

                    if (!_id.HasValue)
                    {
                        product = await _aPIServiceProducts.Insert<Product>(request);
                    }
                    else
                    {
                        product = await _aPIServiceProducts.Update<Product>(_id.Value, request);
                    }

                    if (product != null)
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

        private async void frmProductDetails_Load(object sender, EventArgs e)
        {
            await LoadMeasurementUnits();
            await LoadAttributes();

            var categories = await _aPIServiceCategories.Get<List<Category>>(null);
            var substances = await _aPIServiceSubstances.Get<List<Substance>>(null);
            dgvProductAttributes.AllowUserToAddRows = false;

            if (_id.HasValue)
            {
                try
                {
                    var productCategories = await _aPIServiceProductCategories.Get<List<ProductCategory>>(new CategorySearchObject() { ProductId = _id });
                    var selectedCategories = await _aPIServiceCategories.Get<List<Category>>(new CategorySearchObject() { ListIds = productCategories.Count > 0 ? productCategories.Select(x => x.CategoryId).ToArray() : new int[] { 0 } });
                    categories = categories.Where(x => !selectedCategories.Select(y => y.Id).Contains(x.Id)).ToList();
                    selectedCategories.ToList().ForEach(x => clbCategories.Items.Add(x, true));

                    var productSubstances = await _aPIServiceProductSubstances.Get<List<ProductSubstance>>(new SubstanceSearchObject() { ProductId = _id });
                    var selectedSubstances = await _aPIServiceSubstances.Get<List<Substance>>(new SubstanceSearchObject() { ListIds = productSubstances.Select(x => x.SubstanceId).ToArray() });
                    substances = substances.Where(x => !selectedSubstances.Select(y => y.Id).Contains(x.Id)).ToList();
                    selectedSubstances.ToList().ForEach(x => clbSubstances.Items.Add(x, true));


                    var attributes = (await _aPIServiceProductAttributes.Get<List<ProductAttributeDto>>(new AttributeSearchObject() { ProductId = _id })).ToList();
                    foreach (var item in attributes)
                    {
                        dgvProductAttributes.Rows.Add(item.Id, item.AttributeId, item.Attribute, item.AttributeOptionId, item.AttributeOptionValue);
                    }

                    var product = await _aPIServiceProducts.GetById<Product>(_id);
                    txtId.Text = _id.ToString();
                    txtName.Text = product.Name;
                    txtCode.Text = product.Code;
                    txtPrice.Text = product.Price.ToString();
                    txtDescription.Text = product.Description;
                    comboMeasurementUnitId.SelectedValue = product.MeasurementUnitId;
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            categories.ToList().ForEach(x => clbCategories.Items.Add(x));
            clbCategories.DisplayMember = "Name";

            substances.ToList().ForEach(x => clbSubstances.Items.Add(x));
            clbSubstances.DisplayMember = "Name";
        }

        private async Task LoadMeasurementUnits()
        {
            var result = await _aPIServiceMeasurementUnits.Get<List<MeasurementUnit>>(null);
            result.Insert(0, new MeasurementUnit() { Name = "Select measurement unit" });
            comboMeasurementUnitId.ValueMember = "Id";
            comboMeasurementUnitId.DisplayMember = "Name";
            comboMeasurementUnitId.DataSource = result;
        }


        private async Task LoadAttributes()
        {
            var result = await _aPIServiceAttributes.Get<List<Pharmacy.Core.Entities.Base.Attribute>>(null);
            result.Insert(0, new Pharmacy.Core.Entities.Base.Attribute() { Name = "Select attribute" });

            comboAttributeId.ValueMember = "Id";
            comboAttributeId.DisplayMember = "Name";
            comboAttributeId.DataSource = result;
        }

        private void dgvProductAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvProductAttributes.Rows[e.RowIndex];

            if (e.ColumnIndex == 5)
            {
                dgvProductAttributes.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnAddProductAttribute_Click(object sender, EventArgs e)
        {
            var attributeId = (comboAttributeId.SelectedItem as Pharmacy.Core.Entities.Base.Attribute).Id;
            var attributeOptionId = (comboAttributeOptionId.SelectedItem as AttributeOption).Id;

            if (attributeId == 0)
            {
                errorProvider.SetError(comboAttributeId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(comboAttributeId, null);
            }
            if (attributeOptionId == 0)
            {
                errorProvider.SetError(comboAttributeOptionId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(comboAttributeOptionId, null);
            }

            if (attributeId != 0 && attributeOptionId != 0)
            {
                dgvProductAttributes.Rows.Add(
                    0,
                   attributeId,
                    (comboAttributeId.SelectedItem as Pharmacy.Core.Entities.Base.Attribute).Name,
                    attributeOptionId,
                    (comboAttributeOptionId.SelectedItem as AttributeOption).Value
                    );

                comboAttributeId.SelectedValue = 0;
                comboAttributeOptionId.SelectedValue = 0;
            }
        }

        private async void comboAttributeId_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedAttributeId = comboAttributeId.SelectedValue;
            if (selectedAttributeId != null)
            {
                var result = await _aPIServiceAttributeOptions.Get<List<AttributeOption>>(new AttributeOptionSearchObject() { AttributeId = int.Parse(selectedAttributeId.ToString()) });
                result.Insert(0, new AttributeOption() { Value = "Select option" });

                comboAttributeOptionId.ValueMember = "Id";
                comboAttributeOptionId.DisplayMember = "Value";
                comboAttributeOptionId.DataSource = result;
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

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCode, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtCode, null);
            }
        }

        private void comboMeasurementUnitId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboMeasurementUnitId.SelectedValue?.ToString()) || comboMeasurementUnitId.SelectedValue?.ToString() == "0")
            {
                e.Cancel = true;
                errorProvider.SetError(comboMeasurementUnitId, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(comboMeasurementUnitId, null);
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPrice, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtPrice, null);
            }
        }
    }
}
