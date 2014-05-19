using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class StatisticsForm : Form
    {
        #region Static Access

        public static StatisticsForm GetInstance
        {
            get { return _instance ?? (_instance = new StatisticsForm()); }
        }

        private static StatisticsForm _instance;

        #endregion

        #region Constructor

        public StatisticsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handling

        private void StatisticsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void StatisticsFormKeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        #endregion
    }
}
