using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrainingLog.Entries
{
    [XmlRoot("EntryList")]
    public class EntryList
    {
        #region Public Fields

        [XmlArray("TrainingEntryArray")]
        [XmlArrayItem("TrainingEntry")]
        public TrainingEntry[] TrainingEntries { get; set; }
        public bool TrainingEntriesSpecified { get { return TrainingEntries != null; } }

        [XmlArray("BiodataEntryArray")]
        [XmlArrayItem("BiodataEntry")]
        public BiodataEntry[] BiodataEntries { get; set; }
        public bool BiodataEntriesSpecified { get { return BiodataEntries != null; } }

        [XmlArray("NonSportEntryArray")]
        [XmlArrayItem("NonSportEntry")]
        public NonSportEntry[] NonSportEntries { get; set; }
        public bool NonSportEntriesSpecified { get { return NonSportEntries != null; } }

        [XmlIgnore]
        public Entry[] AllEntries {
            get
            {
                var entries = new List<Entry>();
                if (TrainingEntriesSpecified)
                    entries.AddRange(TrainingEntries);
                if (BiodataEntriesSpecified)
                    entries.AddRange(BiodataEntries);
                if (NonSportEntriesSpecified)
                    entries.AddRange(NonSportEntries);
                return entries.ToArray();
            } }

        #endregion

        #region Constructor

        public EntryList(TrainingEntry[] trainingEntries)
        {
            TrainingEntries = trainingEntries;
        }

        public EntryList(BiodataEntry[] biodataEntries)
        {
            BiodataEntries = biodataEntries;
        }

        public EntryList(NonSportEntry[] nonSportEntries)
        {
            NonSportEntries = nonSportEntries;
        }

        public EntryList()
        {
            // constructor for serializer
        }

        #endregion
    }
}
