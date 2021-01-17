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
            this.SuspendLayout();
            // 
            // lblCancelSignUp
            // 
            this.lblCancelSignUp.AutoSize = true;
            this.lblCancelSignUp.Location = new System.Drawing.Point(711, 504);
            this.lblCancelSignUp.Name = "lblCancelSignUp";
            this.lblCancelSignUp.Size = new System.Drawing.Size(51, 17);
            this.lblCancelSignUp.TabIndex = 11;
            this.lblCancelSignUp.TabStop = true;
            this.lblCancelSignUp.Text = "Cancel";
            this.lblCancelSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCancelSignUp_LinkClicked);
            // 
            // lblPharmacyUniqueIdentifier
            // 
            this.lblPharmacyUniqueIdentifier.AutoSize = true;
            this.lblPharmacyUniqueIdentifier.Location = new System.Drawing.Point(401, 48);
            this.lblPharmacyUniqueIdentifier.Name = "lblPharmacyUniqueIdentifier";
            this.lblPharmacyUniqueIdentifier.Size = new System.Drawing.Size(176, 17);
            this.lblPharmacyUniqueIdentifier.TabIndex = 10;
            this.lblPharmacyUniqueIdentifier.Text = "Pharmacy unique identifier";
            // 
            // txtPharmacyUniqueIdentifier
            // 
            this.txtPharmacyUniqueIdentifier.Location = new System.Drawing.Point(401, 71);
            this.txtPharmacyUniqueIdentifier.Name = "txtPharmacyUniqueIdentifier";
            this.txtPharmacyUniqueIdentifier.Size = new System.Drawing.Size(366, 22);
            this.txtPharmacyUniqueIdentifier.TabIndex = 9;
            // 
            // lblPharmacyName
            // 
            this.lblPharmacyName.AutoSize = true;
            this.lblPharmacyName.Location = new System.Drawing.Point(25, 48);
            this.lblPharmacyName.Name = "lblPharmacyName";
            this.lblPharmacyName.Size = new System.Drawing.Size(110, 17);
            this.lblPharmacyName.TabIndex = 8;
            this.lblPharmacyName.Text = "Pharmacy name";
            // 
            // txtPharmacyName
            // 
            this.txtPharmacyName.Location = new System.Drawing.Point(25, 71);
            this.txtPharmacyName.Name = "txtPharmacyName";
            this.txtPharmacyName.Size = new System.Drawing.Size(366, 22);
            this.txtPharmacyName.TabIndex = 7;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(332, 497);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(143, 30);
            this.btnSignUp.TabIndex = 6;
            this.btnSignUp.Text = "Sign up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_ClickAsync);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(401, 303);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 17);
            this.lblLastName.TabIndex = 15;
            this.lblLastName.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(401, 326);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(366, 22);
            this.txtLastName.TabIndex = 14;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(22, 303);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(74, 17);
            this.lblFirstName.TabIndex = 13;
            this.lblFirstName.Text = "First name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(22, 326);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(366, 22);
            this.txtFirstName.TabIndex = 12;
            // 
            // comboCountryId
            // 
            this.comboCountryId.FormattingEnabled = true;
            this.comboCountryId.Location = new System.Drawing.Point(25, 125);
            this.comboCountryId.Name = "comboCountryId";
            this.comboCountryId.Size = new System.Drawing.Size(366, 24);
            this.comboCountryId.TabIndex = 16;
            // 
            // comboCityId
            // 
            this.comboCityId.FormattingEnabled = true;
            this.comboCityId.Location = new System.Drawing.Point(401, 125);
            this.comboCityId.Name = "comboCityId";
            this.comboCityId.Size = new System.Drawing.Size(366, 24);
            this.comboCityId.TabIndex = 17;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(25, 105);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(57, 17);
            this.lblCountry.TabIndex = 18;
            this.lblCountry.Text = "Country";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(401, 105);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(31, 17);
            this.lblCity.TabIndex = 19;
            this.lblCity.Text = "City";
            // 
            // lblBranchIdentifier
            // 
            this.lblBranchIdentifier.AutoSize = true;
            this.lblBranchIdentifier.Location = new System.Drawing.Point(401, 161);
            this.lblBranchIdentifier.Name = "lblBranchIdentifier";
            this.lblBranchIdentifier.Size = new System.Drawing.Size(224, 17);
            this.lblBranchIdentifier.TabIndex = 23;
            this.lblBranchIdentifier.Text = "Pharmacy branch unique identifier";
            // 
            // txtBranchIDentifier
            // 
            this.txtBranchIDentifier.Location = new System.Drawing.Point(401, 184);
            this.txtBranchIDentifier.Name = "txtBranchIDentifier";
            this.txtBranchIDentifier.Size = new System.Drawing.Size(366, 22);
            this.txtBranchIDentifier.TabIndex = 22;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(25, 161);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 17);
            this.lblAddress.TabIndex = 21;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(25, 184);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(366, 22);
            this.txtAddress.TabIndex = 20;
            // 
            // chkBoxCentral
            // 
            this.chkBoxCentral.AutoSize = true;
            this.chkBoxCentral.Location = new System.Drawing.Point(25, 225);
            this.chkBoxCentral.Name = "chkBoxCentral";
            this.chkBoxCentral.Size = new System.Drawing.Size(364, 21);
            this.chkBoxCentral.TabIndex = 24;
            this.chkBoxCentral.Text = "Whether you are adding a central pharmacy branch?";
            this.chkBoxCentral.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(401, 360);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(401, 383);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(366, 22);
            this.txtEmail.TabIndex = 27;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(22, 360);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(73, 17);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(22, 383);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(366, 22);
            this.txtUsername.TabIndex = 25;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(22, 421);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Passowrd";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(22, 444);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(366, 22);
            this.txtPassword.TabIndex = 29;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(401, 421);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(120, 17);
            this.lblConfirmPassword.TabIndex = 32;
            this.lblConfirmPassword.Text = "Confirm passowrd";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(401, 444);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(366, 22);
            this.txtConfirmPassword.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Pharmacy information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "User information";
            // 
            // chkBoxUseCentralData
            // 
            this.chkBoxUseCentralData.AutoSize = true;
            this.chkBoxUseCentralData.Location = new System.Drawing.Point(401, 225);
            this.chkBoxUseCentralData.Name = "chkBoxUseCentralData";
            this.chkBoxUseCentralData.Size = new System.Drawing.Size(286, 21);
            this.chkBoxUseCentralData.TabIndex = 35;
            this.chkBoxUseCentralData.Text = "Do you want to use central branch data?";
            this.chkBoxUseCentralData.UseVisualStyleBackColor = true;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
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
            this.Name = "frmRegister";
            this.Text = "POS Pharmacy - Register";
            this.Load += new System.EventHandler(this.frmRegister_Load);
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
    }
}