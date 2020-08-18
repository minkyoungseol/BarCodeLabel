using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Module;
using DevExpress.ClipboardSource.SpreadsheetML;
using System.Text.RegularExpressions;
using DevExpress.Utils;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace BarCodeLabel
{
    public partial class SUB_Subject : Form, Module.IMDICHID
    {
        #region 1. 변수 설정
        private string File_Dic = System.IO.Directory.GetCurrentDirectory();
        string UID = CM_Main.UID;
        CM_DBLIB db = new CM_DBLIB();
        bool partCheck = false;     // 중복확인 체크 여부 확인 위한 변수
        #endregion

        
        public SUB_Subject()
        {
            InitializeComponent();
        }

        #region 2. 기본 메뉴 함수
        private void SUB_Subject_Load(object sender, EventArgs e)
        {
            NewData();
        }

        public void NewData()
        {
            FieldClear();
            SetGrid();
        }

        public void AddLine()
        {
            throw new NotImplementedException();
        }

        public void DelData()
        {
            string partNumber = txt_PartNumber.Text;
            if (string.IsNullOrEmpty(partNumber)) { MessageBox.Show("물품정보를 선택해 주세요.");  return; }

            string sQuery = "EXEC SP_BAR_SUBJECT_C @GUBUN, @PARTNUMBER, @REVISION, @UNIT, @BOXQUANTITY, @SILOTNO, @UID";

            SqlParameter[] sPrm = new SqlParameter[7]
            {
                  new SqlParameter("@GUBUN", "DELETE")
                , new SqlParameter("@PARTNUMBER", partNumber)
                , new SqlParameter("@REVISION", "")
                , new SqlParameter("@UNIT", "")
                , new SqlParameter("@BOXQUANTITY", "")
                , new SqlParameter("@SILOTNO", "")
                , new SqlParameter("@UID", "")
            };

            db.NonQueryParams(sQuery, sPrm);

            MessageBox.Show("물품 정보가 삭제 되었습니다.");
            FieldClear();
            FindData();
        }

        public void DelLine()
        {
            throw new NotImplementedException();
        }

        public void ExcelDnData()
        {
            if (gridView2.RowCount == 0)
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

                if (saveFile.ShowDialog() == DialogResult.OK)
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
            throw new NotImplementedException();
        }

        public void FindData()
        {
            string findPartNumber = txt_F_PartNumber.Text;

            string sQuery = "EXEC SP_BAR_SUBJECT_R @GUBUN, @PARTNUMBER";
            if (string.IsNullOrEmpty(findPartNumber))
            {
                SqlParameter[] sPrm = new SqlParameter[2]
                {
                      new SqlParameter("@GUBUN", "ALL")
                    , new SqlParameter("PARTNUMBER", "")
                };
                DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
                DataTable dt = ds.Tables["DATA"];
                gridControl1.DataSource = dt;
                gridControl1.RefreshDataSource();
            }
            else
            {
                SqlParameter[] sPrm = new SqlParameter[2]
                {
                      new SqlParameter("@GUBUN", "SEARCH")
                    , new SqlParameter("@PARTNUMBER", findPartNumber)
                };
                DataSet ds = db.SelectQueryDataset(sQuery, sPrm);
                DataTable dt = ds.Tables["DATA"];
                gridControl1.DataSource = dt;
                gridControl1.RefreshDataSource();
            }

        }

        public void SaveData()
        {
            if(partCheck == false) { MessageBox.Show("Part Number 중복 여부를 확인해주세요."); return; }
            if (string.IsNullOrEmpty(txt_PartNumber.Text)) {MessageBox.Show("Part Number를 입력하세요."); return;}
            if (string.IsNullOrEmpty(txt_Revision.Text)) { MessageBox.Show("Revision을 입력하세요."); return; }
            if (string.IsNullOrEmpty(txt_Unit.Text)) { MessageBox.Show("UNIT을 입력하세요."); return; }
            if (string.IsNullOrEmpty(txt_BoxQuantity.Text)) { MessageBox.Show("Box Quantity를 입력하세요."); return; }
            if (string.IsNullOrEmpty(txt_SILotNo.Text)) { MessageBox.Show("Supplier Interal Lot No를 입력하세요."); return; }
            
            string partNumber = txt_PartNumber.Text;
            string revision = txt_Revision.Text;
            string unit = txt_Unit.Text;
            string boxQuantity = txt_BoxQuantity.Text;
            string sILotNo = txt_SILotNo.Text;

            string sQuery = "EXEC SP_BAR_SUBJECT_C @GUBUN, @PARTNUMBER, @REVISION, @UNIT, @BOXQUANTITY, @SILOTNO, @UID";
            SqlParameter[] sPrm = new SqlParameter[7]
            {
                  new SqlParameter("@GUBUN", "SAVE")
                , new SqlParameter("@PARTNUMBER", partNumber)
                , new SqlParameter("@REVISION", revision)
                , new SqlParameter("@UNIT", unit)
                , new SqlParameter("@BOXQUANTITY", boxQuantity)
                , new SqlParameter("@SILOTNO", sILotNo)
                , new SqlParameter("@UID", UID)
            };

            string resultCode = db.selectParmQuery(sQuery, sPrm);
            
            if (resultCode.Equals("UPDATE"))
            {
                MessageBox.Show("품목 정보가 수정되었습니다.");
                FieldClear();
                FindData();
            }
            else if(resultCode.Equals("INSERT"))
            {
                MessageBox.Show("품목이 등록되었습니다.");
                FieldClear();
                FindData();                
            }
            else
            {
                MessageBox.Show("품목이 등록되지 않았습니다. 관리자에게 문의하세요");
            }
        }
        #endregion

        #region 3. Form 관련 함수
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
            dt.Columns.Add("REVISION", Type.GetType("System.String"));                // 
            dt.Columns.Add("UNIT", Type.GetType("System.String"));                    // 수량 단위
            dt.Columns.Add("B_QUANTITY", Type.GetType("System.String"));            // Box당 지정 수량
            dt.Columns.Add("S_I_LOTNO", Type.GetType("System.String")); // 거래처 코드

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;

            dt.Clear();
            gridView2.RefreshData();

            // 2. Column Name 설정
            gridView2.Columns[0].Caption = "Part Number";
            gridView2.Columns[1].Caption = "Revision";
            gridView2.Columns[2].Caption = "UNIT";
            gridView2.Columns[3].Caption = "Box Quantity";
            gridView2.Columns[4].Caption = "Supplier Interal Lot No";

            // 3. Column Size(Width) 설정
            gridView2.Columns[0].Width = 200;
            gridView2.Columns[1].Width = 60;
            gridView2.Columns[2].Width = 60;
            gridView2.Columns[3].Width = 200;
            gridView2.Columns[4].Width = 200;

            // 4. Column Type변경
            //gridView2.Columns[0].Visible = false;

            // 5. Column ReadOnly, Alignment 설정      
            for (int i = 0; i < gridView2.Columns.Count; i++)
            {
                gridView2.Columns[i].OptionsColumn.ReadOnly = true;
                gridView2.Columns[i].OptionsColumn.AllowEdit = false;

                gridView2.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridView2.Columns[i].AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

                gridView2.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gridView2.Columns[i].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            }

            // 6. Row 홀수, 짝수줄 배경색상 설정
            gridView2.RowStyle += GridView2_RowStyle;

            //gridView2.Columns[1].OptionsColumn.ReadOnly = false; gridView2.Columns[1].OptionsColumn.AllowEdit = true;
            gridView2.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;

            gridView2.OptionsView.ColumnAutoWidth = true;
            gridView2.OptionsView.RowAutoHeight = true;
            gridView2.OptionsBehavior.Editable = true;
            gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은고딕", 8f, FontStyle.Regular);
            gridView2.Appearance.Row.Font = new System.Drawing.Font("맑은고딕", 8f, FontStyle.Regular);

            this.ActiveControl = tablePanel1;
        }

        private void GridView2_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if(e.RowHandle >= 0)
            {
                int i = gridView2.GetDataSourceRowIndex(e.RowHandle);
                if(i == 0 || (i%2) == 0)
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
            txt_PartNumber.ReadOnly = false;
            txt_PartNumber.Text = string.Empty;
            txt_Revision.Text = string.Empty;
            txt_Unit.Text = string.Empty;
            txt_BoxQuantity.Text = string.Empty;
            txt_SILotNo.Text = string.Empty;
        }

        /// <summary>
        /// PartNumber 중복 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CheckPartNumber_Click(object sender, EventArgs e)
        {
            if(gridView2.RowCount == 0)
            {
                MessageBox.Show("조회 후 선택 가능합니다.");
                return;
            }
            partCheck = false;
            string partNumber = txt_PartNumber.Text;

            if (string.IsNullOrEmpty(partNumber)) { MessageBox.Show("PartNumber를 입력해주세요."); return; }

            string sQuery = "EXEC SP_BAR_SUBJECT_R @GUBUN, @PARTNUMBER";

            SqlParameter[] sPrm = new SqlParameter[2]
            {
                  new SqlParameter("@GUBUN", "CHECK")
                , new SqlParameter("@PARTNUMBER", partNumber)
            };

            string result = db.selectParmQuery(sQuery, sPrm);

            if (result.Equals("0")) 
            { 
                MessageBox.Show("등록가능한 PART NUMBER 입니다.");
                partCheck = true;
            }
            else
            {
                MessageBox.Show("이미 등록된 PART NUMBER 입니다. 다른 번호를 입력해주세요.");
                txt_PartNumber.Text = string.Empty;
                txt_PartNumber.Focus();
                partCheck = false;
                return;
            }            
        }
        #endregion

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView2.RowCount == 0)
            {
                MessageBox.Show("조회 후 선택 가능합니다.");
                return;
            }
            txt_PartNumber.ReadOnly = true;
            partCheck = true;
            txt_PartNumber.Text = gridView2.GetFocusedDataRow()["PART_NUMBER"].ToString();
            txt_Revision.Text = gridView2.GetFocusedDataRow()["REVISION"].ToString();
            txt_Unit.Text = gridView2.GetFocusedDataRow()["UNIT"].ToString();
            txt_BoxQuantity.Text = gridView2.GetFocusedDataRow()["B_QUANTITY"].ToString();
            txt_SILotNo.Text = gridView2.GetFocusedDataRow()["S_I_LOTNO"].ToString();
        }


    }
}
