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
    public partial class frmBiling : Form
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
        public frmBiling(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                //var categoriesList = clbCategories.CheckedItems.Cast<Category>().Select(x => x.Id).ToList();
                //var substancesList = clbSubstances.CheckedItems.Cast<Substance>().Select(x => x.Id).ToList();
                //var productAttributesList = new List<ProductAttribute>();
                //foreach (DataGridViewRow row in dgvProductAttributes.Rows)
                //{
                //    var productAttribute = new ProductAttribute()
                //    {
                //        Id = (int)row.Cells[0].Value,
                //        ProductId = 0,
                //        AttributeId = (int)row.Cells[1].Value,
                //        AttributeOptionId = (int)row.Cells[3].Value
                //    };
                //    productAttributesList.Add(productAttribute);
                //}
                //try
                //{
                //    ProductUpsertRequest request = new ProductUpsertRequest()
                //    {
                //        Name = txtName.Text,
                //        Code = txtCode.Text,
                //        MeasurementUnitId = int.Parse(comboMeasurementUnitId.SelectedValue.ToString()),
                //        Price = decimal.Parse(txtPrice.Text.Replace(".", ",")),
                //        Description = txtDescription.Text,
                //        Categories = categoriesList,
                //        Substances = substancesList,
                //        ProductAttributes = productAttributesList
                //    };

                //    Product product = null;

                //    if (!_id.HasValue)
                //    {
                //        product = await _aPIServiceProducts.Insert<Product>(request);
                //    }
                //    else
                //    {
                //        product = await _aPIServiceProducts.Update<Product>(_id.Value, request);
                //    }

                //    if (product != null)
                //    {
                //        MessageBox.Show("Successfully saved!");
                //        this.Close();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error");
                //}
            }
        }

        private async void frmBilling_Load(object sender, EventArgs e)
        {
            await LoadCategories();

            var categories = await _aPIServiceCategories.Get<List<Category>>(null);
            var substances = await _aPIServiceSubstances.Get<List<Substance>>(null);
            dgvProducts.AllowUserToAddRows = false;

            if (_id.HasValue)
            {
                //try
                //{
                //    var productCategories = await _aPIServiceProductCategories.Get<List<ProductCategory>>(new CategorySearchObject() { ProductId = _id });
                //    var selectedCategories = await _aPIServiceCategories.Get<List<Category>>(new CategorySearchObject() { ListIds = productCategories.Count > 0 ? productCategories.Select(x => x.CategoryId).ToArray() : new int[] { 0 } });
                //    categories = categories.Where(x => !selectedCategories.Select(y => y.Id).Contains(x.Id)).ToList();
                //    selectedCategories.ToList().ForEach(x => clbCategories.Items.Add(x, true));

                //    var productSubstances = await _aPIServiceProductSubstances.Get<List<ProductSubstance>>(new SubstanceSearchObject() { ProductId = _id });
                //    var selectedSubstances = await _aPIServiceSubstances.Get<List<Substance>>(new SubstanceSearchObject() { ListIds = productSubstances.Select(x => x.SubstanceId).ToArray() });
                //    substances = substances.Where(x => !selectedSubstances.Select(y => y.Id).Contains(x.Id)).ToList();
                //    selectedSubstances.ToList().ForEach(x => clbSubstances.Items.Add(x, true));


                //    var attributes = (await _aPIServiceProductAttributes.Get<List<ProductAttributeDto>>(new AttributeSearchObject() { ProductId = _id })).ToList();
                //    foreach (var item in attributes)
                //    {
                //        dgvProductAttributes.Rows.Add(item.Id, item.AttributeId, item.Attribute, item.AttributeOptionId, item.AttributeOptionValue);
                //    }

                //    var product = await _aPIServiceProducts.GetById<Product>(_id);
                //    txtId.Text = _id.ToString();
                //    txtName.Text = product.Name;
                //    txtCode.Text = product.Code;
                //    txtPrice.Text = product.Price.ToString();
                //    txtDescription.Text = product.Description;
                //    comboMeasurementUnitId.SelectedValue = product.MeasurementUnitId;
                //}
                //catch (Exception ex)
                //{

                //    throw;
                //}

            }
            //categories.ToList().ForEach(x => clbCategories.Items.Add(x));
            //clbCategories.DisplayMember = "Name";

            //substances.ToList().ForEach(x => clbSubstances.Items.Add(x));
            //clbSubstances.DisplayMember = "Name";
        }

        private async Task LoadCategories()
        {
            var result = await _aPIServiceCategories.Get<List<Category>>(null);
            result.Insert(0, new Category() { Name = "Select category" });
            comboCategoryId.ValueMember = "Id";
            comboCategoryId.DisplayMember = "Name";
            comboCategoryId.DataSource = result;
        }


      

        private void dgvProductAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvProducts.Rows[e.RowIndex];

            if (e.ColumnIndex == 5)
            {
                dgvProducts.Rows.RemoveAt(e.RowIndex);
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
                dgvProducts.Rows.Add(
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
