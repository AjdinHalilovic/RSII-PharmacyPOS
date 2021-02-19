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

namespace Pharmacy.WindowsUI.Settings
{
    public partial class frmCategories : Form
    {
        private readonly APIService _aPIServiceCategories = new APIService("Categories");

        public frmCategories()
        {
            InitializeComponent();
        }

        private async void btnShow_ClickAsync(object sender, EventArgs e)
        {
            var searchObj = new BaseSearchObject()
            {
                SearchTerm = txtPretraga.Text
            };
            var result = await _aPIServiceCategories.Get<List<BaseDto>>(searchObj);

            dgvCategories.DataSource = result;
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                var categoryId = int.Parse(dgvCategories.SelectedRows[0].Cells[0].Value.ToString());

                frmCategoryDetails frm = new frmCategoryDetails(categoryId);
                frm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryDetails frm = new frmCategoryDetails(null);
            frm.Show();
        }

        private async void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            var searchObj = new BaseSearchObject()
            {
                SearchTerm = txtPretraga.Text
            };
            var result = await _aPIServiceCategories.Get<List<BaseDto>>(searchObj);

            dgvCategories.DataSource = result;
        }
    }
}
