﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket osluskujuciSocket;

        public Server() 
        {
            osluskujuciSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));
            osluskujuciSocket.Bind(endPoint);
            osluskujuciSocket.Listen(5);

            Thread thread = new Thread(AcceptClient); 
            thread.Start();
        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSocket = osluskujuciSocket.Accept();
                    ClientHandler client = new ClientHandler(klijentskiSocket);
                    Thread klijentskaNit = new Thread(client.HandleRequest); 
                    klijentskaNit.Start();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
        }

        public void Stop()
        {
            osluskujuciSocket.Close();
        }

    }
}
