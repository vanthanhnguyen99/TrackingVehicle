using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace VehicleTracking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static coord tracking = new coord();
        public static FormMain main;
        public static SortedDictionary<string, coord> dataList = new SortedDictionary<string, coord>();
        public static coord location;
        public static bool isRefresh;
        public static int error = -1; // 0 là không thể kết nối server, 1 là server từ chối kết nối , 2 là mất kết nối đến Server
        public static Socket sender;
        public static void startClient()
        {
            tracking.name = "";
            location = new coord();
            isRefresh = false;
            byte[] bytes = new byte[1024];
           

            try
            {
                // Connect to a Remote server  
                // Get Host IP Address that is used to establish a connection  
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
                // If a host has multiple addresses, you will get a list of addresses  
                //IPHostEntry host = Dns.GetHostEntry("http://192.168.6.128");
                IPAddress ipAddress = IPAddress.Parse("116.109.68.173");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8084);

                // Create a TCP/IP  socket.    
                sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.    
                try
                {
                    // Connect to Remote EndPoint  
                    sender.Connect(remoteEP);

                    // clear all data on startup
                    dataList.Clear();
                    tracking.name = "";
                    if (Program.main != null)
                    {
                        Program.main.comboBox1.Invoke((MethodInvoker)(() => Program.main.comboBox1.Items.Clear()));
                        Program.main.comboBox1.Invoke((MethodInvoker)(() => Program.main.comboBox1.Items.Add("Vehicle's name")));
                        Program.main.comboBox1.Invoke((MethodInvoker)(() => Program.main.comboBox1.SelectedIndex = 0));
                    } 
                        

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data  into a byte array.    
                    //byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the client type through the socket.
                    int type = 2;
                    byte[] data = BitConverter.GetBytes(type);
                    sender.Send(data);

                    // Receive the response from the remote device.
                    
                    int byteRecv = sender.Receive(bytes, 1, 0);
                    if (!BitConverter.ToBoolean(bytes, 0))
                    {
                        error = 1; // server từ chối kết nối
                        return; // return if server not accept
                    }
                    bytes.Initialize();
                    byteRecv = sender.Receive(bytes, 0);
                    location.convertByteToCord(bytes);

                    // check Server disconnect
                    if (byteRecv == 0)
                    {
                        error = 2;
                        Console.WriteLine("Server Disconnected");
                        return;
                    }    

                    if (location.x != -1)
                    {

                        try
                        {
                            coord x = Program.dataList[location.name];
                            dataList[location.name] = new coord(location.x, location.y, location.name);
                            FormMain.list.Add(location.name);
                        }
                        catch (Exception e)
                        {

                            if (main != null)
                            {
                                main.comboBox1.Invoke((MethodInvoker)(() => main.comboBox1.Items.Add(location.name)));
                                dataList[location.name] = new coord(location.x, location.y, location.name);
                                FormMain.list.Add(location.name);
                            }
                            Console.WriteLine("khoi catch");
                        }
                        if (location.name == tracking.name)
                        {
                            Program.tracking.x = location.x;
                            Program.tracking.y = location.y;
                            Program.tracking.name = location.name;
                            isRefresh = true;
                        }
                        
                    }
                    else // prepare disconect
                    {
                        if (location.name == Program.tracking.name)
                        {
                            tracking.x = -1.0;
                            tracking.y = -1.0;
                            isRefresh = true;
                        }
                        else
                        {
                            if (main.comboBox1 != null) main.comboBox1.Invoke((MethodInvoker)(() => main.comboBox1.Items.Remove(location.name)));
                        }    
                        dataList.Remove(location.name);
                    }

                    
                    while (byteRecv > 0)
                    {
                        data = BitConverter.GetBytes(true);
                        sender.Send(data);
                        Console.WriteLine();
                        // display data received
                        //Console.WriteLine("Data received: " + byteRecv);
                        //location.displayData();

                        // receive data
                        bytes.Initialize();
                        byteRecv = sender.Receive(bytes, 0);
                        location.convertByteToCord(bytes);

                        if (location.x != -1)
                        {
                            try
                            {
                                coord x = Program.dataList[location.name];
                                dataList[location.name] = new coord(location.x, location.y, location.name);
                                FormMain.list.Add(location.name);
                            }
                            catch (Exception e)
                            {
                                if (main != null)
                                {
                                    main.comboBox1.Invoke((MethodInvoker)(() => main.comboBox1.Items.Add(location.name)));
                                    dataList[location.name] = new coord(location.x, location.y, location.name);
                                    FormMain.list.Add(location.name);
                                    Console.WriteLine("hoi cham");
                                }
                                Console.WriteLine("khoi catch");
                            }
                            if (location.name == tracking.name)
                            {
                                Program.tracking.x = location.x;
                                Program.tracking.y = location.y;
                                Program.tracking.name = location.name;
                                isRefresh = true;
                            }
                            
                        }
                        else // prepare disconect
                        {
                            if (location.name == Program.tracking.name)
                            {
                                tracking.x = -1.0;
                                tracking.y = -1.0;
                                isRefresh = true;
                            }
                            else
                            {
                                if (main.comboBox1 != null) main.comboBox1.Invoke((MethodInvoker)(() => main.comboBox1.Items.Remove(location.name)));
                            }
                            dataList.Remove(location.name);
                        }

                        Thread.Sleep(100);
                    }


                    // Release the socket.    
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    // check Server disconnect
                    if (byteRecv == 0)
                    {
                        error = 2;
                        Console.WriteLine("Server Disconnected");
                        return;
                    }

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());

                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    error = 0; // không thể kết nối tới server
                    Console.WriteLine("Đã lỗi rồi");
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    Console.WriteLine("cactch 2");
                    return;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                Console.WriteLine("cactch 1");
                
                return;
                
            }


        }
      
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.main = new FormMain();
            Application.Run(main);

        }
    }
}
