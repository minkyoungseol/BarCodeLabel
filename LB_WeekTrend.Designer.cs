namespace BarCodeLabel
{
    partial class LB_WeekTrend
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
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle4 = new DevExpress.XtraCharts.ChartTitle();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartControl_Pie = new DevExpress.XtraCharts.ChartControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date_StartDate = new System.Windows.Forms.DateTimePicker();
            this.date_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date_ProdDate = new System.Windows.Forms.DateTimePicker();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.btn_Report = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chartControl_Bar = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_Pie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_Bar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1264, 825);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "주별 TREND";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartControl_Pie, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chartControl_Bar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.875F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1256, 800);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chartControl_Pie
            // 
            this.chartControl_Pie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl_Pie.Legend.Name = "Default Legend";
            this.chartControl_Pie.Location = new System.Drawing.Point(3, 151);
            this.chartControl_Pie.Name = "chartControl_Pie";
            this.chartControl_Pie.PaletteName = "Foundry";
            this.chartControl_Pie.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl_Pie.Size = new System.Drawing.Size(622, 439);
            this.chartControl_Pie.TabIndex = 2;
            chartTitle3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle3.Text = "품목별 출력 현황";
            this.chartControl_Pie.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle3});
            // 
            // groupControl2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl2, 2);
            this.groupControl2.Controls.Add(this.tableLayoutPanel2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1250, 142);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "검색 조건";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.085346F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.99678F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.25604F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.70853F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.334944F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.38647F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.71498F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.date_StartDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.date_EndDate, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_Remark, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Report, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.date_ProdDate, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1242, 117);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "기준 일자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(238, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 77);
            this.label2.TabIndex = 2;
            this.label2.Text = "(기준일자 이전 6일 ~ 기준일자 까지 조회)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // date_StartDate
            // 
            this.date_StartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_StartDate.Enabled = false;
            this.date_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_StartDate.Location = new System.Drawing.Point(500, 27);
            this.date_StartDate.Name = "date_StartDate";
            this.date_StartDate.Size = new System.Drawing.Size(125, 22);
            this.date_StartDate.TabIndex = 3;
            // 
            // date_EndDate
            // 
            this.date_EndDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_EndDate.Enabled = false;
            this.date_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_EndDate.Location = new System.Drawing.Point(660, 27);
            this.date_EndDate.Name = "date_EndDate";
            this.date_EndDate.Size = new System.Drawing.Size(122, 22);
            this.date_EndDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(632, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "비고";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date_ProdDate
            // 
            this.date_ProdDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.date_ProdDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_ProdDate.Location = new System.Drawing.Point(90, 27);
            this.date_ProdDate.Name = "date_ProdDate";
            this.date_ProdDate.Size = new System.Drawing.Size(130, 22);
            this.date_ProdDate.TabIndex = 1;
            this.date_ProdDate.ValueChanged += new System.EventHandler(this.date_ProdDate_ValueChanged);
            // 
            // txt_Remark
            // 
            this.txt_Remark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.txt_Remark, 4);
            this.txt_Remark.Location = new System.Drawing.Point(90, 86);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(564, 22);
            this.txt_Remark.TabIndex = 7;
            // 
            // btn_Report
            // 
            this.btn_Report.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Report.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.subreport_32x321;
            this.btn_Report.Location = new System.Drawing.Point(660, 85);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(122, 23);
            this.btn_Report.TabIndex = 8;
            this.btn_Report.Text = "레포트  출력";
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // gridControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl1, 2);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 596);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1250, 201);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // chartControl_Bar
            // 
            this.chartControl_Bar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartControl_Bar.Legend.Name = "Default Legend";
            this.chartControl_Bar.Location = new System.Drawing.Point(631, 153);
            this.chartControl_Bar.Name = "chartControl_Bar";
            this.chartControl_Bar.PaletteName = "Foundry";
            this.chartControl_Bar.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl_Bar.Size = new System.Drawing.Size(622, 434);
            this.chartControl_Bar.TabIndex = 4;
            chartTitle4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle4.Text = "일자별 출력 현황";
            this.chartControl_Bar.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle4});
            // 
            // LB_WeekTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 825);
            this.Controls.Add(this.groupControl1);
            this.Name = "LB_WeekTrend";
            this.Text = "주차별 TREND";
            this.Load += new System.EventHandler(this.LB_WeekTrend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_Pie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_Bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date_ProdDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.DateTimePicker date_StartDate;
        private System.Windows.Forms.DateTimePicker date_EndDate;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraCharts.ChartControl chartControl_Bar;
        private DevExpress.XtraCharts.ChartControl chartControl_Pie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Remark;
        private DevExpress.XtraEditors.SimpleButton btn_Report;
    }
}