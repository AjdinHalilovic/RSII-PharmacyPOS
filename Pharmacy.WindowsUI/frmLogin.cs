using Flurl.Http;
using Pharmacy.Core.Models.Access;
using Pharmacy.WindowsUI.Users;
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
            AutoValidate = AutoValidate.Disable;
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
                APIService._userFullName = response.UserFullName;
                APIService._isAdmin = response.IsAdmin;
                APIService._branchIdentifier = response.BranchIdentifier;

                frmIndex frm = new frmIndex();
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();


            }
            catch (FlurlHttpException ex)
            {
                MessageBox.Show("Incorect username or password");
            }
        }

        

        private void lblLinkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Show();
        }
    }
}
