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
    public partial class frmReports : Form
    {
        private readonly APIService _aPIServiceBills = new APIService("Bills");
        private readonly APIService _aPIServicePersons = new APIService("Persons");
        private readonly APIService _aPIServiceProducts = new APIService("Products");
        private readonly APIService _aPIServiceBillItems = new APIService("BillItems");

        public frmReports()
        {
            InitializeComponent();
        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            dateTimePickerTo.Value = DateTime.Now;

            dateTimePickerFromProduct.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            dateTimePickerToProduct.Value = DateTime.Now;

            await LoadUsers();
            await LoadProducts();
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

        private async Task LoadProducts()
        {
            var result = await _aPIServiceProducts.Get<List<ProductDto>>(null);
            result.Insert(0, new ProductDto() { Name = "Select product", Id = 0 });
            comboProductId.ValueMember = "Id";
            comboProductId.DisplayMember = "Name";
            comboProductId.DataSource = result;
        }

        private async Task LoadProductsChart()
        {
            var searchByProduct = new BillSearchObject()
            {
                DateFrom = dateTimePickerFromProduct.Value,
                DateTo = dateTimePickerToProduct.Value,
                SearchTerm = string.Empty,
                ProductId = comboProductId.SelectedValue != null && int.Parse(comboProductId.SelectedValue.ToString()) != 0 ? int.Parse(comboProductId.SelectedValue.ToString()) : (int?)null
            };
            var billsByProduct = await _aPIServiceBills.Get<List<BillDto>>(searchByProduct);

            List<decimal> valuesProductY = new List<decimal>();
            List<DateTime> valuesProductX = new List<DateTime>();

            billsByProduct.ForEach(x => { valuesProductY.Add(x.Amount); valuesProductX.Add(x.CreatedDateTime); });

            if (!valuesProductX.Any())
            {
                valuesProductX.Add(dateTimePickerFromProduct.Value);
                valuesProductX.Add(dateTimePickerToProduct.Value);
            }

            if (!valuesProductY.Any())
            {
                valuesProductY.Add(0);
                valuesProductY.Add(0);
            }

            chartSalesByProduct.Series["Prihod"].Points.DataBindXY(valuesProductX, valuesProductY);
        }

        private async Task LoadSalesChart()
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

            bills.GroupBy(x => x.CreatedDateTime.ToShortDateString())
                .Select(x => new BillDto { Amount = x.Sum(y => y.Amount), CreatedDateTime = x.FirstOrDefault().CreatedDateTime }).ToList()
                .ForEach(x => { valuesY.Add(x.Amount); valuesX.Add(x.CreatedDateTime); });

            
            if (!valuesX.Any())
            {
                valuesX.Add(dateTimePickerFrom.Value);
                valuesX.Add(dateTimePickerTo.Value);
            }

            if (!valuesY.Any())
            {
                valuesY.Add(0);
                valuesY.Add(0);
            }

            chartSalesByTime.Series["Prihod"].Points.DataBindXY(valuesX, valuesY);
        }
        async Task LoadCharts()
        {
            try
            {
                await LoadSalesChart();

                await LoadProductsChart();

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private async void comboCategoryId_ValueMemberChanged(object sender, EventArgs e)
        {
            await LoadSalesChart();
        }

        private async void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            await LoadSalesChart();
        }

        private async void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            await LoadSalesChart();
        }

        private async void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            await LoadSalesChart();
        }

        private async void refreshChartsBtn_Click(object sender, EventArgs e)
        {
            await LoadCharts();
        }

        private async void comboProductId_SelectedValueChanged(object sender, EventArgs e)
        {
            await LoadProductsChart();
        }

        private async void printDetailsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                #region Data
                var search = new BillSearchObject()
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value,
                    SearchTerm = string.Empty,
                    UserId = comboUserId.SelectedValue != null && int.Parse(comboUserId.SelectedValue.ToString()) != 0 ? int.Parse(comboUserId.SelectedValue.ToString()) : (int?)null
                };
                var bills = await _aPIServiceBills.Get<List<BillDto>>(search);

                //var searchByProduct = new BillSearchObject()
                //{
                //    DateFrom = dateTimePickerFromProduct.Value,
                //    DateTo = dateTimePickerToProduct.Value,
                //    SearchTerm = string.Empty,
                //    ProductId = comboProductId.SelectedValue != null && int.Parse(comboProductId.SelectedValue.ToString()) != 0 ? int.Parse(comboProductId.SelectedValue.ToString()) : (int?)null
                //};
                //var billsByProduct = await _aPIServiceBills.Get<List<BillDto>>(searchByProduct);

                var searchBillItems = new BillItemSearchObject()
                {
                    DateFrom = dateTimePickerFromProduct.Value,
                    DateTo = dateTimePickerToProduct.Value,
                    SearchTerm = string.Empty,
                    ProductId = comboProductId.SelectedValue != null && int.Parse(comboProductId.SelectedValue.ToString()) != 0 ? int.Parse(comboProductId.SelectedValue.ToString()) : (int?)null
                };
                var billItems = await _aPIServiceBillItems.Get<List<BillItemDto>>(searchBillItems);
                #endregion

                Stream stream = File.OpenWrite($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\SalesCharts{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf");
                Document doc = new Document();
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                iTextSharp.text.Font times = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN);

                doc.Add(new Paragraph($"Report for sales by users \n\n", times) { Alignment = Element.ALIGN_CENTER, Font = times });
                doc.Add(new Paragraph($"The report refers to the: \n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
                doc.Add(new Paragraph($"-Period:{search.DateFrom?.ToString()} - {search.DateTo?.ToString()}\n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
                doc.Add(new Paragraph($"-and to the {(!search.UserId.HasValue ? "all":"")} user{(!search.UserId.HasValue ? "s" : "")} {(!search.UserId.HasValue ? "" : bills.FirstOrDefault()?.UserFullName)}\n\n", times) { Alignment = Element.ALIGN_LEFT, Font = times });


                #region Table 
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.AddCell(new PdfPCell(new Phrase("CREATED DATE")) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("STAFF")) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("AMOUNT")) { HorizontalAlignment = Element.ALIGN_CENTER });
                foreach (var item in bills)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.CreatedDateTimeFormated)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.UserFullName)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase(item.Amount.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                doc.Add(table);
                //Paragraph footer = new Paragraph($"Footer neki €", times)
                //{
                //    Alignment = Element.ALIGN_CENTER,
                //    Font = times
                //};
                //doc.Add(footer);
                doc.Add(new Paragraph("\n"));
                #endregion

                doc.Add(new Paragraph($"Report for sales by products \n\n", times) { Alignment = Element.ALIGN_CENTER, Font = times });
                doc.Add(new Paragraph($"The report refers to the: \n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
                doc.Add(new Paragraph($"-Period: {searchBillItems.DateFrom?.ToString()} - {searchBillItems.DateTo?.ToString()} \n", times) { Alignment = Element.ALIGN_LEFT, Font = times });
                doc.Add(new Paragraph($"-and to the {(!searchBillItems.ProductId.HasValue ? "all" : "")} product{(!searchBillItems.ProductId.HasValue ? "s" : "")} {(!searchBillItems.ProductId.HasValue ? "" : billItems.FirstOrDefault()?.Product)} \n\n", times) { Alignment = Element.ALIGN_LEFT, Font = times });

                #region Table 2
                PdfPTable tableByProduct = new PdfPTable(3);
                tableByProduct.WidthPercentage = 100;
                tableByProduct.AddCell(new PdfPCell(new Phrase("PRODUCT")) { HorizontalAlignment = Element.ALIGN_CENTER });
                tableByProduct.AddCell(new PdfPCell(new Phrase("QUANTITY")) { HorizontalAlignment = Element.ALIGN_CENTER });
                tableByProduct.AddCell(new PdfPCell(new Phrase("AMOUNT")) { HorizontalAlignment = Element.ALIGN_CENTER });
                foreach (var item in billItems.GroupBy(x=>x.Product))
                {
                    tableByProduct.AddCell(new PdfPCell(new Phrase(item.Key)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    tableByProduct.AddCell(new PdfPCell(new Phrase(item.Sum(x=>x.Quantity).ToString())) { HorizontalAlignment = Element.ALIGN_LEFT });
                    tableByProduct.AddCell(new PdfPCell(new Phrase(item.Sum(x=>x.Amount).ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                doc.Add(tableByProduct);
                #endregion

                doc.Close();

                MessageBox.Show("Report successfully saved to desktop.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void dateTimePickerFromProduct_ValueChanged(object sender, EventArgs e)
        {
            await LoadProductsChart();
        }

        private async void dateTimePickerToProduct_ValueChanged(object sender, EventArgs e)
        {
            await LoadProductsChart();
        }
    }
}
