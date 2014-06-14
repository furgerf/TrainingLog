using System.Xml.Serialization;
using System.Linq;

namespace TrainingLog.Entries
{
    [XmlRoot("EntryList")]
    public class EntryList
    {
        #region Public Fields

        [XmlArray("TrainingEntryArray")]
        [XmlArrayItem("TrainingEntry")]
        public TrainingEntry[] TrainingEntries { get; set; }

        [XmlArray("BiodataEntryArray")]
        [XmlArrayItem("BiodataEntryObject")]
        public BiodataEntry[] BiodataEntries { get; set; }

        [XmlArray("NonSportEntryArray")]
        [XmlArrayItem("NonSportEntryObject")]
        public NonSportEntry[] NonSportEntries { get; set; } 

        [XmlIgnore]
        public Entry[] AllEntries { get { return TrainingEntries.Cast<Entry>().Concat(BiodataEntries).Concat(NonSportEntries).ToArray(); } }

        #endregion

        #region Constructor

        public EntryList(TrainingEntry[] trainingEntries, BiodataEntry[] biodataEntries, NonSportEntry[] nonSportEntries)
        {
            TrainingEntries = trainingEntries;
            BiodataEntries = biodataEntries;
            NonSportEntries = nonSportEntries;
        }

        public EntryList()
        {
            // constructor for serializer
        }

        #endregion
    }
}
