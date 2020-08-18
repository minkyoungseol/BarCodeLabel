using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Pdf.Native;
using DevExpress.Utils;
using DevExpress.XtraReports.Serialization;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Wizards.Presenters;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSplashScreen;
using Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeLabel
{
    public partial class LB_LabelPrint : Form, Module.IMDICHID
    {
        #region 1. 변수 설정
        private Ini SettingIni;
        string HistoryIni = @"D:BarCodeLabel_Config\" + DateTime.Now.ToString("yyyyMMdd") + ".ini";
        string UID = CM_Main.UID;
        string lotNo;
        string boxNo;        
        CM_DBLIB db = new CM_DBLIB();
        #endregion

        public LB_LabelPrint()
        {
            InitializeComponent();
            PrinterSettings ps = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                ps.PrinterName = printer;
                combo_PrinterName.Items.Add(printer);
            }
        }

        #region 2. 기본 메뉴 함수
        private void LB_LabelPrint_Load(object sender, EventArgs e)
        {
            SettingIni = new Ini(@"D:BarCodeLabel_Config\Setting.ini");

            string printer = CM_Main.GetDefaultPrinter();
            combo_PrinterName.SelectedItem = "";
            NewData();
        }

        public void NewData()
        {
            FieldClear();
            SetGrid();
            //FindData();
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
            throw new NotImplementedException();
        }

        public void ExcelUpData()
        {
            //throw new NotImplementedException();
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "엑셀파일(*.xlsx)|*.xlsx|(*.xls)|*.xls";
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    string conStr = "";
                    string fileName = openFile.FileName;
                    if (File.Exists(fileName))
                    {
                        if (Path.GetExtension(fileName).ToLower() == "xls")
                        {
                            conStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties=Excel 8.0;", fileName);
                        }
                        else if (Path.GetExtension(fileName).ToLower() == "xlsx")
                        {
                            conStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Extended Properties=Excel 12.0 XML;HDR=YES;", fileName);
                        }
                    }

                    DataSet data = new DataSet();

                    string sQuery = "SELECT * FROM [Sheet$]";
                    OleDbConnection oleConn = new OleDbConnection(sQuery);
                    oleConn.Open();

                    OleDbCommand oleCmd = new OleDbCommand(sQuery, oleConn);
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(oleCmd);

                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    data.Tables.Add(dt);

                    gridControl1.DataSource = data.Tables[0].DefaultView;

                    dt.Dispose();
                    dataAdapter.Dispose();
                    oleCmd.Dispose();

                    oleConn.Close();
                    oleConn.Dispose();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            throw new NotImplementedException();
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
            gridView1.RefreshData();

            // 2. Column Name 설정
            gridView1.Columns[0].Caption = "Part Number";
            gridView1.Columns[1].Caption = "Revision";
            gridView1.Columns[2].Caption = "UNIT";
            gridView1.Columns[3].Caption = "Box Quantity";
            gridView1.Columns[4].Caption = "Supplier Interal Lot No";

            // 3. Column Size(Width) 설정
            gridView1.Columns[0].Width = 200;
            gridView1.Columns[1].Width = 60;
            gridView1.Columns[2].Width = 60;
            gridView1.Columns[3].Width = 200;
            gridView1.Columns[4].Width = 200;

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

            this.ActiveControl = tableLayoutPanel4;
        }

        private void GridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                int i = gridView1.GetDataSourceRowIndex(e.RowHandle);
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
            calc_PointX.Text = string.Empty;
            calc_PointY.Text = string.Empty;
            combo_PrinterName.Text = string.Empty;
            date_ProdDate.Value = System.DateTime.Now;
            txt_PartNumber.Text = string.Empty;
            txt_Revision.Text = string.Empty;
            txt_Unit.Text = string.Empty;
            txt_BoxQuantity.Text = string.Empty;
            txt_SILotNo.Text = string.Empty;
            calc_ItemCount.Text = string.Empty;
        }

        /// <summary>
        ///  GridView 더블 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.RowCount == 0)
            {
                MessageBox.Show("조회 후 선택 가능합니다.");
                return;
            }
            txt_PartNumber.Text = gridView1.GetFocusedDataRow()["PART_NUMBER"].ToString();
            txt_Revision.Text = gridView1.GetFocusedDataRow()["REVISION"].ToString();
            txt_Unit.Text = gridView1.GetFocusedDataRow()["UNIT"].ToString();
            txt_BoxQuantity.Text = gridView1.GetFocusedDataRow()["B_QUANTITY"].ToString();
            txt_SILotNo.Text = gridView1.GetFocusedDataRow()["S_I_LOTNO"].ToString();
        }

        /// <summary>
        /// 프린트, X좌표, Y좌표 저장 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SavePrinterPoint_Click(object sender, EventArgs e)
        {
            SettingIni.SetIniValue("LB_LabelPrint", "PrintName", combo_PrinterName.Text);
            SettingIni.SetIniValue("LB_LabelPrint", "PointX", calc_PointX.Text);
            SettingIni.SetIniValue("LB_LabelPrint", "PointY", calc_PointY.Text);
        }

        /// <summary>
        /// 인쇄 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            // 유효성 검증
            if (string.IsNullOrEmpty(txt_PartNumber.Text)) { MessageBox.Show("품목 정보에서 품목을 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(txt_Revision.Text)) { MessageBox.Show("품목 정보에서 품목을 선택해 주세요."); return; }            
            if (string.IsNullOrEmpty(txt_Unit.Text)) { MessageBox.Show("품목 정보에서 품목을 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(txt_SILotNo.Text)) { MessageBox.Show("품목 정보에서 품목을 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(txt_BoxQuantity.Text)) { MessageBox.Show("품목 정보에서 품목을 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(date_ProdDate.Text)) { MessageBox.Show("기준일자를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(combo_PrinterName.Text)) { MessageBox.Show("프린터를 선택해 주세요."); return; }
            if (string.IsNullOrEmpty(calc_ItemCount.Value.ToString())) { MessageBox.Show("물품 수량을 입력해 주세요."); return; }

            string defaultPrinter = combo_PrinterName.Text;
            string partNumber = txt_PartNumber.Text;
            string revision = txt_Revision.Text;
            string prodDate = date_ProdDate.Text;
            string unit = txt_Unit.Text;
            string sILotNo = txt_SILotNo.Text;

            int boxQuantity = Convert.ToInt32(txt_BoxQuantity.Text);        // 박스당 기준 수량
            int itemCount = Convert.ToInt32(calc_ItemCount.Text);           // 물건 수량

            int numOfPrint = (itemCount / boxQuantity);                     // 라벨 출력 매수(몫) = 나머지가 0이면 그대로, 0이 아니면 +1
            int remainder = itemCount % boxQuantity;
            if (remainder != 0)
            {
                numOfPrint = numOfPrint + 1;
                for (int i = 0; i < numOfPrint; i++)
                {
                    lotNo = GetNo("L", 3, prodDate);
                    boxNo = GetNo("B", 5, prodDate);

                    if (i != (numOfPrint - 1))
                    {
                        barCodePrint(defaultPrinter, partNumber, revision, Convert.ToString(boxQuantity), prodDate, unit, lotNo, sILotNo, boxNo);
                        barCodeInfo_Save(partNumber, Convert.ToString(boxQuantity), prodDate, lotNo, boxNo, UID);
                        File.AppendAllText(HistoryIni, DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "::"
                                                     + partNumber + "::"
                                                     + revision + "::"
                                                     + prodDate + "::"
                                                     + unit + "::"
                                                     + sILotNo + "::"
                                                     + Convert.ToString(boxQuantity) + "::"
                                                     + lotNo + "::"
                                                     + boxNo + "::"
                                                     + UID
                                                     + "\n"
                        );
                    }
                    else
                    {
                        barCodePrint(defaultPrinter, partNumber, revision, Convert.ToString(remainder), prodDate, unit, lotNo, sILotNo, boxNo);
                        barCodeInfo_Save(partNumber, Convert.ToString(remainder), prodDate, lotNo, boxNo, UID);
                        File.AppendAllText(HistoryIni, DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "::"
                                                     + partNumber + "::"
                                                     + revision + "::"
                                                     + prodDate + "::"
                                                     + unit + "::"
                                                     + sILotNo + "::"
                                                     + Convert.ToString(remainder) + "::"
                                                     + lotNo + "::"
                                                     + boxNo + "::"
                                                     + UID
                                                     + "\n"
                        );
                    }
                }
            }
            else
            {
                for (int i = 0; i < numOfPrint; i++)
                {
                    lotNo = GetNo("L", 3, prodDate);
                    boxNo = GetNo("B", 5, prodDate);

                    barCodePrint(defaultPrinter, partNumber, revision, Convert.ToString(boxQuantity), prodDate, unit, lotNo, sILotNo, boxNo);
                    File.AppendAllText(HistoryIni, DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "::"
                                                     + partNumber + "::"
                                                     + revision + "::"
                                                     + prodDate + "::"
                                                     + unit + "::"
                                                     + sILotNo + "::"
                                                     + Convert.ToString(boxQuantity) + "::"
                                                     + lotNo + "::"
                                                     + boxNo + "::"
                                                     + UID
                                                     + "\n"
                    );
                }
            }
        }

        /// <summary>
        ///  채번하기 
        /// </summary>
        /// <param name="header"> 바코드 구분(L = Lot, B = Box)</param>
        /// <param name="seqLength"> Seq 길이 </param>
        /// <param name="prodDate"> 기준일자 </param>
        /// <returns></returns>
        private string GetNo(string header, int seqLength, string prodDate)
        {
            string barCodeNumber = "";
            try
            {
                string sQuery = "";

                sQuery = "EXEC SP_MD_GETNO_R @HEADER, @SEQLENGTH, @CONDATE";

                SqlParameter[] sPrm = new SqlParameter[3]
                {
                      new SqlParameter("@HEADER", header)
                    , new SqlParameter("@SEQLENGTH", seqLength)
                    , new SqlParameter("@CONDATE", prodDate)
                };
                barCodeNumber = db.selectParmQuery(sQuery, sPrm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return barCodeNumber;
        }

        /// <summary>
        /// 출력하면서 출력한 바코드 정보 BARCODEINFO TABLE에 저장
        /// </summary>
        /// <param name="partNumber"> 파트 번호 </param>
        /// <param name="quantity"> 수량 </param>
        /// <param name="prodDate"> 발행 기준 일자 </param>
        /// <param name="lotNo"> LOT 번호 </param>
        /// <param name="boxNo"> BOX 번호 </param>
        /// /// <param name="UID"> 사용자 ID </param>
        private void barCodeInfo_Save(string partNumber, string quantity, string prodDate, string lotNo, string boxNo, string UID)
        {
            int resultCode = 0;

            string sQuery = "";
            sQuery = "EXEC SP_BAR_BARCODEINFO_C @PARTNUMBER, @QUANTITY, @PRODDATE, @LOTNO, @BOXNO, @UID";

            SqlParameter[] sPrm = new SqlParameter[6]
            {
                  new SqlParameter("@PARTNUMBER", partNumber)
                , new SqlParameter("@QUANTITY", quantity)
                , new SqlParameter("@PRODDATE", prodDate)
                , new SqlParameter("@LOTNO", lotNo)
                , new SqlParameter("@BOXNO", boxNo)
                , new SqlParameter("@UID", UID)
            };
            resultCode = db.NonQueryParams(sQuery, sPrm);

            if (resultCode != 0)
            {
                MessageBox.Show("출력정보 저장 실패!! 관리자에게 문의하세요!");
            }
        }

        /// <summary>
        /// 프린트 실행(디자인, 데이터 넣어서 프린터 전달)
        /// </summary>
        /// <param name="defaultPrinter"> 선택한 프린터 이름 </param>
        /// <param name="partNumber"></param>
        /// <param name="revision"></param>
        /// <param name="quantity"></param>
        /// <param name="prodDate"></param>
        /// <param name="unit"></param>
        /// <param name="lotNo"></param>
        /// <param name="sILotNo"></param>
        /// <param name="boxNo"></param>
        public void barCodePrint(string defaultPrinter, string partNumber, string revision, string quantity, string prodDate
                                 , string unit, string lotNo, string sILotNo, string boxNo)
        {
            PrintDialog pd = new PrintDialog();

            string s = "";

            s += "^XA";

            // 가로줄
            s += "^FO10,40^GB620,0,2^FS";
            s += "^FO400,360^GB230,0,2^FS";
            s += "^FO400,490^GB130,0,2^FS";
            s += "^FO530,565^GB100,0,2^FS";
            s += "^FO140,590^GB260,0,2^FS";
            s += "^FO530,710^GB100,0,2^FS";
            s += "^FO140,870^GB490,0,2^FS";
            s += "^FO10,1090^GB720,0,2^FS";

            // 세로줄
            s += "^FO10,40^GB0,1050,2^FS";
            s += "^FO140,40^GB0,1050,2^FS";
            s += "^FO270,40^GB0,550,2^FS";
            s += "^FO335,40^GB0,550,2^FS";
            s += "^FO400,40^GB0,830,2^FS";
            s += "^FO465,40^GB0,320,2^FS";
            s += "^FO530,40^GB0,830,2^FS";
            s += "^FO730,870^GB0,220,2^FS";

            // 색상 반전(배경 : 검정, 글씨: 흰색)
            s += "^LRY^FO630,40";
            s += "^GB101,832,101^FS";
            s += "^FWR";
            s += "^FO695,43^A0,20,20^FD Supplier Name^FS";
            s += "^FO695,365^A0,15,15^FD ZFPlant ^FS";
            s += "^FO670,365^A0,15,15^FD TRW Automotive technologies ^FS";
            s += "^FO655,43^A0,20,20^FD Halla StackPole Corporation ^FS";
            s += "^FO645,365^A0,15,15^FD(Shanhai),Co.Ltd.)^FS";
            s += "^FO660,750^A0,35,35^FD 208 ^FS";

            // 데이터명
            s += "^FO600,43^A0,20,20^FD Part Number:^FS";
            s += "^FO600,363^A0,20,20^FD Revision: ^FS";
            s += "^FO600,713^A0,20,20^FD Bonded ^FS";
            s += "^FO485,43^A0,20,20^FD Quantity: ^FS";
            s += "^FO485,363^A0,20,20^FD UNIT: ^FS";
            s += "^FO430,363^A0,20,20^FD " + unit + "^FS";
            s += "^FO420,43^A0,20,20^FD Prod Date:^FS";
            s += "^FO355,43^A0,20,20^FD Lot No.:^FS";
            s += "^FO290,43^A0,20,20^FD Supplier Interal Lot No:^FS";
            //s += "^ FO240,43^A0,20,20^FD Serial No.:^FS";

            //데이터 값
            s += "^FO590,200^A0,30,30^FD" + partNumber + "^FS";
            s += "^FO550,100^BY2^BC,35,N,N,N^FD" + partNumber + "^FS";
            s += "^FO590,500^A0,30,30^FD" + revision + "^FS";
            s += "^FO550,430^BY2^BC,35,N,N,N^FD" + revision + "^FS";
            s += "^FO480,130^A0,30,30^FD" + quantity + "^FS";
            s += "^FO480,200^BY2^BA,30,N,N,N^FD" + quantity + "^FS";
            s += "^FO415,150^A0,30,30^FD" + prodDate + "^FS";
            s += "^FO355,350^A0,20,20^FD" + lotNo + "^FS";
            s += "^FO290,500^A0,20,20^FD" + sILotNo + "^FS";
            //s += "^FO240,320^A0,20,20^FDUSN63238201807130101^FS";
            //s += "^FO160,60^BY2^BC,55,N,N,N^FDUSN63238201807130101^FS";
            s += "^FO195,655^BQ,2,4^FD" + boxNo + " | " 
                                        + partNumber + " | " 
                                        + quantity + " | " 
                                        + lotNo + " | " 
                                        + sILotNo + " | 208 | " 
                                        + revision + "^FS";
            s += "^FO60,400^BY2^BC,40,N,N,N^FD" + boxNo + "^FS";
            s += "^FO30,500^A0,20,20^FD" + boxNo + "^FS";

            //기본 데이터 값

            s += "^FO150,890^A0N,20,20^FDPart No.: " + partNumber + "^FS";
            s += "^FO150,930^A0N,20,20^FDQuantity: " + quantity + "^FS";
            s += "^FO345,930^A0N,20,20^FDRevision: " + revision + "^FS";
            s += "^FO150,970^A0N,20,20^FDLot No.: " + lotNo + "^FS";
            s += "^FO150,1010^A0N20,20^FDBox No.:^FS";
            s += "^FO150,1050^A0N,20,20^FD" + boxNo + "^FS";
            s += "^FO510,900^BQ,2,4^FD" + boxNo + " | " 
                                        + partNumber + " | " 
                                        + quantity + " | " 
                                        + lotNo + " | " 
                                        + sILotNo + " | 208 | " 
                                        + revision + "^FS";
            s += "^XZ";

            CM_Function.RawPrinterHelper.SendStringToPrinter(defaultPrinter, s);
        }


        #endregion
    }
}
