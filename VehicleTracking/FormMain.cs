using DevExpress.Map;
using DevExpress.XtraBars;
using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace VehicleTracking
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public static BindingList<string> list = new BindingList<string>();

        MapItemStorage storage;
        MapItem[] items = new MapItem[1];
        VectorItemsLayer itemsLayer;
        GeoPoint center;
        bool isFocus = true;

        Thread t; // tcp
        Thread thread; // display vehicle
        Thread checking; // check connection with Server
        Thread currentThread;
        public FormMain()
        {
            InitializeComponent();

            currentThread = Thread.CurrentThread;

            comboBox1.Items.Add("Vehicle's name");
            comboBox1.SelectedIndex = 0;
           
            
            t = new Thread(() =>
            {
                Program.error = -1;
                Program.startClient();
            });
            t.Start(); 

            thread = new Thread(() =>
            {
                trackvVehicle();
            });
            thread.Start();

            Thread.Sleep(2000); // wait for connect to Server
            checking = new Thread( ()=>
            {
                while (true)
                {
                    checkServerConnection();
                }
            });
            checking.Start();
            
        }

        DataTable LoadDataFromXml(string path)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            DataTable table = ds.Tables[0];
            return table;
        }
        void bbiInitialView_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapControl1.ZoomLevel = 3.0;
            mapControl1.CenterPoint = new GeoPoint(50, -7);
        }
        void bbiZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapControl1.ZoomOut();
        }
        void bbiZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapControl1.ZoomIn();
        }
        void chkLockNavigation_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            mapControl1.EnableScrolling = !mapControl1.EnableScrolling;
            mapControl1.EnableZooming = !mapControl1.EnableZooming;
            bbiZoomIn.Enabled = mapControl1.EnableZooming;
            bbiZoomOut.Enabled = mapControl1.EnableZooming;
        }
        void chkShowNavPanel_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            mapControl1.NavigationPanelOptions.Visible = !mapControl1.NavigationPanelOptions.Visible;
        }
        void chkShowMiniMap_CheckedChanged(object sender, ItemClickEventArgs e)
        {
           /* mapControl1.MiniMap.Visible = !mapControl1.MiniMap.Visible;*/
        }
        void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            
            if (Program.tracking.name == "") return;
            mapControl1.Invoke((MethodInvoker)(() => mapControl1.Zoom(13.0)));
            mapControl1.Invoke((MethodInvoker)(() => mapControl1.CenterPoint = new GeoPoint(Program.tracking.x, Program.tracking.y)));
            isFocus = true; 
            
        }

        static string GetRelativePath(string name)
        {
            name = "Data\\" + name;
            string path = Application.StartupPath;
            string s = "\\";
            for (int i = 0; i <= 10; i++)
            {
                if (System.IO.File.Exists(path + s + name))
                    return (path + s + name);
                else
                    s += "..\\";
            }
            return "";
        }

        private void mapControl1_Click(object sender, EventArgs e)
        {
            //MapItem[] map = new MapItem[1];'
            isFocus = false;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            center = new GeoPoint(0, 0);

            // from here
            mapControl1.Layers.Add(imageLayer1);
            // Create a layer to display vector items.
            itemsLayer = new VectorItemsLayer();
            mapControl1.Layers.Add(itemsLayer);

            // Create a storage for map items and generate them.
            storage = new MapItemStorage();
            //items = new MapItem[1];

            storage.DataChanged += new DataAdapterChangedEventHandler(storage_Change);


        }
        MapItem[] GetLocationData()
        {
            return new MapItem[] {
                
                new MapDot() { Location = new GeoPoint(-10, 10), Size = 18, Stroke = Color.Red, Fill = Color.Blue }
            };
        }
        void trackvVehicle()
        {

            coord location = new coord();
            while (true)
            {
                
                if (Program.isRefresh)
                {
                    if (mapControl1.ZoomLevel != 13) isFocus = false;

                    location.x = Program.tracking.x;
                    location.y = Program.tracking.y;
                    if (location.x == -1.0) // Disconect
                    {
                        MessageBox.Show("Vehicle "+ comboBox1.SelectedItem.ToString() + " disconnected!");
                        comboBox1.Invoke((MethodInvoker)(() => comboBox1.Items.Remove(Program.tracking.name)));
                        comboBox1.Invoke((MethodInvoker)(() => comboBox1.SelectedIndex = 0));
                        Program.tracking.name = "";
                        if (storage.Items != null) storage.Items.Clear();
                    }
                    else
                    {
                        center.Latitude = location.x;
                        center.Longitude = location.y;

                        Console.WriteLine(location.x + "," + location.y);
                        items.SetValue(new MapDot() { Location = new GeoPoint(location.x, location.y), Size = 10, Stroke = Color.Red, Fill = Color.Blue }, 0);

                        if (storage.Items != null) storage.Items.Clear();
                        storage.Items.AddRange(items);
                        itemsLayer.Data = storage;

                        //mapControl1.Zoom(13.0);
                        if (isFocus)
                        {
                            mapControl1.Invoke((MethodInvoker)(() => mapControl1.Zoom(13.0)));
                            mapControl1.Invoke((MethodInvoker)(() => mapControl1.CenterPoint = new GeoPoint(location.x, location.y)));
                        }    
                       
                        //comboBox1.Invoke((MethodInvoker)(() => comboBox1.DataSource = list));
                    }

                    Program.isRefresh = false;
                    

                }
                Thread.Sleep(100);
               
            }    
           
        }

        private void storage_Change(object sender, EventArgs e)
        {
            if (storage.Items.Count > 0)
            {
                Console.WriteLine(Program.dataList.Count);
                
                
            }    
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) return;
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            mapControl1.ZoomLevel = 13;
            isFocus = true;
            Program.tracking = Program.dataList[comboBox1.SelectedItem.ToString()];
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bingMapDataProvider1.Kind == BingMapKind.Road)
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                bingMapDataProvider1.Kind = BingMapKind.Hybrid;
            }

            else
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                bingMapDataProvider1.Kind = BingMapKind.Road;
            }
        }
        private void checkServerConnection()
        {
            
            if (Program.error == 0) // Không thể kết nối với Server
            {
                
                Program.main.Invoke((MethodInvoker)(() => MessageBox.Show("Không thể kết nối đến Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                thread.Abort();
                t.Abort();
                Program.main.Invoke((MethodInvoker)(() => Program.main.Close()));
                checking.Abort();

                return;
            }

            if (Program.error == 1) // Server từ chối kết nối
            {
                
                Program.main.Invoke((MethodInvoker)(() => MessageBox.Show("Server từ chối kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                thread.Abort();
                t.Abort();
                Program.main.Invoke((MethodInvoker)(() => Program.main.Close()));
                checking.Abort();

                return;
            }
            if (Program.error == 2) // Mất kết nối Server
            {
               
                Program.main.Invoke((MethodInvoker)(() => MessageBox.Show("Mất kết nối tới Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                thread.Abort();
                t.Abort();
                Program.main.Invoke((MethodInvoker)(() => Program.main.Close()));
                checking.Abort();

                return;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
            t.Abort();
            checking.Abort();
            Thread.Sleep(1000);
            if (Program.sender.Connected)
            {
                Program.sender.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                Program.sender.Close();
            }

        }
    }
}
