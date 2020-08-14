using Flurl.Http;
using Pharmacy.Core.Models.Access;
using Pharmacy.WindowsUI.Korisnici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.WindowsUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _aPIService = new APIService("Users");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                LoginRequest request = new LoginRequest()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };
                var url = $"{Properties.Settings.Default.APIUrl}/Users/Login/Token";

                TokenResponse response = await url.PostJsonAsync(request).ReceiveJson<TokenResponse>();

                //TokenResponse response = await _aPIService.Insert<TokenResponse>(request);
                APIService._token = response.AccessToken;

                frmIndex frm = new frmIndex();
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        

        private void lblLinkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Show();
        }
    }
}
