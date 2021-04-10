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
        public string InterpreterPath = "D:\\Anaconda\\python.exe";
        public string APICollectorPath = "C:\\Users\\양성준\\Source\\Repos\\GraduationProject\\APICollector\\APICollector.py";
        public string DartCollectorPath = "C:\\Users\\양성준\\Source\\Repos\\GraduationProject\\APICollector\\DartCollector.py";
        public int MaxRequestsCount = 1000;
        public float RequestsInterval = 0.4f;
        public string DartAPI = "085990c5ee309d660c0e658abaeb455e7454eecb";
        public string DBIP = "localhost";
        public int DBPort = 3306;
        public string DBID = "root";
        public string DBPW = "vmfhwprxm1";

    }
}
