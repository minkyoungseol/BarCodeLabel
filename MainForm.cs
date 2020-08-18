using Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeLabel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region /// 메뉴 호출 ///
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                SUB_Subject frm = new SUB_Subject();

                CheckPermission(frm.Name);

                if (this.MdiChildren.Length != 0)
                {
                    foreach (Form child in this.MdiChildren)
                    {
                        if (child.Name.Equals(frm.Name))
                        {
                            child.Focus();
                            return;
                        }
                    }
                }                
                frm.MdiParent = this;
                frm.Text = "품목 등록";
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                this.ActivateMdiChild(frm);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_LabelPrint_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                LB_LabelPrint frm = new LB_LabelPrint();

                CheckPermission(frm.Name);

                if (this.MdiChildren.Length != 0)
                {
                    foreach (Form child in this.MdiChildren)
                    {
                        if (child.Name.Equals(frm.Name))
                        {
                            child.Focus();
                            return;
                        }
                    }
                }

                frm.MdiParent = this;
                frm.Text = "라벨 발행";
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                this.ActivateMdiChild(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_LabelPrint_View_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                LB_LabelStatus frm = new LB_LabelStatus();

                CheckPermission(frm.Name);

                if (this.MdiChildren.Length != 0)
                {
                    foreach (Form child in this.MdiChildren)
                    {
                        if (child.Name.Equals(frm.Name))
                        {
                            child.Focus();
                            return;
                        }
                    }
                }

                frm.MdiParent = this;
                frm.Text = "라벨 발행 현황";
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                this.ActivateMdiChild(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_WeekTrend_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                LB_WeekTrend frm = new LB_WeekTrend();

                CheckPermission(frm.Name);

                if(this.MdiChildren.Length != 0)
                {
                    foreach(Form child in this.MdiChildren)
                    {
                        if (child.Name.Equals(frm.Name))
                        {
                            child.Focus();
                            return;
                        }
                    }
                }

                frm.MdiParent = this;
                frm.Text = "주별 TREND";
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                this.ActivateMdiChild(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion /// 메뉴 호출 /// 

        // 신규 버튼
        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if(active == null)
                {
                    return;
                }

                if(this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.NewData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 엑셀 업로드 버튼
        private void btn_ExcelUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.ExcelUpData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 엑셀 다운로드 버튼
        private void btn_ExcelDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.ExcelDnData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_PdfDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.PdfDnData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 라인 추가 버튼
        private void btn_AddLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.AddLine();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 라인 삭제 버튼
        private void btn_DelLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.DelLine();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 저장 버튼
        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.SaveData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 삭제 버튼
        private void btn_Del_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.DelData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        // 닫기 버튼
        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }
                active.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 시스템 종료 버튼
        private void btn_LogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
                CM_Main.UID = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 검색 버튼
        private void btn_Find_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var active = this.ActiveMdiChild;

                if (active == null)
                {
                    return;
                }

                if (this.ActiveMdiChild.Name != null)
                {
                    object activeForm;
                    activeForm = this.ActiveMdiChild;
                    Module.IMDICHID ChildForm = (Module.IMDICHID)this.ActiveMdiChild;
                    this.Cursor = Cursors.WaitCursor;

                    ChildForm.FindData();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 버튼 활성화, 비활성화 설정
        /// </summary>
        /// <param name="formName"> 폼 Name </param>
        private void CheckPermission(string formName)
        {
            if (formName.Equals("SUB_Subject"))            // 품목등록
            {
                btn_Find.Enabled = true;
                btn_Save.Enabled = true;
                btn_ExcelUp.Enabled = false;
                btn_ExcelDown.Enabled = true;
                btn_AddLine.Enabled = false;
                btn_DelLine.Enabled = false;
                btn_Del.Enabled = true;
                btn_PdfDown.Enabled = false;
            }
            else if (formName.Equals("LB_LabelPrint"))     // 라벨 발행
            {
                btn_Find.Enabled = true;
                btn_Save.Enabled = false;
                btn_ExcelUp.Enabled = true;
                btn_ExcelDown.Enabled = false;
                btn_AddLine.Enabled = false;
                btn_DelLine.Enabled = false;
                btn_Del.Enabled = false;
                btn_PdfDown.Enabled = false;
            }
            else if (formName.Equals("LB_LabelStatus"))    // 라벨 발행 현황
            {
                btn_Find.Enabled = true;
                btn_Save.Enabled = false;
                btn_ExcelUp.Enabled = false;
                btn_ExcelDown.Enabled = true;
                btn_AddLine.Enabled = false;
                btn_DelLine.Enabled = false;
                btn_Del.Enabled = false;
                btn_PdfDown.Enabled = true;
            }
            else if (formName.Equals("LB_WeekTrend"))
            {
                btn_Find.Enabled = true;
                btn_Save.Enabled = false;
                btn_ExcelUp.Enabled = false;
                btn_ExcelDown.Enabled = true;
                btn_AddLine.Enabled = false;
                btn_DelLine.Enabled = false;
                btn_Del.Enabled = false;
                btn_PdfDown.Enabled = true;
            }
        }

        /// <summary>
        ///  자식 폼 활성화 되어 있을 때 탭 메뉴로 이동시 버튼 권한 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {            
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            else
            {
                CheckPermission(ActiveMdiChild.Name);
            }
            
        }

    }
}
