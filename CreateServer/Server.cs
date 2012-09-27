using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


namespace CreateServer
{
    public delegate void NetMessage(ref byte[] bytes);
    
    public class Server
    {
        TcpClient m_Client;
        TcpListener m_Listener;
        Thread m_ListenThread;
        bool m_Alive = true;

        public NetMessage Traversal;

        public static string GetIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in host.AddressList)
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            return "UNKNOWN_IP";
        }

        public void Stop()
        {
            m_Alive = false;
            TcpClient killClient = new TcpClient();
            killClient.Connect(Server.GetIP(), 25000);
            byte[] kill = new byte[sizeof(int)];
            kill = BitConverter.GetBytes((int)0xC0DE);
            killClient.GetStream().Write(kill, 0, sizeof(int));
            m_ListenThread.Join();
        }

        public void Create()
        {
            m_Listener = new TcpListener(IPAddress.Any, 25000);
            m_ListenThread = new Thread(new ThreadStart(ListenForClients));
            m_ListenThread.Start();
        }
        
        public void ListenForClients()
        {
            m_Listener.Start();
            while (m_Alive)
            {
                m_Client = m_Listener.AcceptTcpClient();                
                Thread clientCom = new Thread(new ParameterizedThreadStart(HandleComms));
                clientCom.Start(m_Client);
            }
            m_Listener.Stop();
        }
        
        public void HandleComms(object com)
        {
            TcpClient lClient = com as TcpClient;
            NetworkStream srm = lClient.GetStream();
            byte[] header_dat = new byte[sizeof(int)];
            srm.Read(header_dat, 0, sizeof(int));
            int header_parse = BitConverter.ToInt32(header_dat, 0);
            if (header_parse == 0xC0DE)
            {
                return; // Kill message.
            }
            byte[] data_out = new byte[header_parse]; // data - header
            srm.Read(data_out, 0, (int)header_parse);
            if (Traversal != null)
            {
                Traversal.Invoke(ref data_out);
            }
        }
    }

}
