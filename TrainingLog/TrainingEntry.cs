using System;

namespace TrainingLog
{
    public class TrainingEntry
    {
        #region Public Fields

        public TimeSpan Duration { get; set; }

        public double DistanceKm { get { return _distanceM / 1000.0; } set { _distanceM = (int)(1000*value); } }

        public int DistanceM { get { return _distanceM; } set { _distanceM = value; } }

        public Utils.Index Feeling { get; set; }

        public String Note { get; set; }

        public TimeSpan Pace { get { return new TimeSpan(0, (int)(Duration.TotalMinutes / DistanceKm), 0); } }

        public double Speed { get { return DistanceKm/Duration.TotalHours; } }

        public SweatData SweatData { get { return _sweatData; } set { _sweatData = value; _sweatData.TrainingEntry = this; } }

        #endregion

        #region Private Fields

        private int _distanceM;

        private SweatData _sweatData;

        #endregion

        #region Constructor

        public TrainingEntry(TimeSpan duration)
        {
            Duration = duration;
        }

        #endregion

        #region Main Methods



        #endregion
    }
}
