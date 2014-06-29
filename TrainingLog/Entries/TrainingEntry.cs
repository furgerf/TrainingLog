using System;
using System.Xml.Serialization;

namespace TrainingLog.Entries
{
    [XmlType("TrainingEntry")]
    public class TrainingEntry : Entry
    {
        #region Public Fields

        [XmlIgnore]
        public TimeSpan? Duration { get; set; }

        [XmlElement("Duration")]
        public string DurationString { get { return (Duration ?? TimeSpan.MinValue).ToString(); } set { Duration = TimeSpan.Parse(value); } }
        public bool DurationStringSpecified { get { return Duration != null; } }

        [XmlIgnore]
        public double DistanceKm { get { return (DistanceM ?? 0) / 1000.0; } set { DistanceM = (int)(1000 * value); } }

        [XmlElement("Distance")]
        public int? DistanceM { get; set; }
        public bool DistanceMSpecified { get { return DistanceM != null && DistanceM != 0; } }

        [XmlIgnore]
        public TimeSpan Pace { get { return TimeSpan.FromSeconds((Duration ?? TimeSpan.MinValue).TotalSeconds/DistanceKm); } }

        [XmlIgnore]
        public double Speed { get { return DistanceKm / (Duration ?? TimeSpan.MinValue).TotalHours; } }

        [XmlElement("Sport")]
        public Common.Sport? Sport { get; set; }
        public bool SportSpecified { get { return Sport != null; } }

        [XmlElement("TrainingType")]
        public Common.TrainingType TrainingType
        {
            get { return _trainingType; }
            set
            {
                if (value == _trainingType) return;
                if (Sport == Common.Sport.Squash && !Array.Exists(Common.SquashTypes, e => e == value))
                    throw new Exception("Invalid training type");
                if (Array.Exists(Common.EnduranceSports, e => e == Sport) && !Array.Exists(Common.EnduranceTypes, e => e == value))
                    throw new Exception("Invalid training type");

                _trainingType = value;
            }
        }
        public bool TrainingTypeSpecified { get { return !TrainingType.Equals(Common.TrainingType.None); } }

        [XmlElement("Calories")]
        public int? Calories { get; set; }
        public bool CaloriesSpecified { get { return Calories != null && Calories != 0; } }

        [XmlElement("AverageHR")]
        public int? AverageHr { get; set; }
        public bool AverageHrSpecified { get { return AverageHr != null && AverageHr != 0; } }

        [XmlIgnore]
        public ZoneData? HrZones { get; set; }

        [XmlElement("HrZones")]
        public string HrZoneString
        {
            get { return HrZoneStringSpecified ? HrZones.ToString() : ""; }
            set
            {
                ZoneData zd;
                if (!ZoneData.TryParse(value, out zd))
                    throw new Exception();
                HrZones = zd;
            }
        }

        public bool HrZoneStringSpecified { get { return !(HrZones ?? ZoneData.Empty()).IsEmpty; } }

        #endregion

        #region Private Fields

        [XmlIgnore]
        private Common.TrainingType _trainingType;

        #endregion

        #region Constructor

        public TrainingEntry()
            : base(Common.EntryType.Training)
        {

        }

        public TrainingEntry(TimeSpan duration)
            : base(Common.EntryType.Training)
        {
            Duration = duration;
        }

        protected TrainingEntry(TimeSpan duration, Common.Sport sport, Common.EntryType entryType)
            : base(entryType)
        {
            // constructor for RaceEntry
            Duration = duration;
            Sport = sport;
        }

        #endregion

        #region Main Methods

        #endregion
    }
}
