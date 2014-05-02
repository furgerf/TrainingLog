using System;
using System.Text;
using System.Windows.Forms;

namespace TrainingLog
{
    public class TrainingEntry : Entry
    {
        public struct ZoneData
        {
            public TimeSpan Zone5;
            public TimeSpan Zone4;
            public TimeSpan Zone3;
            public TimeSpan Zone2;
            public TimeSpan Zone1;

            public override string ToString()
            {
                return Zone5.ToString() + '_' + Zone4 + '_' + Zone3 + '_' + Zone2 + '_' + Zone1;
            }

            public bool IsEmpty { get { return GetDuration() == TimeSpan.Zero; } }

            public static bool TryParse(string s, out ZoneData result)
            {
                result = new ZoneData();

                var split = s.Split('_');
                if (split.Length != 5)
                    return false;

                try
                {
                    result = new ZoneData(TimeSpan.Parse(split[0]), TimeSpan.Parse(split[1]), TimeSpan.Parse(split[2]),
                                          TimeSpan.Parse(split[3]), TimeSpan.Parse(split[4]));
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            public TimeSpan GetDuration()
            {
                return Zone5.Add(Zone4.Add(Zone3.Add(Zone2.Add(Zone1))));
            }


            private ZoneData(TimeSpan zone5, TimeSpan zone4, TimeSpan zone3, TimeSpan zone2, TimeSpan zone1)
            {
                Zone5 = zone5;
                Zone4 = zone4;
                Zone3 = zone3;
                Zone2 = zone2;
                Zone1 = zone1;
            }
        }

        #region Public Fields

        public TimeSpan Duration { get; set; }

        public double DistanceKm { get { return _distanceM / 1000.0; } set { _distanceM = (int)(1000*value); } }

        public int DistanceM { get { return _distanceM; } set { _distanceM = value; } }

        public TimeSpan Pace { get { return new TimeSpan(0, (int)(Duration.TotalMinutes / DistanceKm), 0); } }

        public double Speed { get { return DistanceKm/Duration.TotalHours; } }

        public SweatData SweatData { get { return _sweatData; } set { _sweatData = value; _sweatData.TrainingEntry = this; } }

        public Utils.Sport Sport { get; set; }

        public Enum TrainingType { get; set; }

        public int Calories { get; set; }

        public int AverageHr { get; set; }

        public ZoneData ZoneTime { get; set; }

        #endregion

        #region Private Fields

        private int _distanceM;

        private SweatData _sweatData;

        #endregion

        #region Constructor

        private TrainingEntry() : base("TrainingEntry")
        {
        }

        public TrainingEntry(TimeSpan duration) : base("TrainingEntry")
        {
            Duration = duration;
        }

        protected TrainingEntry(TimeSpan duration, Utils.Sport sport, String entryName) : base(entryName)
        {
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
                        Utils.Sport foo;
                        if (!Enum.TryParse(value, out foo))
                            throw new Exception();
                        Sport = foo;
                        return true;
                    case "TrainingType":
                        Utils.EnduranceType end;
                        if (Enum.TryParse(value, out end))
                        {
                            TrainingType = end;
                            return true;
                        }
                        Utils.SquashType squ;
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
                        Utils.Index bar;
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

        public override Entry TryParse(string data)
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
                sb.Append(AttributeSeparator + "Duration" + AttributeDividor + Duration);
                sb.Append(AttributeSeparator + "Sport" + AttributeDividor + Sport);

                if (TrainingType != null)
                    sb.Append(AttributeSeparator + "TrainingType" + AttributeDividor + TrainingType);
                
                if (DistanceM != 0)
                    sb.Append(AttributeSeparator + "DistanceM" + AttributeDividor + DistanceM);
                if (Calories != 0)
                    sb.Append(AttributeSeparator + "Calories" + AttributeDividor + Calories);
                if (AverageHr != 0)
                    sb.Append(AttributeSeparator + "AverageHr" + AttributeDividor + AverageHr);
                  if (!ZoneTime.IsEmpty)
                      sb.Append(AttributeSeparator + "ZoneTime" + AttributeDividor + AverageHr);
                // TODO: Save SweatData

                if (Note != "")
                    sb.Append(AttributeSeparator + "Note" + AttributeDividor + Note);

                sb.Append(AttributeSeparator + "DateTime" + AttributeDividor + DateTime);

                if (Feeling != Utils.Index.None)
                    sb.Append(AttributeSeparator + "Feeling" + AttributeDividor + Feeling);

                return sb.ToString();
            }
        }

        #endregion
    }
}
