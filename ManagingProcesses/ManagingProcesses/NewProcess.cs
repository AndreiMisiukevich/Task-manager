using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingProcesses
{
    public partial class NewProcess : Form
    {
        private string _file;
        public NewProcess()
        {
            InitializeComponent();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                _file = openFileDialog1.FileName;
                try
                {
                    button2.Show();
                    button2.Text = button2.Text + " " +_file.Split('/').Last();
                }
                catch (IOException)
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_file);
            }
            catch (Exception)
            {
                MessageBox.Show("Файл данного типа нельзя запустить");
            }
            this.Close();
        }
    }
}