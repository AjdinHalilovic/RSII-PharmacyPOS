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
            this.txtLastName = new System.Windows.Forms.TextBox();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnAddProductAttribute = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.lblUserDetails.Location = new System.Drawing.Point(46, 25);
            this.lblUserDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserDetails.Name = "lblUserDetails";
            this.lblUserDetails.Size = new System.Drawing.Size(144, 22);
            this.lblUserDetails.TabIndex = 44;
            this.lblUserDetails.Text = "Product details";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(584, 67);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 17);
            this.lblCode.TabIndex = 48;
            this.lblCode.Text = "Code";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(584, 91);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(464, 22);
            this.txtLastName.TabIndex = 47;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 67);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 46;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 91);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(481, 22);
            this.txtName.TabIndex = 45;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(584, 123);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 17);
            this.lblPrice.TabIndex = 50;
            this.lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(584, 147);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(464, 22);
            this.txtPrice.TabIndex = 49;
            // 
            // comboMeasurementUnitId
            // 
            this.comboMeasurementUnitId.FormattingEnabled = true;
            this.comboMeasurementUnitId.Location = new System.Drawing.Point(50, 147);
            this.comboMeasurementUnitId.Name = "comboMeasurementUnitId";
            this.comboMeasurementUnitId.Size = new System.Drawing.Size(481, 24);
            this.comboMeasurementUnitId.TabIndex = 51;
            // 
            // lblMeasurementUnit
            // 
            this.lblMeasurementUnit.AutoSize = true;
            this.lblMeasurementUnit.Location = new System.Drawing.Point(50, 127);
            this.lblMeasurementUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMeasurementUnit.Name = "lblMeasurementUnit";
            this.lblMeasurementUnit.Size = new System.Drawing.Size(121, 17);
            this.lblMeasurementUnit.TabIndex = 52;
            this.lblMeasurementUnit.Text = "Measurement unit";
            // 
            // clbCategories
            // 
            this.clbCategories.FormattingEnabled = true;
            this.clbCategories.Location = new System.Drawing.Point(50, 206);
            this.clbCategories.Margin = new System.Windows.Forms.Padding(4);
            this.clbCategories.Name = "clbCategories";
            this.clbCategories.Size = new System.Drawing.Size(481, 106);
            this.clbCategories.TabIndex = 53;
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(50, 185);
            this.lblCategories.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(76, 17);
            this.lblCategories.TabIndex = 54;
            this.lblCategories.Text = "Categories";
            // 
            // lblSubstances
            // 
            this.lblSubstances.AutoSize = true;
            this.lblSubstances.Location = new System.Drawing.Point(584, 185);
            this.lblSubstances.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubstances.Name = "lblSubstances";
            this.lblSubstances.Size = new System.Drawing.Size(82, 17);
            this.lblSubstances.TabIndex = 56;
            this.lblSubstances.Text = "Substances";
            // 
            // clbSubstances
            // 
            this.clbSubstances.FormattingEnabled = true;
            this.clbSubstances.Location = new System.Drawing.Point(584, 206);
            this.clbSubstances.Margin = new System.Windows.Forms.Padding(4);
            this.clbSubstances.Name = "clbSubstances";
            this.clbSubstances.Size = new System.Drawing.Size(464, 106);
            this.clbSubstances.TabIndex = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(50, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 130);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(985, 102);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(449, 523);
            this.btnSaveUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(199, 39);
            this.btnSaveUser.TabIndex = 58;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            // 
            // btnAddProductAttribute
            // 
            this.btnAddProductAttribute.Location = new System.Drawing.Point(57, 462);
            this.btnAddProductAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProductAttribute.Name = "btnAddProductAttribute";
            this.btnAddProductAttribute.Size = new System.Drawing.Size(184, 27);
            this.btnAddProductAttribute.TabIndex = 59;
            this.btnAddProductAttribute.Text = "Add product attribute";
            this.btnAddProductAttribute.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(57, 540);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(38, 22);
            this.txtId.TabIndex = 60;
            this.txtId.Visible = false;
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 575);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAddProductAttribute);
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
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblUserDetails);
            this.Name = "frmProductDetails";
            this.Text = "Product details";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblUserDetails;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtLastName;
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAddProductAttribute;
        private System.Windows.Forms.Button btnSaveUser;
    }
}