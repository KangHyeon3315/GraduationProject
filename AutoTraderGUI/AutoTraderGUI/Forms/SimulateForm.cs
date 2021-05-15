﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AutoTraderGUI.Forms
{
    public partial class SimulateForm : UserControl
    {
        Forms.AlgorithmManager algorithmManager;
        List<Library.Simulate> simulates;

        SimulateChart emptyChart = new SimulateChart();
        SImulateInfoForm emptyInfo = new SImulateInfoForm(null);
        int chartIdx = -1;
        SettingsInterface settings;
        public SimulateForm(SettingsInterface settings)
        {
            this.settings = settings;
            InitializeComponent();
            Dock = DockStyle.Fill;
            simulates = new List<Library.Simulate>();

            initializeInfo();
            ChartPanel.Controls.Add(emptyChart);
            SimulateInfoPanel.Controls.Add(emptyInfo);
            MonitoringViewer.Start();
        }
        
        private void AlgorithmManageClick(object sender, EventArgs e)
        {
            algorithmManager = new Forms.AlgorithmManager();
            algorithmManager.ShowDialog();
            string selectedAlgorithm = algorithmManager.SelectedAlgorithmName;

            if (selectedAlgorithm == null || selectedAlgorithm.Trim() == "")
                return;

            Library.Simulate simulate = new Library.Simulate(settings, selectedAlgorithm, SimulateUnit.Text, int.Parse(InitialAssets.Text.Replace(",", "")) ,float.Parse(Tax.Text), float.Parse(Charge.Text));

            AlgorithmCombo.Items.Add(selectedAlgorithm);
            AlgorithmCombo.SelectedIndex = AlgorithmCombo.Items.Count - 1;
            simulates.Add(simulate);
            

            initializeInfo();
        }

        void initializeInfo()
        {
            SimulateUnit.Enabled = true;
            InitialAssets.Enabled = true;
            Tax.Enabled = true;
            Charge.Enabled = true;

            SimulateUnit.SelectedIndex = 0;
            InitialAssets.Text = 10000000.ToString("N0");
            Charge.Text = "0.00015";
            Tax.Text = "0.0025";
        }

        private void MonitoringViewer_Tick(object sender, EventArgs e)
        {
            if(AlgorithmCombo.Items.Count == 0)
            {
                //initializeInfo();
                return;
            }
                

            int selectedIndex = AlgorithmCombo.SelectedIndex;

            if (simulates[selectedIndex].isSimulating)
            {
                // 시뮬레이트 진행중
                SimulateUnit.Enabled = false;
                InitialAssets.Enabled = false;
                Tax.Enabled = false;
                Charge.Enabled = false;
            }
            else
            {
                // 시뮬레이트 진행X
                SimulateUnit.Enabled = true;
                InitialAssets.Enabled = true;
                Tax.Enabled = true;
                Charge.Enabled = true;
            }

            // 시뮬레이트 진행중인 상황 Update
            try
            {

                if(selectedIndex != chartIdx)
                {
                    ChartPanel.Controls.Clear();
                    ChartPanel.Controls.Add(simulates[selectedIndex].agent.chart);
                    SimulateInfoPanel.Controls.Clear();
                    SimulateInfoPanel.Controls.Add(simulates[selectedIndex].agent.info);
                    chartIdx = selectedIndex;
                }

            }
            catch
            {

            }
            
            
        }

        private void InitialAssets_Leave(object sender, EventArgs e)
        {
            InitialAssets.Text = string.Format("{0:N0}", int.Parse(InitialAssets.Text));
        }

        private void LoadSimulation_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "시뮬레이션 파일 (*.simul)   |*.simul";
            openFileDialog1.FileName = "";
            DialogResult OpenResult = openFileDialog1.ShowDialog();

            if (OpenResult == DialogResult.OK)
            {
                Library.SimulateAgent simulAgent;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                simulAgent = (Library.SimulateAgent)bf.Deserialize(fs);
                fs.Close();

                Library.Simulate simul= new Library.Simulate(settings, simulAgent.algorithm.AlgorithmName, simulAgent.SimulateUnit, (int)simulAgent.Assets, simulAgent.Tax, simulAgent.Charge);
                simul.agent = simulAgent;
                simulAgent.LoadChart();
                simulAgent.LoadInfo(simul.simulInterface);

                simulates.Add(simul);
                AlgorithmCombo.Items.Add(simulAgent.algorithm.AlgorithmName);
                AlgorithmCombo.SelectedIndex = AlgorithmCombo.Items.Count - 1;

            }
        }
    }
}
