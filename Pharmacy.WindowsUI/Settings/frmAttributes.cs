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
    public partial class frmAttributes : Form
    {
        private readonly APIService _aPIServiceAttributes = new APIService("Attributes");

        public frmAttributes()
        {
            InitializeComponent();
        }

        private async void btnShow_ClickAsync(object sender, EventArgs e)
        {
            var searchObj = new BaseSearchObject()
            {
                SearchTerm = txtPretraga.Text
            };
            var result = await _aPIServiceAttributes.Get<List<BaseDto>>(searchObj);

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
                var attributeId = int.Parse(dgvCategories.SelectedRows[0].Cells[0].Value.ToString());

                frmAttributeDetails frm = new frmAttributeDetails(attributeId);
                frm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAttributeDetails frm = new frmAttributeDetails(null);
            frm.Show();
        }
    }
}
