namespace Pharmacy.WindowsUI.Billing
{
    partial class frmReports
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSalesByTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.comboUserId = new System.Windows.Forms.ComboBox();
            this.lblBiling = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartSalesByProduct = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerToProduct = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFromProduct = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboProductId = new System.Windows.Forms.ComboBox();
            this.productDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.baseDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refreshChartsBtn = new System.Windows.Forms.Button();
            this.printDetailsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSalesByTime
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSalesByTime.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSalesByTime.Legends.Add(legend3);
            this.chartSalesByTime.Location = new System.Drawing.Point(33, 113);
            this.chartSalesByTime.Margin = new System.Windows.Forms.Padding(4);
            this.chartSalesByTime.Name = "chartSalesByTime";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Prihod";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartSalesByTime.Series.Add(series3);
            this.chartSalesByTime.Size = new System.Drawing.Size(1213, 318);
            this.chartSalesByTime.TabIndex = 7;
            this.chartSalesByTime.Text = "chartSalesByTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 70;
            this.label1.Text = "Search by user";
            // 
            // comboUserId
            // 
            this.comboUserId.FormattingEnabled = true;
            this.comboUserId.Location = new System.Drawing.Point(35, 70);
            this.comboUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboUserId.Name = "comboUserId";
            this.comboUserId.Size = new System.Drawing.Size(353, 24);
            this.comboUserId.TabIndex = 69;
            this.comboUserId.SelectedValueChanged += new System.EventHandler(this.comboCategoryId_ValueMemberChanged);
            // 
            // lblBiling
            // 
            this.lblBiling.AutoSize = true;
            this.lblBiling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiling.Location = new System.Drawing.Point(31, 11);
            this.lblBiling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBiling.Name = "lblBiling";
            this.lblBiling.Size = new System.Drawing.Size(193, 22);
            this.lblBiling.TabIndex = 72;
            this.lblBiling.Text = "Report sales by time";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(461, 71);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(353, 22);
            this.dateTimePickerFrom.TabIndex = 73;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(893, 71);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(353, 22);
            this.dateTimePickerTo.TabIndex = 74;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 75;
            this.label3.Text = "Date from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(889, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 76;
            this.label4.Text = "Date to";
            // 
            // chartSalesByProduct
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSalesByProduct.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSalesByProduct.Legends.Add(legend4);
            this.chartSalesByProduct.Location = new System.Drawing.Point(35, 551);
            this.chartSalesByProduct.Margin = new System.Windows.Forms.Padding(4);
            this.chartSalesByProduct.Name = "chartSalesByProduct";
            this.chartSalesByProduct.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Prihod";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartSalesByProduct.Series.Add(series4);
            this.chartSalesByProduct.Size = new System.Drawing.Size(1213, 378);
            this.chartSalesByProduct.TabIndex = 77;
            this.chartSalesByProduct.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 445);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 22);
            this.label2.TabIndex = 78;
            this.label2.Text = "Report sales by product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(890, 481);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 84;
            this.label5.Text = "Date to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 481);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 83;
            this.label6.Text = "Date from";
            // 
            // dateTimePickerToProduct
            // 
            this.dateTimePickerToProduct.Location = new System.Drawing.Point(894, 500);
            this.dateTimePickerToProduct.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerToProduct.Name = "dateTimePickerToProduct";
            this.dateTimePickerToProduct.Size = new System.Drawing.Size(353, 22);
            this.dateTimePickerToProduct.TabIndex = 82;
            this.dateTimePickerToProduct.ValueChanged += new System.EventHandler(this.dateTimePickerToProduct_ValueChanged);
            // 
            // dateTimePickerFromProduct
            // 
            this.dateTimePickerFromProduct.Location = new System.Drawing.Point(462, 500);
            this.dateTimePickerFromProduct.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFromProduct.Name = "dateTimePickerFromProduct";
            this.dateTimePickerFromProduct.Size = new System.Drawing.Size(353, 22);
            this.dateTimePickerFromProduct.TabIndex = 81;
            this.dateTimePickerFromProduct.ValueChanged += new System.EventHandler(this.dateTimePickerFromProduct_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 481);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 80;
            this.label7.Text = "Search by product";
            // 
            // comboProductId
            // 
            this.comboProductId.FormattingEnabled = true;
            this.comboProductId.Location = new System.Drawing.Point(36, 499);
            this.comboProductId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboProductId.Name = "comboProductId";
            this.comboProductId.Size = new System.Drawing.Size(353, 24);
            this.comboProductId.TabIndex = 79;
            this.comboProductId.SelectedValueChanged += new System.EventHandler(this.comboProductId_SelectedValueChanged);
            // 
            // productDtoBindingSource1
            // 
            this.productDtoBindingSource1.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductDto);
            // 
            // baseDtoBindingSource
            // 
            this.baseDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.BaseDto);
            // 
            // productDtoBindingSource
            // 
            this.productDtoBindingSource.DataSource = typeof(Pharmacy.Core.Entities.Base.DTO.ProductDto);
            // 
            // refreshChartsBtn
            // 
            this.refreshChartsBtn.Location = new System.Drawing.Point(987, 23);
            this.refreshChartsBtn.Name = "refreshChartsBtn";
            this.refreshChartsBtn.Size = new System.Drawing.Size(127, 31);
            this.refreshChartsBtn.TabIndex = 85;
            this.refreshChartsBtn.Text = "Refresh reports";
            this.refreshChartsBtn.UseVisualStyleBackColor = true;
            this.refreshChartsBtn.Click += new System.EventHandler(this.refreshChartsBtn_Click);
            // 
            // printDetailsBtn
            // 
            this.printDetailsBtn.Location = new System.Drawing.Point(1132, 23);
            this.printDetailsBtn.Name = "printDetailsBtn";
            this.printDetailsBtn.Size = new System.Drawing.Size(114, 31);
            this.printDetailsBtn.TabIndex = 86;
            this.printDetailsBtn.Text = "Print details";
            this.printDetailsBtn.UseVisualStyleBackColor = true;
            this.printDetailsBtn.Click += new System.EventHandler(this.printDetailsBtn_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 944);
            this.Controls.Add(this.printDetailsBtn);
            this.Controls.Add(this.refreshChartsBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerToProduct);
            this.Controls.Add(this.dateTimePickerFromProduct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboProductId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartSalesByProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.lblBiling);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboUserId);
            this.Controls.Add(this.chartSalesByTime);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmReports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource baseDtoBindingSource;
        private System.Windows.Forms.BindingSource productDtoBindingSource1;
        private System.Windows.Forms.BindingSource productDtoBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesByTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboUserId;
        private System.Windows.Forms.Label lblBiling;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesByProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerToProduct;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromProduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboProductId;
        private System.Windows.Forms.Button refreshChartsBtn;
        private System.Windows.Forms.Button printDetailsBtn;
    }
}