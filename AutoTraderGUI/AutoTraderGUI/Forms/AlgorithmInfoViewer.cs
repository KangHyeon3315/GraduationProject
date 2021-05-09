using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AutoTraderGUI.Forms
{
    public partial class AlgorithmInfoViewer : Form
    {
        public AlgorithmInfoViewer(string FileName)
        {
            InitializeComponent();

            this.CenterToParent();

            Library.AlgorithmInfo algorithmInfo;
            FileStream fs = new FileStream(Application.StartupPath + "\\Algorithm\\" + FileName + ".trstr", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            algorithmInfo = (Library.AlgorithmInfo)bf.Deserialize(fs);
            fs.Close();

            AlgorithmName.Text = algorithmInfo.AlgorithmName;
            Distribute.Text = algorithmInfo.DistributeNum.ToString();
            MaxOwnDate.Text = algorithmInfo.MaxOwnDate.ToString();
            BuyTiming.Text = algorithmInfo.buyTiming.ToString();
            BuyTrends.Text = algorithmInfo.marketTrends.ToString();
            SellTiming.Text = algorithmInfo.sellTiming.ToString();
            ProfitCut.Text = algorithmInfo.profitCut.ToString() + "%";
            LossCut.Text = algorithmInfo.lossCut.ToString() + "%";

            BuySQL.Text = algorithmInfo.buySQLFormat;
            SellSQL.Text = algorithmInfo.sellSQLFormat;
        }
    }
}
