using Flurl.Http;
using Pharmacy.WindowsUI.Billing;
using Pharmacy.WindowsUI.Settings;
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
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private async void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/Users/Logout";
                var response = await url.WithOAuthBearerToken(APIService._token).GetAsync();

                APIService._token = null;
                APIService._userFullName = null;
                this.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            menuItemFullName.Text = APIService._userFullName;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmUsers = new frmUsers();
            frmUsers.WindowState = FormWindowState.Maximized;
            frmUsers.MdiParent = this;
            frmUsers.Show();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCategories = new frmCategories();
            frmCategories.WindowState = FormWindowState.Maximized;
            frmCategories.MdiParent = this;
            frmCategories.Show();
        }

        private void attributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAttributes = new frmAttributes();
            frmAttributes.WindowState = FormWindowState.Maximized;
            frmAttributes.MdiParent = this;
            frmAttributes.Show();
        }

        private void substancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSubstances = new frmSubstances();
            frmSubstances.WindowState = FormWindowState.Maximized;
            frmSubstances.MdiParent = this;
            frmSubstances.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmProducts = new frmProducts();
            frmProducts.WindowState = FormWindowState.Maximized;
            frmProducts.MdiParent = this;
            frmProducts.Show();
        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmBiling = new frmBiling();
            frmBiling.WindowState = FormWindowState.Maximized;
            frmBiling.MdiParent = this;
            frmBiling.Show();
        }
    }
}
