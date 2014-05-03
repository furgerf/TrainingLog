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

        public override string ToString()
        {
            return Zone5.ToString() + '_' + Zone4 + '_' + Zone3 + '_' + Zone2 + '_' + Zone1;
        }

        public bool IsEmpty
        {
            get { return GetDuration() == TimeSpan.Zero; }
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
}
