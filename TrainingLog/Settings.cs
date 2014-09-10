using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TrainingLog
{
    public class Settings
    {
        #region Public Fields

        [XmlElement("DataPath")]
        public string DataPath
        {
            get { return _dataPath; }
            set
            {
                var saveSettings = DataPathSpecified;
                _dataPath = value;
                if (saveSettings)
                    SaveSettings();
            }
        }

        public bool DataPathSpecified { get { return !string.IsNullOrEmpty(DataPath); } }

        #endregion

        #region Private Fields

        [XmlIgnore]
        private readonly string SettingsPath = Directory.GetCurrentDirectory() + "\\settings.xml";
            
        [XmlIgnore]
        private string _dataPath;

        #endregion

        #region Constructor

        public Settings()
        {
            // for xml deserialization
        }

        #endregion

        #region Main Methods

        public static Settings LoadSettings()
        {
            return ActuallyLoadSettings((new Settings()).SettingsPath);
        }

        private static Settings ActuallyLoadSettings(string path)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            //try
            //{
                using (var stringReader = new StringReader(File.ReadAllText(path)))
                using (var reader = XmlReader.Create(stringReader))
                {
                    return (Settings)serializer.Deserialize(reader);
                }
            //}
            //catch (FileNotFoundException fe)
            //{
            //    //MessageBox.Show("File " + fe.FileName + " not found. Please select settings file");
            //}
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
