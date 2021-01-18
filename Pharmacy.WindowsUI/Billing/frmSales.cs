using iTextSharp.text;
using iTextSharp.text.pdf;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private readonly APIService _aPIServiceBillItems = new APIService("BillItems");

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
            result.Insert(0, new PharmacyBranchDto() { BranchIdentifier = "Select branch", Id = 0 });
            comboPharmacyBranchId.ValueMember = "Id";
            comboPharmacyBranchId.DisplayMember = "BranchIdentifier";
            comboPharmacyBranchId.DataSource = result;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            #region Data
            var search = new BillSearchObject()
            {
                DateFrom = dateTimePickerFrom.Value,
                DateTo = dateTimePickerTo.Value,
                IncludeBranchFiltering = true,
                PharmacyBranchId = comboPharmacyBranchId.SelectedValue != null && int.Parse(comboPharmacyBranchId.SelectedValue.ToString()) != 0 ? int.Parse(comboPharmacyBranchId.SelectedValue.ToString()) : (int?)null
            };
            var bills = await _aPIServiceBills.Get<List<BillDto>>(search);

            #endregion

            Stream stream = File.OpenWrite($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Sales_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.pdf");
            Document doc = new Document();
            PdfWriter.GetInstance(doc, stream);
            doc.Open();

            iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN);

            doc.Add(new Paragraph($"Report for sales by users \n\n", times) { Alignment = Element.ALIGN_CENTER, Font = times });
            doc.Add(new Paragraph($"The report refers to the: \n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
            doc.Add(new Paragraph($"-Period:{search.DateFrom?.ToString()} - {search.DateTo?.ToString()}\n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
            doc.Add(new Paragraph($"-and to the {(!search.PharmacyBranchId.HasValue ? "all" : "")} branch{(!search.PharmacyBranchId.HasValue ? "es" : "")} {(!search.PharmacyBranchId.HasValue ? "" : bills.FirstOrDefault()?.BranchIdentifier)}\n\n", times) { Alignment = Element.ALIGN_LEFT, Font = times });


            #region Table 
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;
            table.AddCell(new PdfPCell(new Phrase("CREATED DATE")) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("BRANCH")) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("USER")) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("BILL NUMBER")) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("AMOUNT")) { HorizontalAlignment = Element.ALIGN_CENTER });

            foreach (var branchItems in bills.GroupBy(x => x.BranchIdentifier))
            {
                foreach (var item in branchItems.OrderBy(x => x.CreatedDateTime))
                {
                    table.AddCell(new PdfPCell(new Phrase(item.CreatedDateTimeFormated)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.BranchIdentifier)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.UserFullName)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.Number)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.Amount.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                table.AddCell(new PdfPCell(new Phrase("BRANCH TOTAL:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase(branchItems.Sum(x => x.Amount).ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }

            table.AddCell(new PdfPCell(new Phrase("TOTAL:")) { HorizontalAlignment = Element.ALIGN_LEFT });
            table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
            table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
            table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
            table.AddCell(new PdfPCell(new Phrase(bills.Sum(x => x.Amount).ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
            doc.Add(table);
            //Paragraph footer = new Paragraph($"Footer neki €", times)
            //{
            //    Alignment = Element.ALIGN_CENTER,
            //    Font = times
            //};
            //doc.Add(footer);
            doc.Add(new Paragraph("\n"));
            #endregion



            doc.Close();

            MessageBox.Show("Report successfully saved to desktop.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                var id = row.Cells[0].Value;
                var user = row.Cells[4].Value;
                var billNumber = row.Cells[5].Value;
                var createdDate = row.Cells[2].Value;

                var searchBillItems = new BillItemSearchObject()
                {
                    BillId = int.Parse(id.ToString()),
                    IncludeBranchFiltering = true
                };
                var billItems = await _aPIServiceBillItems.Get<List<BillItemDto>>(searchBillItems);


                Stream stream = File.OpenWrite($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Bill_No_{billNumber}_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.pdf");
                Document doc = new Document();
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN);

                doc.Add(new Paragraph($"BILL: {billNumber} \n\n\n", times) { Alignment = Element.ALIGN_CENTER, Font = times });


                #region Table 
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.AddCell(new PdfPCell(new Phrase("PRODUCT")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("CODE")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("PRICE")) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase("QUANTITY")) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase("TOTAL")) { HorizontalAlignment = Element.ALIGN_RIGHT });


                foreach (var item in billItems)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.Product)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.ProductCode)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.Price.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(item.Amount.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                table.AddCell(new PdfPCell(new Phrase("TOTAL:")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase("/")) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase(billItems.Sum(x => x.Amount).ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });


                doc.Add(table);
               
                doc.Add(new Paragraph("\n\n\n"));
                doc.Add(new Paragraph($"Bill ({billNumber}) issued by {user} at {createdDate}: \n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
                #endregion



                doc.Close();

                MessageBox.Show("Report successfully saved to desktop.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
