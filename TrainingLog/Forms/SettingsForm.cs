using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TrainingLog.Entries;

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

            txtTrainingPath.Text = _settings.TrainingPath;
            txtBiodataPath.Text = _settings.BiodataPath;
            txtNonsportPath.Text = _settings.NonSportPath;
            txtEquipmentPath.Text = _settings.EquipmentPath;
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

        private void ButChangeTrainingPathClick(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
                        {
                            Filter = "XML File (*.xml)|*.xml",
                            InitialDirectory = new FileInfo(_settings.TrainingPath).DirectoryName,
                            Multiselect = false
                        };
            if (f.ShowDialog() != DialogResult.OK) return;

            _settings.TrainingPath = f.FileName;
            txtTrainingPath.Text = f.FileName;
        }

        private void butChangeBiodataPath_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
            {
                Filter = "XML File (*.xml)|*.xml",
                InitialDirectory = new FileInfo(_settings.BiodataPath).DirectoryName,
                Multiselect = false
            };
            if (f.ShowDialog() != DialogResult.OK) return;

            _settings.BiodataPath = f.FileName;
            txtBiodataPath.Text = f.FileName;
        }

        private void butChangeNonSportPath_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
            {
                Filter = "XML File (*.xml)|*.xml",
                InitialDirectory = new FileInfo(_settings.NonSportPath).DirectoryName,
                Multiselect = false
            };
            if (f.ShowDialog() != DialogResult.OK) return;

            _settings.NonSportPath = f.FileName;
            txtNonsportPath.Text = f.FileName;
        }

        private void butChangeEquipmentPath_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog
            {
                Filter = "XML File (*.xml)|*.xml",
                InitialDirectory = new FileInfo(_settings.EquipmentPath).DirectoryName,
                Multiselect = false
            };
            if (f.ShowDialog() != DialogResult.OK) return;

            _settings.EquipmentPath = f.FileName;
            txtEquipmentPath.Text = f.FileName;
        }

        private void ButOpenTrainingLogClick(object sender, EventArgs e)
        {
            Process.Start(_settings.TrainingPath);
        }

        private void butOpenBiodataLog_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.BiodataPath);
        }

        private void butOpenNonSportLog_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.NonSportPath);
        }

        private void butOpenEquipmentLog_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.EquipmentPath);
        }


        private void ButBackupClick(object sender, EventArgs e)
        {
            Model.Instance.WriteEntries(typeof(TrainingEntry), new FileInfo(_settings.TrainingPath).DirectoryName + "\\backup\\training_" + DateTime.Today.ToString("yyyy_MM_dd") + ".xml");
            Model.Instance.WriteEntries(typeof(BiodataEntry), new FileInfo(_settings.BiodataPath).DirectoryName + "\\backup\\biodata_" + DateTime.Today.ToString("yyyy_MM_dd") + ".xml");
            Model.Instance.WriteEntries(typeof(NonSportEntry), new FileInfo(_settings.NonSportPath).DirectoryName + "\\backup\\nonsport_" + DateTime.Today.ToString("yyyy_MM_dd") + ".xml");
            Model.Instance.WriteEntries(typeof(Equipment), new FileInfo(_settings.EquipmentPath).DirectoryName + "\\backup\\equipment_" + DateTime.Today.ToString("yyyy_MM_dd") + ".xml");
            MessageBox.Show("Backup created successfully!", "Backup created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButOpenFolderClick(object sender, EventArgs e)
        {
            Process.Start(new FileInfo(_settings.TrainingPath).DirectoryName ?? "C:\\");
        }

        #endregion
    }
}
