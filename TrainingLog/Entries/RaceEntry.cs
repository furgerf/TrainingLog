using System;

namespace TrainingLog.Entries
{
    public class RaceEntry : TrainingEntry
    {
        #region Public Fields

        public int Rank { get; set; }

        #endregion

        #region Private Fields

        #endregion

        #region Constructor

        public RaceEntry(TimeSpan duration)
            :base(duration, Common.Sport.Running,  Common.EntryType.Race)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Main Methods

        #endregion
    }
}
