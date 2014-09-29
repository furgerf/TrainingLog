using System;

namespace TrainingLog.Entries
{
    class RunningRace : TrainingEntry
    {
        #region Public Fields

        public TimeSpan ExactTime { get; set; }

        public double ExactDistanceKm { get; set; }

        public int OverallRank { get; set; }

        public int AgeGroupRank { get; set; }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public RunningRace()
            : base(Common.Sport.Running, Common.EntryType.Competition)
        {

        }

        #endregion

        #region Main Methods



        #endregion

        #region Event Handling



        #endregion
    }
}
