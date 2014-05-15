using System.Xml.Serialization;

namespace TrainingLog
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
        public BioDataEntry[] BiodataEntries { get; set; } 

        #endregion

        #region Constructor

        public EntryList(TrainingEntry[] trainingEntries, BioDataEntry[] biodataEntries)
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
