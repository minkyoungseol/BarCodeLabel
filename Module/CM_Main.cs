// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using VB = Microsoft.VisualBasic;
//using Microsoft.VisualBasic.Compatibility;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Text;

//using Login;

namespace Module
{
    public class CM_Main
    {

        //파일 경로
        public static string COMMON_PATH;
        public static string EXEPATH;
        public static string RPTPATH;
        public static string LANPATH;
        public static string WINDOWSPATH;
        public static string SYSTEMPATH;

        //서버 접속을 위한 정보 저장
        public static string ADDRESS;
        public static string DATABASE;
        public static string S_PWD;
        public static string S_UID;
        public static string QUERYTIME;

        // 로그인 아이디, 비번
        public static string UID;
        public static string UPW;
        //public static string UNAME;
        
        //FTP 서버 정보
        public static short ServerType; //[  1:DB,   2:FTP   ]   default = DB
        public static string FTP_ADDRESS;
        public static string FTP_PORT;
        public static string FTP_UID;
        public static string FTP_PWD;

        // 화면id 화면명
        public static string GS_FormID;
        public static string GS_FormNM;

        public static string gPrinter;

        //작업표시줄에 표시하기 위한 API
        [DllImport("user32", EntryPoint = "GetWindowLongA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetWindowLong(int hwnd, int nIndex);
        [DllImport("user32", EntryPoint = "SetWindowLongA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetWindowLong(int hwnd, int nIndex, int dwNewLong);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void ReleaseCapture();

        //윈도우 디렉토리 및 시스템 디렉토리를 가져오는 API
        [DllImport("kernel32", EntryPoint = "GetWindowsDirectoryA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetWindowsDirectory(string lpBuffer, int nSize);
        [DllImport("kernel32.dll", EntryPoint = "GetSystemDirectoryA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetSystemDirectory(string lpBuffer, int nSize);


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const short HTCAPTION = 2;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int SetTextCharacterExtra(
            IntPtr hdc, //dc handle
            int nCharExtra // extra-space value
            );


        //프로그램 시작부
        public static void Read_INI()
        {
            try
            {
                //common.ini 경로 설정
                COMMON_PATH = AppDomain.CurrentDomain.BaseDirectory + "common.ini";
                EXEPATH = AppDomain.CurrentDomain.BaseDirectory;
                RPTPATH = AppDomain.CurrentDomain.BaseDirectory + "Print\\";
                LANPATH = AppDomain.CurrentDomain.BaseDirectory + "Language\\";
                WINDOWSPATH = GetWinSysPath(false);
                SYSTEMPATH = GetWinSysPath(true);

                Ini ini = new Ini(@"D:BarCodeLabel_Config\Setting.ini");
                UID = ini.GetIniValue("USER_INFO", "UID");
                UPW = ini.GetIniValue("USER_INFO", "UPW");
                //UNAME = ini.GetIniValue("USER_INFO", "UNAME");

                //서버 접속을 위한 정보
                ADDRESS = ini.GetIniValue("SQLPATH", "ADDRESS");
                DATABASE = ini.GetIniValue("SQLPATH", "DATABASE");
                S_UID = ini.GetIniValue("SQLPATH", "S_UID");
                S_PWD = ini.GetIniValue("SQLPATH", "S_PWD");
                QUERYTIME = ini.GetIniValue("SQLPATH", "QUERYTIME");

                //Connection 을 위한 ODBC Driver 사용, OLE DB Provider 사용 Provider = SqlOleDb
                CM_ADO.CNString = "Driver={SQL Server};" + "Server=" + ADDRESS.Trim() + ";" + "Database=" + DATABASE.Trim() + ";" + "UID=" + S_UID.Trim() + ";" + "PWD=" + S_PWD.Trim();

                CM_ADO.CNStringSP = "server=" + CM_Main.ADDRESS.Trim() + ";database=" + CM_Main.DATABASE.Trim() + ";uid=" + CM_Main.S_UID.Trim() + ";pwd=" + CM_Main.S_PWD.Trim() + " ";

                object[] strCommand = null;
                strCommand = Strings.Split(VB.Interaction.Command(), " ", -1, (VB.CompareMethod)1);
            }
            catch (Exception ex)
            {

            }
        }

        //클라이언트 컴퓨터의 윈도우 및 시스템 디렉토리를 가져오는 함수
        static public string GetWinSysPath(bool System_Renamed)
        {
            return "";
        }


        //-----------------------------------------------------------------------------------------------------------------------
        //    설명 : 콤보박스의 현재 인덱스를 클릭이벤트 없이 바꾸는 함수
        //
        //    인자 : ComboBox - 콤보 컨트롤
        //           ListIndex - 바꾸고자하는 리스트 인덱스
        //-----------------------------------------------------------------------------------------------------------------------
        public static void SetComboIndex(System.Windows.Forms.ComboBox CmbBx, int ListIndex)
        {
            try
            {
                const int CB_SETCURSEL = 0x14E; //인덱스값을 바꿔준다.(Click이벤트가 발생하지 않는다.)

                SendMessage((int)CmbBx.Handle, CB_SETCURSEL, ListIndex, "0");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " \n SetComboIndex Function Error! ");
                return;
            }
        }

        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

    }

     public class Ini
    {
        private string iniPath;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

        public Ini(string path)
        {
            this.iniPath = path;  //INI 파일 위치를 생성할때 인자로 넘겨 받음
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(    // GetIniValue 를 위해
            String section,
            String key,
            String def,
            StringBuilder retVal,
            int size,
            String filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // SetIniValue를 위해
            String section,
            String key,
            String val,
            String filePath);

        // INI 값을 읽어 온다. 
        public String GetIniValue(String Section, String Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);
            return temp.ToString();
        }

        // INI 값을 셋팅
        public void SetIniValue(String Section, String Key, String Value)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }

        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }
    }
}
