using System;

namespace TrainingLog
{
    public abstract class Entry
    {
        #region Public Fields

        public String Note { get; set; }

        public DateTime DateTime { get; set; }

        public Utils.Index Feeling { get; set; }

        #endregion

        #region Private Fields

        // used between name~value pairs
        protected const char AttributeSeparator = '\t';

        // used to separate name and value
        protected const char AttributeDividor = '\v';

        #endregion

        protected Entry(String entryName)
        {
            EntryName = entryName;
        }

        #region Main Methods

        public abstract Entry TryParse(String data);

        public abstract String LogString { get; }

        protected readonly String EntryName;

        #endregion
    }
}
