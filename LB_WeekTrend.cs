using DevExpress.Utils;
using Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.Charts.Model;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.XtraPrinting.Native.ExportOptionsControllers;
using DevExpress.XtraPrintingLinks;
using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;

namespace BarCodeLabel
{
    public partial class LB_WeekTrend : Form, Module.IMDICHID
    {
        #region 1. 변수 설정
        CM_DBLIB db = new CM_DBLIB();
        #endregion

        public LB_WeekTrend()
        {
            InitializeComponent();
        }

        private void LB_WeekTrend_Load(object sender, EventArgs e)
        {
            date_StartDate.Value = DateTime.Now.AddDays(-6);
            SetGrid();
        }

        #region 2. 기본 메뉴 함수
        public void AddLine()
        {
            throw new NotImplementedException();
        }

        public void DelData()
        {
            throw new NotImplementedException();
        }

        public void DelLine()
        {
            throw new NotImplementedException();
        }

        public void ExcelDnData()
        {
            if(gridView1.RowCount == 0 )
            {
                MessageBox.Show("저장할 데이터가 없습니다. 조회 후 다운로드 가능합니다.");
                return;
            }
            else
            {
                string FileName = this.Text + "(" + DateTime.Now.ToString("yyyyMMdd") + ").xlsx";

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel파일(*.xlsx)|*.xlsx";
                saveFile.FileName = FileName;
                saveFile.RestoreDirectory = true;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    PrintingSystemBase ps = new PrintingSystemBase();   // 프린트 형식에 각각 컨트롤을 링크로 만들어서 같은 엑셀 파일에 뿌리기
                    CompositeLinkBase cl = new CompositeLinkBase();

                    cl.PrintingSystemBase = ps;
                    PrintableComponentLinkBase pcl1 = new PrintableComponentLinkBase(); // 첫번째 그래프 들어갈 링크
                    pcl1.Component = chartControl_Pie;
                    PrintableComponentLinkBase pcl2 = new PrintableComponentLinkBase(); // 두번째 그래프 들어갈 링크
                    pcl2.Component = chartControl_Bar;
                    PrintableComponentLinkBase pcl3 = new PrintableComponentLinkBase(); // 세번째 그리드 들어갈 링크
                    pcl3.Component = gridControl1;

                    XlsxExportOptions options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.DifferentFiles;

                    cl.Links.Add(pcl1);
                    cl.Links.Add(pcl2);
                    cl.Links.Add(pcl3);
                    cl.CreateDocument(); // 각각의 링크를 합쳐서 한개의 문서로 만들어줌
                    cl.ExportToXlsx(saveFile.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG }); // 데이터 있는 만큼만 그리드 그림
                    
                    //gridView1.ExportToXlsx(saveFile.FileName, new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });                    
                }
            }            
        }

        public void ExcelUpData()
        {
            throw new NotImplementedException();
        }

        public void FindData()
        {
            DataSet ds = GetChartData(); // DB에서 바 차트 정보, 파이 차트 정보 한꺼번에 가져오기
            DataTable dt = ds.Tables["DATA"];
            gridControl1.DataSource = dt;
            gridControl1.RefreshDataSource();

            SetBarChart();
            SetPieChart();
        }

        public void NewData()
        {
            date_ProdDate.Value = DateTime.Now;
            date_StartDate.Value = DateTime.Now.AddDays(-6);
            date_EndDate.Value = DateTime.Now;

            SetGrid();
            chartControl_Bar.Series.Clear();
            chartControl_Pie.Series.Clear();
        }

        public void PdfDnData()
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("저장할 데이터가 없습니다. 조회 후 다운로드 가능합니다.");
                return;
            }
            else
            {
                string FileName = this.Text + "(" + DateTime.Now.ToString("yyyyMMdd") + ").pdf";

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF파일(*.pdf)|*.pdf";
                saveFile.FileName = FileName;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    PrintingSystemBase ps = new PrintingSystemBase();   // 프린트 형식에 각각 컨트롤을 링크로 만들어서 같은 엑셀 파일에 뿌리기
                    CompositeLinkBase cl = new CompositeLinkBase();

                    cl.PrintingSystemBase = ps;
                    PrintableComponentLinkBase pcl1 = new PrintableComponentLinkBase(); // 첫번째 그래프 들어갈 링크
                    pcl1.Component = chartControl_Pie;
                    PrintableComponentLinkBase pcl2 = new PrintableComponentLinkBase(); // 두번째 그래프 들어갈 링크
                    pcl2.Component = chartControl_Bar;
                    PrintableComponentLinkBase pcl3 = new PrintableComponentLinkBase(); // 세번째 그리드 들어갈 링크
                    pcl3.Component = gridControl1;

                    XlsxExportOptions options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.DifferentFiles;

                    cl.Links.Add(pcl1);
                    cl.Links.Add(pcl2);
                    cl.Links.Add(pcl3);
                    cl.CreateDocument(); // 각각의 링크를 합쳐서 한개의 문서로 만들어줌
                    cl.ExportToPdf(saveFile.FileName);
                    //gridView1.ExportToPdf(saveFile.FileName);
                }
            }
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 3. Form 관련 함수
        /// <summary>
        /// 레포트 출력 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Report_Click(object sender, EventArgs e)
        {
            if (string.Empty == txt_Remark.Text)        // 비고란 빈칸 검증
            {
                MessageBox.Show("비고란을 입력해주세요.", "오류");
                txt_Remark.Focus();
                return;
            }
            else if (gridView1.RowCount == 0)
            {
                MessageBox.Show("조회 후 출력이 가능합니다. 조회 먼저 실행해 주세요.", "오류");
                txt_Remark.Text = string.Empty;
                return;
            }
            string startDate = date_StartDate.Value.ToString("yyyy-MM-dd");
            string endDate = date_EndDate.Value.ToString("yyyy-MM-dd");
            string remark = txt_Remark.Text;

            DataSet ds = GetChartBarInfo(); // DB에서 바 차트 정보 가져오기

            Report1 report1 = new Report1(startDate, endDate, remark);  // 시작일, 종료일, 비고 전달해서 바로 출력하기 위해 값 같이 넘김
            report1.DataSource = ds;   // 레포트 datasource에 가져온 dataset 설정
            //report1.DataMember = "DATA";

            using(ReportPrintTool printTool = new ReportPrintTool(report1)) // 레포트 미리보기 팝업
            {
                printTool.ShowRibbonPreviewDialog();
            }

            txt_Remark.Text = string.Empty; // 비고란 지우기
            
        }

        /// <summary>
        /// Grid 설정
        /// </summary>
        private void SetGrid()
        {
            gridControl1.DataSource = null;
            DataTable dt = new DataTable();

            // gridView1 셋팅
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            dt.Columns.Add("PROD_DATE", Type.GetType("System.String"));               // 발행 기준일
            dt.Columns.Add("PART_NUMBER", Type.GetType("System.String"));             // 품번
            dt.Columns.Add("CNT", Type.GetType("System.String"));                     // 발행 매수

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;

            dt.Clear();
            gridView1.RefreshData();

            // 2. Column Name 설정
            gridView1.Columns[0].Caption = "기준 일자";
            gridView1.Columns[1].Caption = "품번";
            gridView1.Columns[2].Caption = "발행매수";

            // 3. Column Size(Width) 설정
            gridView1.Columns[0].Width = 200;
            gridView1.Columns[1].Width = 200;
            gridView1.Columns[2].Width = 100;

            // 4. Column Type변경
            //gridView2.Columns[0].Visible = false;

            // 5. Column ReadOnly, Alignment 설정      
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;

                gridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridView1.Columns[i].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            }

            // 6. Row 홀수, 짝수줄 배경색상 설정
            gridView1.RowStyle += GridView1_RowStyle; ;

            //gridView2.Columns[1].OptionsColumn.ReadOnly = false; gridView2.Columns[1].OptionsColumn.AllowEdit = true;
            gridView1.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은고딕", 8f, FontStyle.Regular);
            gridView1.Appearance.Row.Font = new System.Drawing.Font("맑은고딕", 8f, FontStyle.Regular);

            this.ActiveControl = tableLayoutPanel1;
        }

        /// <summary>
        /// 파이 차트 설정
        /// </summary>
        private void SetPieChart()
        {
            chartControl_Pie.Series.Clear();

            DataSet ds = GetChartPieInfo(); // DB 에서 파이 차트 정보 가져오기
            DataTable dt = ds.Tables["DATA"];

            Series series = new Series("", ViewType.Pie);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                series.Points.Add(new SeriesPoint(dt.Rows[i][0].ToString(), Convert.ToInt32(dt.Rows[i][1].ToString())));
                /// 시리즈에 데이터를 point 로 넣어야 들어감(string, int) => (품번, 매수) 형식으로 만들어서 넣어줌
            }
            series.LegendTextPattern = "{A}";   // 오른쪽 상단 색깔별 데이터명(품번) 텍스트 형식 지정
            series.Label.TextPattern = "{VP:p0} ({V:}매)";   // 파이 그래프별 라벨 텍스트 형식 지정
            series.Label.Border.Visibility = DefaultBoolean.False;  // 라벨 데이터에 테두리 없애기
            chartControl_Pie.Series.Add(series);    // 차트컨트롤에 시리즈 추가하면 뿌려줌
            
        }

        /// <summary>
        ///  바 차트 설정
        /// </summary>
        private void SetBarChart()
        {
            chartControl_Bar.Series.Clear();
            DataSet ds = GetChartBarInfo(); // DB에서 바 차트 정보 가져오기
            DataTable dt = ds.Tables["DATA"];

            Series series = new Series("", ViewType.Bar);

            chartControl_Bar.Series.Add(series);

            chartControl_Bar.CrosshairEnabled = DefaultBoolean.False;

            XYDiagram diagram = (XYDiagram)chartControl_Bar.Diagram;
            diagram.AxisX.Label.TextPattern = "{A: yy-MM-dd}";  // X축 라벨 표시 형식 
            //diagram.AxisY.WholeRange.MaxValue = 50;             // Y축 최대값 
            //diagram.AxisY.WholeRange.MinValue = 0;              // Y축 최소값
            diagram.AxisX.WholeRange.MaxValue = 0;
            diagram.AxisY.WholeRange.Auto = true;               // Y축 Min-Max값에 따라 유동적으로 설정            
            diagram.EnableAxisXScrolling = false;
            diagram.EnableAxisXZooming = false;
            diagram.EnableAxisYScrolling = false;
            diagram.EnableAxisYZooming = false;

            series.DataSource = dt;
            series.ArgumentDataMember = dt.Columns[0].ColumnName;
            series.ValueDataMembers.AddRange(new string[] { dt.Columns[1].ColumnName});
            series.LabelsVisibility = DefaultBoolean.True;
            (series.Label as BarSeriesLabel).Position = BarSeriesLabelPosition.Top;  // 라벨 위치 막대그래프 위에 나타나도록
            series.Label.Border.Visibility = DefaultBoolean.False;  // 라벨 데이터에 테두리 없애기
        }

        /// <summary>
        /// GridView 홀, 짝수줄 배경 색상 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int i = gridView1.GetDataSourceRowIndex(e.RowHandle);
                if (i == 0 || (i % 2) == 0)
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }        

        /// <summary>
        /// 기준일자 선택하면 시작일자 종료일자 바로 셋팅해서 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void date_ProdDate_ValueChanged(object sender, EventArgs e)
        {
            date_StartDate.Value = date_ProdDate.Value.AddDays(-6);
            date_EndDate.Value = date_ProdDate.Value;
        }

        #endregion

        #region 4. DB에 데이터 가져오는 함수
        /// <summary>
        /// 바 차트, 파이 차트 정보 한꺼번에 가져오기
        /// </summary>
        /// <returns></returns>
        private DataSet GetChartData()
        {
            string startDate = date_StartDate.Value.ToString("yyyy-MM-dd");
            string endDate = date_EndDate.Value.ToString("yyyy-MM-dd");

            string sQuery = "";
            sQuery = "EXEC SP_BAR_BARCODEINFO_R @GUBUN, @STARTDATE, @ENDDATE, @BOXNO";
            SqlParameter[] sPrm = new SqlParameter[4]
            {
                  new SqlParameter("@GUBUN", "CHART")
                , new SqlParameter("@STARTDATE", startDate)
                , new SqlParameter("@ENDDATE", endDate)
                , new SqlParameter("@BOXNO", "")
            };

            DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
            return ds;
        }
        /// <summary>
        /// 바 차트 정보(일별 총 출력 매수)
        /// </summary>
        /// <returns></returns>
        private DataSet GetChartBarInfo()
        {
            string startDate = date_StartDate.Value.ToString("yyyy-MM-dd");
            string endDate = date_EndDate.Value.ToString("yyyy-MM-dd");
            string sQuery = "";
            sQuery = "EXEC SP_BAR_BARCODEINFO_R @GUBUN, @STARTDATE, @ENDDATE, @BOXNO";
            SqlParameter[] sPrm = new SqlParameter[4]
            {
                  new SqlParameter("@GUBUN", "CHARTBAR")
                , new SqlParameter("@STARTDATE", startDate)
                , new SqlParameter("@ENDDATE", endDate)
                , new SqlParameter("@BOXNO", "")
            };

            DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
            return ds;
        }

        /// <summary>
        /// 파이 차트 정보(각 일자 품목별 출력 매수)
        /// </summary>
        /// <returns></returns>
        private DataSet GetChartPieInfo()
        {
            string startDate = date_StartDate.Value.ToString("yyyy-MM-dd");
            string endDate = date_EndDate.Value.ToString("yyyy-MM-dd");
            string sQuery = "";
            sQuery = "EXEC SP_BAR_BARCODEINFO_R @GUBUN, @STARTDATE, @ENDDATE, @BOXNO";
            SqlParameter[] sPrm = new SqlParameter[4]
            {
                  new SqlParameter("@GUBUN", "CHARTPIE")
                , new SqlParameter("@STARTDATE", startDate)
                , new SqlParameter("@ENDDATE", endDate)
                , new SqlParameter("@BOXNO", "")
            };

            DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
            return ds;
        }
        #endregion

    }
}
