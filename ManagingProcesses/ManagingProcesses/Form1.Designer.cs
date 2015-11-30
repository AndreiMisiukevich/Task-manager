namespace ManagingProcesses
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.observeTb = new System.Windows.Forms.TextBox();
            this.observeButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.dataGridProcesses = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangePriority = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NumberOfThreads = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchThreads = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TabControlProcess = new System.Windows.Forms.TabControl();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcesses)).BeginInit();
            this.TabControlProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(169, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application for watching and managing processes and threads of system";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chart2);
            this.tabPage4.Controls.Add(this.chart1);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(954, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Chart";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea13.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chart2.Legends.Add(legend13);
            this.chart2.Location = new System.Drawing.Point(3, 188);
            this.chart2.Name = "chart2";
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.chart2.Series.Add(series13);
            this.chart2.Size = new System.Drawing.Size(948, 197);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea14.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chart1.Legends.Add(legend14);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.chart1.Series.Add(series14);
            this.chart1.Size = new System.Drawing.Size(954, 200);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(954, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(279, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(223, 57);
            this.button4.TabIndex = 4;
            this.button4.Text = "Открыть файл логирования";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(517, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "управлением. Для просмотра файла нажмите кнопку ниже";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "и потоков системы, а также их";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "полное логирование процессов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "В данном приложении ведется";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.observeTb);
            this.tabPage1.Controls.Add(this.observeButton);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.RefreshButton);
            this.tabPage1.Controls.Add(this.dataGridProcesses);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(954, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Processes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // observeTb
            // 
            this.observeTb.BackColor = System.Drawing.Color.Snow;
            this.observeTb.Location = new System.Drawing.Point(825, 345);
            this.observeTb.Name = "observeTb";
            this.observeTb.Size = new System.Drawing.Size(105, 29);
            this.observeTb.TabIndex = 8;
            // 
            // observeButton
            // 
            this.observeButton.BackColor = System.Drawing.Color.SeaShell;
            this.observeButton.Location = new System.Drawing.Point(825, 313);
            this.observeButton.Name = "observeButton";
            this.observeButton.Size = new System.Drawing.Size(105, 26);
            this.observeButton.TabIndex = 7;
            this.observeButton.Text = "Observe";
            this.observeButton.UseVisualStyleBackColor = false;
            this.observeButton.Click += new System.EventHandler(this.observeButton_Click);
            this.observeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.observeButton_MouseDown);
            this.observeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.observeButton_MouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(825, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 62);
            this.button3.TabIndex = 6;
            this.button3.Text = "Run new process";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(825, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 98);
            this.button2.TabIndex = 5;
            this.button2.Text = "Try to close selected process";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(845, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(825, 245);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 29);
            this.textBox1.TabIndex = 2;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(825, 6);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(105, 39);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // dataGridProcesses
            // 
            this.dataGridProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.Memory,
            this.Priority,
            this.ChangePriority,
            this.NumberOfThreads,
            this.WatchThreads});
            this.dataGridProcesses.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProcesses.Location = new System.Drawing.Point(3, 3);
            this.dataGridProcesses.MultiSelect = false;
            this.dataGridProcesses.Name = "dataGridProcesses";
            this.dataGridProcesses.RowTemplate.Height = 30;
            this.dataGridProcesses.Size = new System.Drawing.Size(948, 382);
            this.dataGridProcesses.TabIndex = 0;
            this.dataGridProcesses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProcesses_CellContentClick);
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Name";
            this.ProcessName.MinimumWidth = 7;
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            this.ProcessName.Width = 200;
            // 
            // Memory
            // 
            this.Memory.HeaderText = "Memory, Bytes";
            this.Memory.Name = "Memory";
            this.Memory.ReadOnly = true;
            this.Memory.Width = 120;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 150;
            // 
            // ChangePriority
            // 
            this.ChangePriority.HeaderText = "Change prority";
            this.ChangePriority.Name = "ChangePriority";
            this.ChangePriority.ReadOnly = true;
            // 
            // NumberOfThreads
            // 
            this.NumberOfThreads.HeaderText = "Thread\'s count";
            this.NumberOfThreads.Name = "NumberOfThreads";
            this.NumberOfThreads.ReadOnly = true;
            // 
            // WatchThreads
            // 
            this.WatchThreads.HeaderText = "Watch";
            this.WatchThreads.Name = "WatchThreads";
            this.WatchThreads.ReadOnly = true;
            // 
            // TabControlProcess
            // 
            this.TabControlProcess.Controls.Add(this.tabPage1);
            this.TabControlProcess.Controls.Add(this.tabPage2);
            this.TabControlProcess.Controls.Add(this.tabPage4);
            this.TabControlProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TabControlProcess.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControlProcess.Location = new System.Drawing.Point(-7, 58);
            this.TabControlProcess.Name = "TabControlProcess";
            this.TabControlProcess.SelectedIndex = 0;
            this.TabControlProcess.Size = new System.Drawing.Size(962, 422);
            this.TabControlProcess.TabIndex = 0;
            this.TabControlProcess.Click += new System.EventHandler(this.TabControlProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(949, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabControlProcess);
            this.Name = "Form1";
            this.Text = "Managing system processes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcesses)).EndInit();
            this.TabControlProcess.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.DataGridView dataGridProcesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewButtonColumn ChangePriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfThreads;
        private System.Windows.Forms.DataGridViewButtonColumn WatchThreads;
        private System.Windows.Forms.TabControl TabControlProcess;
        private System.Windows.Forms.Button observeButton;
        private System.Windows.Forms.TextBox observeTb;
    }
}

