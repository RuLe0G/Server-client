using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            //создание объекта для отслеживания сообщений переданных с ip адреса через порт
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            //начало прослушивания
            listener.Start();
            //цикл подключения клиентов
            while (true)
            {
                //принятие запроса на подключение
                TcpClient client = listener.AcceptTcpClient();
                //создание нового потока для обслуживания нового клиента
                Thread clientThread = new Thread(() => Process(client));
                clientThread.Start();
            }
            if (listener != null)
                listener.Stop();
        }

        const int port = 8888;
        //объект, прослушивающий порт
        static TcpListener listener;

        //функция обработки сообщений от клиента
        public static void Process(TcpClient tcpClient)
        {
            TcpClient client = tcpClient;
            NetworkStream stream = null;
            try
            {
                //получение потока для обмена сообщениями
                stream = client.GetStream();
                // буфер для получаемых данных
                byte[] data = new byte[64];
                //цикл обработки сообщений
                while (true)
                {
                    //объект, для формирования строк
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    //до тех пор, пока в потоке есть данные
                    do
                    {
                        //из потока считываются 64 байта и записываются в data
                        bytes = stream.Read(data, 0, data.Length);
                        //из считанных данных формируется строка
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    //преобразование сообщения
                    string message = builder.ToString();
                    //вывод сообщения в консоль сервера
                    Console.WriteLine(message);
                    //преобразование сообщения в набор байт
                    data = Encoding.Unicode.GetBytes(message);
                    //отправка сообщения обратно клиенту
                    stream.Write(data, 0, data.Length);
                }
            }
3
 catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //освобождение ресурсов при завершении сеанса
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
