using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class SettingsForm : Form
    {
        public static SettingsForm GetInstance
        {
            get { return _instance ?? (_instance = new SettingsForm()); }
        }

        private static SettingsForm _instance;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }
    }
}
