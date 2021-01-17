using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
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
    public partial class frmSales : Form
    {
        private readonly APIService _aPIServiceBills = new APIService("Bills");
        private readonly APIService _aPIServicePharmacyBranches = new APIService("PharmacyBranches");

        public frmSales()
        {
            InitializeComponent();
        }

        private async void btnShow_ClickAsync(object sender, EventArgs e)
        {
            var searchObj = new BillSearchObject()
            {
                DateFrom = dateTimePickerFrom.Value,
                DateTo = dateTimePickerTo.Value,
                IncludeBranchFiltering = true,
                PharmacyBranchId = comboPharmacyBranchId.SelectedValue != null && int.Parse(comboPharmacyBranchId.SelectedValue.ToString()) != 0 ? int.Parse(comboPharmacyBranchId.SelectedValue.ToString()) : (int?)null
            };
            var result = await _aPIServiceBills.Get<List<BillDto>>(searchObj);
            dgvProducts.DataSource = new BindingList<BillDto>(result);
        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dateTimePickerTo.Value = DateTime.Now;

            await LoadBranches();
        }

        private async Task LoadBranches()
        {
            var result = await _aPIServicePharmacyBranches.Get<List<PharmacyBranchDto>>(null);
            result.Insert(0, new PharmacyBranchDto() { BranchIdentifier = "Select person", Id = 0 });
            comboPharmacyBranchId.ValueMember = "Id";
            comboPharmacyBranchId.DisplayMember = "BranchIdentifier";
            comboPharmacyBranchId.DataSource = result;
        }


        
    }
}
