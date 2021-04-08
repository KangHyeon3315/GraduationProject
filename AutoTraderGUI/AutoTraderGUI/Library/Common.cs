using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTraderGUI
{
    public interface LogInterface
    {
        void WriteLog(string info, string task, string company, string log);
    }

    public interface ProgressInterface
    {
        string Task { get; set; }
        int RqCount { get; set; }
        string Company { get; set; }
        int CompleteCount { get; set; }
        int CompanyCount { get; set; }
        int Progress { get; set; }
    }

    class Queue
    {
        List<string> ReceiveQueue;

        private readonly object thisLock = new object();
        public Queue()
        {
            ReceiveQueue = new List<string>();
        }

        public void Add(string data)
        {
            lock (thisLock)
            {
                ReceiveQueue.Add(data);
            }
        }
        public string Get()
        {
            string data;
            lock (thisLock)
            {
                if (ReceiveQueue.Count > 0)
                {
                    data = ReceiveQueue[0];
                    ReceiveQueue.RemoveAt(0);
                }
                else
                {
                    data = "";
                }
            }

            return data;
        }
    }

    enum Role
    {
        None,
        APICollector,
        DartCollector
    }
    class Common
    {
    }
}
