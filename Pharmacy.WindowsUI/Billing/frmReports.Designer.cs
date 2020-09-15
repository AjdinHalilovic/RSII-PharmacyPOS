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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSalesByTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.comboUserId = new System.Windows.Forms.ComboBox();
            this.lblBiling = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.baseDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSalesByTime
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSalesByTime.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSalesByTime.Legends.Add(legend1);
            this.chartSalesByTime.Location = new System.Drawing.Point(26, 127);
            this.chartSalesByTime.Name = "chartSalesByTime";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Prihod";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartSalesByTime.Series.Add(series1);
            this.chartSalesByTime.Size = new System.Drawing.Size(910, 368);
            this.chartSalesByTime.TabIndex = 7;
            this.chartSalesByTime.Text = "chartSalesByTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Search by user";
            // 
            // comboUserId
            // 
            this.comboUserId.FormattingEnabled = true;
            this.comboUserId.Location = new System.Drawing.Point(26, 57);
            this.comboUserId.Margin = new System.Windows.Forms.Padding(2);
            this.comboUserId.Name = "comboUserId";
            this.comboUserId.Size = new System.Drawing.Size(266, 21);
            this.comboUserId.TabIndex = 69;
            this.comboUserId.SelectedValueChanged += new System.EventHandler(this.comboCategoryId_ValueMemberChanged);
            // 
            // lblBiling
            // 
            this.lblBiling.AutoSize = true;
            this.lblBiling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiling.Location = new System.Drawing.Point(23, 9);
            this.lblBiling.Name = "lblBiling";
            this.lblBiling.Size = new System.Drawing.Size(157, 17);
            this.lblBiling.TabIndex = 72;
            this.lblBiling.Text = "Report sales by time";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(346, 58);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(266, 20);
            this.dateTimePickerFrom.TabIndex = 73;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(670, 58);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(266, 20);
            this.dateTimePickerTo.TabIndex = 74;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Date from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(667, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Date to";
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
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 544);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.lblBiling);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboUserId);
            this.Controls.Add(this.chartSalesByTime);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByTime)).EndInit();
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
    }
}