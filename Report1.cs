using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Module;

namespace BarCodeLabel
{
    public partial class Report1 : DevExpress.XtraReports.UI.XtraReport
    {
        CM_DBLIB db = new CM_DBLIB();

        public Report1(string startDate, string endDate, string remark)
        {
            InitializeComponent();
            // 전달받은 값을 값이 들어갈 라벨에 설정
            lb_StartDate.Text = startDate;
            lb_EndDate.Text = endDate;
            tc_Remark.Text = remark;
        }

    }
}
