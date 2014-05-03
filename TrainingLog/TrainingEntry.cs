using System;
using System.Text;
using System.Windows.Forms;

namespace TrainingLog
{
    public class TrainingEntry : Entry
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

        public int Calories { get; set; }

        public int AverageHr { get; set; }

        public ZoneData ZoneTime { get; set; }

        public ZoneData ZoneData { get { return _zoneData; } }

        #endregion

        #region Private Fields

        private int _distanceM;

        private SweatData _sweatData;

        private readonly ZoneData _zoneData;

        #endregion

        #region Constructor

        private TrainingEntry() : base(Common.EntryType.Training)
        {
            _zoneData = new ZoneData();
        }

        public TrainingEntry(TimeSpan duration) : base(Common.EntryType.Training)
        {
            _zoneData = new ZoneData();
            Duration = duration;
        }

        protected TrainingEntry(TimeSpan duration, Common.Sport sport, Common.EntryType entryType) : base(entryType)
        {
            _zoneData = new ZoneData();
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
                    case "ZoneTime":
                        ZoneData zd;
                        var b = ZoneData.TryParse(value, out zd);
                        if (b)
                            ZoneTime = zd;
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
            var attributes = data.Split(AttributeSeparator);

            if (attributes.Length <= 1)
                return null;

            var entry = new TrainingEntry();

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
                if (!ZoneTime.IsEmpty)
                    sb.Append(AttributeSeparator + "ZoneTime" + AttributeDividor + ZoneTime);
                // TODO: Save SweatData

                if (Note != "")
                    sb.Append(AttributeSeparator + "Note" + AttributeDividor + Note);
                if (Feeling != Common.Index.None)
                    sb.Append(AttributeSeparator + "Feeling" + AttributeDividor + Feeling);

                return sb.ToString();
            }
        }

        #endregion
    }
}
