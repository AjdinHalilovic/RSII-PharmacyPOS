using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
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
    public partial class frmProducts : Form
    {
        private readonly APIService _aPIServiceProducts = new APIService("Products");

        public frmProducts()
        {
            InitializeComponent();
        }

        private async void btnShow_ClickAsync(object sender, EventArgs e)
        {
            var searchObj = new BaseSearchObject()
            {
                SearchTerm = txtPretraga.Text
            };
            var result = await _aPIServiceProducts.Get<List<ProductDto>>(searchObj);
            dgvProducts.DataSource = new BindingList<ProductDto>(result);
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var productId = int.Parse(dgvProducts.SelectedRows[0].Cells[0].Value.ToString());

                frmProductDetails frm = new frmProductDetails(productId);
                frm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductDetails frm = new frmProductDetails(null);
            frm.Show();
        }

        private async void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvProducts.Rows[e.RowIndex];

            if (e.ColumnIndex == 10)
            {
                try
                {
                    await _aPIServiceProducts.Delete(dgvProducts.Rows[e.RowIndex].Cells[0].Value);
                    dgvProducts.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Successfully deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
