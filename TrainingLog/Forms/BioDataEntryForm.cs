using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class BioDataEntryForm : Form
    {
        public static BioDataEntryForm GetInstance
        {
            get { return _instance ?? (_instance = new BioDataEntryForm()); }
        }

        private static BioDataEntryForm _instance;

        public BioDataEntryForm()
        {
            InitializeComponent();
        }

        private void BioDataEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

    }
}
