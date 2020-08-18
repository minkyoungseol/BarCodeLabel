using Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeLabel
{
    public partial class LogIn : Form
    {
        string UID;
        string UPW;
        private Ini SettingIni;
        private string HistoryIni;
        CM_DBLIB db = new CM_DBLIB();

        public LogIn()
        { 
            InitializeComponent();            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // Settingini파일 Load
            if (Directory.Exists(@"D:BarCodeLabel_Config") == false) { Directory.CreateDirectory(@"D:BarCodeLabel_Config"); }
            if (File.Exists(@"D:BarCodeLabel_Config\Setting.ini") == false) { File.Create(@"D:BarCodeLabel_Config\Setting.ini"); }
            if (File.Exists(@"D:BarCodeLabel_Config\" + DateTime.Now.ToString("yyyyMMdd") + ".ini") == false) { File.Create(@"D:BarCodeLabel_Config\" + DateTime.Now.ToString("yyyyMMdd") + ".ini"); }

            SettingIni = new Ini(@"D:BarCodeLabel_Config\Setting.ini");
            HistoryIni = @"D:BarCodeLabel_Config\" + DateTime.Now.ToString("yyyyMMdd") + ".ini";

            txt_ID.Text = "";
            txt_PW.Text = "";

            CM_Main.UID = "";
            CM_Main.UPW = "";

            CM_Main.Read_INI();
            
            if(CM_Main.UID != "")
            {
                txt_ID.Text = CM_Main.UID;
                check_SaveID.Checked = true;
            }
            else
            {
                txt_ID.Text = "";
                check_SaveID.Checked = false;
            }
            if(CM_Main.UPW != "")
            {
                txt_PW.Text = CM_Main.UPW;
                check_SavePW.Checked = true;
            }
            else
            {
                txt_PW.Text = "";
                check_SavePW.Checked = false;
            }
        }

        /// <summary>
        /// 로그인 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UID = txt_ID.Text;
            UPW = txt_PW.Text;
            string C_PW = EncryptSHA512(UPW);       // 비밀번호 암호화

            try
            {
                if(check_SaveID.Checked == true)    // 아이디 저장 체크
                {
                    SettingIni.SetIniValue("USER_INFO", "UID", UID);
                }
                else
                {
                    SettingIni.SetIniValue("USER_INFO", "UID", "");
                }

                string sQuery = "";
                string Rstr = "";
                sQuery = "EXEC SP_LOGINCHECK_R @P_ID, @P_PW";

                SqlParameter[] sPrm = new SqlParameter[2]
                {
                      new SqlParameter("@P_ID", UID)
                    , new SqlParameter("@P_PW", C_PW)
                };

                Rstr = db.selectParmQuery(sQuery, sPrm);

                if(Rstr == "1")
                {
                    if (check_SavePW.Checked == true)   // 비밀번호 저장 체크
                    {
                        SettingIni.SetIniValue("USER_INFO", "UPW", UPW);
                    }
                    else
                    {
                        SettingIni.SetIniValue("USER_INFO", "UPW", "");
                    }
                    CM_Main.UID = UID;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호를 확인해 주세요.");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 비밀번호 암호화
        public static string EncryptSHA512(string Data)
        {
            SHA512 sha = new SHA512Managed();
            //byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(Data));
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(Data));
            StringBuilder strb = new StringBuilder();
            foreach (byte b in hash)
            {
                strb.AppendFormat("{0:x2}", b);
            }
            return strb.ToString();
        }
        #endregion

        #region 비밀번호 입력 후 엔터 키 입력 == 로그인 버튼 클릭
        private void txt_PW_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(null, null);
                e.Handled = true;
                return;
            }            
        }
        #endregion
    }
}
