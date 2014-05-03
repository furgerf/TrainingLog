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
            var entryType = data.Substring(0, data.IndexOf(AttributeSeparator));

            switch (entryType)
            {
                case "BioDataEntry":
                    return BioDataEntry.ParseBioDataEntry(data);
                case "RaceEntry":
                    return RaceEntry.ParseRaceEntry(data);
                case "TrainingEntry":
                    return TrainingEntry.ParseTrainingEntry(data);
                default:
                    return null;
            }
        }

        #endregion
    }
}
