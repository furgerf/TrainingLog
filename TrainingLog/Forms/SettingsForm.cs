using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class SettingsForm : Form
    {
        #region Static Access

        public static SettingsForm Instance
        {
            get { return _instance ?? (_instance = new SettingsForm()); }
        }

        private static SettingsForm _instance;

        #endregion

        private Settings _settings { get { return MainForm.Instance.Settings; } }

        #region Constructor

        private SettingsForm()
        {
            InitializeComponent();

            txtLogPath.Text = _settings.DataPath;
        }

        #endregion

        #region Event Handling

        private void SettingsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.Instance.Show();
            MainForm.Instance.BringToFront();

            e.Cancel = !MainForm.Instance.CloseForms;
        }

        private void SettingsFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void ButExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButChangeLogPathClick(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
                        {
                            Filter = "XML File (*.xml)|*.xml",
                            InitialDirectory = new FileInfo(_settings.DataPath).DirectoryName,
                            Multiselect = false
                        };
            if (f.ShowDialog() != DialogResult.OK) return;
            
            _settings.DataPath = f.FileName;
            txtLogPath.Text = f.FileName;
        }

        private void ButOpenLogClick(object sender, EventArgs e)
        {
            Process.Start(_settings.DataPath);
        }

        private void ButBackupClick(object sender, EventArgs e)
        {
            Model.Instance.WriteEntries(new FileInfo(_settings.DataPath).DirectoryName + "\\backup\\log_" + DateTime.Today.ToString("yyyy_MM_dd") + ".xml");
            MessageBox.Show("Backup created successfully!", "Backup created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButOpenFolderClick(object sender, EventArgs e)
        {
            Process.Start(new FileInfo(_settings.DataPath).DirectoryName ?? "C:\\");
        }

        #endregion
    }
}
