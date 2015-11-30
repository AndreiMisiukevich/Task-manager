using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace ManagingProcesses
{
    public partial class MostFatProcesses : Form
    {
        private const string Pattern = "ID: {0};\r\n Name : {1};\r\n Memory {2} (Mb);";
        private CustomProcessInfo[] _procArr;

        public MostFatProcesses()
        {

            InitializeComponent();
        }

        public void SetNewProcesses(IEnumerable<CustomProcessInfo> processes)
        {
            _procArr = processes.ToArray();
            Array.Sort(_procArr, (a, b) => b.Memory > a.Memory ? 1 : b.Memory == a.Memory ? 0 : -1);

            textBox1.AppendText(string.Format(Pattern, _procArr[0].Id, _procArr[0].Name, _procArr[0].Memory));
            textBox2.AppendText(string.Format(Pattern, _procArr[1].Id, _procArr[1].Name, _procArr[1].Memory));
            textBox3.AppendText(string.Format(Pattern, _procArr[2].Id, _procArr[2].Name, _procArr[2].Memory));
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StopProc(_procArr[0].Id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopProc(_procArr[1].Id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopProc(_procArr[2].Id);
        }

        private void StopProc(int id)
        {
            try
            {
                var processes = Process.GetProcesses();
                var curProc = processes.FirstOrDefault(x => x.Id == id);
                if (curProc != null)
                {
                    curProc.Kill();
                }
            }
            catch
            {
                MessageBox.Show(@"System process! Canceled", @"Error");
            }
        }


        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }

    public class CustomProcessInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BigInteger Memory { get; set; }

    }
}
