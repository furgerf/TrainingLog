using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TrainingLog.Forms
{
    public partial class MainForm : Form
    {
        #region Public Fields

        public static MainForm Instance { get; private set; }

        public bool CloseForms { get; private set; }

        public Settings Settings { get; private set; }

        #endregion

        #region Constructor

        private MainForm()
        {
            if (Instance != null)
                throw new Exception("Shouldn\'t have been initialized before!");

            InitializeComponent();

            Instance = this;

            Settings = Settings.LoadSettings();

            if (File.Exists(Settings.DataPath))
                Model.Initialize(Settings.DataPath);
            else
            {
                var dlg = new OpenFileDialog
                              { InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString(), Filter = "XML-Files|*.xml" };

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Closing application...", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ButExitClick();
                    return;
                }

                if (
                    MessageBox.Show("Do you want to load the new log file from now on?", "Change settings",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Settings.DataPath = dlg.FileName;

                Model.Initialize(dlg.FileName);
            }

            EventHandler onFormHide = (s, e) =>
                                          {
                                              if (((Form) s).Visible) return;
                                              Instance.Show();
                                              Instance.BringToFront();
                                          };

            TrainingEntryForm.Instance.VisibleChanged += onFormHide;
            BiodataEntryForm.Instance.VisibleChanged += onFormHide;
            TrainingLogForm.Instance.VisibleChanged += onFormHide;
            StatisticsForm.Instance.VisibleChanged += onFormHide;
            SettingsForm.Instance.VisibleChanged += onFormHide;

            Closed += (s, e) => Application.Exit();

            ButShowStatisticsClick();
            //ButShowLogClick();
            //ButSettingsClick();
        }

        #endregion
        
        #region Methods

        public static void Initialize()
        {
            new MainForm();
        }

        #endregion
        
        #region Event Handling

        private void ButAddTrainingClick(object sender = null, EventArgs e = null)
        {
            Hide();
            TrainingEntryForm.Instance.Show();
            TrainingEntryForm.Instance.BringToFront();
        }

        private void ButAddBiodataClick(object sender = null, EventArgs e = null)
        {
            Hide();
            BiodataEntryForm.Instance.Show();
            BiodataEntryForm.Instance.BringToFront();
        }

        private void ButShowLogClick(object sender = null, EventArgs e = null)
        {
            Hide();
            TrainingLogForm.Instance.Show();
            TrainingLogForm.Instance.BringToFront();
        }

        private void ButShowStatisticsClick(object sender = null, EventArgs e = null)
        {
            Hide();
            StatisticsForm.Instance.Show();
            StatisticsForm.Instance.BringToFront();
        }

        private void ButSettingsClick(object sender = null, EventArgs e = null)
        {
            Hide();
            SettingsForm.Instance.Show();
            SettingsForm.Instance.BringToFront();
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForms = true;

            TrainingEntryForm.Instance.Close();
            BiodataEntryForm.Instance.Close();
            TrainingLogForm.Instance.Close();
            StatisticsForm.Instance.Close();
            SettingsForm.Instance.Close();
        }

        private void ButExitClick(object sender = null, EventArgs e = null)
        {
            Close();
        }

        #endregion
    }
}
