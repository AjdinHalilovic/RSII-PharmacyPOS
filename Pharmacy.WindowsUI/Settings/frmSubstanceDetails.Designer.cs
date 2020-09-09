namespace Pharmacy.WindowsUI.Settings
{
    partial class frmSubstanceDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.clbProhibitedSubstances = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryDetails
            // 
            this.lblCategoryDetails.AutoSize = true;
            this.lblCategoryDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryDetails.Location = new System.Drawing.Point(45, 22);
            this.lblCategoryDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoryDetails.Name = "lblCategoryDetails";
            this.lblCategoryDetails.Size = new System.Drawing.Size(169, 22);
            this.lblCategoryDetails.TabIndex = 44;
            this.lblCategoryDetails.Text = "Substance details";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(268, 277);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(199, 39);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_ClickAsync);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(46, 61);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 47;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(46, 85);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(650, 22);
            this.txtName.TabIndex = 46;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Prohibited substance";
            // 
            // clbProhibitedSubstances
            // 
            this.clbProhibitedSubstances.FormattingEnabled = true;
            this.clbProhibitedSubstances.Location = new System.Drawing.Point(46, 144);
            this.clbProhibitedSubstances.Name = "clbProhibitedSubstances";
            this.clbProhibitedSubstances.Size = new System.Drawing.Size(650, 106);
            this.clbProhibitedSubstances.TabIndex = 49;
            // 
            // frmSubstanceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 329);
            this.Controls.Add(this.clbProhibitedSubstances);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCategoryDetails);
            this.Name = "frmSubstanceDetails";
            this.Text = "Substance details";
            this.Load += new System.EventHandler(this.frmCategoryDetails_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckedListBox clbProhibitedSubstances;
        private System.Windows.Forms.Label label1;
    }
}