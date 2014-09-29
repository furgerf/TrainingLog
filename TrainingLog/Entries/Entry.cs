using System;
using System.Xml.Serialization;

namespace TrainingLog.Entries
{
    public abstract class Entry
    {
        #region Public Fields

        [XmlElement("Note")]
        public string Note { get; set; }
        public bool NoteSpecified { get { return !string.IsNullOrEmpty(Note); } }

        [XmlElement("EntryDate")]
        public DateTime? Date { get; set; }
        public bool DateSpecified { get { return Date != null; } }

        [XmlElement("Feeling")]
        public Common.Index? Feeling { get; set; }
        public bool FeelingSpecified { get { return Feeling != null; } }

        #endregion

        #region Protected Fields

        [XmlIgnore]
        public readonly string EntryName;

        #endregion

        #region Constructor

        protected Entry(Common.EntryType entryType)
        {
            EntryName = entryType.ToString();
        }

        #endregion

        #region Main Methods

        #endregion
    }
}
