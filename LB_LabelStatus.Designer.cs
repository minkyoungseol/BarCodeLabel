namespace BarCodeLabel
{
    partial class LB_LabelStatus
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date_StartDate = new System.Windows.Forms.DateTimePicker();
            this.date_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_F_BoxNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_PartNumber = new System.Windows.Forms.TextBox();
            this.txt_Revision = new System.Windows.Forms.TextBox();
            this.txt_Quantiity = new System.Windows.Forms.TextBox();
            this.txt_Unit = new System.Windows.Forms.TextBox();
            this.txt_ProdDate = new System.Windows.Forms.TextBox();
            this.txt_LotNo = new System.Windows.Forms.TextBox();
            this.txt_SILotNo = new System.Windows.Forms.TextBox();
            this.txt_BoxNo = new System.Windows.Forms.TextBox();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 115);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(959, 707);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tableLayoutPanel2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(959, 106);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "검색 조건";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.date_StartDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.date_EndDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_F_BoxNo, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(951, 81);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Box No";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "기준 일자";
            // 
            // date_StartDate
            // 
            this.date_StartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_StartDate.Location = new System.Drawing.Point(81, 29);
            this.date_StartDate.Name = "date_StartDate";
            this.date_StartDate.Size = new System.Drawing.Size(112, 22);
            this.date_StartDate.TabIndex = 0;
            // 
            // date_EndDate
            // 
            this.date_EndDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_EndDate.Location = new System.Drawing.Point(242, 29);
            this.date_EndDate.Name = "date_EndDate";
            this.date_EndDate.Size = new System.Drawing.Size(129, 22);
            this.date_EndDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "~";
            // 
            // txt_F_BoxNo
            // 
            this.txt_F_BoxNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_F_BoxNo.Location = new System.Drawing.Point(476, 29);
            this.txt_F_BoxNo.Name = "txt_F_BoxNo";
            this.txt_F_BoxNo.Size = new System.Drawing.Size(174, 22);
            this.txt_F_BoxNo.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.34494F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.65506F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.57576F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.42424F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 825);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.tableLayoutPanel3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(968, 3);
            this.groupControl2.Name = "groupControl2";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl2, 2);
            this.groupControl2.Size = new System.Drawing.Size(293, 819);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "바코드 발행 상세 정보";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label9, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label11, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label10, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.txt_PartNumber, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_Revision, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txt_Quantiity, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txt_Unit, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.txt_ProdDate, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.txt_LotNo, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.txt_SILotNo, 3, 6);
            this.tableLayoutPanel3.Controls.Add(this.txt_BoxNo, 3, 7);
            this.tableLayoutPanel3.Controls.Add(this.btn_Print, 1, 8);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(285, 794);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label4, 2);
            this.label4.Location = new System.Drawing.Point(31, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part Number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label5, 2);
            this.label5.Location = new System.Drawing.Point(31, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Revision";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label6, 2);
            this.label6.Location = new System.Drawing.Point(31, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Quantity";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label7, 2);
            this.label7.Location = new System.Drawing.Point(31, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "UNIT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label8, 2);
            this.label8.Location = new System.Drawing.Point(31, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "Prod Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label9, 2);
            this.label9.Location = new System.Drawing.Point(31, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "Lot No";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label11, 2);
            this.label11.Location = new System.Drawing.Point(31, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 63);
            this.label11.TabIndex = 9;
            this.label11.Text = "Supplier Interal\r\nLot NO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.label10, 2);
            this.label10.Location = new System.Drawing.Point(31, 465);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "Box No";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_PartNumber
            // 
            this.txt_PartNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_PartNumber, 2);
            this.txt_PartNumber.Location = new System.Drawing.Point(130, 20);
            this.txt_PartNumber.Name = "txt_PartNumber";
            this.txt_PartNumber.ReadOnly = true;
            this.txt_PartNumber.Size = new System.Drawing.Size(122, 22);
            this.txt_PartNumber.TabIndex = 10;
            // 
            // txt_Revision
            // 
            this.txt_Revision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_Revision, 2);
            this.txt_Revision.Location = new System.Drawing.Point(130, 83);
            this.txt_Revision.Name = "txt_Revision";
            this.txt_Revision.ReadOnly = true;
            this.txt_Revision.Size = new System.Drawing.Size(122, 22);
            this.txt_Revision.TabIndex = 11;
            // 
            // txt_Quantiity
            // 
            this.txt_Quantiity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_Quantiity, 2);
            this.txt_Quantiity.Location = new System.Drawing.Point(130, 146);
            this.txt_Quantiity.Name = "txt_Quantiity";
            this.txt_Quantiity.ReadOnly = true;
            this.txt_Quantiity.Size = new System.Drawing.Size(122, 22);
            this.txt_Quantiity.TabIndex = 12;
            // 
            // txt_Unit
            // 
            this.txt_Unit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_Unit, 2);
            this.txt_Unit.Location = new System.Drawing.Point(130, 209);
            this.txt_Unit.Name = "txt_Unit";
            this.txt_Unit.ReadOnly = true;
            this.txt_Unit.Size = new System.Drawing.Size(122, 22);
            this.txt_Unit.TabIndex = 13;
            // 
            // txt_ProdDate
            // 
            this.txt_ProdDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_ProdDate, 2);
            this.txt_ProdDate.Location = new System.Drawing.Point(130, 272);
            this.txt_ProdDate.Name = "txt_ProdDate";
            this.txt_ProdDate.ReadOnly = true;
            this.txt_ProdDate.Size = new System.Drawing.Size(122, 22);
            this.txt_ProdDate.TabIndex = 14;
            // 
            // txt_LotNo
            // 
            this.txt_LotNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_LotNo, 2);
            this.txt_LotNo.Location = new System.Drawing.Point(130, 335);
            this.txt_LotNo.Name = "txt_LotNo";
            this.txt_LotNo.ReadOnly = true;
            this.txt_LotNo.Size = new System.Drawing.Size(122, 22);
            this.txt_LotNo.TabIndex = 15;
            // 
            // txt_SILotNo
            // 
            this.txt_SILotNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_SILotNo, 2);
            this.txt_SILotNo.Location = new System.Drawing.Point(130, 398);
            this.txt_SILotNo.Name = "txt_SILotNo";
            this.txt_SILotNo.ReadOnly = true;
            this.txt_SILotNo.Size = new System.Drawing.Size(122, 22);
            this.txt_SILotNo.TabIndex = 16;
            // 
            // txt_BoxNo
            // 
            this.txt_BoxNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.SetColumnSpan(this.txt_BoxNo, 2);
            this.txt_BoxNo.Location = new System.Drawing.Point(130, 461);
            this.txt_BoxNo.Name = "txt_BoxNo";
            this.txt_BoxNo.ReadOnly = true;
            this.txt_BoxNo.Size = new System.Drawing.Size(122, 22);
            this.txt_BoxNo.TabIndex = 17;
            // 
            // btn_Print
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.btn_Print, 4);
            this.btn_Print.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.printer_32x32;
            this.btn_Print.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_Print.Location = new System.Drawing.Point(31, 507);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(221, 136);
            this.btn_Print.TabIndex = 18;
            this.btn_Print.Text = "재발행";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // LB_LabelStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 825);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LB_LabelStatus";
            this.Text = "라벨 출력 현황";
            this.Load += new System.EventHandler(this.LB_LabelStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_StartDate;
        private System.Windows.Forms.DateTimePicker date_EndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_F_BoxNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_PartNumber;
        private System.Windows.Forms.TextBox txt_Revision;
        private System.Windows.Forms.TextBox txt_Quantiity;
        private System.Windows.Forms.TextBox txt_Unit;
        private System.Windows.Forms.TextBox txt_ProdDate;
        private System.Windows.Forms.TextBox txt_LotNo;
        private System.Windows.Forms.TextBox txt_SILotNo;
        private System.Windows.Forms.TextBox txt_BoxNo;
        private DevExpress.XtraEditors.SimpleButton btn_Print;
    }
}