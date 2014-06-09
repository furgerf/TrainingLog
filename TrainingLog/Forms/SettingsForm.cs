using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class SettingsForm : Form
    {
        #region Static Access

        public static SettingsForm GetInstance
        {
            get { return _instance ?? (_instance = new SettingsForm()); }
        }

        private static SettingsForm _instance;

        #endregion

        private Settings _settings { get { return MainForm.GetInstance.Settings; } }

        #region Constructor

        public SettingsForm()
        {
            InitializeComponent();

            txtLogPath.Text = _settings.DataPath;
        }

        #endregion

        #region Event Handling

        private void SettingsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void SettingsFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void ButExitClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ButChangeLogPathClick(object sender, System.EventArgs e)
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

        private void ButOpenLogClick(object sender, System.EventArgs e)
        {
            Process.Start(_settings.DataPath);
        }

        #endregion
    }
}
