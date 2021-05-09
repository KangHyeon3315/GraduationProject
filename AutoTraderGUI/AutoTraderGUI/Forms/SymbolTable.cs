﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTraderGUI.Forms
{
    [Serializable]
    public partial class SymbolTable : UserControl
    {
        public SymbolTable()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            SymbolsListView.FullRowSelect = true;
        }
        
        public void AddSymbol(string varName, string indicatorName, int offset, string Parameter, string ParameterValue)
        {
            ListViewItem item = new ListViewItem(SymbolsListView.Items.Count.ToString());
            item.SubItems.Add(varName);
            item.SubItems.Add(indicatorName);
            item.SubItems.Add(offset.ToString());
            item.SubItems.Add(Parameter);
            item.SubItems.Add(ParameterValue);
            SymbolsListView.Items.Add(item);
        }

        private void DeleteSymbolClick(object sender, EventArgs e)
        {
            for(int i = SymbolsListView.SelectedIndices.Count - 1; i >= 0; i--)
            {
                SymbolsListView.Items.RemoveAt(SymbolsListView.SelectedIndices[i]);
            }
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            int totalWidth = SymbolsListView.Size.Width;
            int restWidth = totalWidth;
            SymbolsListView.Columns[0].Width = 60;          
            restWidth -= SymbolsListView.Columns[0].Width;

            SymbolsListView.Columns[2].Width = 120;         
            restWidth -= SymbolsListView.Columns[2].Width;

            SymbolsListView.Columns[3].Width = 60;          
            restWidth -= SymbolsListView.Columns[3].Width;

            SymbolsListView.Columns[4].Width = 180;          
            restWidth -= SymbolsListView.Columns[4].Width;

            SymbolsListView.Columns[5].Width = 180;
            restWidth -= SymbolsListView.Columns[5].Width;

            SymbolsListView.Columns[1].Width = restWidth;
        }
    }
}