namespace Pharmacy.WindowsUI.Users
{
    partial class frmUserDetails
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
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.clbRoles = new System.Windows.Forms.CheckedListBox();
            this.comboCountryId = new System.Windows.Forms.ComboBox();
            this.comboCityId = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblUserDetails = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(457, 527);
            this.btnSaveUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(199, 39);
            this.btnSaveUser.TabIndex = 0;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // clbRoles
            // 
            this.clbRoles.FormattingEnabled = true;
            this.clbRoles.Location = new System.Drawing.Point(63, 420);
            this.clbRoles.Margin = new System.Windows.Forms.Padding(4);
            this.clbRoles.Name = "clbRoles";
            this.clbRoles.Size = new System.Drawing.Size(973, 72);
            this.clbRoles.TabIndex = 1;
            this.clbRoles.Validating += new System.ComponentModel.CancelEventHandler(this.clbRoles_Validating);
            // 
            // comboCountryId
            // 
            this.comboCountryId.FormattingEnabled = true;
            this.comboCountryId.Location = new System.Drawing.Point(63, 138);
            this.comboCountryId.Margin = new System.Windows.Forms.Padding(4);
            this.comboCountryId.Name = "comboCountryId";
            this.comboCountryId.Size = new System.Drawing.Size(307, 24);
            this.comboCountryId.TabIndex = 2;
            this.comboCountryId.Validating += new System.ComponentModel.CancelEventHandler(this.comboCountryId_Validating);
            // 
            // comboCityId
            // 
            this.comboCityId.FormattingEnabled = true;
            this.comboCityId.Location = new System.Drawing.Point(392, 138);
            this.comboCityId.Margin = new System.Windows.Forms.Padding(4);
            this.comboCityId.Name = "comboCityId";
            this.comboCityId.Size = new System.Drawing.Size(307, 24);
            this.comboCityId.TabIndex = 3;
            this.comboCityId.Validating += new System.ComponentModel.CancelEventHandler(this.comboCityId_Validating);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(63, 114);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(57, 17);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Country";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(392, 114);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(31, 17);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "City";
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(63, 400);
            this.lblRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(44, 17);
            this.lblRoles.TabIndex = 6;
            this.lblRoles.Text = "Roles";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(63, 74);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(307, 22);
            this.txtFirstName.TabIndex = 7;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(63, 50);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(74, 17);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(392, 50);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 17);
            this.lblLastName.TabIndex = 10;
            this.lblLastName.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(392, 74);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(307, 22);
            this.txtLastName.TabIndex = 9;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(725, 50);
            this.lblDateOfBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 17);
            this.lblDateOfBirth.TabIndex = 12;
            this.lblDateOfBirth.Text = "Birth date";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(729, 74);
            this.dtpDateOfBirth.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(307, 22);
            this.dtpDateOfBirth.TabIndex = 13;
            this.dtpDateOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDateOfBirth_Validating);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(729, 139);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(307, 22);
            this.txtAddress.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(725, 119);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 17);
            this.lblAddress.TabIndex = 15;
            this.lblAddress.Text = "Address";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(568, 338);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(120, 17);
            this.lblConfirmPassword.TabIndex = 40;
            this.lblConfirmPassword.Text = "Confirm passowrd";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(568, 362);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(468, 22);
            this.txtConfirmPassword.TabIndex = 39;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(63, 338);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 38;
            this.lblPassword.Text = "Passowrd";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(63, 362);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(480, 22);
            this.txtPassword.TabIndex = 37;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(568, 277);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 36;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(568, 300);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(468, 22);
            this.txtEmail.TabIndex = 35;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(63, 277);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(73, 17);
            this.lblUserName.TabIndex = 34;
            this.lblUserName.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(63, 300);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(480, 22);
            this.txtUsername.TabIndex = 33;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(63, 193);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(973, 67);
            this.txtNote.TabIndex = 41;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(63, 174);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(38, 17);
            this.lblNote.TabIndex = 42;
            this.lblNote.Text = "Note";
            // 
            // lblUserDetails
            // 
            this.lblUserDetails.AutoSize = true;
            this.lblUserDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDetails.Location = new System.Drawing.Point(63, 16);
            this.lblUserDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserDetails.Name = "lblUserDetails";
            this.lblUserDetails.Size = new System.Drawing.Size(117, 22);
            this.lblUserDetails.TabIndex = 43;
            this.lblUserDetails.Text = "User details";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(63, 553);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(40, 22);
            this.txtId.TabIndex = 44;
            this.txtId.Visible = false;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 601);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblUserDetails);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.comboCityId);
            this.Controls.Add(this.comboCountryId);
            this.Controls.Add(this.clbRoles);
            this.Controls.Add(this.btnSaveUser);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUserDetails";
            this.Text = "User details";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.CheckedListBox clbRoles;
        private System.Windows.Forms.ComboBox comboCountryId;
        private System.Windows.Forms.ComboBox comboCityId;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblUserDetails;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtId;
    }
}