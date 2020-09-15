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
    public partial class frmReports : Form
    {
        private readonly APIService _aPIServiceBills = new APIService("Bills");
        private readonly APIService _aPIServicePersons = new APIService("Persons");

        public frmReports()
        {
            InitializeComponent();
        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dateTimePickerTo.Value = DateTime.Now;

            await LoadUsers();
            await LoadCharts();

        }
        private async Task LoadUsers()
        {
            var result = await _aPIServicePersons.Get<List<PersonDto>>(null);
            result.Insert(0, new PersonDto() { FullName = "Select person", Id = 0 });
            comboUserId.ValueMember = "Id";
            comboUserId.DisplayMember = "FullName";
            comboUserId.DataSource = result;
        }

        async Task LoadCharts()
        {
            try
            {

                var search = new BillSearchObject()
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value,
                    SearchTerm = string.Empty,
                    UserId = comboUserId.SelectedValue != null && int.Parse(comboUserId.SelectedValue.ToString()) != 0 ? int.Parse(comboUserId.SelectedValue.ToString()) : (int?)null
                };
                var bills = await _aPIServiceBills.Get<List<BillDto>>(search);

                List<decimal> valuesY = new List<decimal>();
                List<DateTime> valuesX = new List<DateTime>();

                bills.ForEach(x => { valuesY.Add(x.Amount); valuesX.Add(x.CreatedDateTime); });

                //valuesY.Add(10);
                //valuesX.Add(DateTime.Now);

                //valuesY.Add(15);
                //valuesX.Add(DateTime.Now.AddDays(2));

                chartSalesByTime.Series["Prihod"].Points.DataBindXY(valuesX, valuesY);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void comboCategoryId_ValueMemberChanged(object sender, EventArgs e)
        {
            await LoadCharts();
        }

        private async void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            await LoadCharts();
        }

        private async void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            await LoadCharts();
        }

        private async void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            await LoadCharts();
        }
    }
}
