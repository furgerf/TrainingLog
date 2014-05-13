
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

        #region Methods

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        #endregion
    }
}
