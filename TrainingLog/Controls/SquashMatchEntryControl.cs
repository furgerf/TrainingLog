using System;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Controls
{
    public partial class SquashMatchEntryControl : UserControl
    {
        public TimeSpan? ExactTime
        {
            get { return txtMatchTime.TimeSpan; }
        }

        public string Opponent
        {
            get { return comOpponent.Text; }
        }

        public string Result
        {
            get { return txtResult.Text; }
        }

        public int MatchAverageHr
        {
            get { return int.Parse(txtMatchAverageHr.Text); }
        }

        public string Competition
        {
            get { return comCompetition.Text; }
        }

        public SquashMatchEntryControl()
        {
            InitializeComponent();
        }

        public void UpdateComboBoxes()
        {
            comOpponent.Items.Clear();
            foreach (var s in Model.Instance.SquashMatchEntries.Where(e => e.OpponentSpecified))
                if (!comOpponent.Items.Contains(s.Opponent))
                    comOpponent.Items.Add(s.Opponent);
            
            comCompetition.Items.Clear();
            foreach (var s in Model.Instance.SquashMatchEntries)
                if (!comCompetition.Items.Contains(s.CompetitionName))
                    comCompetition.Items.Add(s.CompetitionName);
        }
    }
}
