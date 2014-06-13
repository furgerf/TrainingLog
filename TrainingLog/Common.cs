using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using GlacialComponents.Controls;
using TrainingLog.Properties;

namespace TrainingLog
{
    public class Common
    {
        public delegate void MarkItem(GLItem item, bool visible);

        public delegate void ApplyItemVisibility();

        #region Enums

        public enum Index
        {
            Terrible, Bad, Okay, Good, Fantastic, Count, None
        }

        public static readonly Sport[] EnduranceSports = new[] {Sport.Running, Sport.Cycling};
        public enum Sport
        {
            Running, Cycling, Squash, Other, Count
        }

        public static readonly TrainingType[] EnduranceTypes =
            new[]
                {
                    TrainingType.Easy, TrainingType.Interval, TrainingType.Fartlek, TrainingType.Base, TrainingType.Long, 
                    TrainingType.Tempo, TrainingType.Mountain, TrainingType.Other
                };

        public static readonly TrainingType[] SquashTypes = new[]
                                                                {
                                                                    TrainingType.Solo, TrainingType.Training,
                                                                    TrainingType.Club, TrainingType.Match
                                                                };

        public static readonly TrainingType[] AllTypes = EnduranceTypes.Concat(SquashTypes).ToArray();

        public static Color[] EnduranceTypeColors = new []
                                                        {
                                                            Color.LightGray, Color.Red, Color.DarkOliveGreen, Color.SteelBlue, Color.Goldenrod, Color.MediumPurple, Color.SaddleBrown, Color.LightGreen
                                                        };

        public enum TrainingType
        {
            None = 0,
            Easy = 10, Interval, Fartlek, Base, Long, Tempo, Mountain, Other,
            Solo = 20, Training, Club, Match, Count
        }

        public enum EntryType
        {
            Training, Race, BioData, Count
        }

        #endregion

        #region Constants

        public const double SignificancePercentage = 0.05;

        public static readonly Icon IconDelete;

        public static readonly Icon IconEdit;

        #endregion

        #region Static Constructor

        static Common()
        {
            IconDelete = (Icon)Resources.ResourceManager.GetObject("delete");
            IconEdit = (Icon)Resources.ResourceManager.GetObject("edit");
        }

        #endregion

        #region Methods

        public static TrainingType[] GetTrainingTypes(Sport sport)
        {
            switch (sport)
            {
                case Sport.Running:
                case Sport.Cycling:
                    return EnduranceTypes;
                case Sport.Squash:
                    return SquashTypes;
                case Sport.Other:
                    return new TrainingType[0];
                default:
                    throw new ArgumentOutOfRangeException("sport");
            }
        }

        public static Color[] GetTrainingTypeColors(Sport sport)
        {
            switch (sport)
            {
                case Sport.Running:
                case Sport.Cycling:
                    var res = EnduranceTypeColors;
                    if (res.Length != EnduranceTypes.Length)
                        throw new Exception();
                    return res;
                default:
                    throw new ArgumentOutOfRangeException("sport");
            }
        }

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
