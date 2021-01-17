namespace Pharmacy.WindowsUI
{
    partial class frmIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.branchIdentifierLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.branchIdentifier = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFullName = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.substancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.branchIdentifierLabel,
            this.branchIdentifier,
            this.menuItemFullName,
            this.signOutToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.branchesToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.attributesToolStripMenuItem,
            this.substancesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip.Size = new System.Drawing.Size(159, 558);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // branchIdentifierLabel
            // 
            this.branchIdentifierLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.branchIdentifierLabel.Name = "branchIdentifierLabel";
            this.branchIdentifierLabel.Size = new System.Drawing.Size(153, 24);
            this.branchIdentifierLabel.Text = "Branch Identifier";
            // 
            // branchIdentifier
            // 
            this.branchIdentifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.branchIdentifier.Name = "branchIdentifier";
            this.branchIdentifier.Size = new System.Drawing.Size(153, 4);
            // 
            // menuItemFullName
            // 
            this.menuItemFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuItemFullName.Name = "menuItemFullName";
            this.menuItemFullName.Size = new System.Drawing.Size(153, 4);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.billingToolStripMenuItem.Text = "Billing";
            this.billingToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.billingToolStripMenuItem.Click += new System.EventHandler(this.billingToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartsToolStripMenuItem,
            this.salesToolStripMenuItem});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.reportsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // chartsToolStripMenuItem
            // 
            this.chartsToolStripMenuItem.Name = "chartsToolStripMenuItem";
            this.chartsToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.chartsToolStripMenuItem.Text = "Charts";
            this.chartsToolStripMenuItem.Click += new System.EventHandler(this.chartsToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // branchesToolStripMenuItem
            // 
            this.branchesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchesToolStripMenuItem.Name = "branchesToolStripMenuItem";
            this.branchesToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.branchesToolStripMenuItem.Text = "Branches";
            this.branchesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.branchesToolStripMenuItem.Click += new System.EventHandler(this.branchesToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // attributesToolStripMenuItem
            // 
            this.attributesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.attributesToolStripMenuItem.Name = "attributesToolStripMenuItem";
            this.attributesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.attributesToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.attributesToolStripMenuItem.Text = "Attributes";
            this.attributesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attributesToolStripMenuItem.Click += new System.EventHandler(this.attributesToolStripMenuItem_Click);
            // 
            // substancesToolStripMenuItem
            // 
            this.substancesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.substancesToolStripMenuItem.Name = "substancesToolStripMenuItem";
            this.substancesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.substancesToolStripMenuItem.Size = new System.Drawing.Size(153, 29);
            this.substancesToolStripMenuItem.Text = "Substances";
            this.substancesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.substancesToolStripMenuItem.Click += new System.EventHandler(this.substancesToolStripMenuItem_Click);
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(931, 558);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIndex";
            this.RightToLeftLayout = true;
            this.Text = "POS Pharmacy";
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFullName;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem substancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchIdentifierLabel;
        private System.Windows.Forms.ToolStripMenuItem branchIdentifier;
        private System.Windows.Forms.ToolStripMenuItem branchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
    }
}



