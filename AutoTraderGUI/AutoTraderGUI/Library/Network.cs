using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AutoTraderGUI.Library
{
    class Network
    {
        Settings settings;

        Socket server;
        Thread serverTh;

        public APICollector apiCollector;
        public DartCollector dartCollector;

        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;
        public Network(LogInterface logInterface, ProgressInterface progressInterface, Settings settings)
        {
            this.settings = settings;
            this.logInterface = logInterface;
            this.progressInterface = progressInterface;

            serverTh = new Thread(new ThreadStart(RunServer));
            serverTh.Start();
        }

        void RunServer()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(ipep);

            server.Listen(3);

            logInterface.WriteLog("log", "None", "None", "Run Server Thread");

            try
            {
                while (true)
                {
                    logInterface.WriteLog("log", "None", "None", "Wait Accept Client");
                    Socket sock = server.Accept();
                    Library.Client client = new Library.Client(sock, logInterface);

                    if(client.role == Role.APICollector)
                    {
                        apiCollector = new APICollector(sock, logInterface, progressInterface, settings);
                        apiCollector.ReceiveQueue = client.ReceiveQueue;
                        client.ReceiveTh.Abort();
                    }
                    else if(client.role == Role.DartCollector)
                    {
                        dartCollector = new DartCollector(sock, logInterface, settings);
                        dartCollector.ReceiveQueue = client.ReceiveQueue;
                        client.ReceiveTh.Abort();
                    }
                    else
                    {
                        logInterface.WriteLog("log", "None", "None", "UnKnown Role's Process : " + client.role.ToString());
                    }
                    
                }
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("exception", "RunServer", "None", ex.Message);
            }
        }
    }
}
