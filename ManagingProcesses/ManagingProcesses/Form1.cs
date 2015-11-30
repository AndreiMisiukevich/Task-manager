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
using System.Windows.Forms.DataVisualization.Charting;
using BusinessLogic;
using ExcelDAO;
using Timer = System.Windows.Forms.Timer;

namespace ManagingProcesses
{
    public partial class Form1 : Form
    {
        #region Constants

        private const string LogFile = @"U:\6semestr\Course project\ManagingProcesses\ManagingProcesses\bin\Debug\" +
                                       "logger.xlsx";

        private static int CountOfCurrentPoint = 1;
        private int _counter = 1;
        private ManageProcess manage = new ManageProcess();
        private PerformanceCounter cpucounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter memcounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        private List<string[]> logs = new List<string[]>();
        private const int ChangePriorityColumn = 3;
        private const int ThreadsShowColumn = 5;
        private const int TimeoutEventMilliSeconds = 500;
        private const int StartIndexOfRow = 0;
        private const string RejectMessage = "Request rejected because of ";
        private const string ErrorReasonMessage = "Process was not closed beacause of ";
        private const int MegaByteConverterConst = 100000;
        private const int NumberOfPointsInChart = 10;

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            FillFormWithProcesses();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeoutEventMilliSeconds;
            timer.Start();

            Timer timer2 = new Timer();
            timer2.Tick += new EventHandler(timer_TickForLog);
            timer2.Interval = TimeoutEventMilliSeconds;
            timer2.Start();

            #region fill in color charts

            chart2.Series.First().XValueMember = "X";
            chart2.Series.First().YValueMembers = "Y";
            chart2.Series[0].Name = "% загруженности памяти, динамика";
            chart2.Series[0].ShadowColor = BackColor;
            chart2.BackColor = Color.Aquamarine;
            chart2.BackSecondaryColor = Color.Green;
            chart2.ForeColor = Color.Aquamarine;
            chart2.Series[0].Color = Color.Crimson;

            chart1.Series.First().XValueMember = "X";
            chart1.Series.First().YValueMembers = "Y";
            chart1.Series[0].Name = "% загруженности ЦП, динамика";
            chart1.Series[0].ShadowColor = BackColor;
            chart1.BackColor = Color.Aquamarine;
            chart1.BackSecondaryColor = Color.Green;
            chart1.ForeColor = Color.Aquamarine;
            chart1.Series[0].Color = Color.BlueViolet;

            #endregion
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FillFormWithProcesses();
        }

        private void dataGridProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ChangePriorityColumn && e.RowIndex >= StartIndexOfRow)
            {
                var name = dataGridProcesses["ProcessName", e.RowIndex].Value.ToString();
                try
                {
                    new ChangePriority(Process.GetProcessesByName(name).First()).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(RejectMessage + ex.Message);
                }
            }
            if (e.ColumnIndex == ThreadsShowColumn && e.RowIndex >= StartIndexOfRow)
            {
                var name = dataGridProcesses["ProcessName", e.RowIndex].Value.ToString();
                try
                {
                    new ThreadsForm(Process.GetProcessesByName(name).First()).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(RejectMessage + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            textBox1.Text = "";
            if (text.Length == 0)
                FillFormWithProcesses();
            var filteredList = manage.GetProcesses().Where((x) => x.ProcessName.Contains(text)).ToList();
            FillFormWithProcesses(filteredList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var name = dataGridProcesses["ProcessName", dataGridProcesses.SelectedCells[0].RowIndex].Value.ToString();

            try
            {
                var process = manage.GetProcesses().FirstOrDefault(x => x.ProcessName == name);
                if (process != null)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorReasonMessage + ex.Message);
            }
        }

        private void TabControlProcess_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (
                var excel =
                    new ExcelFile(LogFile)
                )
            {
                excel.AddLogs(logs);
            }
            Process.Start(LogFile);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new NewProcess().Show();
        }

        #endregion

        #region Events on timer

        private void timer_Tick(object sender, EventArgs e)
        {
            var cp = cpucounter.NextValue();
            if (chart1.Series[StartIndexOfRow].Points.Count > NumberOfPointsInChart)
            {
                var points = new List<System.Windows.Forms.DataVisualization.Charting.DataPoint>();
                foreach (var point in chart1.Series[StartIndexOfRow].Points)
                {
                    points.Add(point);
                }
                for (int j = 0; j < points.Count; j++)
                {
                    points[j].XValue = j;
                }
                chart1.Series[StartIndexOfRow].Points.Clear();
                for (int j = 0; j < points.Count - 1; j++)
                {
                    chart1.Series[StartIndexOfRow].Points.AddXY(points[j + 1].XValue, points[j + 1].YValues.First());
                }
                chart1.Series[StartIndexOfRow].Points.AddXY(NumberOfPointsInChart, cp);
            }
            else
            {
                chart1.Series[StartIndexOfRow].Points.AddXY(CountOfCurrentPoint, cp);
            }

            var m = memcounter.NextValue();
            chart2.Series[StartIndexOfRow].Points.AddXY(CountOfCurrentPoint, m);

            CountOfCurrentPoint++;
            Invalidate();
        }

        private void timer_TickForLog(object sender, EventArgs e)
        {
            var m =
                manage.GetProcesses()
                    .Select(x => x.VirtualMemorySize64/MegaByteConverterConst)
                    .Aggregate((x, y) => x + y);
            var numberOfProcesses = manage.GetProcesses().Count.ToString();
            var time = DateTime.Now.ToLongTimeString();
            logs.Add(new string[] {"Следующее действие. Подробная информация:"});
            logs.Add(new string[] {"Время : ", time});
            logs.Add(new string[] {"Количество процессов : ", numberOfProcesses + " processes"});
            logs.Add(new string[] {"Загруженность памяти : ", m + " kb"});
        }

        #endregion

        #region Logic methods

        private void FillFormWithProcesses(List<Process> list = null)
        {
            dataGridProcesses.Rows.Clear();
            if (list == null)
                list = manage.GetProcesses();
            for (int i = StartIndexOfRow; i < list.Count; i++)
            {
                dataGridProcesses.Rows.Add();
                try
                {
                    dataGridProcesses["ProcessName", i].Value = list[i].ProcessName;
                }
                catch (Exception)
                {
                    dataGridProcesses["ProcessName", i].Value = "Rejected";
                    dataGridProcesses["ProcessName", i].Style.BackColor = Color.Crimson;
                }
                try
                {
                    dataGridProcesses["Priority", i].Value = list[i].PriorityClass.ToString();
                }
                catch (Exception)
                {
                    dataGridProcesses["Priority", i].Value = "Rejected";
                    dataGridProcesses["Priority", i].Style.BackColor = Color.Crimson;
                }
                try
                {
                    dataGridProcesses["NumberOfThreads", i].Value = list[i].Threads.Count;
                }
                catch (Exception)
                {
                    dataGridProcesses["NumberOfThreads", i].Value = "Rejected";
                    dataGridProcesses["NumberOfThreads", i].Style.BackColor = Color.Crimson;
                }
                try
                {
                    dataGridProcesses["Memory", i].Value = list[i].PagedMemorySize64;
                }
                catch (Exception)
                {
                    dataGridProcesses["Memory", i].Value = "Rejected";
                    dataGridProcesses["Memory", i].Style.BackColor = Color.Crimson;
                }

                dataGridProcesses["WatchThreads", i].Value = "Threads";
                dataGridProcesses["ChangePriority", i].Value = "change";
            }
        }

        #endregion


        #region Observer Logic

        private void observeButton_Click(object sender, EventArgs e)
        {


            int time;
            if (!int.TryParse(observeTb.Text, out time))
            {
                MessageBox.Show(@"Parse error!", @"Error");
                return;
            }

            var thr = new Thread(() =>
            {
                var customProcessInfoList = new List<CustomProcessInfo>();
                var startTime = DateTime.Now;
                while ((DateTime.Now - startTime).Seconds < time)
                {
                    var processes = Process.GetProcesses().ToList();
                    processes.ForEach(x =>
                    {
                        var proc = customProcessInfoList.FirstOrDefault(p => p.Id == x.Id);
                        if (proc != null)
                        {
                            proc.Memory += x.VirtualMemorySize64/MegaByteConverterConst;
                        }
                        else
                        {
                            customProcessInfoList.Add(new CustomProcessInfo
                            {
                                Id = x.Id,
                                Name = x.ProcessName,
                                Memory = x.VirtualMemorySize64/MegaByteConverterConst
                            });
                        }
                    });

                    Thread.Sleep(1000);
                }

                var form = new MostFatProcesses();
                form.SetNewProcesses(customProcessInfoList);
                form.Visible = true;
                form.Show();
                form.Text = string.Format("From {0} Till {1}", startTime, DateTime.Now);
                Application.Run();
            }) {IsBackground = true};
            thr.Start();

            MessageBox.Show(@"Started!", @"Attention!");
        }

        private void observeButton_MouseDown(object sender, MouseEventArgs e)
        {
            observeButton.BackColor = Color.LightGreen;
            observeTb.BackColor = Color.BurlyWood;
        }

        private void observeButton_MouseUp(object sender, MouseEventArgs e)
        {
            observeButton.BackColor = Color.SeaShell;
            observeTb.BackColor = Color.Snow;
        }

        #endregion
    }
}
