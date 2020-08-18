using DevExpress.Utils;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
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

namespace BarCodeLabel
{
    public partial class LB_LabelStatus : Form, Module.IMDICHID
    {
        #region 1. 변수 설정
        CM_DBLIB db = new CM_DBLIB();
        private Ini SettingIni;
        #endregion

        public LB_LabelStatus()
        {
            InitializeComponent();
        }

        private void LB_LabelStatus_Load(object sender, EventArgs e)
        {
            SetGrid();
        }

        #region 2. 기본 메뉴 함수
        public void NewData()
        {
            date_StartDate.Value = DateTime.Now;
            date_EndDate.Value = DateTime.Now;
            txt_F_BoxNo.Text = string.Empty;

            FieldClear();
            SetGrid();
        }

        public void FindData()
        {
            FieldClear();

            string startDate = date_StartDate.Value.ToString();
            string endDate = date_EndDate.Value.ToString();
            string f_BoxNo = txt_F_BoxNo.Text;
            string sQuery = "";
            sQuery = "EXEC SP_BAR_BARCODEINFO_R @GUBUN, @STARTDATE, @ENDDATE, @BOXNO";

            if (string.IsNullOrEmpty(txt_F_BoxNo.Text))
            {
                SqlParameter[] sPrm = new SqlParameter[4]
                {
                      new SqlParameter("@GUBUN", "ALL")
                    , new SqlParameter("@STARTDATE", "")
                    , new SqlParameter("@ENDDATE", "")
                    , new SqlParameter("@BOXNO", "")
                };
                DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
                DataTable dt = ds.Tables["DATA"];
                gridControl1.DataSource = dt;
                gridControl1.RefreshDataSource();
            }
            else
            {
                SqlParameter[] sPrm = new SqlParameter[4]
                {
                      new SqlParameter("@GUBUN", "SEARCH")
                    , new SqlParameter("@STARTDATE", startDate)
                    , new SqlParameter("@ENDDATE", endDate)
                    , new SqlParameter("@BOXNO", f_BoxNo)
                };
                DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
                DataTable dt = ds.Tables["DATA"];
                gridControl1.DataSource = dt;
                gridControl1.RefreshDataSource();
            }
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

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
            if(gridView1.RowCount == 0)
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

                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(saveFile.FileName, new XlsxExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG });
                }
            }
        }

        public void ExcelUpData()
        {
            throw new NotImplementedException();
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

                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToPdf(saveFile.FileName);
                }
            }
        }
        #endregion

        #region 3. Form 관련 함수
        /// <summary>
        /// Grid 더블 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("조회 후 선택 가능합니다.");
                return;
            }
            txt_PartNumber.Text = gridView1.GetFocusedDataRow()["PART_NUMBER"].ToString();
            txt_Revision.Text = gridView1.GetFocusedDataRow()["REVISION"].ToString();
            txt_Quantiity.Text = gridView1.GetFocusedDataRow()["QUANTITY"].ToString();
            txt_Unit.Text = gridView1.GetFocusedDataRow()["UNIT"].ToString();
            txt_ProdDate.Text = gridView1.GetFocusedDataRow()["PROD_DATE"].ToString();
            txt_LotNo.Text = gridView1.GetFocusedDataRow()["LOT_NO"].ToString();
            txt_SILotNo.Text = gridView1.GetFocusedDataRow()["S_I_LOTNO"].ToString();
            txt_BoxNo.Text = gridView1.GetFocusedDataRow()["BOX_NO"].ToString();
        }

        /// <summary>
        /// 재발행 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            SettingIni = new Ini(@"D:BarCodeLabel_Config\Setting.ini");
            string defaultPrinter = SettingIni.GetIniValue("LB_LABELPRINT", "PRINTNAME");       // SettingIni에서 defaultPrint 가져오기
            string partNumber = txt_PartNumber.Text;                                            // 파트 번호
            string revision = txt_Revision.Text;                                                // Revision
            string quantity = txt_Quantiity.Text;                                               // 수량
            string prodDate = txt_ProdDate.Text;                                                // 발행 기준 일자
            string unit = txt_Unit.Text;                                                        // 수량 단위
            string lotNo = txt_LotNo.Text;                                                      // LOT 번호
            string sILotNo = txt_SILotNo.Text;                                                  // 거래처 번호
            string boxNo = txt_BoxNo.Text;                                                      // 박스 번호

            // Text Field 입력 유효 검증
            if (string.IsNullOrEmpty(partNumber)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(revision)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(quantity)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(prodDate)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(unit)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(lotNo)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(boxNo)) { MessageBox.Show("재발행 할 라벨 정보를 선택해 주세요."); return; }

            // 라벨 발행(정보 전달 -> 출력)
            LB_LabelPrint labelPrint = new LB_LabelPrint();
            labelPrint.barCodePrint(defaultPrinter, partNumber, revision, quantity, prodDate, unit, lotNo, sILotNo, boxNo);

            // DB BARCODEINFO 테이블 라벨 재발행 횟수 추가
            string sQuery = "EXEC SP_BAR_BARCODEINFO_U @BOXNO";
            SqlParameter[] sPrm = new SqlParameter[1]
            {
                new SqlParameter("@BOXNO", boxNo)
            };
            db.NonQueryParams(sQuery, sPrm);
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
            dt.Columns.Add("PART_NUMBER", Type.GetType("System.String"));             // 품번
            dt.Columns.Add("REVISION", Type.GetType("System.String"));                
            dt.Columns.Add("UNIT", Type.GetType("System.String"));                    // 수량 단위
            dt.Columns.Add("QUANTITY", Type.GetType("System.String"));                // 수량
            dt.Columns.Add("S_I_LOTNO", Type.GetType("System.String"));               // 거래처 코드
            dt.Columns.Add("LOT_NO", Type.GetType("System.String"));                  // 로트 번호
            dt.Columns.Add("BOX_NO", Type.GetType("System.String"));                  // 박스 번호
            dt.Columns.Add("PROD_DATE", Type.GetType("System.String"));               // 발행 기준일
            dt.Columns.Add("REPRINT_COUNT", Type.GetType("System.String"));           // 재발행 횟수

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;

            dt.Clear();
            gridView1.RefreshData();

            // 2. Column Name 설정
            gridView1.Columns[0].Caption = "품번";
            gridView1.Columns[1].Caption = "Revision";
            gridView1.Columns[2].Caption = "UNIT";
            gridView1.Columns[3].Caption = "수량";
            gridView1.Columns[4].Caption = "거래처 번호";
            gridView1.Columns[5].Caption = "로트 번호";
            gridView1.Columns[6].Caption = "박스 번호";
            gridView1.Columns[7].Caption = "기준일";
            gridView1.Columns[8].Caption = "재발행";

            // 3. Column Size(Width) 설정
            gridView1.Columns[0].Width = 115;
            gridView1.Columns[1].Width = 45;
            gridView1.Columns[2].Width = 45;
            gridView1.Columns[3].Width = 50;
            gridView1.Columns[4].Width = 115;
            gridView1.Columns[5].Width = 115;
            gridView1.Columns[6].Width = 115;
            gridView1.Columns[7].Width = 100;
            gridView1.Columns[8].Width = 40;

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
            gridView1.RowStyle += GridView1_RowStyle;

            //gridView2.Columns[1].OptionsColumn.ReadOnly = false; gridView2.Columns[1].OptionsColumn.AllowEdit = true;
            gridView1.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은고딕", 8f, FontStyle.Regular);
            gridView1.Appearance.Row.Font = new System.Drawing.Font("맑은고딕", 8f, FontStyle.Regular);

            this.ActiveControl = tableLayoutPanel1;
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
        /// Text Field 지우기
        /// </summary>
        private void FieldClear()
        {
            txt_PartNumber.Text = string.Empty;
            txt_Revision.Text = string.Empty;
            txt_Quantiity.Text = string.Empty;
            txt_Unit.Text = string.Empty;
            txt_ProdDate.Text = string.Empty;
            txt_LotNo.Text = string.Empty;
            txt_SILotNo.Text = string.Empty;
            txt_BoxNo.Text = string.Empty;
        }
        #endregion
    }
}
