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
            this.dgvProductAttributes = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeOptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeOptionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblAttribute = new System.Windows.Forms.Label();
            this.lblAttributeOption = new System.Windows.Forms.Label();
            this.comboAttributeOptionId = new System.Windows.Forms.ComboBox();
            this.comboAttributeId = new System.Windows.Forms.ComboBox();
            this.btnAddProductAttribute = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
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
            // lblBiling
            // 
            this.lblBiling.AutoSize = true;
            this.lblBiling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiling.Location = new System.Drawing.Point(34, 20);
            this.lblBiling.Name = "lblBiling";
            this.lblBiling.Size = new System.Drawing.Size(52, 17);
            this.lblBiling.TabIndex = 44;
            this.lblBiling.Text = "Billing";
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
            // personAttributeDtoBindingSource
            // 
            this.personAttributeDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductAttributeDto);
            // 
            // frmBiling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 572);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBiling);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBiling";
            this.Text = "Billing";
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
        private System.Windows.Forms.Label lblBiling;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAddProductAttribute;
        private System.Windows.Forms.Button btnSaveUser;
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