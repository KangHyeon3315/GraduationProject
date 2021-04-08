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
    class APICollector : Client
    {
        Thread LogTh;

        Settings settings;
        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;
        public APICollector(Socket sock, LogInterface logInterface, ProgressInterface progressInterface, Settings settings) : base(sock, logInterface, Role.APICollector)
        {
            this.settings = settings;
            this.logInterface = logInterface;
            this.progressInterface = progressInterface;

            LogTh = new Thread(new ThreadStart(LogManaging));
            LogTh.Start();
        }

        void LogManaging()
        {
            while (true)
            {
                string ReceiveMsg = ReceiveQueue.Get();

                if (ReceiveMsg == "")
                    continue;

                string[] data = ReceiveMsg.Split(';');
                switch (data[0])
                {
                    case "RqCount":
                        progressInterface.RqCount = int.Parse(data[1]);
                        break;
                    case "work":
                        progressInterface.Task = data[1];
                        break;
                    case "Company":
                        progressInterface.Company = data[1];
                        break;
                    case "CompanyCount":
                        progressInterface.CompanyCount = int.Parse(data[1]);
                        break;
                    case "CompleteCount":
                        progressInterface.CompleteCount = int.Parse(data[1]);
                        progressInterface.Progress = (int)(float.Parse(data[1]) / (float)(progressInterface.CompanyCount) * 100);
                        break;
                    case "Requests":
                        if (data[1] == "RequestsInterval")
                        {
                            Send(string.Format("RequestsInterval;{0}", settings.info.RequestsInterval));
                        }
                        else if(data[1] == "DBInfo")
                        {
                            Send(string.Format("DBInfo;{0};{1};{2};{3}", settings.info.DBIP, settings.info.DBPort, settings.info.DBID, settings.info.DBPW));                            
                        }
                        logInterface.WriteLog(data[0], progressInterface.Task, progressInterface.Company, data[1]);
                        break;
                    case "log":
                    case "Exception":
                        logInterface.WriteLog(data[0], progressInterface.Task, progressInterface.Company, data[1]);
                        break;
                }

                Thread.Sleep(200);
            }
        }
    }
}
