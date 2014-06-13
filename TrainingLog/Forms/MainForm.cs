using System;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class MainForm : Form
    {
        #region Public Fields

        public static MainForm GetInstance { get; private set; }

        public bool CloseForms { get; private set; }

        public Settings Settings { get; private set; }

        #endregion

        #region Constructor

        public MainForm()
        {
            if (GetInstance != null)
                throw new Exception("Shouldn\'t have been initialized before!");

            InitializeComponent();

            GetInstance = this;

            Settings = Settings.LoadSettings();

            Model.Initialize();

            ButShowStatisticsClick();
            //ButShowLogClick();
            //ButSettingsClick();
        }

        #endregion

        #region Event Handling

        private void ButAddTrainingClick(object sender = null, EventArgs e = null)
        {
            Hide();
            TrainingEntryForm.GetInstance.Show();
            TrainingEntryForm.GetInstance.BringToFront();
        }

        private void ButAddBiodataClick(object sender = null, EventArgs e = null)
        {
            Hide();
            BiodataEntryForm.GetInstance.Show();
            BiodataEntryForm.GetInstance.BringToFront();
        }

        private void ButShowLogClick(object sender = null, EventArgs e = null)
        {
            Hide();
            TrainingLogForm.GetInstance.UpdateData();
            TrainingLogForm.GetInstance.Show();
            TrainingLogForm.GetInstance.BringToFront();
        }

        private void ButShowStatisticsClick(object sender = null, EventArgs e = null)
        {
            Hide();
            StatisticsForm.GetInstance.UpdateData();
            StatisticsForm.GetInstance.Show();
            StatisticsForm.GetInstance.BringToFront();
        }

        private void ButSettingsClick(object sender = null, EventArgs e = null)
        {
            Hide();
            SettingsForm.GetInstance.Show();
            SettingsForm.GetInstance.BringToFront();
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForms = true;

            TrainingEntryForm.GetInstance.Close();
            BiodataEntryForm.GetInstance.Close();
            TrainingLogForm.GetInstance.Close();
            StatisticsForm.GetInstance.Close();
            SettingsForm.GetInstance.Close();
        }

        private void ButExitClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
