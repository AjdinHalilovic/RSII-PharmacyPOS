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
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Users;

namespace Pharmacy.WindowsUI.Users
{
    public partial class frmUsers : Form
    {
        private readonly APIService _aPIServiceUsers = new APIService("Users");
        private readonly APIService _aPIServicePersons = new APIService("Persons");
        public frmUsers()
        {
            InitializeComponent();
        }

        private void dgvKorisnici_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private async void btnPrikazi_ClickAsync(object sender, EventArgs e)
        {
            var searchObj = new PersonSearchObject()
            {
                FullName = txtPretraga.Text
            };
            var result = await _aPIServicePersons.Get<List<PersonDto>>(searchObj);

            dgvUsers.DataSource = result;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var userId = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());

            frmUserDetails frm = new frmUserDetails(userId);
            frm.Show();
        }
    }
}
