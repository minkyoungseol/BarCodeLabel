using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BarCodeLabel
{
    public partial class BarCode : DevExpress.XtraReports.UI.XtraReport
    {
        public BarCode(string partNumber, string revision, string quantity, string prodDate, string unit, string lotNo, string sILotNo, string boxNo)        
        {
            InitializeComponent();
            tc_PartNumber.Text = partNumber;
            tc_Quantity.Text = quantity;
            tc_Revision.Text = revision;
            tc_LotNo.Text = lotNo;
            tc_BoxNo.Text = boxNo;

            txt_PartNumber.Text = partNumber;
            txt_Revision.Text = revision;
            txt_Quantity.Text = quantity;
            txt_ProdDate.Text = prodDate;
            txt_Unit.Text = unit;
            txt_LotNo.Text = lotNo;
            txt_SILotNo.Text = sILotNo;

            barCode_PartNumber.Text = partNumber;
            barCode_Revision.Text = revision;
            barCode_Quantity.Text = quantity;
            barCode_BoxNo.Text = boxNo;
            barCode_QR1.Text = boxNo + " | "
                             + partNumber + " | "
                             + quantity + " | "
                             + lotNo + " | "
                             + sILotNo + " | 208 | "
                             + revision;
            barCode_QR2.Text = boxNo + " | "
                             + partNumber + " | "
                             + quantity + " | "
                             + lotNo + " | "
                             + sILotNo + " | 208 | "
                             + revision;
        }

    }
}
