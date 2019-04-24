using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const int port = 8888;
        static TcpListener listener;

        public MainWindow()
        {
            InitializeComponent();            ContentDa.Text = "Начало";
            listener = new TcpListener(IPAddress.Parse("10.23.168.50"), port);
            listener.Start();
            Thread serverThread = new Thread(() => Count1());
            serverThread.Start();

        }

        public void Count1()
        {
            while (true)
            {
                
                TcpClient client = listener.AcceptTcpClient();
                
                Thread clientThread = new Thread(() => Process(client));
                clientThread.Start();

                //if (listener != null)
                //{
                //    listener.Stop();
                //    break;
                //}
            }                               
        }

        public static void Process(TcpClient tcpClient)
        {
            TcpClient client = tcpClient;
            NetworkStream stream = null;
            try
            {                
                stream = client.GetStream();
                byte[] data = new byte[64];
               
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                ContentDa.text += message;
                
                    data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
             
            }
            catch (Exception ex)
            {
                ContentDa.text += ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

    }
}
