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
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRowDeleteBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCategoryId = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBillItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.substancesNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).BeginInit();
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
            this.lblBiling.Location = new System.Drawing.Point(34, 7);
            this.lblBiling.Name = "lblBiling";
            this.lblBiling.Size = new System.Drawing.Size(52, 17);
            this.lblBiling.TabIndex = 44;
            this.lblBiling.Text = "Billing";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(582, 411);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(347, 32);
            this.btnSaveUser.TabIndex = 58;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(39, 423);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(30, 20);
            this.txtId.TabIndex = 60;
            this.txtId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.dgvProducts);
            this.groupBox2.Location = new System.Drawing.Point(37, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(818, 282);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select products";
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
            this.dgvProducts.Location = new System.Drawing.Point(2, 15);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(814, 265);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductAttributes_CellContentClickAsync);
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
            // dgvRowDeleteBtn
            // 
            this.dgvRowDeleteBtn.HeaderText = "Action";
            this.dgvRowDeleteBtn.MinimumWidth = 6;
            this.dgvRowDeleteBtn.Name = "dgvRowDeleteBtn";
            this.dgvRowDeleteBtn.ReadOnly = true;
            this.dgvRowDeleteBtn.Text = "Add item";
            this.dgvRowDeleteBtn.ToolTipText = "Add item";
            this.dgvRowDeleteBtn.UseColumnTextForButtonValue = true;
            this.dgvRowDeleteBtn.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Category";
            // 
            // comboCategoryId
            // 
            this.comboCategoryId.FormattingEnabled = true;
            this.comboCategoryId.Location = new System.Drawing.Point(461, 52);
            this.comboCategoryId.Margin = new System.Windows.Forms.Padding(2);
            this.comboCategoryId.Name = "comboCategoryId";
            this.comboCategoryId.Size = new System.Drawing.Size(392, 21);
            this.comboCategoryId.TabIndex = 67;
            this.comboCategoryId.SelectedValueChanged += new System.EventHandler(this.comboCategoryId_ValueMemberChangedAsync);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(37, 52);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(408, 21);
            this.txtSearch.TabIndex = 69;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChangedAsync);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Search";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.dgvBillItems);
            this.groupBox3.Location = new System.Drawing.Point(885, 76);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(563, 280);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Products";
            // 
            // dgvBillItems
            // 
            this.dgvBillItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Attribute,
            this.Quantity,
            this.Action});
            this.dgvBillItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillItems.Location = new System.Drawing.Point(2, 15);
            this.dgvBillItems.Name = "dgvBillItems";
            this.dgvBillItems.ReadOnly = true;
            this.dgvBillItems.Size = new System.Drawing.Size(559, 263);
            this.dgvBillItems.TabIndex = 1;
            this.dgvBillItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillItems_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Attribute
            // 
            this.Attribute.DataPropertyName = "Price";
            this.Attribute.HeaderText = "Price";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Text = "Remove";
            this.Action.ToolTipText = "Remove";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(884, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "Total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1401, 358);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 17);
            this.lblTotal.TabIndex = 73;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // productDtoBindingSource
            // 
            this.productDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductDto);
            // 
            // frmBiling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 572);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboCategoryId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.lblBiling);
            this.Margin = new System.Windows.Forms.Padding(2);
            //this.Name = "frmBiling";
            this.Text = "Billing";
            this.Load += new System.EventHandler(this.frmBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblBiling;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource productDtoBindingSource;
        private System.Windows.Forms.ComboBox comboCategoryId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
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
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DataGridView dgvBillItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
    }
}