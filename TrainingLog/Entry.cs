using System;
using System.Xml.Serialization;

namespace TrainingLog
{
    public abstract class Entry
    {
        #region Public Fields

        [XmlElement("Note", IsNullable = false)]
        public string Note { get; set; }
        public bool NoteSpecified { get { return Note != null; } }

        [XmlElement("EntryDate")]
        public DateTime? Date { get; set; }
        public bool DateSpecified { get { return Date != null; } }

        [XmlElement("Feeling")]
        public Common.Index? Feeling { get; set; }
        public bool FeelingSpecified { get { return Feeling != null; } }

        public abstract string LogString { get; }

        #endregion

        #region Protected Fields

        // used between name~value pairs
        protected const char AttributeSeparator = '\t';

        // used to separate name and value
        protected const char AttributeDividor = '\v';

        [XmlIgnore]
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
