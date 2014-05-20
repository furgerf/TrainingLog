using System;
using System.Xml.Serialization;

namespace TrainingLog
{
    [XmlType("BiodataEntry")]
    public class BiodataEntry : Entry
    {
        #region Public Fields

        [XmlElement("RestingHR")]
        public int? RestingHeartRate { get; set; }
        public bool RestingHeartRateSpecified { get { return RestingHeartRate != null && RestingHeartRate != 0; } }

        [XmlElement("OwnIndex")]
        public int? OwnIndex { get; set; }
        public bool OwnIndexSpecified { get { return OwnIndex != null && OwnIndex != 0; } }  

        [XmlElement("Weight")]
        public decimal? Weight { get; set; }
        public bool WeightSpecified { get { return Weight != null && Weight != 0; } }

        [XmlIgnore]
        public TimeSpan? SleepDuration { get; set; }
        
        [XmlElement("SleepDuration")]
        public string SleepDurationString { get { return (SleepDuration ?? TimeSpan.Zero).ToString(); } set { SleepDuration = TimeSpan.Parse(value); } }
        public bool SleepDurationStringSpecified { get { return SleepDuration != null; } } 

        [XmlElement("SleepQuality")]
        public Common.Index? SleepQuality { get; set; }
        public bool SleepQualitySpecified { get { return SleepQuality != null; } } 

        [XmlElement("Nibbles")]
        public string Nibbles { get; set; }
        public bool NibblesSpecified { get { return !string.IsNullOrEmpty(Nibbles); } }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public BiodataEntry() : base(Common.EntryType.BioData)
        {
            
        }

        #endregion

        #region Main Methods

        #endregion
    }
}
