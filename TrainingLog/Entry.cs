using System;

namespace TrainingLog
{
    public abstract class Entry
    {
        #region Public Fields

        public String Note { get; set; }

        public DateTime DateTime { get; set; }

        public Common.Index Feeling { get; set; }

        public abstract string LogString { get; }

        #endregion

        #region Protected Fields

        // used between name~value pairs
        protected const char AttributeSeparator = '\t';

        // used to separate name and value
        protected const char AttributeDividor = '\v';

        protected readonly string EntryName;

        #endregion

        #region Constructor

        protected Entry(Common.EntryType entryType)
        {
            EntryName = entryType.ToString();
        }

        #endregion

        #region Main Methods

        public static Entry Parse(string data)
        {
            var entryType = (int)Enum.Parse(typeof(Common.EntryType), data.Substring(0, data.IndexOf(AttributeSeparator)));

            switch (entryType)
            {
                case (int)Common.EntryType.BioData:
                    return BioDataEntry.ParseBioDataEntry(data);
                case (int)Common.EntryType.Race:
                    return RaceEntry.ParseRaceEntry(data);
                case (int)Common.EntryType.Training:
                    return TrainingEntry.ParseTrainingEntry(data);
                default:
                    return null;
            }
        }

        #endregion
    }
}
