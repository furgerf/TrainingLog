using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class SleepForm : Form
    {
        #region Public Fields

        public TextBox OriginalText { get; set; }
            
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                if (value.Equals(_duration))
                    return;
                _duration = value;

                numSleepDuration.Value = (decimal)_duration.TotalHours;
            }
        }

        public Common.Index Quality
        {
            get { return _quality; }
            set
            {
                if (value.Equals(_quality)) return;
                _quality = value;

                comSleepQuality.Text = _quality.ToString();
            }
        }

        #endregion

        #region Private Fields

        private TimeSpan _duration;
        
        private Common.Index _quality = Common.Index.None;

        #endregion

        #region Constructor

        public SleepForm()
        {
            InitializeComponent();

            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comSleepQuality.Items.Add(Enum.GetName(typeof(Common.Index), i));
        }

        #endregion

        #region Event Handling

        private void ButOkClick(object sender, EventArgs e)
        {
            OriginalText.Text = TimeSpan.FromHours((double)numSleepDuration.Value).ToString() + " (" + comSleepQuality.SelectedItem + ")";

            OriginalText.BackColor = TrainingLogForm.GetColor(((double)(int)Enum.Parse(typeof(Common.Index), comSleepQuality.Text) / ((int)Common.Index.Count - 1)), Color.Red, Color.Yellow, Color.Green);

            Close();
        }

        private void ButCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
