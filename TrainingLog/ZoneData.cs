using System;
using System.Runtime.Serialization;

namespace TrainingLog
{
    [Serializable]
    public struct ZoneData : ISerializable
    {
        #region Public Fields

        public TimeSpan Zone5 { get { return _zones[4]; } }
        public TimeSpan Zone4 { get { return _zones[3]; } }
        public TimeSpan Zone3 { get { return _zones[2]; } }
        public TimeSpan Zone2 { get { return _zones[1]; } }
        public TimeSpan Zone1 { get { return _zones[0]; } }

        public TimeSpan Duration
        {
            get
            {
                return _zones[4].Add(_zones[3]).Add(_zones[2]).Add(_zones[1]).Add(_zones[0]);
            }
        }

        public bool IsEmpty
        {
            get { return _zones == null || Duration == TimeSpan.Zero; }
        }

        #endregion

        #region Private Fields

        private readonly TimeSpan[] _zones;

        #endregion

        #region Constructor

        private ZoneData(TimeSpan zone5, TimeSpan zone4, TimeSpan zone3, TimeSpan zone2, TimeSpan zone1)
        {
            _zones = new[] {zone1, zone2, zone3, zone4, zone5};
        }

        public ZoneData(SerializationInfo info, StreamingContext ctxt)
        {
            if (info.MemberCount > 0)
            _zones = new[]
                         {
                             TimeSpan.Parse(info.GetValue("zone1", typeof (TimeSpan)).ToString()),
                             TimeSpan.Parse(info.GetValue("zone2", typeof (TimeSpan)).ToString()),
                             TimeSpan.Parse(info.GetValue("zone3", typeof (TimeSpan)).ToString()),
                             TimeSpan.Parse(info.GetValue("zone4", typeof (TimeSpan)).ToString()),
                             TimeSpan.Parse(info.GetValue("zone5", typeof (TimeSpan)).ToString()),
                         };
            else 
                _zones = new TimeSpan[5];
        }

        #endregion

        #region Main Methods

        public static ZoneData Empty()
        {
            return new ZoneData(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (IsEmpty)
                return;
            info.AddValue("zone1", Zone1, typeof(TimeSpan));
            info.AddValue("zone2", Zone2, typeof(TimeSpan));
            info.AddValue("zone3", Zone3, typeof(TimeSpan));
            info.AddValue("zone4", Zone4, typeof(TimeSpan));
            info.AddValue("zone5", Zone5, typeof(TimeSpan));
        }

        private TimeSpan GetZone(int index)
        {
            return _zones[index - 1];
        }

        private double GetZoneSeconds(int index)
        {
            return GetZone(index).TotalSeconds;
        }

        public double GetZonePercentage(int index)
        {
            return GetZoneSeconds(index) / Duration.TotalSeconds;
        }

        public override string ToString()
        {
            return Zone5.ToString() + '_' + Zone4 + '_' + Zone3 + '_' + Zone2 + '_' + Zone1;
        }

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

        public void Normailze(TimeSpan duration)
        {
            var sum = Zone1.TotalSeconds + Zone2.TotalSeconds + Zone3.TotalSeconds + Zone4.TotalSeconds +
                      Zone5.TotalSeconds;

            var seconds = duration.TotalSeconds - sum;

            var perc2 = (int)(Zone2.TotalSeconds / sum * seconds);
            var perc3 = (int)(Zone3.TotalSeconds / sum * seconds);
            var perc4 = (int)(Zone4.TotalSeconds / sum * seconds);
            var perc5 = (int)(Zone5.TotalSeconds / sum * seconds);

            if (seconds > 0)
            {
                _zones[4] = Zone5.Add(TimeSpan.FromSeconds(perc5));
                _zones[3] = Zone4.Add(TimeSpan.FromSeconds(perc4));
                _zones[2] = Zone3.Add(TimeSpan.FromSeconds(perc3));
                _zones[1] = Zone2.Add(TimeSpan.FromSeconds(perc2));
                _zones[0] = Zone1.Add(TimeSpan.FromSeconds(seconds - perc5 - perc4 - perc3 - perc2));
            }
            else if (seconds < 0)
            {
                _zones[4] = Zone5.Subtract(TimeSpan.FromSeconds(-perc5));
                _zones[3] = Zone4.Subtract(TimeSpan.FromSeconds(-perc4));
                _zones[2] = Zone3.Subtract(TimeSpan.FromSeconds(-perc3));
                _zones[1] = Zone2.Subtract(TimeSpan.FromSeconds(-perc2));
                _zones[0] = Zone1.Subtract(TimeSpan.FromSeconds(-seconds - perc5 - perc4 - perc3 - perc2));
            }
        }

        #endregion
    }
}
