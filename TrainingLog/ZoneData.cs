using System;

namespace TrainingLog
{
    public struct ZoneData
    {
        public TimeSpan Zone5;
        public TimeSpan Zone4;
        public TimeSpan Zone3;
        public TimeSpan Zone2;
        public TimeSpan Zone1;

        public TimeSpan GetZone(int index)
        {
            switch (index)
            {
                case 1:
                    return Zone1;
                case 2:
                    return Zone2;
                case 3:
                    return Zone3;
                case 4:
                    return Zone4;
                case 5:
                    return Zone5;
                default:
                    throw new ArgumentException();
            }
        }
        public double GetZoneSeconds(int index)
        {
            return GetZone(index).TotalSeconds;
        }

        public double GetZonePercentage(int index)
        {
            return GetZoneSeconds(index)/Duration.TotalSeconds;
        }

        public override string ToString()
        {
            return Zone5.ToString() + '_' + Zone4 + '_' + Zone3 + '_' + Zone2 + '_' + Zone1;
        }

        public bool IsEmpty
        {
            get { return Duration == TimeSpan.Zero; }
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

        public TimeSpan Duration { get { return Zone5.Add(Zone4.Add(Zone3.Add(Zone2.Add(Zone1)))); } }

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
                Zone5 = Zone5.Add(TimeSpan.FromSeconds(perc5));
                Zone4 = Zone4.Add(TimeSpan.FromSeconds(perc4));
                Zone3 = Zone3.Add(TimeSpan.FromSeconds(perc3));
                Zone2 = Zone2.Add(TimeSpan.FromSeconds(perc2));
                Zone1 = Zone1.Add(TimeSpan.FromSeconds(seconds - perc5 - perc4 - perc3 - perc2));
            }
            else if (seconds < 0)
            {
                perc2 *= -1;
                perc3 *= -1;
                perc4 *= -1;
                perc5 *= -1;

                Zone5 = Zone5.Subtract(TimeSpan.FromSeconds(perc5));
                Zone4 = Zone4.Subtract(TimeSpan.FromSeconds(perc4));
                Zone3 = Zone3.Subtract(TimeSpan.FromSeconds(perc3));
                Zone2 = Zone2.Subtract(TimeSpan.FromSeconds(perc2));
                Zone1 = Zone1.Subtract(TimeSpan.FromSeconds(-seconds - perc5 - perc4 - perc3 - perc2));
            }
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
}
