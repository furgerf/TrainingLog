using System;
using TrainingLog.Entries;

namespace TrainingLog
{
    public class EntryChangedEventArgs : EventArgs
    {
        #region Public Fields

        public Entry ChangedEntry { get; private set; }

        public bool EntryAdded { get { return _entryAdded; } }

        public bool EntryRemoved { get { return !_entryAdded; } }

        #endregion

        #region Private Fields

        private readonly bool _entryAdded;

        #endregion

        #region Constructor

        public EntryChangedEventArgs(bool entryAdded, Entry changedEntry)
        {
            _entryAdded = entryAdded;
            ChangedEntry = changedEntry;
        }

        #endregion
    }
}
