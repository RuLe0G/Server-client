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
        //10.23.168.50
        const string address = "127.0.0.1";

        public MainWindow()
        {
            InitializeComponent();
            Port.Text = port.ToString();
            IP.Text = address;

        }

        //string userName;
        // st = false;
        NetworkStream stream;
        TcpClient client = null;

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
 
            client = new TcpClient(address, port);

            stream = client.GetStream();

            Thread clientThread = new Thread(new ThreadStart(Count1));
            clientThread.Start();


        }

        public void Count1()
        {
            try
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
                    Dispatcher.BeginInvoke(new Action(() => Content.Text = ("Сервер: " + message)));
                }
            }

            catch
            {
                stream.Close();
                client.Close();
            }
        }



        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Content.Text += "\n client: ";
                string message = Inp.Text.ToString();
                Content.Text += message;

                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            string message = "ddiissccoonnneecctteedd";
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

            stream.Close();
            client.Close();
        }
    }
}

