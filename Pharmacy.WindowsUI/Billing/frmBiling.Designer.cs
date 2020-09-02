namespace Pharmacy.WindowsUI.Billing
{
    partial class frmBiling
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblBiling = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAttribute = new System.Windows.Forms.Label();
            this.lblAttributeOption = new System.Windows.Forms.Label();
            this.comboAttributeOptionId = new System.Windows.Forms.ComboBox();
            this.comboAttributeId = new System.Windows.Forms.ComboBox();
            this.btnAddProductAttribute = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.productDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.substancesNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRowDeleteBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCategoryId = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblBiling
            // 
            this.lblBiling.AutoSize = true;
            this.lblBiling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiling.Location = new System.Drawing.Point(45, 9);
            this.lblBiling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBiling.Name = "lblBiling";
            this.lblBiling.Size = new System.Drawing.Size(65, 22);
            this.lblBiling.TabIndex = 44;
            this.lblBiling.Text = "Billing";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAttribute);
            this.groupBox1.Controls.Add(this.lblAttributeOption);
            this.groupBox1.Controls.Add(this.comboAttributeOptionId);
            this.groupBox1.Controls.Add(this.comboAttributeId);
            this.groupBox1.Controls.Add(this.btnAddProductAttribute);
            this.groupBox1.Location = new System.Drawing.Point(45, 439);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(999, 183);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // lblAttribute
            // 
            this.lblAttribute.AutoSize = true;
            this.lblAttribute.Location = new System.Drawing.Point(8, 22);
            this.lblAttribute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(61, 17);
            this.lblAttribute.TabIndex = 64;
            this.lblAttribute.Text = "Attribute";
            // 
            // lblAttributeOption
            // 
            this.lblAttributeOption.AutoSize = true;
            this.lblAttributeOption.Location = new System.Drawing.Point(8, 74);
            this.lblAttributeOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttributeOption.Name = "lblAttributeOption";
            this.lblAttributeOption.Size = new System.Drawing.Size(107, 17);
            this.lblAttributeOption.TabIndex = 66;
            this.lblAttributeOption.Text = "Attribute Option";
            // 
            // comboAttributeOptionId
            // 
            this.comboAttributeOptionId.FormattingEnabled = true;
            this.comboAttributeOptionId.Location = new System.Drawing.Point(12, 92);
            this.comboAttributeOptionId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboAttributeOptionId.Name = "comboAttributeOptionId";
            this.comboAttributeOptionId.Size = new System.Drawing.Size(469, 24);
            this.comboAttributeOptionId.TabIndex = 65;
            // 
            // comboAttributeId
            // 
            this.comboAttributeId.FormattingEnabled = true;
            this.comboAttributeId.Location = new System.Drawing.Point(12, 41);
            this.comboAttributeId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboAttributeId.Name = "comboAttributeId";
            this.comboAttributeId.Size = new System.Drawing.Size(469, 24);
            this.comboAttributeId.TabIndex = 63;
            this.comboAttributeId.SelectedValueChanged += new System.EventHandler(this.comboAttributeId_SelectedValueChanged);
            // 
            // btnAddProductAttribute
            // 
            this.btnAddProductAttribute.Location = new System.Drawing.Point(283, 150);
            this.btnAddProductAttribute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddProductAttribute.Name = "btnAddProductAttribute";
            this.btnAddProductAttribute.Size = new System.Drawing.Size(200, 27);
            this.btnAddProductAttribute.TabIndex = 59;
            this.btnAddProductAttribute.Text = "Add product attribute";
            this.btnAddProductAttribute.UseVisualStyleBackColor = true;
            this.btnAddProductAttribute.Click += new System.EventHandler(this.btnAddProductAttribute_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(451, 650);
            this.btnSaveUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(199, 39);
            this.btnSaveUser.TabIndex = 58;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(59, 667);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(39, 22);
            this.txtId.TabIndex = 60;
            this.txtId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.dgvProducts);
            this.groupBox2.Location = new System.Drawing.Point(49, 93);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(686, 278);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Products";
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
            this.nameDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.Price,
            this.quantityDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.measurementUnitDataGridViewTextBoxColumn,
            this.categoriesDataGridViewTextBoxColumn,
            this.substancesNumberDataGridViewTextBoxColumn,
            this.attributeNumberDataGridViewTextBoxColumn,
            this.dgvRowDeleteBtn});
            this.dgvProducts.DataSource = this.productDtoBindingSource;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 17);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(680, 259);
            this.dgvProducts.TabIndex = 1;
            // 
            // productDtoBindingSource
            // 
            this.productDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductDto);
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
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            this.descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // measurementUnitDataGridViewTextBoxColumn
            // 
            this.measurementUnitDataGridViewTextBoxColumn.DataPropertyName = "MeasurementUnit";
            this.measurementUnitDataGridViewTextBoxColumn.HeaderText = "MeasurementUnit";
            this.measurementUnitDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.measurementUnitDataGridViewTextBoxColumn.Name = "measurementUnitDataGridViewTextBoxColumn";
            this.measurementUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.measurementUnitDataGridViewTextBoxColumn.Visible = false;
            this.measurementUnitDataGridViewTextBoxColumn.Width = 125;
            // 
            // categoriesDataGridViewTextBoxColumn
            // 
            this.categoriesDataGridViewTextBoxColumn.DataPropertyName = "Categories";
            this.categoriesDataGridViewTextBoxColumn.HeaderText = "Categories";
            this.categoriesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoriesDataGridViewTextBoxColumn.Name = "categoriesDataGridViewTextBoxColumn";
            this.categoriesDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoriesDataGridViewTextBoxColumn.Visible = false;
            this.categoriesDataGridViewTextBoxColumn.Width = 125;
            // 
            // substancesNumberDataGridViewTextBoxColumn
            // 
            this.substancesNumberDataGridViewTextBoxColumn.DataPropertyName = "SubstancesNumber";
            this.substancesNumberDataGridViewTextBoxColumn.HeaderText = "SubstancesNumber";
            this.substancesNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.substancesNumberDataGridViewTextBoxColumn.Name = "substancesNumberDataGridViewTextBoxColumn";
            this.substancesNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.substancesNumberDataGridViewTextBoxColumn.Visible = false;
            this.substancesNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // attributeNumberDataGridViewTextBoxColumn
            // 
            this.attributeNumberDataGridViewTextBoxColumn.DataPropertyName = "AttributeNumber";
            this.attributeNumberDataGridViewTextBoxColumn.HeaderText = "AttributeNumber";
            this.attributeNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.attributeNumberDataGridViewTextBoxColumn.Name = "attributeNumberDataGridViewTextBoxColumn";
            this.attributeNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.attributeNumberDataGridViewTextBoxColumn.Visible = false;
            this.attributeNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // dgvRowDeleteBtn
            // 
            this.dgvRowDeleteBtn.HeaderText = "Action";
            this.dgvRowDeleteBtn.MinimumWidth = 6;
            this.dgvRowDeleteBtn.Name = "dgvRowDeleteBtn";
            this.dgvRowDeleteBtn.ReadOnly = true;
            this.dgvRowDeleteBtn.Text = "Delete";
            this.dgvRowDeleteBtn.ToolTipText = "Delete";
            this.dgvRowDeleteBtn.UseColumnTextForButtonValue = true;
            this.dgvRowDeleteBtn.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Category";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboCategoryId
            // 
            this.comboCategoryId.FormattingEnabled = true;
            this.comboCategoryId.Location = new System.Drawing.Point(416, 65);
            this.comboCategoryId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboCategoryId.Name = "comboCategoryId";
            this.comboCategoryId.Size = new System.Drawing.Size(319, 24);
            this.comboCategoryId.TabIndex = 67;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(49, 65);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(346, 24);
            this.txtSearch.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Search";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(780, 213);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 84);
            this.listBox1.TabIndex = 71;
            // 
            // frmBiling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 704);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboCategoryId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBiling);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBiling";
            this.Text = "Billing";
            this.Load += new System.EventHandler(this.frmBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblBiling;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAddProductAttribute;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label lblAttributeOption;
        private System.Windows.Forms.Label lblAttribute;
        private System.Windows.Forms.ComboBox comboAttributeOptionId;
        private System.Windows.Forms.ComboBox comboAttributeId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measurementUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn substancesNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dgvRowDeleteBtn;
        private System.Windows.Forms.BindingSource productDtoBindingSource;
        private System.Windows.Forms.ComboBox comboCategoryId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox listBox1;
    }
}