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

        #region Constructor

        public SettingsForm()
        {
            InitializeComponent();
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

        #endregion
    }
}
