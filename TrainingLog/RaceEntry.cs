using System;

namespace TrainingLog
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

        public static RaceEntry ParseRaceEntry (string data)
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
