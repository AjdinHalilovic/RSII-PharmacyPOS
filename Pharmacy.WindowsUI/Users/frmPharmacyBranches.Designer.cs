namespace Pharmacy.WindowsUI.Users
{
    partial class frmPharmacyBranches
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pharmacyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIdentifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centralDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pharmacyBranchDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.personDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyBranchDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsers);
            this.groupBox1.Location = new System.Drawing.Point(13, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1308, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Branch offices";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.pharmacyIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.branchIdentifierDataGridViewTextBoxColumn,
            this.centralDataGridViewCheckBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn});
            this.dgvUsers.DataSource = this.pharmacyBranchDtoBindingSource;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(3, 17);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(1302, 379);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvKorisnici_Scroll);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // pharmacyIdDataGridViewTextBoxColumn
            // 
            this.pharmacyIdDataGridViewTextBoxColumn.DataPropertyName = "PharmacyId";
            this.pharmacyIdDataGridViewTextBoxColumn.HeaderText = "PharmacyId";
            this.pharmacyIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pharmacyIdDataGridViewTextBoxColumn.Name = "pharmacyIdDataGridViewTextBoxColumn";
            this.pharmacyIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.pharmacyIdDataGridViewTextBoxColumn.Visible = false;
            this.pharmacyIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // branchIdentifierDataGridViewTextBoxColumn
            // 
            this.branchIdentifierDataGridViewTextBoxColumn.DataPropertyName = "BranchIdentifier";
            this.branchIdentifierDataGridViewTextBoxColumn.HeaderText = "BranchIdentifier";
            this.branchIdentifierDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.branchIdentifierDataGridViewTextBoxColumn.Name = "branchIdentifierDataGridViewTextBoxColumn";
            this.branchIdentifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchIdentifierDataGridViewTextBoxColumn.Width = 125;
            // 
            // centralDataGridViewCheckBoxColumn
            // 
            this.centralDataGridViewCheckBoxColumn.DataPropertyName = "Central";
            this.centralDataGridViewCheckBoxColumn.HeaderText = "Central";
            this.centralDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.centralDataGridViewCheckBoxColumn.Name = "centralDataGridViewCheckBoxColumn";
            this.centralDataGridViewCheckBoxColumn.ReadOnly = true;
            this.centralDataGridViewCheckBoxColumn.Width = 125;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryDataGridViewTextBoxColumn.Width = 125;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // pharmacyBranchDtoBindingSource
            // 
            this.pharmacyBranchDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.PharmacyBranchDto);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(1217, 17);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(101, 32);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Show";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_ClickAsync);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(16, 14);
            this.txtPretraga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPretraga.Multiline = true;
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(652, 32);
            this.txtPretraga.TabIndex = 2;
            // 
            // personDtoBindingSource
            // 
            this.personDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.PersonDto);
            // 
            // frmPharmacyBranches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 462);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPharmacyBranches";
            this.Text = "POS Pharmacy - Branches";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyBranchDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.BindingSource personDtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pharmacyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIdentifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn centralDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pharmacyBranchDtoBindingSource;
    }
}