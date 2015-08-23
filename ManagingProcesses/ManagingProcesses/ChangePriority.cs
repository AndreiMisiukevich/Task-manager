using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingProcesses
{
    public partial class ChangePriority : Form
    {
        private Process _process;
        public ChangePriority(Process process)
        {
            this._process = process;
            InitializeComponent();
            CheckForNeedButton(_process.PriorityClass);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _process.PriorityClass = ProcessPriorityClass.Normal;
            }
            else if (radioButton2.Checked)
            {
                _process.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            else if (radioButton3.Checked)
            {
                _process.PriorityClass = ProcessPriorityClass.BelowNormal;
            }
            else if (radioButton4.Checked)
            {
                _process.PriorityClass = ProcessPriorityClass.High;
            }
            else if (radioButton5.Checked)
            {
                _process.PriorityClass = ProcessPriorityClass.Idle;
            }
            else
            {
                _process.PriorityClass = ProcessPriorityClass.RealTime;
            }
            this.Close();
        }

        private bool CheckForNeedButton(ProcessPriorityClass priority)
        {
            if (priority == ProcessPriorityClass.Normal)
            {
                radioButton1.Checked = true;
                return true;
            }
            else if (priority == ProcessPriorityClass.AboveNormal)
            {
                radioButton2.Checked = true;
                return true;
            }
            else if (priority == ProcessPriorityClass.BelowNormal)
            {
                radioButton3.Checked = true;
                return true;
            }
            else if (priority == ProcessPriorityClass.High)
            {
                radioButton4.Checked = true;
                return true;
            }
            else if (priority == ProcessPriorityClass.Idle)
            {
                radioButton5.Checked = true;
                return true;
            }
            else if (priority == ProcessPriorityClass.RealTime)
            {
                radioButton6.Checked = true;
                return true;
            }
            return false;
        }
    }
}
