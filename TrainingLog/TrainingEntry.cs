using System;

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

        public Utils.Sport Sport { get; set; }

        #endregion

        #region Private Fields

        private int _distanceM;

        private SweatData _sweatData;

        #endregion

        #region Constructor

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

        public override Entry TryParse(string data)
        {
            throw new NotImplementedException();
        }

        public override string LogString
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
