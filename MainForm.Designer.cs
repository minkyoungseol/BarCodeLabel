namespace BarCodeLabel
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btn_LogOut = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.btn_New = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Find = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Del = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ExcelUp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ExcelDown = new DevExpress.XtraBars.BarButtonItem();
            this.btn_PdfDown = new DevExpress.XtraBars.BarButtonItem();
            this.btn_AddLine = new DevExpress.XtraBars.BarButtonItem();
            this.btn_DelLine = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_LabelPrint = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_LabelPrint_View = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_WeekTrend = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3,
            this.bar4});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItem2,
            this.btn_New,
            this.btn_ExcelUp,
            this.btn_ExcelDown,
            this.btn_AddLine,
            this.btn_DelLine,
            this.btn_Close,
            this.btn_LogOut,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btn_Save,
            this.btn_Find,
            this.btn_Del,
            this.btn_PdfDown});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 1;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_LogOut)});
            this.bar1.Offset = 1130;
            this.bar1.Text = "Tools";
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.Caption = "시스템 종료";
            this.btn_LogOut.Id = 8;
            this.btn_LogOut.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.cancel_32x32;
            this.btn_LogOut.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12));
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_LogOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LogOut_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(2314, 169);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "라벨발행";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "라벨 발행";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "샘플 라벨 발행";
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "라벨출력현황";
            this.barSubItem2.Id = 1;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 5";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 1;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(2318, 196);
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_New),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Find),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Save),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Del),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ExcelUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ExcelDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_PdfDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_AddLine),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_DelLine),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Close)});
            this.bar4.Text = "Custom 5";
            // 
            // btn_New
            // 
            this.btn_New.Caption = "신규";
            this.btn_New.Id = 2;
            this.btn_New.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.new_32x32;
            this.btn_New.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btn_New.Name = "btn_New";
            this.btn_New.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_New.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_New_ItemClick);
            // 
            // btn_Find
            // 
            this.btn_Find.Caption = "조회";
            this.btn_Find.Id = 12;
            this.btn_Find.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.zoom_32x32;
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Find.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Find_ItemClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Caption = "저장";
            this.btn_Save.Id = 11;
            this.btn_Save.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.save_32x32;
            this.btn_Save.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.save_32x321;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Save_ItemClick);
            // 
            // btn_Del
            // 
            this.btn_Del.Caption = "삭제";
            this.btn_Del.Id = 13;
            this.btn_Del.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.trash_32x32;
            this.btn_Del.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.trash_32x32;
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Del.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Del_ItemClick);
            // 
            // btn_ExcelUp
            // 
            this.btn_ExcelUp.Caption = "엑셀업로드";
            this.btn_ExcelUp.Id = 3;
            this.btn_ExcelUp.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.exporttoxlsx_32x32;
            this.btn_ExcelUp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btn_ExcelUp.Name = "btn_ExcelUp";
            this.btn_ExcelUp.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_ExcelUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ExcelUp_ItemClick);
            // 
            // btn_ExcelDown
            // 
            this.btn_ExcelDown.Caption = "엑셀다운로드";
            this.btn_ExcelDown.Id = 4;
            this.btn_ExcelDown.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.exporttoxlsx_32x32;
            this.btn_ExcelDown.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.btn_ExcelDown.Name = "btn_ExcelDown";
            this.btn_ExcelDown.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_ExcelDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ExcelDown_ItemClick);
            // 
            // btn_PdfDown
            // 
            this.btn_PdfDown.Caption = "PDF다운로드";
            this.btn_PdfDown.Id = 14;
            this.btn_PdfDown.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.exporttopdf_32x32;
            this.btn_PdfDown.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.exporttopdf_32x32;
            this.btn_PdfDown.Name = "btn_PdfDown";
            this.btn_PdfDown.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_PdfDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_PdfDown_ItemClick);
            // 
            // btn_AddLine
            // 
            this.btn_AddLine.Caption = "라인추가";
            this.btn_AddLine.Id = 5;
            this.btn_AddLine.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.addfooter_32x32;
            this.btn_AddLine.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.btn_AddLine.Name = "btn_AddLine";
            this.btn_AddLine.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_AddLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_AddLine_ItemClick);
            // 
            // btn_DelLine
            // 
            this.btn_DelLine.Caption = "라인삭제";
            this.btn_DelLine.Id = 6;
            this.btn_DelLine.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.deletefooter_32x32;
            this.btn_DelLine.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btn_DelLine.Name = "btn_DelLine";
            this.btn_DelLine.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_DelLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DelLine_ItemClick);
            // 
            // btn_Close
            // 
            this.btn_Close.Caption = "닫기";
            this.btn_Close.Id = 7;
            this.btn_Close.ImageOptions.Image = global::BarCodeLabel.Properties.Resources.none_32x32;
            this.btn_Close.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Close_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.PaintStyleName = "WindowsXP";
            this.barAndDockingController1.PropertiesBar.ScaleEditors = false;
            this.barAndDockingController1.PropertiesRibbon.ScaleEditors = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1284, 66);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 674);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1284, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 66);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 608);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1284, 66);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 608);
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel1,
            this.dockPanel1,
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dockPanel1.ID = new System.Guid("09fca0e9-0ba5-45e9-94cc-ca38c1e8fbe2");
            this.dockPanel1.Location = new System.Drawing.Point(0, 66);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(161, 200);
            this.dockPanel1.Size = new System.Drawing.Size(161, 608);
            this.dockPanel1.Text = "메뉴";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 21);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(155, 584);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btn_LabelPrint,
            this.btn_LabelPrint_View,
            this.navBarItem1,
            this.btn_WeekTrend});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 155;
            this.navBarControl1.Size = new System.Drawing.Size(155, 584);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator();
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "바코드 라벨";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_LabelPrint),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_LabelPrint_View),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_WeekTrend)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btn_LabelPrint
            // 
            this.btn_LabelPrint.Caption = "제조 라벨 발행";
            this.btn_LabelPrint.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.barcode_32x321;
            this.btn_LabelPrint.ImageOptions.SmallImage = global::BarCodeLabel.Properties.Resources.barcode_16x161;
            this.btn_LabelPrint.Name = "btn_LabelPrint";
            this.btn_LabelPrint.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_LabelPrint_LinkClicked);
            // 
            // btn_LabelPrint_View
            // 
            this.btn_LabelPrint_View.Caption = "라벨 발행 현황";
            this.btn_LabelPrint_View.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.subreport_32x32;
            this.btn_LabelPrint_View.ImageOptions.SmallImage = global::BarCodeLabel.Properties.Resources.subreport_16x16;
            this.btn_LabelPrint_View.Name = "btn_LabelPrint_View";
            this.btn_LabelPrint_View.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_LabelPrint_View_LinkClicked);
            // 
            // btn_WeekTrend
            // 
            this.btn_WeekTrend.Caption = "주별 TREND";
            this.btn_WeekTrend.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.barofpie_32x32;
            this.btn_WeekTrend.ImageOptions.SmallImage = global::BarCodeLabel.Properties.Resources.barofpie_16x16;
            this.btn_WeekTrend.Name = "btn_WeekTrend";
            this.btn_WeekTrend.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_WeekTrend_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "품목 관리";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "품목 등록";
            this.navBarItem1.ImageOptions.LargeImage = global::BarCodeLabel.Properties.Resources.editname_32x32;
            this.navBarItem1.ImageOptions.SmallImage = global::BarCodeLabel.Properties.Resources.editname_16x16;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.SelectedPageChanged += new System.EventHandler(this.xtraTabbedMdiManager1_SelectedPageChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 696);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "라벨 출력 시스템";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

         }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btn_LogOut;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem btn_New;
        private DevExpress.XtraBars.BarButtonItem btn_ExcelUp;
        private DevExpress.XtraBars.BarButtonItem btn_ExcelDown;
        private DevExpress.XtraBars.BarButtonItem btn_AddLine;
        private DevExpress.XtraBars.BarButtonItem btn_DelLine;
        private DevExpress.XtraBars.BarButtonItem btn_Close;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btn_LabelPrint;
        private DevExpress.XtraNavBar.NavBarItem btn_LabelPrint_View;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraBars.BarButtonItem btn_Save;
        private DevExpress.XtraBars.BarButtonItem btn_Find;
        private DevExpress.XtraBars.BarButtonItem btn_Del;
        private DevExpress.XtraBars.BarButtonItem btn_PdfDown;
        private DevExpress.XtraNavBar.NavBarItem btn_WeekTrend;
    }
}

