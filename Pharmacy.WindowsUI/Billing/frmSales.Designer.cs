namespace Pharmacy.WindowsUI.Billing
{
    partial class frmSales
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPharmacyBranchId = new System.Windows.Forms.ComboBox();
            this.billDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.baseDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.billDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.billDtoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateTimeFormatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIdentifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userFullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtoBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1115, 15);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 32);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Print";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(1008, 15);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(101, 32);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_ClickAsync);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dgvProducts);
            this.groupBox1.Location = new System.Drawing.Point(9, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1211, 414);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.createdDateTimeDataGridViewTextBoxColumn,
            this.createdDateTimeFormatedDataGridViewTextBoxColumn,
            this.branchIdentifierDataGridViewTextBoxColumn,
            this.userFullNameDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dgvProducts.DataSource = this.billDtoBindingSource2;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 17);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(1205, 395);
            this.dgvProducts.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(648, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 82;
            this.label4.Text = "Date to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 81;
            this.label3.Text = "Date from";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(651, 23);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(244, 22);
            this.dateTimePickerTo.TabIndex = 80;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(385, 24);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(247, 22);
            this.dateTimePickerFrom.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Search by branch";
            // 
            // comboPharmacyBranchId
            // 
            this.comboPharmacyBranchId.FormattingEnabled = true;
            this.comboPharmacyBranchId.Location = new System.Drawing.Point(17, 23);
            this.comboPharmacyBranchId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboPharmacyBranchId.Name = "comboPharmacyBranchId";
            this.comboPharmacyBranchId.Size = new System.Drawing.Size(353, 24);
            this.comboPharmacyBranchId.TabIndex = 77;
            // 
            // billDtoBindingSource
            // 
            this.billDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.BillDto);
            // 
            // productDtoBindingSource1
            // 
            this.productDtoBindingSource1.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductDto);
            // 
            // baseDtoBindingSource
            // 
            this.baseDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.BaseDto);
            // 
            // productDtoBindingSource
            // 
            this.productDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductDto);
            // 
            // billDtoBindingSource1
            // 
            this.billDtoBindingSource1.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.BillDto);
            // 
            // billDtoBindingSource2
            // 
            this.billDtoBindingSource2.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.BillDto);
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
            // createdDateTimeDataGridViewTextBoxColumn
            // 
            this.createdDateTimeDataGridViewTextBoxColumn.DataPropertyName = "CreatedDateTime";
            this.createdDateTimeDataGridViewTextBoxColumn.HeaderText = "CreatedDateTime";
            this.createdDateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.createdDateTimeDataGridViewTextBoxColumn.Name = "createdDateTimeDataGridViewTextBoxColumn";
            this.createdDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDateTimeDataGridViewTextBoxColumn.Visible = false;
            this.createdDateTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // createdDateTimeFormatedDataGridViewTextBoxColumn
            // 
            this.createdDateTimeFormatedDataGridViewTextBoxColumn.DataPropertyName = "CreatedDateTimeFormated";
            this.createdDateTimeFormatedDataGridViewTextBoxColumn.HeaderText = "Created date";
            this.createdDateTimeFormatedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.createdDateTimeFormatedDataGridViewTextBoxColumn.Name = "createdDateTimeFormatedDataGridViewTextBoxColumn";
            this.createdDateTimeFormatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDateTimeFormatedDataGridViewTextBoxColumn.Width = 125;
            // 
            // branchIdentifierDataGridViewTextBoxColumn
            // 
            this.branchIdentifierDataGridViewTextBoxColumn.DataPropertyName = "BranchIdentifier";
            this.branchIdentifierDataGridViewTextBoxColumn.HeaderText = "Branch";
            this.branchIdentifierDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.branchIdentifierDataGridViewTextBoxColumn.Name = "branchIdentifierDataGridViewTextBoxColumn";
            this.branchIdentifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchIdentifierDataGridViewTextBoxColumn.Width = 125;
            // 
            // userFullNameDataGridViewTextBoxColumn
            // 
            this.userFullNameDataGridViewTextBoxColumn.DataPropertyName = "UserFullName";
            this.userFullNameDataGridViewTextBoxColumn.HeaderText = "User";
            this.userFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userFullNameDataGridViewTextBoxColumn.Name = "userFullNameDataGridViewTextBoxColumn";
            this.userFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userFullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Bill number";
            this.numberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Visible = false;
            this.amountDataGridViewTextBoxColumn.Width = 125;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 464);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPharmacyBranchId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billDtoBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.BindingSource baseDtoBindingSource;
        private System.Windows.Forms.BindingSource productDtoBindingSource1;
        private System.Windows.Forms.BindingSource productDtoBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPharmacyBranchId;
        private System.Windows.Forms.BindingSource billDtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateTimeFormatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIdentifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userFullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource billDtoBindingSource2;
        private System.Windows.Forms.BindingSource billDtoBindingSource1;
    }
}