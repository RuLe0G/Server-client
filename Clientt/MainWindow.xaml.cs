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

        string userName;
        bool st = false;
        NetworkStream stream;

        private void Connect_Click(object sender, RoutedEventArgs e)
        {

            Thread myThread1 = new Thread(new ThreadStart(Count1));
            myThread1.Start();


        }

        public void Count1()
        {
            string userName = name.Text.ToString();

            TcpClient client = null;
            try
            {

                client = new TcpClient(address, port);

                NetworkStream stream = client.GetStream();

                while (true)
                {
                    st = true;
                }
            }

            catch (Exception)
            {

            }
            finally
            {
                client.Close();
            }

        }

        public void Count2()
        {
            
            Content.Text += userName + ": ";
            string message = Inp.Text.ToString();
            Content.Text += message;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
            data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;            do
            {
                
                bytes = stream.Read(data, 0, data.Length);
                
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);
            message = builder.ToString();            Content.Text = ("Сервер: " + message);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Thread myThread2 = new Thread(new ThreadStart(Count2));
            myThread2.Start();
        }
    }
}

