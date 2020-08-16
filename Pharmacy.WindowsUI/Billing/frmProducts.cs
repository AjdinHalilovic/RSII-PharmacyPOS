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

            dgvProducts.DataSource = result;
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

                //frmCategoryDetails frm = new frmCategoryDetails(productId);
                //frm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //frmCategoryDetails frm = new frmCategoryDetails(null);
            //frm.Show();
        }
    }
}
