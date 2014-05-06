using System;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class TrainingLogForm : Form
    {
        public static TrainingLogForm GetInstance
        {
            get { return _instance ?? (_instance = new TrainingLogForm()); }
        }

        private static TrainingLogForm _instance;

        public TrainingLogForm()
        {
            InitializeComponent();
            entryListControl1.SetColumnsHeaders(new []{ "Date", "Sport", "Type", "Duration", "Calories", "Avg. HR", "Zone Data", "Distance", "Feeling", "Notes" });

            foreach(var entry in Model.Instance.TrainingEntries)
            {
                entryListControl1.AddEntry(new string[]
                                               {
                                                   entry.DateTime.ToShortDateString(), Enum.GetName(typeof (Common.Sport), entry.Sport),
                                                   Enum.GetName(typeof (Common.TrainingType), entry.TrainingType),
                                                   entry.Duration.ToString()
                                               });
            }
        }

        private void TrainingLogFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void TrainingLogFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
