namespace Pharmacy.WindowsUI
{
    partial class frmRegister
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
            this.lblCancelSignUp = new System.Windows.Forms.LinkLabel();
            this.lblPharmacyUniqueIdentifier = new System.Windows.Forms.Label();
            this.txtPharmacyUniqueIdentifier = new System.Windows.Forms.TextBox();
            this.lblPharmacyName = new System.Windows.Forms.Label();
            this.txtPharmacyName = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.comboCountryId = new System.Windows.Forms.ComboBox();
            this.comboCityId = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblBranchIdentifier = new System.Windows.Forms.Label();
            this.txtBranchIDentifier = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.chkBoxCentral = new System.Windows.Forms.CheckBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBoxUseCentralData = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCancelSignUp
            // 
            this.lblCancelSignUp.AutoSize = true;
            this.lblCancelSignUp.Location = new System.Drawing.Point(533, 410);
            this.lblCancelSignUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCancelSignUp.Name = "lblCancelSignUp";
            this.lblCancelSignUp.Size = new System.Drawing.Size(40, 13);
            this.lblCancelSignUp.TabIndex = 11;
            this.lblCancelSignUp.TabStop = true;
            this.lblCancelSignUp.Text = "Cancel";
            this.lblCancelSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCancelSignUp_LinkClicked);
            // 
            // lblPharmacyUniqueIdentifier
            // 
            this.lblPharmacyUniqueIdentifier.AutoSize = true;
            this.lblPharmacyUniqueIdentifier.Location = new System.Drawing.Point(301, 39);
            this.lblPharmacyUniqueIdentifier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPharmacyUniqueIdentifier.Name = "lblPharmacyUniqueIdentifier";
            this.lblPharmacyUniqueIdentifier.Size = new System.Drawing.Size(131, 13);
            this.lblPharmacyUniqueIdentifier.TabIndex = 10;
            this.lblPharmacyUniqueIdentifier.Text = "Pharmacy unique identifier";
            // 
            // txtPharmacyUniqueIdentifier
            // 
            this.txtPharmacyUniqueIdentifier.Location = new System.Drawing.Point(301, 58);
            this.txtPharmacyUniqueIdentifier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPharmacyUniqueIdentifier.Name = "txtPharmacyUniqueIdentifier";
            this.txtPharmacyUniqueIdentifier.Size = new System.Drawing.Size(276, 20);
            this.txtPharmacyUniqueIdentifier.TabIndex = 9;
            this.txtPharmacyUniqueIdentifier.Validating += new System.ComponentModel.CancelEventHandler(this.txtPharmacyUniqueIdentifier_Validating);
            // 
            // lblPharmacyName
            // 
            this.lblPharmacyName.AutoSize = true;
            this.lblPharmacyName.Location = new System.Drawing.Point(19, 39);
            this.lblPharmacyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPharmacyName.Name = "lblPharmacyName";
            this.lblPharmacyName.Size = new System.Drawing.Size(83, 13);
            this.lblPharmacyName.TabIndex = 8;
            this.lblPharmacyName.Text = "Pharmacy name";
            // 
            // txtPharmacyName
            // 
            this.txtPharmacyName.Location = new System.Drawing.Point(19, 58);
            this.txtPharmacyName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPharmacyName.Name = "txtPharmacyName";
            this.txtPharmacyName.Size = new System.Drawing.Size(276, 20);
            this.txtPharmacyName.TabIndex = 7;
            this.txtPharmacyName.Validating += new System.ComponentModel.CancelEventHandler(this.txtPharmacyName_Validating);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(249, 404);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(107, 24);
            this.btnSignUp.TabIndex = 6;
            this.btnSignUp.Text = "Sign up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_ClickAsync);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(301, 246);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(56, 13);
            this.lblLastName.TabIndex = 15;
            this.lblLastName.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(301, 265);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(276, 20);
            this.txtLastName.TabIndex = 14;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(16, 246);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(55, 13);
            this.lblFirstName.TabIndex = 13;
            this.lblFirstName.Text = "First name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(16, 265);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(276, 20);
            this.txtFirstName.TabIndex = 12;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // comboCountryId
            // 
            this.comboCountryId.FormattingEnabled = true;
            this.comboCountryId.Location = new System.Drawing.Point(19, 102);
            this.comboCountryId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCountryId.Name = "comboCountryId";
            this.comboCountryId.Size = new System.Drawing.Size(276, 21);
            this.comboCountryId.TabIndex = 16;
            this.comboCountryId.Validating += new System.ComponentModel.CancelEventHandler(this.comboCountryId_Validating);
            // 
            // comboCityId
            // 
            this.comboCityId.FormattingEnabled = true;
            this.comboCityId.Location = new System.Drawing.Point(301, 102);
            this.comboCityId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCityId.Name = "comboCityId";
            this.comboCityId.Size = new System.Drawing.Size(276, 21);
            this.comboCityId.TabIndex = 17;
            this.comboCityId.Validating += new System.ComponentModel.CancelEventHandler(this.comboCityId_Validating);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(19, 85);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 18;
            this.lblCountry.Text = "Country";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(301, 85);
            this.lblCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 19;
            this.lblCity.Text = "City";
            // 
            // lblBranchIdentifier
            // 
            this.lblBranchIdentifier.AutoSize = true;
            this.lblBranchIdentifier.Location = new System.Drawing.Point(301, 131);
            this.lblBranchIdentifier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBranchIdentifier.Name = "lblBranchIdentifier";
            this.lblBranchIdentifier.Size = new System.Drawing.Size(167, 13);
            this.lblBranchIdentifier.TabIndex = 23;
            this.lblBranchIdentifier.Text = "Pharmacy branch unique identifier";
            // 
            // txtBranchIDentifier
            // 
            this.txtBranchIDentifier.Location = new System.Drawing.Point(301, 150);
            this.txtBranchIDentifier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBranchIDentifier.Name = "txtBranchIDentifier";
            this.txtBranchIDentifier.Size = new System.Drawing.Size(276, 20);
            this.txtBranchIDentifier.TabIndex = 22;
            this.txtBranchIDentifier.Validating += new System.ComponentModel.CancelEventHandler(this.txtBranchIDentifier_Validating);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(19, 131);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 21;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(19, 150);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(276, 20);
            this.txtAddress.TabIndex = 20;
            // 
            // chkBoxCentral
            // 
            this.chkBoxCentral.AutoSize = true;
            this.chkBoxCentral.Location = new System.Drawing.Point(19, 183);
            this.chkBoxCentral.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBoxCentral.Name = "chkBoxCentral";
            this.chkBoxCentral.Size = new System.Drawing.Size(275, 17);
            this.chkBoxCentral.TabIndex = 24;
            this.chkBoxCentral.Text = "Whether you are adding a central pharmacy branch?";
            this.chkBoxCentral.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(301, 292);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(301, 311);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(276, 20);
            this.txtEmail.TabIndex = 27;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(16, 292);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(16, 311);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(276, 20);
            this.txtUsername.TabIndex = 25;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 342);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Passowrd";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 361);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(276, 20);
            this.txtPassword.TabIndex = 29;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(301, 342);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(90, 13);
            this.lblConfirmPassword.TabIndex = 32;
            this.lblConfirmPassword.Text = "Confirm passowrd";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(301, 361);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(276, 20);
            this.txtConfirmPassword.TabIndex = 31;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Pharmacy information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "User information";
            // 
            // chkBoxUseCentralData
            // 
            this.chkBoxUseCentralData.AutoSize = true;
            this.chkBoxUseCentralData.Location = new System.Drawing.Point(301, 183);
            this.chkBoxUseCentralData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBoxUseCentralData.Name = "chkBoxUseCentralData";
            this.chkBoxUseCentralData.Size = new System.Drawing.Size(219, 17);
            this.chkBoxUseCentralData.TabIndex = 35;
            this.chkBoxUseCentralData.Text = "Do you want to use central branch data?";
            this.chkBoxUseCentralData.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 441);
            this.Controls.Add(this.chkBoxUseCentralData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.chkBoxCentral);
            this.Controls.Add(this.lblBranchIdentifier);
            this.Controls.Add(this.txtBranchIDentifier);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.comboCityId);
            this.Controls.Add(this.comboCountryId);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblCancelSignUp);
            this.Controls.Add(this.lblPharmacyUniqueIdentifier);
            this.Controls.Add(this.txtPharmacyUniqueIdentifier);
            this.Controls.Add(this.lblPharmacyName);
            this.Controls.Add(this.txtPharmacyName);
            this.Controls.Add(this.btnSignUp);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmRegister";
            this.Text = "POS Pharmacy - Register";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblCancelSignUp;
        private System.Windows.Forms.Label lblPharmacyUniqueIdentifier;
        private System.Windows.Forms.TextBox txtPharmacyUniqueIdentifier;
        private System.Windows.Forms.Label lblPharmacyName;
        private System.Windows.Forms.TextBox txtPharmacyName;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox comboCountryId;
        private System.Windows.Forms.ComboBox comboCityId;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblBranchIdentifier;
        private System.Windows.Forms.TextBox txtBranchIDentifier;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.CheckBox chkBoxCentral;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBoxUseCentralData;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}