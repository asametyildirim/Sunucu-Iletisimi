using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace SunucuIletisimi
{



    class WSoket
    {


        public static string connectionIP = "127.0.0.1";
        public static int connectionPort = 25001;
        public static IPAddress localAdd;
        public static TcpListener listener;
        public static TcpClient client;
        public static bool running;

        public static void WsocketStart()
        {

            Thread mThread;
            ThreadStart ts = new ThreadStart(GetInfo);
            mThread = new Thread(ts);
            mThread.Start();
            Console.WriteLine("Burası Main");

        }

        public static void GetInfo()
        {
            Console.WriteLine("Burası GetInfo (thread)");
            localAdd = IPAddress.Parse(connectionIP);
            listener = new TcpListener(IPAddress.Any, connectionPort);
            listener.Start();

            client = listener.AcceptTcpClient();

            running = true;

            while (running)
            {
                SendAndReceiveData();
            }
            listener.Stop();

        }


        public static void SendAndReceiveData()
        {
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            while (true)
            {
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (dataReceived != null)
                {

                    Form1.txt_python_test.Text = "merhaba";

                }

                Console.WriteLine(dataReceived);

                byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message python! Do you see this message?");
                nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);


            }

        }
    }
}
