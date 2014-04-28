using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class TrainingEntryForm : Form
    {
        public static TrainingEntryForm GetInstance { 
            get { return _instance ?? (_instance = new TrainingEntryForm()); }
        }

        private static TrainingEntryForm _instance;

        public TrainingEntryForm()
        {
            InitializeComponent();
        }

        private void TrainingEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }
    }
}
