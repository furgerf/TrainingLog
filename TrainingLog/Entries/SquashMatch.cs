using System;
using System.Xml.Serialization;

namespace TrainingLog.Entries
{
    [XmlType("SquashMatch")]
    public class SquashMatch : TrainingEntry
    {
        #region Public Fields

        [XmlIgnore]
        public TimeSpan? MatchTime { get; set; }

        [XmlElement("MatchTime")]
        public string MatchTimeString { get { return (MatchTime ?? TimeSpan.MinValue).ToString(); } set { MatchTime = TimeSpan.Parse(value); } }
        public bool MatchTimeStringSpecified { get { return MatchTime != null; } }

        [XmlElement("Opponent")]
        public string Opponent { get; set; }
        public bool OpponentSpecified { get { return Opponent != null; } }

        [XmlElement("Result")]
        public string Result { get; set; }

        [XmlElement("MatchAverageHr")]
        public int? MatchAverageHr { get; set; }
        public bool MatchAverageHrSpecified { get { return MatchAverageHr != null; } }

        [XmlElement("CompetitionName")]
        public string CompetitionName { get; set; }

        #endregion

        #region Constructor

        public SquashMatch(TimeSpan duration, string result, string competition) :
            base(duration, Common.Sport.Squash, Common.EntryType.Competition)
        {
            Result = result;
            CompetitionName = competition;
        }

        public SquashMatch()
        {
            // for XML
        }

        #endregion
    }
}
