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
            :base(duration, "RaceEntry")
        {
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
