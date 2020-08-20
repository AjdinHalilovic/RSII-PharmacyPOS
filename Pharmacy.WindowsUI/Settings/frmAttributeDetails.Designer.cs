namespace Pharmacy.WindowsUI.Settings
{
    partial class frmAttributeDetails
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
            this.lblCategoryDetails = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnAddAttributeValue = new System.Windows.Forms.Button();
            this.dgvAttributeOptions = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeOptionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeOptions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryDetails
            // 
            this.lblCategoryDetails.AutoSize = true;
            this.lblCategoryDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryDetails.Location = new System.Drawing.Point(34, 18);
            this.lblCategoryDetails.Name = "lblCategoryDetails";
            this.lblCategoryDetails.Size = new System.Drawing.Size(123, 17);
            this.lblCategoryDetails.TabIndex = 44;
            this.lblCategoryDetails.Text = "Attribute details";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 32);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_ClickAsync);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(34, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 47;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(34, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(482, 20);
            this.txtName.TabIndex = 46;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(0, 36);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(218, 20);
            this.txtValue.TabIndex = 48;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(3, 20);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 49;
            this.lblValue.Text = "Value";
            // 
            // btnAddAttributeValue
            // 
            this.btnAddAttributeValue.Location = new System.Drawing.Point(129, 62);
            this.btnAddAttributeValue.Name = "btnAddAttributeValue";
            this.btnAddAttributeValue.Size = new System.Drawing.Size(89, 22);
            this.btnAddAttributeValue.TabIndex = 60;
            this.btnAddAttributeValue.Text = "Add value";
            this.btnAddAttributeValue.UseVisualStyleBackColor = true;
            this.btnAddAttributeValue.Click += new System.EventHandler(this.btnAddAttributeValue_Click);
            // 
            // dgvAttributeOptions
            // 
            this.dgvAttributeOptions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAttributeOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.AttributeOptionValue,
            this.Action});
            this.dgvAttributeOptions.Location = new System.Drawing.Point(238, 36);
            this.dgvAttributeOptions.Name = "dgvAttributeOptions";
            this.dgvAttributeOptions.Size = new System.Drawing.Size(244, 129);
            this.dgvAttributeOptions.TabIndex = 61;
            this.dgvAttributeOptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttributeOptions_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // AttributeOptionValue
            // 
            this.AttributeOptionValue.DataPropertyName = "OptionValue";
            this.AttributeOptionValue.HeaderText = "Option value";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAttributeOptions);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.btnAddAttributeValue);
            this.groupBox1.Controls.Add(this.lblValue);
            this.groupBox1.Location = new System.Drawing.Point(34, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 167);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // frmAttributeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCategoryDetails);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAttributeDetails";
            this.Text = "Attribute details";
            this.Load += new System.EventHandler(this.frmCategoryDetails_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeOptions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnAddAttributeValue;
        public System.Windows.Forms.DataGridView dgvAttributeOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeOptionValue;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}