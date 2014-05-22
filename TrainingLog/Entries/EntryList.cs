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

        [XmlIgnore]
        public Entry[] AllEntries { get { return TrainingEntries.Cast<Entry>().Concat(BiodataEntries).ToArray(); } }

        #endregion

        #region Constructor

        public EntryList(TrainingEntry[] trainingEntries, BiodataEntry[] biodataEntries)
        {
            TrainingEntries = trainingEntries;
            BiodataEntries = biodataEntries;
        }

        public EntryList()
        {
            // constructor for serializer
        }

        #endregion
    }
}
