using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;

namespace TelnetTemp
{
    public partial class MainForm : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private System.Timers.Timer timer = new System.Timers.Timer();
        private TelnetConnection telnetConnection = new TelnetConnection();

        public MainForm()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.IsHideToTray)
            {
                Hide();
            }
            else
            {
                ApplicationExit();
            }

            e.Cancel = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            logger.Info("Start new session");

            LoadSettings();
            ApplySettings();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            ApplySettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationExit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            Activate();
        }

        private void ApplicationExit()
        {
            DialogResult dialogResult = MessageBox.Show(this, "Application will be closed", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                notifyIcon.Visible = false;
                Application.ExitThread();
            }
        }

        private void LoadSettings()
        {
            autorunCheckBox.Checked = Properties.Settings.Default.IsAutorun;
            hideToTrayCheckBox.Checked = Properties.Settings.Default.IsHideToTray;
            telnetTextBox.Text = Properties.Settings.Default.TelnetAddress;
            portNumeric.Value = Properties.Settings.Default.TelnetPort;
            hostTextBox.Text = Properties.Settings.Default.HostAddress;
            intervalNumeric.Value = Properties.Settings.Default.Interval;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.IsAutorun = autorunCheckBox.Checked;
            Properties.Settings.Default.IsHideToTray = hideToTrayCheckBox.Checked;
            Properties.Settings.Default.TelnetAddress = telnetTextBox.Text;
            Properties.Settings.Default.TelnetPort = (int)portNumeric.Value;
            Properties.Settings.Default.HostAddress = hostTextBox.Text;
            Properties.Settings.Default.Interval = (int)intervalNumeric.Value;

            Properties.Settings.Default.Save();
        }

        private void ApplySettings()
        {
            notifyIcon.Visible = Properties.Settings.Default.IsHideToTray;
            Functions.SetAutorunValue(Properties.Settings.Default.IsAutorun);

            timer.Interval = Properties.Settings.Default.Interval * 1000;
            timer.Stop();

            AsyncGetTemp();
        }

        private void AsyncGetTemp()
        {
            Task.Factory.StartNew(() =>
            {
                GetTemp();
                timer.Start();
            });
        }

        private void GetTemp()
        {
            //logger.Info(Thread.CurrentThread.ManagedThreadId);
            try
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.TelnetAddress))
                    return;

                telnetConnection.Connect(Properties.Settings.Default.TelnetAddress, Properties.Settings.Default.TelnetPort);

                Thread.Sleep(100);

                String result = telnetConnection.Read();
                logger.Info("TELNET: " + result);

                telnetConnection.Close();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GetTemp();
        }
    }
}
