using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTraderGUI.Library
{
    [Serializable]
    class SettingsInfo
    {
        public string InterpreterPath;
        public string APICollectorPath;
        public string DartCollectorPath;
        public int MaxRequestsCount;
        public float RequestsInterval;
        public string DartAPI;
        public string DBIP;
        public int DBPort;
        public string DBID;
        public string DBPW;

    }
}
