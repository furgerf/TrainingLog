using System;

namespace TrainingLog
{
    public class BioDataEntry
    {
        #region Public Fields

        public int RestingHeartRate { get; set; }

        public double Weight { get; set; }

        public TimeSpan SleepDuration { get; set; }

        public Utils.Index SleepQuality { get; set; }

        public Utils.Index Feeling { get; set; }

        public String Nibbles { get; set; }

        public String Note { get; set; }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public BioDataEntry()
        {

        }

        #endregion

        #region Main Methods



        #endregion
    }
}
