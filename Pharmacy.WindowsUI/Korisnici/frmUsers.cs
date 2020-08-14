using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using Pharmacy.Core.Entities.Base;

namespace Pharmacy.WindowsUI.Korisnici
{
    public partial class frmUsers : Form
    {
        private readonly APIService _aPIService = new APIService("Users");
        public frmUsers()
        {
            InitializeComponent();
        }

        private void dgvKorisnici_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private async void btnPrikazi_ClickAsync(object sender, EventArgs e)
        {
            string searchObj = txtPretraga.Text;
            var result = await _aPIService.Get<List<User>>(searchObj);

            dgvKorisnici.DataSource = result;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
