using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TrainingLog.Entries;
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

        public enum TrainingType
        {
            None = 0,
            Easy = 10, Interval, Fartlek, Base, Long, Tempo, Mountain, Other,
            Solo = 20, Training, Club, Match, Count
        }

        public enum EntryType
        {
            Training, Race, BioData, NonSport, Count
        }
        
        #endregion

        #region Enum Categories

        public static readonly Sport[] EnduranceSports = new[] { Sport.Running, Sport.Cycling };

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

        private static readonly Dictionary<TrainingType, Color> TrainingTypeColors = new Dictionary<TrainingType, Color> { { TrainingType.Easy, Color.LightGray }, { TrainingType.Interval, Color.Red }, { TrainingType.Fartlek, Color.DarkOliveGreen }, { TrainingType.Base, Color.SteelBlue }, { TrainingType.Long, Color.Goldenrod }, { TrainingType.Tempo, Color.MediumPurple }, { TrainingType.Mountain, Color.SaddleBrown }, { TrainingType.Other, Color.LightGreen }, { TrainingType.Solo, Color.RoyalBlue }, { TrainingType.Training, Color.DarkOrange }, { TrainingType.Club, Color.Green }, { TrainingType.Match, Color.MediumVioletRed } }; 
            
        #endregion

        #region Constants

        public const double SignificancePercentage = 0.05;

        public static readonly Icon IconDelete;

        public static readonly Icon IconEdit;

        public const char DotChar = '\u25CF';

        public static readonly string ThreeDots = DotChar + " " + DotChar + " " + DotChar;

        public readonly static Func<DateTime, DateTime, NonSportEntry[]> NonSportEntries = (firstDate, lastDate) =>
        {
            var nse = Model.Instance.NonSportEntries.Where(e => e.Date <= lastDate && e.GetEndDate >= firstDate).ToArray();

            for (var i = 0; i < nse.Length; i++)
                if (nse[i].GetEndDate > lastDate)
                {
                    nse[i] = nse[i].Clone();
                    nse[i].EndDate = lastDate;
                    nse[i].Note += " " + ThreeDots;
                }
                else if (nse[i].Date < firstDate)
                {
                    nse[i] = nse[i].Clone();
                    nse[i].Date = firstDate;
                    nse[i].Note = ThreeDots + " " + nse[i].Note;
                }
            return nse;
        };

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
            var tt = GetTrainingTypes(sport);
            var res = new Color[tt.Length];
            for (var i = 0; i < tt.Length; i++)
                res[i] = TrainingTypeColors[tt[i]];

            return res;
        }

        #endregion
    }
}
