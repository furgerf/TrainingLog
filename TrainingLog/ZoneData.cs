using System;
using System.Windows.Forms;

namespace TrainingLog
{
    public struct ZoneData
    {
        #region Public Fields

        public TimeSpan Zone5 { get { return Zones[4]; } }
        public TimeSpan Zone4 { get { return Zones[3]; } }
        public TimeSpan Zone3 { get { return Zones[2]; } }
        public TimeSpan Zone2 { get { return Zones[1]; } }
        public TimeSpan Zone1 { get { return Zones[0]; } }

        public TimeSpan Duration
        {
            get
            {
                return Zones[4].Add(Zones[3]).Add(Zones[2]).Add(Zones[1]).Add(Zones[0]);
            }
        }

        public bool IsEmpty
        {
            get { return Zones == null || Duration == TimeSpan.Zero; }
        }

        #endregion

        #region Private Fields

        public readonly TimeSpan[] Zones;

        #endregion

        #region Constructor

        private ZoneData(TimeSpan zone5, TimeSpan zone4, TimeSpan zone3, TimeSpan zone2, TimeSpan zone1)
        {
            Zones = new[] {zone1, zone2, zone3, zone4, zone5};
        }

        #endregion

        #region Main Methods

        public static ZoneData Empty()
        {
            return new ZoneData(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);
        }

        private TimeSpan GetZone(int index)
        {
            return Zones[index - 1];
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
            MessageBox.Show("Should fix normalizing (last zone is messed up)");
            var sum = Zone1.TotalSeconds + Zone2.TotalSeconds + Zone3.TotalSeconds + Zone4.TotalSeconds +
                      Zone5.TotalSeconds;

            var seconds = duration.TotalSeconds - sum;

            var perc2 = (int)(Zone2.TotalSeconds / sum * seconds);
            var perc3 = (int)(Zone3.TotalSeconds / sum * seconds);
            var perc4 = (int)(Zone4.TotalSeconds / sum * seconds);
            var perc5 = (int)(Zone5.TotalSeconds / sum * seconds);

            if (seconds > 0)
            {
                Zones[4] = Zone5.Add(TimeSpan.FromSeconds(perc5));
                Zones[3] = Zone4.Add(TimeSpan.FromSeconds(perc4));
                Zones[2] = Zone3.Add(TimeSpan.FromSeconds(perc3));
                Zones[1] = Zone2.Add(TimeSpan.FromSeconds(perc2));
                Zones[0] = Zone1.Add(TimeSpan.FromSeconds(seconds - perc5 - perc4 - perc3 - perc2));
            }
            else if (seconds < 0)
            {
                Zones[4] = Zone5.Subtract(TimeSpan.FromSeconds(-perc5));
                Zones[3] = Zone4.Subtract(TimeSpan.FromSeconds(-perc4));
                Zones[2] = Zone3.Subtract(TimeSpan.FromSeconds(-perc3));
                Zones[1] = Zone2.Subtract(TimeSpan.FromSeconds(-perc2));
                Zones[0] = Zone1.Subtract(TimeSpan.FromSeconds(-seconds - perc5 - perc4 - perc3 - perc2));
            }
        }

        #endregion
    }
}
