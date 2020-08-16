using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Billing;
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
        APIService _aPIServiceCategories = new APIService("Categories");
        APIService _aPIServiceProductCategories = new APIService("ProductCategories");
        APIService _aPIServiceSubstances = new APIService("Substances");
        APIService _aPIServiceProductSubstances = new APIService("ProductSubstances");

        private int? _id = null;
        public frmProductDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {

        }

        private async void frmProductDetails_Load(object sender, EventArgs e)
        {
            await LoadMeasurementUnits();

            var categories = await _aPIServiceCategories.Get<List<Category>>(null);
            var substances = await _aPIServiceSubstances.Get<List<Substance>>(null);

            if (_id.HasValue)
            {
                var productCategories = await _aPIServiceProductCategories.Get<List<ProductCategory>>(new CategorySearchObject() { ProductId = _id });
                var selectedCategories = await _aPIServiceCategories.Get<List<Category>>(new CategorySearchObject() { ListIds = productCategories.Select(x => x.CategoryId).ToArray() });
                categories = categories.Where(x => !selectedCategories.Select(y => y.Id).Contains(x.Id)).ToList();
                selectedCategories.ToList().ForEach(x => clbCategories.Items.Add(x, true));

                var productSubstances = await _aPIServiceProductSubstances.Get<List<ProductSubstance>>(new SubstanceSearchObject() { ProductId = _id });
                var selectedSubstances = await _aPIServiceSubstances.Get<List<Substance>>(new SubstanceSearchObject() { ListIds = productSubstances.Select(x => x.SubstanceId).ToArray() });
                substances = substances.Where(x => !selectedSubstances.Select(y => y.Id).Contains(x.Id)).ToList();
                selectedSubstances.ToList().ForEach(x => clbSubstances.Items.Add(x, true));

                dgvProductAttributes.DataSource = new List<ProductAttributeDto>() { new ProductAttributeDto() { Attribute = "bboja", Id = 1, AttributeOptionValue = "Zelena" } };
                
                var product = await _aPIServiceProducts.GetById<Product>(_id);
                txtId.Text = _id.ToString();
                txtName.Text = product.Name;
                txtCode.Text = product.Code;
                txtPrice.Text = product.Price.ToString();
                txtDescription.Text = product.Description;
                comboMeasurementUnitId.SelectedValue = product.MeasurementUnitId;

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

        private void dgvProductAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvProductAttributes.Rows[e.RowIndex];

            if(e.ColumnIndex == 3)
            {
                //remove row form dgv;
            }
        }
    }
}
