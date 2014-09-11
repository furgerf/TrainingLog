using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TrainingLog
{
    public class Settings
    {
        #region Public Fields

        [XmlElement("TrainingPath")]
        public string TrainingPath
        {
            get { return _trainingPath; }
            set
            {
                var saveSettings = TrainingPathSpecified;
                _trainingPath = value;
                if (saveSettings)
                    SaveSettings();
            }
        }
        public bool TrainingPathSpecified { get { return !string.IsNullOrEmpty(TrainingPath); } }
        [XmlIgnore]
        private string _trainingPath;

        [XmlElement("BiodataPath")]
        public string BiodataPath
        {
            get { return _biodataPath; }
            set
            {
                var saveSettings = BiodataPathSpecified;
                _biodataPath = value;
                if (saveSettings)
                    SaveSettings();
            }
        }
        public bool BiodataPathSpecified { get { return !string.IsNullOrEmpty(BiodataPath); } }
        [XmlIgnore]
        private string _biodataPath;

        [XmlElement("NonSportPath")]
        public string NonSportPath
        {
            get { return _nonsportPath; }
            set
            {
                var saveSettings = NonSportPathSpecified;
                _nonsportPath = value;
                if (saveSettings)
                    SaveSettings();
            }
        }
        public bool NonSportPathSpecified { get { return !string.IsNullOrEmpty(NonSportPath); } }
        [XmlIgnore]
        private string _nonsportPath;

        #endregion

        #region Private Fields

        [XmlIgnore]
        public const string SettingsPath = "settings.xml";
            
        #endregion

        #region Constructor

        public Settings()
        {
            // for xml deserialization
        }

        #endregion

        #region Main Methods

        public static Settings LoadSettings(string path = SettingsPath)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using (var stringReader = new StringReader(File.ReadAllText(path)))
            using (var reader = XmlReader.Create(stringReader))
            {
                return (Settings)serializer.Deserialize(reader);
            }
        }

        private void SaveSettings()
        {
            using (var tw = new StreamWriter(SettingsPath))
            {
                var ser = new XmlSerializer(typeof(Settings));
                ser.Serialize(tw, this);
            }
        }

        #endregion
    }
}
