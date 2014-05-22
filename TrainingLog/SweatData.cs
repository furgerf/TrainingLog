using System;
using TrainingLog.Entries;

namespace TrainingLog
{
    public class SweatData
    {
        #region Public Fields

        public TrainingEntry TrainingEntry { get; set; }

        public double WeightBefore { get; set; }

        public double WeightAfter { get; set; }

        public double WeightLoss { get { return WeightBefore - WeightAfter; } }

        public double Temperature { get; set; }

        public String Weather { get; set; }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public SweatData(double weightBefore, double weightAfter)
        {
            WeightBefore = weightBefore;
            WeightAfter = weightAfter;

            throw new NotImplementedException();
        }

        #endregion

        #region Main Methods



        #endregion
    }
}
