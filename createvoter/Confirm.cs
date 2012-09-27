using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace StudentVote
{
    public partial class Confirm : Form
    {
        string FirstName;
        string LastName;
        string UserName;

        string FirstChoiceCurrentSelection;
        string SecondChoiceCurrentSelection;
        string ThirdChoiceCurrentSelection;

        string IPAdress = "10.50.58.159";//GetIP();
        string Port = "25000";

        bool ChangedIP;
        IPForm m_IPForm;

        string message;

        public bool Sent;

        public Confirm(string firstName, string lastName, string userName, string firstChoiceCurrentSelection, string secondChoiceCurrentSelection, string thirdChoiceCurrentSelection)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            FirstChoiceCurrentSelection = firstChoiceCurrentSelection;
            SecondChoiceCurrentSelection = secondChoiceCurrentSelection;
            ThirdChoiceCurrentSelection = thirdChoiceCurrentSelection;

            NameAndJunk.Text = "First Name: " + FirstName + "\n" +
                               "Last Name: " + LastName + "\n" +
                               "User Name: " + UserName + "\n" +
                               "Primary Selection: " + FirstChoiceCurrentSelection + "\n" +
                               "Seconday Selection: " + SecondChoiceCurrentSelection + "\n" +
                               "Tertiary Selection: " + ThirdChoiceCurrentSelection;

            IPAdressText.Text = "Teacher's IP: " + IPAdress + ":" + Port;

            Sent = false;

        }

        private void ConectAndSend_Click(object sender, EventArgs e)
        {
                message = FirstName + "/" + LastName + "/" + UserName + "/" + FirstChoiceCurrentSelection + "/" + SecondChoiceCurrentSelection + "/" + ThirdChoiceCurrentSelection;

                TcpClient m_Client = new TcpClient();
                NetworkStream m_Stream;

                m_Client.Connect(IPAdress, int.Parse(Port));
                m_Stream = m_Client.GetStream();

                byte[] msg = ASCIIEncoding.ASCII.GetBytes(message);
                byte[] header = new byte[sizeof(int)];
                int length = (int)msg.Length;
                header = BitConverter.GetBytes(length);
                m_Stream.Write(header, 0, header.Length);
                m_Stream.Write(msg, 0, msg.Length);

                m_Stream.Close();
            

            Sent = true;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IPAdressText_Click(object sender, EventArgs e)
        {
            m_IPForm = new IPForm();
            m_IPForm.Show();
            ChangedIP = true;
        }

        public static string GetIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in host.AddressList)
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            return "UNKNOWN_IP";
        }

        private void Confirm_Activated(object sender, EventArgs e)
        {
            if (ChangedIP && m_IPForm.IPAdressAndPort != null)
            {
                IPAdress = m_IPForm.IPAdressAndPort.Substring(0, m_IPForm.IPAdressAndPort.IndexOf(':'));
                Port = m_IPForm.IPAdressAndPort.Substring(m_IPForm.IPAdressAndPort.IndexOf(':') + 1, m_IPForm.IPAdressAndPort.Length - m_IPForm.IPAdressAndPort.IndexOf(':') - 1);
            }

            IPAdressText.Text = "Teacher's IP: " + IPAdress + ":" + Port;
        }
    }
}
