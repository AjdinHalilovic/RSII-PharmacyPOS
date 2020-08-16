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
    public partial class frmSubstances : Form
    {
        private readonly APIService _aPIServiceSubstances = new APIService("Substances");

        public frmSubstances()
        {
            InitializeComponent();
        }

        private async void btnShow_ClickAsync(object sender, EventArgs e)
        {
            var searchObj = new BaseSearchObject()
            {
                SearchTerm = txtPretraga.Text
            };
            var result = await _aPIServiceSubstances.Get<List<BaseDto>>(searchObj);

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
                var substanceId = int.Parse(dgvCategories.SelectedRows[0].Cells[0].Value.ToString());

                frmSubstanceDetails frm = new frmSubstanceDetails(substanceId);
                frm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSubstanceDetails frm = new frmSubstanceDetails(null);
            frm.Show();
        }
    }
}
