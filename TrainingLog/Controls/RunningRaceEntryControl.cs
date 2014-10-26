using System;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Controls
{
    public partial class RunningRaceEntryControl : UserControl
    {
        public TimeSpan? ExactTime
        {
            get { return txtExactTime.TimeSpan; }
        }

        public decimal? ExactDistanceKm
        {
            get { return txtExactDistanceKm.Decimal; }
        }

        public int? RaceAverageHr
        {
            get { return txtRaceAverageHr.Integer; }
        }

        public int OverallRank
        {
            get { return (int) numOverallRank.Value; }
        }

        public int AgeGroupRank
        {
            get { return (int) numAgeGroupRank.Value; }
        }

        public string Competition
        {
            get { return comCompetition.Text; }
        }

        public RunningRaceEntryControl()
        {
            InitializeComponent();
        }

        public void UpdateComboBoxes()
        {
            comCompetition.Items.Clear();
            foreach (var s in Model.Instance.RunningRaceEntries)
                if (!comCompetition.Items.Contains(s.CompetitionName))
                    comCompetition.Items.Add(s.CompetitionName);
        }
    }
}
