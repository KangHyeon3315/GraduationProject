﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AutoTraderGUI.Library
{
    class DartCollector : Client
    {
        string Company;
        public bool Complete;

        Thread LogTh;

        Settings settings;
        LogInterface logInterface = null;

        public DartCollector(Socket sock, LogInterface logInterface, Settings settings) : base(sock, logInterface, Role.APICollector)
        {
            Complete = false;
            this.settings = settings;
            this.logInterface = logInterface;

            LogTh = new Thread(new ThreadStart(LogManaging));
            LogTh.Start();

        }

        public void Close()
        {
            if(LogTh.IsAlive)
                LogTh.Abort();
            if(ReceiveTh.IsAlive)
                ReceiveTh.Abort();
        }

        void LogManaging()
        {
            while (sock.Connected)
            {
                string ReceiveMsg = ReceiveQueue.Get();

                if (ReceiveMsg == "")
                    continue;

                string[] data = ReceiveMsg.Split(';');
                switch (data[0])
                {
                    case "Company":
                        Company = data[1];
                        break;
                    case "Complete":
                        Complete = true;
                        break;
                    case "Requests":
                        if (data[1] == "RequestsDartKey")
                        {
                            Send(string.Format("RequestsDartKey;{0};", settings.info.DartAPI));
                        }
                        else if (data[1] == "DBInfo")
                        {
                            Send(string.Format("DBInfo;{0};{1};{2};{3};", settings.info.DBIP, settings.info.DBPort, settings.info.DBID, settings.info.DBPW));
                        }
                        logInterface.WriteLog(data[0], "Financial Statement", Company, data[1]);
                        break;
                    case "log":
                    case "Exception":
                        logInterface.WriteLog(data[0], "Financial Statement", Company, data[1]);
                        break;
                }

                Thread.Sleep(200);
            }
        }
    }
}
