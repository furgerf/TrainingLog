using System;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TrainingLog
{
    [XmlType("TrainingEntry")]
    public class TrainingEntry : Entry
    {
        #region Public Fields

        [XmlIgnore]
        public TimeSpan? Duration { get; set; }
        
        [XmlElement("Duration")]
        public string DurationString { get { return (Duration ?? TimeSpan.Zero).ToString(); } set { Duration = TimeSpan.Parse(value); } }
        public bool DurationStringSpecified { get { return Duration != null; } }

        [XmlIgnore]
        public double DistanceKm { get { return (DistanceM ?? 0) / 1000.0; } set { DistanceM = (int)(1000 * value); } }

        [XmlElement("Distance")]
        public int? DistanceM { get; set; }
        public bool DistanceMSpecified { get { return DistanceM != null; } }

        [XmlIgnore]
        public TimeSpan Pace { get { return new TimeSpan(0, (int)((Duration ?? TimeSpan.Zero).TotalMinutes / DistanceKm), 0); } }

        [XmlIgnore]
        public double Speed { get { return DistanceKm/(Duration ?? TimeSpan.Zero).TotalHours; } }

        [XmlIgnore]
        public SweatData SweatData { get { return _sweatData; } set { _sweatData = value; _sweatData.TrainingEntry = this; } }

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
        public bool CaloriesSpecified { get { return Calories != null; } }

        [XmlElement("AverageHR")]
        public int? AverageHr { get; set; }
        public bool AverageHrSpecified { get { return AverageHr != null; } }

        [XmlIgnore]
        public ZoneData? HrZones { get; set; }

        [XmlElement("HrZones")]
        public string HrZoneString
        {
            get { return HrZones.ToString(); }
            set
            {
                ZoneData zd;
                if (!ZoneData.TryParse(value, out zd))
                    throw new Exception();
                HrZones = zd;
            }
        }

        public bool HrZoneStringSpecified { get { return HrZones != null; } }
        
        #endregion

        #region Private Fields

        [XmlIgnore]
        private Common.TrainingType _trainingType;

        [XmlIgnore]
        private SweatData _sweatData;

        #endregion

        #region Constructor

        public TrainingEntry() : base(Common.EntryType.Training)
        {
            // private constructor for parsing (when duration is not yet parsed)
        }

        public TrainingEntry(TimeSpan duration) : base(Common.EntryType.Training)
        {
            Duration = duration;
        }

        protected TrainingEntry(TimeSpan duration, Common.Sport sport, Common.EntryType entryType) : base(entryType)
        {
            // constructor for RaceEntry
            Duration = duration;
            Sport = sport;
        }

        #endregion

        #region Main Methods

        private bool SetAttribute(string attribute, string value)
        {
            try
            {
                switch (attribute)
                {
                    case "Duration":
                        Duration = TimeSpan.Parse(value);
                        return true;
                    case "Sport":
                        Common.Sport foo;
                        if (!Enum.TryParse(value, out foo))
                            throw new Exception();
                        Sport = foo;
                        return true;
                    case "TrainingType":
                        Common.TrainingType end;
                        if (!Enum.TryParse(value, out end))
                            throw new Exception();
                        TrainingType = end;
                        return true;
                    case "DistanceM":
                        DistanceM = int.Parse(value);
                        return true;
                    case "Calories":
                        Calories = int.Parse(value);
                        return true;
                    case "AverageHr":
                        AverageHr = int.Parse(value);
                        return true;
                    case "HrZones":
                        ZoneData zd;
                        var b = ZoneData.TryParse(value, out zd);
                        if (b)
                            HrZones = zd;
                        return b;
                    case "Note":
                        Note = value;
                        return true;
                    case "Date":
                        Date = DateTime.Parse(value);
                        return true;
                    case "Feeling":
                        Common.Index bar;
                        if (!Enum.TryParse(value, out bar))
                            throw new Exception();
                        Feeling = bar;
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TrainingEntry ParseTrainingEntry (string data)
        {
            if (!data.Contains("Date" + AttributeDividor) || !data.Contains("Sport" + AttributeDividor) ||
                !data.Contains("Duration" + AttributeDividor) || !data.Contains("TrainingType" + AttributeDividor))
            {
                MessageBox.Show(
                    "Error while parsing training entry: One or more required attribute (Date, Sport, TrainingType, Duration) was not found!",
                    "Parsing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var attributes = data.Split(AttributeSeparator);

            var entry = new TrainingEntry
                            {
                                Note = "",
                                Feeling = Common.Index.None
                            };

            for (var i = 1; i < attributes.Length; i++)
            {
                var pair = attributes[i].Split(AttributeDividor);

                if (entry.SetAttribute(pair[0], pair[1])) continue;

                MessageBox.Show("Error while parsing \"" + attributes[i] + "\".", "Parsing error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return entry;
        }

        public override string LogString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(EntryName);

                // mandatory fields
                sb.Append(AttributeSeparator + "Duration" + AttributeDividor + Duration);
                sb.Append(AttributeSeparator + "Sport" + AttributeDividor + Sport);
                sb.Append(AttributeSeparator + "Date" + AttributeDividor + Date);
                sb.Append(AttributeSeparator + "TrainingType" + AttributeDividor + TrainingType);

                // optional fields
                if (DistanceM != 0)
                    sb.Append(AttributeSeparator + "DistanceM" + AttributeDividor + DistanceM);
                if (Calories != 0)
                    sb.Append(AttributeSeparator + "Calories" + AttributeDividor + Calories);
                if (AverageHr != 0)
                    sb.Append(AttributeSeparator + "AverageHr" + AttributeDividor + AverageHr);
                if (HrZones != null)
                    sb.Append(AttributeSeparator + "HrZones" + AttributeDividor + HrZones);
                if (Note != "")
                    sb.Append(AttributeSeparator + "Note" + AttributeDividor + Note);
                if (Feeling != Common.Index.None)
                    sb.Append(AttributeSeparator + "Feeling" + AttributeDividor + Feeling);
                // TODO: Save SweatData
                
                return sb.ToString();
            }
        }

        #endregion
    }
}
