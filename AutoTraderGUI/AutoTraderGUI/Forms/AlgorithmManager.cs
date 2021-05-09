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
    public partial class AlgorithmManager : Form
    {
        public string SelectedAlgorithmName;

        Library.AlgorithmInfo selectedAlgorithm;
        Forms.AlgorithmInfoControl algorithmInfo;
        Forms.AlgorithmEdit algorithmCreate;

        AlgorithmInfoInterface algorithmInfoInterface;

        public AlgorithmManager()
        {
            InitializeComponent();

            this.CenterToParent();

            algorithmInfo = new Forms.AlgorithmInfoControl();
            algorithmInfoInterface = algorithmInfo.algorithmInfoInterface;

            BasicLayout.Controls.Clear();
            BasicLayout.Controls.Add(ToolLayout);
            BasicLayout.Controls.Add(algorithmInfo);
        }

        private void AlgorithmOptionManagerClick(object sender, EventArgs e)
        {
            algorithmCreate = new Forms.AlgorithmEdit(algorithmInfoInterface);
            algorithmCreate.Show();
        }

        private void AlgorithmSelect(object sender, EventArgs e)
        {
            if(algorithmInfo.AlgorithmInfo.SelectedItems.Count > 0)
            {
                SelectedAlgorithmName = algorithmInfo.AlgorithmInfo.SelectedItems[0].Text;
                Close();
            }
            else
            {
                MessageBox.Show("알고리즘을 먼저 선택하세요.");
            }
            
        }

        private void SearchClick(object sender, EventArgs e)
        {
            for(int i = 0; i < algorithmInfo.AlgorithmInfo.Items.Count; i++)
            {
                if(algorithmInfo.AlgorithmInfo.Items[i].Text == SearchTextBox.Text)
                {
                    algorithmInfo.AlgorithmInfo.SelectedIndices.Clear();
                    algorithmInfo.AlgorithmInfo.SelectedIndices.Add(i);
                    algorithmInfo.AlgorithmInfo.Items[i].EnsureVisible();
                    break;
                }
            }
        }
    }
}
