namespace Pharmacy.WindowsUI.Billing
{
    partial class frmProductDetails
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
            this.lblUserDetails = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.comboMeasurementUnitId = new System.Windows.Forms.ComboBox();
            this.lblMeasurementUnit = new System.Windows.Forms.Label();
            this.clbCategories = new System.Windows.Forms.CheckedListBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lblSubstances = new System.Windows.Forms.Label();
            this.clbSubstances = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProductAttributes = new System.Windows.Forms.DataGridView();
            this.lblAttribute = new System.Windows.Forms.Label();
            this.lblAttributeOption = new System.Windows.Forms.Label();
            this.comboAttributeOptionId = new System.Windows.Forms.ComboBox();
            this.comboAttributeId = new System.Windows.Forms.ComboBox();
            this.btnAddProductAttribute = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeOptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeOptionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.personAttributeDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personAttributeDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblUserDetails
            // 
            this.lblUserDetails.AutoSize = true;
            this.lblUserDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDetails.Location = new System.Drawing.Point(34, 20);
            this.lblUserDetails.Name = "lblUserDetails";
            this.lblUserDetails.Size = new System.Drawing.Size(117, 17);
            this.lblUserDetails.TabIndex = 44;
            this.lblUserDetails.Text = "Product details";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(438, 54);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 48;
            this.lblCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(438, 74);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(349, 20);
            this.txtCode.TabIndex = 47;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(38, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 46;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(38, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(362, 20);
            this.txtName.TabIndex = 45;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(438, 100);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 50;
            this.lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(438, 119);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(349, 20);
            this.txtPrice.TabIndex = 49;
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            // 
            // comboMeasurementUnitId
            // 
            this.comboMeasurementUnitId.FormattingEnabled = true;
            this.comboMeasurementUnitId.Location = new System.Drawing.Point(38, 119);
            this.comboMeasurementUnitId.Margin = new System.Windows.Forms.Padding(2);
            this.comboMeasurementUnitId.Name = "comboMeasurementUnitId";
            this.comboMeasurementUnitId.Size = new System.Drawing.Size(362, 21);
            this.comboMeasurementUnitId.TabIndex = 51;
            this.comboMeasurementUnitId.Validating += new System.ComponentModel.CancelEventHandler(this.comboMeasurementUnitId_Validating);
            // 
            // lblMeasurementUnit
            // 
            this.lblMeasurementUnit.AutoSize = true;
            this.lblMeasurementUnit.Location = new System.Drawing.Point(38, 103);
            this.lblMeasurementUnit.Name = "lblMeasurementUnit";
            this.lblMeasurementUnit.Size = new System.Drawing.Size(91, 13);
            this.lblMeasurementUnit.TabIndex = 52;
            this.lblMeasurementUnit.Text = "Measurement unit";
            // 
            // clbCategories
            // 
            this.clbCategories.FormattingEnabled = true;
            this.clbCategories.Location = new System.Drawing.Point(34, 259);
            this.clbCategories.Name = "clbCategories";
            this.clbCategories.Size = new System.Drawing.Size(362, 79);
            this.clbCategories.TabIndex = 53;
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(34, 242);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(57, 13);
            this.lblCategories.TabIndex = 54;
            this.lblCategories.Text = "Categories";
            // 
            // lblSubstances
            // 
            this.lblSubstances.AutoSize = true;
            this.lblSubstances.Location = new System.Drawing.Point(434, 242);
            this.lblSubstances.Name = "lblSubstances";
            this.lblSubstances.Size = new System.Drawing.Size(63, 13);
            this.lblSubstances.TabIndex = 56;
            this.lblSubstances.Text = "Substances";
            // 
            // clbSubstances
            // 
            this.clbSubstances.FormattingEnabled = true;
            this.clbSubstances.Location = new System.Drawing.Point(434, 259);
            this.clbSubstances.Name = "clbSubstances";
            this.clbSubstances.Size = new System.Drawing.Size(349, 79);
            this.clbSubstances.TabIndex = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProductAttributes);
            this.groupBox1.Controls.Add(this.lblAttribute);
            this.groupBox1.Controls.Add(this.lblAttributeOption);
            this.groupBox1.Controls.Add(this.comboAttributeOptionId);
            this.groupBox1.Controls.Add(this.comboAttributeId);
            this.groupBox1.Controls.Add(this.btnAddProductAttribute);
            this.groupBox1.Location = new System.Drawing.Point(34, 357);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(749, 149);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // dgvProductAttributes
            // 
            this.dgvProductAttributes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProductAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.AttributeId,
            this.Attribute,
            this.AttributeOptionId,
            this.AttributeOptionValue,
            this.Action});
            this.dgvProductAttributes.Location = new System.Drawing.Point(400, 15);
            this.dgvProductAttributes.Name = "dgvProductAttributes";
            this.dgvProductAttributes.Size = new System.Drawing.Size(346, 129);
            this.dgvProductAttributes.TabIndex = 0;
            this.dgvProductAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductAttributes_CellContentClick);
            // 
            // lblAttribute
            // 
            this.lblAttribute.AutoSize = true;
            this.lblAttribute.Location = new System.Drawing.Point(6, 18);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(46, 13);
            this.lblAttribute.TabIndex = 64;
            this.lblAttribute.Text = "Attribute";
            // 
            // lblAttributeOption
            // 
            this.lblAttributeOption.AutoSize = true;
            this.lblAttributeOption.Location = new System.Drawing.Point(6, 60);
            this.lblAttributeOption.Name = "lblAttributeOption";
            this.lblAttributeOption.Size = new System.Drawing.Size(80, 13);
            this.lblAttributeOption.TabIndex = 66;
            this.lblAttributeOption.Text = "Attribute Option";
            // 
            // comboAttributeOptionId
            // 
            this.comboAttributeOptionId.FormattingEnabled = true;
            this.comboAttributeOptionId.Location = new System.Drawing.Point(9, 75);
            this.comboAttributeOptionId.Margin = new System.Windows.Forms.Padding(2);
            this.comboAttributeOptionId.Name = "comboAttributeOptionId";
            this.comboAttributeOptionId.Size = new System.Drawing.Size(353, 21);
            this.comboAttributeOptionId.TabIndex = 65;
            // 
            // comboAttributeId
            // 
            this.comboAttributeId.FormattingEnabled = true;
            this.comboAttributeId.Location = new System.Drawing.Point(9, 33);
            this.comboAttributeId.Margin = new System.Windows.Forms.Padding(2);
            this.comboAttributeId.Name = "comboAttributeId";
            this.comboAttributeId.Size = new System.Drawing.Size(353, 21);
            this.comboAttributeId.TabIndex = 63;
            this.comboAttributeId.SelectedValueChanged += new System.EventHandler(this.comboAttributeId_SelectedValueChanged);
            // 
            // btnAddProductAttribute
            // 
            this.btnAddProductAttribute.Location = new System.Drawing.Point(212, 122);
            this.btnAddProductAttribute.Name = "btnAddProductAttribute";
            this.btnAddProductAttribute.Size = new System.Drawing.Size(150, 22);
            this.btnAddProductAttribute.TabIndex = 59;
            this.btnAddProductAttribute.Text = "Add product attribute";
            this.btnAddProductAttribute.UseVisualStyleBackColor = true;
            this.btnAddProductAttribute.Click += new System.EventHandler(this.btnAddProductAttribute_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(338, 528);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(149, 32);
            this.btnSaveUser.TabIndex = 58;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(44, 542);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(30, 20);
            this.txtId.TabIndex = 60;
            this.txtId.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(37, 170);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(746, 61);
            this.txtDescription.TabIndex = 61;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(38, 154);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 62;
            this.lblDescription.Text = "Description";
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // AttributeId
            // 
            this.AttributeId.HeaderText = "AttributeId";
            this.AttributeId.Name = "AttributeId";
            this.AttributeId.Visible = false;
            // 
            // Attribute
            // 
            this.Attribute.DataPropertyName = "Attribute";
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            // 
            // AttributeOptionId
            // 
            this.AttributeOptionId.HeaderText = "AttributeOptionId";
            this.AttributeOptionId.Name = "AttributeOptionId";
            this.AttributeOptionId.Visible = false;
            // 
            // AttributeOptionValue
            // 
            this.AttributeOptionValue.DataPropertyName = "AttributeOptionValue";
            this.AttributeOptionValue.HeaderText = "Attribute value";
            this.AttributeOptionValue.Name = "AttributeOptionValue";
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.Text = "Delete";
            this.Action.ToolTipText = "Delete";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // personAttributeDtoBindingSource
            // 
            //this.personAttributeDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductAttributeDto);
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 572);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSubstances);
            this.Controls.Add(this.clbSubstances);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.clbCategories);
            this.Controls.Add(this.lblMeasurementUnit);
            this.Controls.Add(this.comboMeasurementUnitId);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblUserDetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmProductDetails";
            this.Text = "Product details";
            this.Load += new System.EventHandler(this.frmProductDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personAttributeDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblUserDetails;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblMeasurementUnit;
        private System.Windows.Forms.ComboBox comboMeasurementUnitId;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.CheckedListBox clbCategories;
        private System.Windows.Forms.Label lblSubstances;
        private System.Windows.Forms.CheckedListBox clbSubstances;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAddProductAttribute;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.BindingSource personAttributeDtoBindingSource;
        private System.Windows.Forms.Label lblAttributeOption;
        private System.Windows.Forms.Label lblAttribute;
        private System.Windows.Forms.ComboBox comboAttributeOptionId;
        private System.Windows.Forms.ComboBox comboAttributeId;
        public System.Windows.Forms.DataGridView dgvProductAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeOptionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeOptionValue;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}