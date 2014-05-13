using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace TrainingLog
{
    [Serializable]
    public class TrainingEntry : Entry, ISerializable
    {
        #region Public Fields

        public TimeSpan Duration { get; set; }

        public double DistanceKm { get { return _distanceM / 1000.0; } set { _distanceM = (int)(1000*value); } }

        public int DistanceM { get { return _distanceM; } set { _distanceM = value; } }

        public TimeSpan Pace { get { return new TimeSpan(0, (int)(Duration.TotalMinutes / DistanceKm), 0); } }

        public double Speed { get { return DistanceKm/Duration.TotalHours; } }

        public SweatData SweatData { get { return _sweatData; } set { _sweatData = value; _sweatData.TrainingEntry = this; } }

        public Common.Sport Sport { get; set; }

        public Enum TrainingType { get; set; }

        public bool HasTrainingType { get { return TrainingType.ToString().Equals(Common.TrainingType.None.ToString()); } }

        public int Calories { get; set; }

        public int AverageHr { get; set; }

        public ZoneData ZoneData { get; set; }

        #endregion

        #region Private Fields

        private const string NoteKey = "note";
        private const string DateKey = "date";
        private const string FeelingKey = "feeling";
        private const string DurationKey = "duration";
        private const string DistanceKey = "distance";
        private const string SportKey = "sport";
        private const string TrainingTypeKey = "trainingtype";
        private const string CaloriesKey = "calories";
        private const string AverageHrKey = "averagehr";
        private const string ZoneDataKey = "zonedata";

        private int _distanceM;

        private SweatData _sweatData;

        #endregion

        #region Constructor

        private TrainingEntry() : base(Common.EntryType.Training)
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

        public TrainingEntry(SerializationInfo info, StreamingContext ctxt) : base(Common.EntryType.Training)
        {
            Note = info.GetValue(NoteKey, typeof (string)).ToString();
            DateTime = DateTime.Parse(info.GetValue(DateKey, typeof (DateTime)).ToString());
            Feeling = (Common.Index) info.GetValue(FeelingKey, typeof (Common.Index));
		    Duration = TimeSpan.Parse(info.GetValue(DurationKey, typeof(TimeSpan)).ToString());
            DistanceM = info.GetInt32(DistanceKey);
            Sport = (Common.Sport) info.GetValue(SportKey, typeof (Common.Sport));
            TrainingType = (Common.TrainingType) info.GetValue(TrainingTypeKey, typeof (Common.TrainingType));
            Calories = info.GetInt32(CaloriesKey);
            AverageHr = info.GetInt32(AverageHrKey);

            ZoneData zd;
            ZoneData.TryParse(info.GetValue(ZoneDataKey, typeof (ZoneData)).ToString(), out zd);
            ZoneData = zd;
        }

        #endregion

        #region Main Methods

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(NoteKey, Note);
            info.AddValue(DateKey, DateTime);
            info.AddValue(FeelingKey, Feeling);
            info.AddValue(DurationKey, Duration);
            info.AddValue(DistanceKey, DistanceM);
            info.AddValue(SportKey, Sport);
            info.AddValue(TrainingTypeKey, TrainingType);
            info.AddValue(CaloriesKey, Calories);
            info.AddValue(AverageHrKey, AverageHr);
            info.AddValue(ZoneDataKey, ZoneData);
        }

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
                        Common.EnduranceType end;
                        if (Enum.TryParse(value, out end))
                        {
                            TrainingType = end;
                            return true;
                        }
                        Common.SquashType squ;
                        if (Enum.TryParse(value, out squ))
                        {
                            TrainingType = squ;
                            return true;
                        }
                        Common.TrainingType tra;
                        if (Enum.TryParse(value, out tra))
                        {
                            TrainingType = tra;
                            return true;
                        }
                        return false;
                    case "DistanceM":
                        DistanceM = int.Parse(value);
                        return true;
                    case "Calories":
                        Calories = int.Parse(value);
                        return true;
                    case "AverageHr":
                        AverageHr = int.Parse(value);
                        return true;
                    case "ZoneData":
                        ZoneData zd;
                        var b = ZoneData.TryParse(value, out zd);
                        if (b)
                            ZoneData = zd;
                        return b;
                    case "Note":
                        Note = value;
                        return true;
                    case "DateTime":
                        DateTime = DateTime.Parse(value);
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
            if (!data.Contains("DateTime" + AttributeDividor) || !data.Contains("Sport" + AttributeDividor) ||
                !data.Contains("Duration" + AttributeDividor) || !data.Contains("TrainingType" + AttributeDividor))
            {
                MessageBox.Show(
                    "Error while parsing training entry: One or more required attribute (DateTime, Sport, TrainingType, Duration) was not found!",
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
                sb.Append(AttributeSeparator + "DateTime" + AttributeDividor + DateTime);
                sb.Append(AttributeSeparator + "TrainingType" + AttributeDividor + TrainingType);

                // optional fields
                if (DistanceM != 0)
                    sb.Append(AttributeSeparator + "DistanceM" + AttributeDividor + DistanceM);
                if (Calories != 0)
                    sb.Append(AttributeSeparator + "Calories" + AttributeDividor + Calories);
                if (AverageHr != 0)
                    sb.Append(AttributeSeparator + "AverageHr" + AttributeDividor + AverageHr);
                if (!ZoneData.IsEmpty)
                    sb.Append(AttributeSeparator + "ZoneData" + AttributeDividor + ZoneData);
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
