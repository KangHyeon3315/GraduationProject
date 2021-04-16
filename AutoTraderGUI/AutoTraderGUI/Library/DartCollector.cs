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
    class DartCollector : Client
    {
        string Company;
        public bool Complete;

        public Thread LogTh;

        Settings settings;
        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;

        public DartCollector(Socket sock, LogInterface logInterface, ProgressInterface progressInterface, Settings settings) : base(sock, logInterface, Role.APICollector)
        {
            Complete = false;
            this.settings = settings;
            this.logInterface = logInterface;
            this.progressInterface = progressInterface;

            LogTh = new Thread(new ThreadStart(LogManaging));
            LogTh.Start();

        }

        public void Close()
        {
            sock.Close();
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
                        progressInterface.Company = Company;
                        break;
                    case "Complete":
                        Complete = true;
                        break;
                    case "RqCount":
                        progressInterface.RqCount = int.Parse(data[1]);
                        break;
                    case "work":
                        progressInterface.Task = data[1];
                        break;
                    case "CompanyCount":
                        progressInterface.CompanyCount = int.Parse(data[1]);
                        break;
                    case "CompleteCount":
                        progressInterface.CompleteCount = int.Parse(data[1]);
                        progressInterface.Progress = (int)(float.Parse(data[1]) / (float)(progressInterface.CompanyCount) * 100);
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
                    case "Debug":
                    case "Log":
                    case "Exception":
                        logInterface.WriteLog(data[0], "Financial Statement", Company, data[1]);
                        break;
                }

                Thread.Sleep(200);
            }
        }
    }
}
