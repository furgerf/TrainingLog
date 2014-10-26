using System;
using System.Xml.Serialization;

namespace TrainingLog.Entries
{
    [XmlType("RunningRace")]
    public class RunningRace : TrainingEntry
    {
        #region Public Fields

        [XmlIgnore]
        public TimeSpan? ExactTime { get; set; }

        [XmlElement("ExactTime")]
        public string ExactTimeString { get { return (ExactTime ?? TimeSpan.MinValue).ToString(); } set { ExactTime = TimeSpan.Parse(value); } }
        public bool ExactTimeStringSpecified { get { return ExactTime != null; } }

        [XmlElement("ExactDistance")]
        public double ExactDistanceM { get; set; }

        [XmlElement("RaceAverageHr")]
        public int? RaceAverageHr { get; set; }
        public bool RaceAverageHrSpecified { get { return RaceAverageHr != null; } }

        [XmlElement("OverallRank")]
        public int? OverallRank { get; set; }
        public bool OverallRankSpecified { get { return OverallRank != null; } }

        [XmlElement("AgeGroupRank")]
        public int? AgeGroupRank { get; set; }
        public bool AgeGroupRankSpecified { get { return AgeGroupRank != null; } }

        [XmlElement("CompetitionName")]
        public string CompetitionName { get; set; }

        #endregion

        #region Constructor

        public RunningRace(TimeSpan duration, TimeSpan exactTime, double exactDistanceM, string competitionName)
            : base(duration, Common.Sport.Running, Common.EntryType.Competition)
        {
            ExactTime = exactTime;
            ExactDistanceM = exactDistanceM;
            CompetitionName = competitionName;
        }

        public RunningRace()
        {
            // for XML
        }

        #endregion
    }
}
