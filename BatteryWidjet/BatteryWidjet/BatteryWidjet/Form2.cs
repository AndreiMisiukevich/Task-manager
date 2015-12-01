using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectConfiguration;
using System.Diagnostics;

namespace PresentationLayer
{
    public partial class Form2 : Form
    {
        private List<Process> _procList = new List<Process>();

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var index in checkedListBox1.CheckedIndices)
            {
                try
                {
                    _procList[(int)index].Kill();
                }
                catch { continue; }
            }

            RefreshList();
            MessageBox.Show(StringConst.PREPARED, StringConst.ATTENTION);
            
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
            {
                RefreshList();
            }
        }

        private void RefreshList()
        {
            checkedListBox1.Items.Clear();
            _procList = RefreshCurrentProcesses();
            foreach(var item in _procList)
            {
                checkedListBox1.Items.Add(item.ProcessName);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private List<Process> RefreshCurrentProcesses()
        {
            var procArr = Process.GetProcesses();
            var procList = new List<Process>();
            foreach (Process process in procArr)
            {
                try
                {
                    if (process.PriorityClass == ProcessPriorityClass.BelowNormal ||
                        process.PriorityClass == ProcessPriorityClass.Normal)
                    {
                        procList.Add(process);
                    }
                }
                catch
                {
                    continue;
                }
            }

            return procList;
        }
    }
}
