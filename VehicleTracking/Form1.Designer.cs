
namespace VehicleTracking
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraMap.MiniMap miniMap6 = new DevExpress.XtraMap.MiniMap();
            DevExpress.XtraMap.DynamicMiniMapBehavior dynamicMiniMapBehavior6 = new DevExpress.XtraMap.DynamicMiniMapBehavior();
            this.miniMapVectorItemsLayer2 = new DevExpress.XtraMap.MiniMapVectorItemsLayer();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.chkMiniMap = new DevExpress.XtraBars.BarCheckItem();
            this.chkShowNavPanel = new DevExpress.XtraBars.BarCheckItem();
            this.chkNavigation = new DevExpress.XtraBars.BarCheckItem();
            this.bbiZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInitialView = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem_changeType = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listSourceDataAdapter1 = new DevExpress.XtraMap.ListSourceDataAdapter();
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.informationLayer1 = new DevExpress.XtraMap.InformationLayer();
            this.bingGeocodeDataProvider1 = new DevExpress.XtraMap.BingGeocodeDataProvider();
            this.imageLayer1 = new DevExpress.XtraMap.ImageLayer();
            this.bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            this.vectorItemsLayer3 = new DevExpress.XtraMap.VectorItemsLayer();
            this.mapItemStorage1 = new DevExpress.XtraMap.MapItemStorage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            this.SuspendLayout();
            this.miniMapVectorItemsLayer2.Name = "MiniMapShipLayer";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.chkMiniMap,
            this.chkShowNavPanel,
            this.chkNavigation,
            this.bbiZoomIn,
            this.bbiZoomOut,
            this.bbiInitialView,
            this.barCheckItem1,
            this.barButtonItem_changeType});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1101, 158);
            // 
            // chkMiniMap
            // 
            this.chkMiniMap.Caption = "Show Minimap";
            this.chkMiniMap.Id = 1;
            this.chkMiniMap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkMiniMap.ImageOptions.Image")));
            this.chkMiniMap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkMiniMap.ImageOptions.LargeImage")));
            this.chkMiniMap.Name = "chkMiniMap";
            this.chkMiniMap.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowMiniMap_CheckedChanged);
            // 
            // chkShowNavPanel
            // 
            this.chkShowNavPanel.BindableChecked = true;
            this.chkShowNavPanel.Caption = "Show Navigation Panel";
            this.chkShowNavPanel.Checked = true;
            this.chkShowNavPanel.Id = 2;
            this.chkShowNavPanel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkShowNavPanel.ImageOptions.Image")));
            this.chkShowNavPanel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkShowNavPanel.ImageOptions.LargeImage")));
            this.chkShowNavPanel.Name = "chkShowNavPanel";
            this.chkShowNavPanel.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowNavPanel_CheckedChanged);
            // 
            // chkNavigation
            // 
            this.chkNavigation.Caption = "Lock Navigation";
            this.chkNavigation.Id = 3;
            this.chkNavigation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkNavigation.ImageOptions.Image")));
            this.chkNavigation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("chkNavigation.ImageOptions.LargeImage")));
            this.chkNavigation.Name = "chkNavigation";
            this.chkNavigation.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLockNavigation_CheckedChanged);
            // 
            // bbiZoomIn
            // 
            this.bbiZoomIn.Caption = "Zoom In";
            this.bbiZoomIn.Id = 4;
            this.bbiZoomIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiZoomIn.ImageOptions.Image")));
            this.bbiZoomIn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiZoomIn.ImageOptions.LargeImage")));
            this.bbiZoomIn.Name = "bbiZoomIn";
            this.bbiZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomIn_ItemClick);
            // 
            // bbiZoomOut
            // 
            this.bbiZoomOut.Caption = "Zoom Out";
            this.bbiZoomOut.Id = 5;
            this.bbiZoomOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiZoomOut.ImageOptions.Image")));
            this.bbiZoomOut.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiZoomOut.ImageOptions.LargeImage")));
            this.bbiZoomOut.Name = "bbiZoomOut";
            this.bbiZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomOut_ItemClick);
            // 
            // bbiInitialView
            // 
            this.bbiInitialView.Caption = "Initial View";
            this.bbiInitialView.Id = 6;
            this.bbiInitialView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiInitialView.ImageOptions.Image")));
            this.bbiInitialView.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiInitialView.ImageOptions.LargeImage")));
            this.bbiInitialView.Name = "bbiInitialView";
            this.bbiInitialView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInitialView_ItemClick);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.BindableChecked = true;
            this.barCheckItem1.Caption = "Focus";
            this.barCheckItem1.Checked = true;
            this.barCheckItem1.Id = 6;
            this.barCheckItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCheckItem1.ImageOptions.Image")));
            this.barCheckItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCheckItem1.ImageOptions.LargeImage")));
            this.barCheckItem1.Name = "barCheckItem1";
            this.barCheckItem1.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            // 
            // barButtonItem_changeType
            // 
            this.barButtonItem_changeType.Caption = "Change Type";
            this.barButtonItem_changeType.Id = 11;
            this.barButtonItem_changeType.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_changeType.ImageOptions.Image")));
            this.barButtonItem_changeType.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_changeType.ImageOptions.LargeImage")));
            this.barButtonItem_changeType.Name = "barButtonItem_changeType";
            this.barButtonItem_changeType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Options";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiInitialView);
            this.ribbonPageGroup2.ItemLinks.Add(this.chkShowNavPanel);
            this.ribbonPageGroup2.ItemLinks.Add(this.chkNavigation);
            this.ribbonPageGroup2.ItemLinks.Add(this.chkMiniMap);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiZoomIn);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiZoomOut);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "View";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem_changeType);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(540, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.listSourceDataAdapter1.DefaultMapItemType = DevExpress.XtraMap.MapItemType.Dot;
            this.listSourceDataAdapter1.Mappings.Latitude = "Latitude";
            this.listSourceDataAdapter1.Mappings.Longitude = "Longitude";
            // 
            // mapControl1
            // 
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Layers.Add(this.informationLayer1);
            this.mapControl1.Layers.Add(this.imageLayer1);
            this.mapControl1.Layers.Add(this.vectorItemsLayer3);
            this.mapControl1.Location = new System.Drawing.Point(0, 158);
            miniMap6.Alignment = DevExpress.XtraMap.MiniMapAlignment.BottomRight;
            miniMap6.Behavior = dynamicMiniMapBehavior6;
            miniMap6.Layers.Add(this.miniMapVectorItemsLayer2);
            miniMap6.Visible = false;
            this.mapControl1.MiniMap = miniMap6;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(1101, 565);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.ZoomLevel = 3D;
            this.mapControl1.Click += new System.EventHandler(this.mapControl1_Click);
            this.informationLayer1.DataProvider = this.bingGeocodeDataProvider1;
            this.bingGeocodeDataProvider1.BingKey = "dXMuuu5IUUO0EAeoRWUQ~a5xyce-TWMN1LUpg48g3Pg~AjDTPUxypaLVEfJFh8_TdMZaHKZ9XU0vnScBf" +
    "yre6dHV7C5ui4v-6Oo3nEC4G6M0";
            this.bingGeocodeDataProvider1.MaxVisibleResultCount = 1;
            this.bingGeocodeDataProvider1.ProcessMouseEvents = true;
            this.imageLayer1.DataProvider = this.bingMapDataProvider1;
            this.bingMapDataProvider1.BingKey = "dXMuuu5IUUO0EAeoRWUQ~a5xyce-TWMN1LUpg48g3Pg~AjDTPUxypaLVEfJFh8_TdMZaHKZ9XU0vnScBf" +
    "yre6dHV7C5ui4v-6Oo3nEC4G6M0";
            this.bingMapDataProvider1.CacheOptions.MemoryLimit = 4096;
            this.bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Road;
            this.vectorItemsLayer3.Data = this.mapItemStorage1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 723);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.mapControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Vehicle Tracking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;

        private DevExpress.XtraBars.BarCheckItem chkShowNavPanel;
        private DevExpress.XtraBars.BarCheckItem chkNavigation;
        private DevExpress.XtraBars.BarCheckItem chkMiniMap;
        private DevExpress.XtraBars.BarButtonItem bbiZoomIn;
        private DevExpress.XtraBars.BarButtonItem bbiZoomOut;
        private DevExpress.XtraBars.BarButtonItem bbiInitialView;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraMap.ListSourceDataAdapter listSourceDataAdapter1;
        private DevExpress.XtraMap.ImageLayer imageLayer1;
        private DevExpress.XtraMap.InformationLayer informationLayer1;
        public DevExpress.XtraMap.BingGeocodeDataProvider bingGeocodeDataProvider1;
        public DevExpress.XtraMap.MapControl mapControl1;
        public System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_changeType;
        public DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1;
        private DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer3;
        private DevExpress.XtraMap.MapItemStorage mapItemStorage1;
        private DevExpress.XtraMap.MiniMapVectorItemsLayer miniMapVectorItemsLayer2;
    }
}

