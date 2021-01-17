using Flurl.Http;
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
        APIService _aPIServiceCategories = new APIService("Categories");
        APIService _aPIServiceBills = new APIService("Bills");

        private int? _relatedProductId = null;
        private decimal _total = 0;
        public frmBiling()
        {
            InitializeComponent();
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && dgvBillItems.Rows.Count > 0)
            {
                try
                {
                    var request = new BillUpsertRequest()
                    {
                        BillItems = new List<BillItem>()
                    };
                    foreach (DataGridViewRow row in dgvBillItems.Rows)
                    {
                        var billItem = new BillItem()
                        {
                            ProductId = (int)row.Cells[0].Value,
                            UnitPrice = decimal.Parse(row.Cells[2].Value.ToString()),
                            Quantity = int.Parse(row.Cells[3].Value.ToString())
                        };
                        request.BillItems.Add(billItem);
                    }

                    Bill bill = null;

                    bill = await _aPIServiceBills.Insert<Bill>(request);

                    if (bill != null)
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

        private async void frmBilling_Load(object sender, EventArgs e)
        {
            await LoadCategories();
            lblTotal.Text = ((decimal)0).ToString();

            dgvProducts.AllowUserToAddRows = false;
            dgvBillItems.AllowUserToAddRows = false;
        }

        private async Task LoadCategories()
        {
            var result = await _aPIServiceCategories.Get<List<Category>>(null);
            result.Insert(0, new Category() { Name = "Select category" });
            comboCategoryId.ValueMember = "Id";
            comboCategoryId.DisplayMember = "Name";
            comboCategoryId.DataSource = result;
        }
        private async void dgvProductAttributes_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvProducts.Rows[e.RowIndex];

            if (e.ColumnIndex == 10)
            {
                var totalQuantity = int.Parse(row.Cells[4].Value.ToString());
                if (totalQuantity > 0)
                {
                    int rowIndex = -1;
                    var id = row.Cells[0].Value;
                    var name = row.Cells[1].Value;
                    var price = row.Cells[3].Value;
                    var quantity = 1;

                    var listProductIds = new List<int>();
                    foreach (DataGridViewRow itemRow in dgvBillItems.Rows)
                    {
                        if (itemRow.Cells[0].Value.ToString().Equals(id.ToString()))
                        {
                            rowIndex = itemRow.Index;
                        }
                        else
                        {
                            listProductIds.Add(int.Parse(itemRow.Cells[0].Value.ToString()));
                        }
                    }
                    if (rowIndex != -1)
                    {

                        var existingRow = dgvBillItems.Rows[rowIndex];
                        existingRow.Cells[3].Value = (int)existingRow.Cells[3].Value + 1;
                        quantity = (int)existingRow.Cells[3].Value;

                    }
                    else
                    {
                        dgvBillItems.Rows.Add(id, name, price, quantity);
                        //check prohibited substance
                        var search = new ProductSubstanceSearchObject() { ProductId = int.Parse(id.ToString()), ProhibitedProductIds = listProductIds };
                        var url = $"{Properties.Settings.Default.APIUrl}/ProductSubstances/CheckProhibitedSubstances";
                        url += "?";
                        url += await search.ToQueryString();
                        var isProhibited = await url.WithOAuthBearerToken(APIService._token).GetJsonAsync<bool>();
                        if (isProhibited)
                        {
                            MessageBox.Show("The selected product contains active substances that should not be mixed with those from other products");
                        }
                    }

                    _total += decimal.Parse(price.ToString());
                    _relatedProductId = int.Parse(id.ToString());
                    lblTotal.Text = _total.ToString();
                    changeProductQuantity(int.Parse(id.ToString()), -1);

                    await searchProducts();
                }
            }
        }

        private async void txtSearch_TextChangedAsync(object sender, EventArgs e)
        {
            await searchProducts();
        }

        private async void comboCategoryId_ValueMemberChangedAsync(object sender, EventArgs e)
        {
            await searchProducts();
        }

        private async Task searchProducts()
        {
            var searchObj = new ProductSearchObject()
            {
                SearchTerm = txtSearch.Text,
                RelatedProductId = _relatedProductId,
                CategoryId = comboCategoryId.SelectedValue != null ? int.Parse(comboCategoryId.SelectedValue.ToString()) : (int?)null
            };
            var result = await _aPIServiceProducts.Get<List<ProductDto>>(searchObj);
            dgvProducts.DataSource = new BindingList<ProductDto>(result);
        }

        private void changeProductQuantity(int productId, int quantity)
        {
            List<ProductDto> products = new List<ProductDto>();
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                var productAttribute = new ProductDto()
                {
                    Id = (int)row.Cells[0].Value,
                    Name = row.Cells[1].Value?.ToString(),
                    Code = row.Cells[2].Value?.ToString(),
                    Price = decimal.Parse(row.Cells[3].Value.ToString()),
                    Quantity = int.Parse(row.Cells[4].Value.ToString()),
                    Description = row.Cells[5].Value?.ToString(),
                    MeasurementUnit = row.Cells[6].Value?.ToString(),
                    Categories = row.Cells[7].Value?.ToString(),
                    SubstancesNumber = (int)row.Cells[8].Value,
                    AttributeNumber = (int)row.Cells[9].Value
                };
                products.Add(productAttribute);
            }
            products.FirstOrDefault(x => x.Id == productId).Quantity += quantity;
            dgvProducts.DataSource = new BindingList<ProductDto>(products);
        }

        private async void dgvBillItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvBillItems.Rows[e.RowIndex];
            var id = row.Cells[0].Value;
            var price = row.Cells[2].Value;

            if (e.ColumnIndex == 4)
            {
                row.Cells[3].Value = (int)row.Cells[3].Value - 1;
                var quantity = (int)row.Cells[3].Value;
                if (quantity == 0)
                {
                    dgvBillItems.Rows.RemoveAt(e.RowIndex);
                }
                _total -= decimal.Parse(price.ToString());
                _relatedProductId = dgvBillItems.Rows.Count == 0 ? (int?)null : int.Parse(dgvBillItems.Rows[dgvBillItems.Rows.Count - 1].Cells[0].Value.ToString());
                lblTotal.Text = _total.ToString();
                changeProductQuantity(int.Parse(id.ToString()), 1);

                await searchProducts();
            }
        }

    }
}
