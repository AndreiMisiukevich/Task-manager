using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using ProjectConfiguration;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private const int WAITER = 1000;
        private const int MINUTE = 60;
        private const int PERCENTE = 100;
        private const int PROGRESS_COUNT = 5;
        private const int DECIMALS = 20;
        private const int FULL_PROGRESS = 100;
        private const int ZERO = 0;
        private const int TO_PERCENTE = 5;
        private const int PART = 2;

        private volatile ProgressBar[] _leftProgress = new ProgressBar[PROGRESS_COUNT];
        private volatile ProgressBar[] _rightProgress = new ProgressBar[PROGRESS_COUNT];

        private Form2 processesForm = new Form2();

        public Form1()
        {
            InitializeComponent();
            label1.Text = StringConst.LABEL1_TXT;
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.Top -= label1.Parent.Top;
            label1.Left -= label1.Parent.Left;
            label2.Top -= label2.Parent.Top;
            label2.Left -= label2.Parent.Left;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;

            notifyIcon1.Visible = false;

            _leftProgress[0] = progressBar1;
            _leftProgress[1] = progressBar2;
            _leftProgress[2] = progressBar3;
            _leftProgress[3] = progressBar4;
            _leftProgress[4] = progressBar5;

            _rightProgress[0] = progressBar6;
            _rightProgress[1] = progressBar7;
            _rightProgress[2] = progressBar8;
            _rightProgress[3] = progressBar9;
            _rightProgress[4] = progressBar10;

            processesForm.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thread = new Thread(() => ObserveBatteryState());
            thread.IsBackground = true;
            thread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = this.ShowInTaskbar == false ? true : false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Visible = false;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processesForm.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(StringConst.CLOSE_MSG, StringConst.ATTENTION, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        // Custom Methods

        private void ObserveBatteryState()
        {
            try
            {
                while (true)
                {
                    Type powerStatusType = typeof(PowerStatus);
                    PropertyInfo powerStatusInfo = powerStatusType.GetProperties().First(x => x.Name.ToLower() == StringConst.BATTERY_STATUS.ToLower());
                    var bateryChargeStatus = (BatteryChargeStatus)powerStatusInfo.GetValue(SystemInformation.PowerStatus, null);

                    Color color = default(Color);
                    switch (bateryChargeStatus)
                    {
                        case BatteryChargeStatus.Unknown:
                            color = Color.Aqua;
                            break;
                        case BatteryChargeStatus.NoSystemBattery:
                            color = Color.DarkRed;
                            break;
                        case BatteryChargeStatus.Critical:
                            color = Color.Red;
                            if (radioButton2.Checked)
                            {
                                Action<bool> action_radioBtn; 
                                if (radioButton3.Checked)
                                {
                                    action_radioBtn = radioButton3.SetRadioButtonChecked;
                                    radioButton3.Invoke(action_radioBtn, false);
                                    action_radioBtn = radioButton2.SetRadioButtonChecked;
                                    radioButton2.Invoke(action_radioBtn, false);
                                    Application.SetSuspendState(PowerState.Suspend, true, true);
                                    MessageBox.Show(StringConst.SLEEP, StringConst.ATTENTION);
                                }
                                if (radioButton4.Checked)
                                {
                                    action_radioBtn = radioButton4.SetRadioButtonChecked;
                                    radioButton4.Invoke(action_radioBtn, false);
                                    action_radioBtn = radioButton2.SetRadioButtonChecked;
                                    radioButton2.Invoke(action_radioBtn, false);
                                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                                    MessageBox.Show(StringConst.HIBERNATE, StringConst.ATTENTION);
                                }
                                if(checkBox1.Checked)
                                {
                                    Action<bool> action_chkBox;
                                    action_chkBox = checkBox1.SetCheckBoxChecked;
                                    checkBox1.Invoke(action_chkBox, false);
                                    processesForm.Visible = true;
                                }
                            }
                            break;
                        case BatteryChargeStatus.Low:
                            color = Color.Yellow;
                            if(radioButton1.Checked)
                            {
                                Action<bool> action_radioBtn;
                                if(radioButton3.Checked)
                                {
                                    action_radioBtn = radioButton3.SetRadioButtonChecked;
                                    radioButton3.Invoke(action_radioBtn, false);
                                    action_radioBtn = radioButton1.SetRadioButtonChecked;
                                    radioButton1.Invoke(action_radioBtn, false);
                                    Application.SetSuspendState(PowerState.Suspend, true, true);
                                    MessageBox.Show(StringConst.SLEEP, StringConst.ATTENTION);
                                }
                                if(radioButton4.Checked)
                                {
                                    action_radioBtn = radioButton4.SetRadioButtonChecked;
                                    radioButton4.Invoke(action_radioBtn, false);
                                    action_radioBtn = radioButton1.SetRadioButtonChecked;
                                    radioButton1.Invoke(action_radioBtn, false);
                                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                                    MessageBox.Show(StringConst.HIBERNATE, StringConst.ATTENTION);
                                }
                                if(checkBox1.Checked)
                                {
                                    Action<bool> action_chkBox;
                                    action_chkBox = checkBox1.SetCheckBoxChecked;
                                    checkBox1.Invoke(action_chkBox, false);
                                    processesForm.Visible = true;
                                }
                            }
                            break;
                        case BatteryChargeStatus.High:
                            color = Color.GreenYellow;

                            break;
                        case BatteryChargeStatus.Charging:
                            color = Color.LimeGreen;
                            break;
                        default:
                            color = Color.LightGreen;
                            break;
                    }
                    Action<Color> action_form = this.SetFormBackColor;
                    this.Invoke(action_form, color);

                    PropertyInfo lifeRemInfo = powerStatusType.GetProperties().First(x => x.Name.ToLower() == StringConst.BATTERY_LIFE.ToLower());
                    var batteryLifeRem = (float)lifeRemInfo.GetValue(SystemInformation.PowerStatus, null);
                    Action<string> action_label = label2.SetLabelText;
                    int percenteRem = (int)(batteryLifeRem * PERCENTE);
                    label2.Invoke(action_label, percenteRem.ToString());

                    Action<int> action_progress;
                    int currentProgress;
                    for (int i = 0; i < PROGRESS_COUNT; ++i)
                    {
                        if ((percenteRem) / (DECIMALS * (i + 1)) > ZERO)
                        {
                            currentProgress = FULL_PROGRESS;
                        }
                        else
                        {
                            int remindPerc = percenteRem - DECIMALS * i;
                            if (remindPerc > ZERO)
                            {
                                currentProgress = (remindPerc * TO_PERCENTE) / PART;
                            }
                            else
                            {
                                currentProgress = ZERO;
                            }
                        }

                        action_progress = _leftProgress[i].SetProgressBarValue;
                        _leftProgress[i].Invoke(action_progress, currentProgress);
                        action_progress = _rightProgress[i].SetProgressBarValue;
                        _rightProgress[i].Invoke(action_progress, currentProgress);
                    }

                    Thread.Sleep(WAITER);
                }
            }
            catch
            {
                return;
            }
        }

    }
}
