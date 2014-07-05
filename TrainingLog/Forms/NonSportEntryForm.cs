using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class NonSportEntryForm : Form
    {
        #region Fields

        public static NonSportEntryForm Instance
        {
            get { return _instance ?? (_instance = new NonSportEntryForm()); }
        }

        private static NonSportEntryForm _instance;

        #endregion

        #region Constructor

        private NonSportEntryForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #endregion

        #region Event Handling

        private void NonSportEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.Instance.Show();
            MainForm.Instance.BringToFront();

            e.Cancel = !MainForm.Instance.CloseForms;
        }

        private void NonSportEntryFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        #endregion
    }
}
