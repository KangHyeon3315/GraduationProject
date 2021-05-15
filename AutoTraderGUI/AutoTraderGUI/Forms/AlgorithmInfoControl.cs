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
    public partial class AlgorithmInfoControl : UserControl, AlgorithmInfoInterface
    {
        
        public string[] AlgorithmNames
        {
            get
            {
                string[] names = { };
                for (int i = 0; i < AlgorithmInfo.Items.Count; i++)
                {
                    names.Append(AlgorithmInfo.Items[i].Text);
                }
                return names;
            }
        }
        public AlgorithmInfoInterface algorithmInfoInterface
        {
            get
            {
                return this as AlgorithmInfoInterface;
            }
        }
        public AlgorithmInfoControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 25);
            AlgorithmInfo.SmallImageList = imgList;
            AlgorithmInfo.FullRowSelect = true;

            refreshAlgorithmInfo();
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            int totalWidth = AlgorithmInfo.Size.Width;
            int restWidth = totalWidth;
            
            int temp = restWidth / 6;

            AlgorithmInfo.Columns[0].Width = temp;
            restWidth -= AlgorithmInfo.Columns[0].Width;

            AlgorithmInfo.Columns[1].Width = temp;
            restWidth -= AlgorithmInfo.Columns[1].Width;

            AlgorithmInfo.Columns[2].Width = temp;
            restWidth -= AlgorithmInfo.Columns[2].Width;

            AlgorithmInfo.Columns[3].Width = temp;
            restWidth -= AlgorithmInfo.Columns[3].Width;

            AlgorithmInfo.Columns[4].Width = temp;
            restWidth -= AlgorithmInfo.Columns[4].Width;

            AlgorithmInfo.Columns[5].Width = restWidth - 5; 
        }

        public void refreshAlgorithmInfo()
        {
            string[] fileList = Directory.GetFiles(Application.StartupPath + "\\Algorithm\\");

            AlgorithmInfo.Items.Clear();

            for(int i = 0; i < fileList.Length; i++)
            {
                string fileName = fileList[i];


                if (!fileName.Contains(".trstr"))
                    continue;

                Library.AlgorithmInfo algorithmInfo;
                FileStream fs = new FileStream(fileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                algorithmInfo = (Library.AlgorithmInfo)bf.Deserialize(fs);
                fs.Close();

                ListViewItem item = new ListViewItem(algorithmInfo.AlgorithmName);
                item.SubItems.Add(algorithmInfo.Yield.ToString());
                item.SubItems.Add(algorithmInfo.ProfitLossRatio.ToString());
                item.SubItems.Add(algorithmInfo.MDD.ToString());
                item.SubItems.Add(algorithmInfo.MFE.ToString());
                item.SubItems.Add(algorithmInfo.MAE.ToString());

                AlgorithmInfo.Items.Add(item);
                
            }
        }

        private void EidtClick(object sender, EventArgs e)
        {
            if(AlgorithmInfo.SelectedItems.Count > 0)
            {
                string selectedName = AlgorithmInfo.SelectedItems[0].Text;
                AlgorithmEdit edit = new AlgorithmEdit(algorithmInfoInterface);
                edit.Show();
                edit.LoadAlgorithm(selectedName);
            }
            
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            string selectedName = AlgorithmInfo.SelectedItems[0].Text;
            if (File.Exists(Application.StartupPath + "\\Algorithm\\" + selectedName + ".trstr"))
            {
                File.Delete(Application.StartupPath + "\\Algorithm\\" + selectedName + ".trstr");
                refreshAlgorithmInfo();
            }
        }

        private void AlgorithmInfoViewClick(object sender, EventArgs e)
        {
            string selectedName = AlgorithmInfo.SelectedItems[0].Text;
            AlgorithmInfoViewer info = new AlgorithmInfoViewer(selectedName);
            info.Show();
        }
    }
}
