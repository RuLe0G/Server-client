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
using System.Net.Sockets;
using System.Threading;

namespace Clientt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int port = 8888;
        const string address = "10.23.168.50";

        public MainWindow()
        {
            InitializeComponent();
            Port.Text = port.ToString();
            IP.Text = address;

        }

        //string userName;
        bool st = false;
        NetworkStream stream = null;
        TcpClient client = null;

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
 
            client = new TcpClient(address, port);

            stream = client.GetStream();

            Thread clientThread = new Thread(() => Count1());
            clientThread.Start();


        }

        public void Count1()
        {

            while (true)
            {
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
                Content.Text = ("Сервер: " + message);
            }

        }



        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Content.Text += name.Text.ToString() + ": ";
            string message = Inp.Text.ToString();
            Content.Text += message;

            byte[] data = Encoding.Unicode.GetBytes(name.Text.ToString() + ":"+message);
            stream.Write(data, 0, data.Length);
        }
    }
}

