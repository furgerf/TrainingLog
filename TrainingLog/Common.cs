
using System.Drawing;
using TrainingLog.Properties;

namespace TrainingLog
{
    public class Common
    {
        #region Enums

        public enum Index
        {
            Terrible, Bad, Okay, Good, Fantastic, Count, None
        }

        public enum Sport
        {
            Running, Cycling, Squash, Other, Count
        }

        public enum EnduranceType
        {
            Easy, Interval, Fartlek, Base, Long, Tempo, Other, Count
        }

        public enum SquashType
        {
            Solo, Training, Club, Match, Count
        }

        public enum TrainingType
        {
            None
        }

        public enum EntryType
        {
            Training, Race, BioData, Count
        }

        #endregion

        #region Constants

        public const double SignificancePercentage = 0.05;

        public const string DataFilePath = "training.log";

        public static readonly Icon IconDelete;

        public static readonly Icon IconSave;

        #endregion

        #region Static Constructor

        static Common()
        {
            IconDelete = (Icon)Resources.ResourceManager.GetObject("delete");
            IconSave = (Icon)Resources.ResourceManager.GetObject("save");
        }

        #endregion
    }
}
