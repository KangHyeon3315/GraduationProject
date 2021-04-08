using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AutoTraderGUI.Library
{
    class Settings
    {
        public SettingsInfo info;
        public Settings()
        {
            if (File.Exists("SettingsInfo.bin"))
            {
                FileStream openFs = new FileStream("SettingsInfo.bin", FileMode.Open);
                BinaryFormatter openBf = new BinaryFormatter();
                info = (SettingsInfo)openBf.Deserialize(openFs);
                openFs.Close();
            }
            else
            {
                info = new SettingsInfo();
            }
        }

        public void SaveSettings()
        {
            FileStream saveFs = new FileStream("SettingsInfo.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(saveFs, info);
            saveFs.Close();
        }
    }
}
