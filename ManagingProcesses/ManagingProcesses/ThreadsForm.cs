using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingProcesses
{
    public partial class ThreadsForm : Form
    {
        private Process _process;
        public ThreadsForm(Process process)
        {
            this._process = process;
            InitializeComponent();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < process.Threads.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1["ThreadId", i].Value = process.Threads[i].Id;
                dataGridView1["StartTime", i].Value = process.Threads[i].StartTime.ToLongDateString() + process.Threads[i].StartTime.ToLongTimeString();
                dataGridView1["ThreadPriority", i].Value = process.Threads[i].CurrentPriority;
                dataGridView1["ThreadWaitReason", i].Value = process.Threads[i].WaitReason;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
