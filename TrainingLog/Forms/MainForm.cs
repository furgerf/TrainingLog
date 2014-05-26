using System;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class MainForm : Form
    {
        #region Public Fields

        public static MainForm GetInstance { get; private set; }

        public bool CloseForms { get; private set; }

        #endregion

        #region Constructor

        public MainForm()
        {
            if (GetInstance != null)
                throw new Exception("Shouldn\'t have been initialized before!");

            InitializeComponent();

            GetInstance = this;
        }

        #endregion

        #region Event Handling

        private void ButAddTrainingClick(object sender, EventArgs e)
        {
            Hide();
            TrainingEntryForm.GetInstance.Show();
            TrainingEntryForm.GetInstance.BringToFront();
        }

        private void ButAddBiodataClick(object sender, EventArgs e)
        {
            Hide();
            BiodataEntryForm.GetInstance.Show();
            BiodataEntryForm.GetInstance.BringToFront();
        }

        private void ButShowLogClick(object sender, EventArgs e)
        {
            Hide();
            TrainingLogForm.GetInstance.Show();
            TrainingLogForm.GetInstance.BringToFront();
        }

        private void ButShowStatisticsClick(object sender, EventArgs e)
        {
            Hide();
            StatisticsForm.GetInstance.UpdateData();
            StatisticsForm.GetInstance.Show();
            StatisticsForm.GetInstance.BringToFront();
        }

        private void ButSettingsClick(object sender, EventArgs e)
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
