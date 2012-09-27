using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server NetObj = null;
            Console.WriteLine(Server.GetIP());
            NetObj = new Server();
            NetObj.Create();
            NetObj.Traversal = RecieveData;
        }

        static string tempMessage = "";
        static string FirstName;
        static string LastName;
        static string UserName;
        static string FirstChoice;
        static string SecondChoice;
        static string ThirdChoice;

        static void RecieveData(ref byte[] dat)
        {
            string message = ASCIIEncoding.ASCII.GetString(dat);
            Console.WriteLine(message);
            // m_Client.GetStream().Write(message);
            if (tempMessage != message)
            {
                tempMessage = message;

                FirstName = message.Substring(0, message.IndexOf("/"));
                message = message.Remove(0, message.IndexOf("/")+1);

                LastName = message.Substring(0, message.IndexOf("/"));
                message = message.Remove(0, message.IndexOf("/") + 1);

                UserName = message.Substring(0, message.IndexOf("/"));
                message = message.Remove(0, message.IndexOf("/") + 1);

                FirstChoice = message.Substring(0, message.IndexOf("/"));
                message = message.Remove(0, message.IndexOf("/") + 1);

                SecondChoice = message.Substring(0, message.IndexOf("/"));
                message = message.Remove(0, message.IndexOf("/") + 1);

                ThirdChoice = message.Substring(0, message.Length);

                Console.WriteLine(FirstName + LastName + UserName + FirstChoice + SecondChoice + ThirdChoice);



            }

        }
    }
}

