using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TrainingLog
{
    public class Model
    {
        #region Public Fields

        public static Model Instance { get { return _instance ?? (_instance = new Model()); } }

        public Entry[] Entries { get { return _entries.ToArray(); } }
        public RaceEntry[] RaceEntries { get { return _entries.Where(e => e is RaceEntry).Cast<RaceEntry>().ToArray(); } }
        public BiodataEntry[] BiodataEntries { get { return _entries.Where(e => e is BiodataEntry).Cast<BiodataEntry>().ToArray(); } }
        public TrainingEntry[] TrainingEntries { get { return _entries.Where(e => e is TrainingEntry).Cast<TrainingEntry>().ToArray(); } }

        #endregion

        #region Private Fields

        private const string DataFilePath = "log.xml";

        private static Model _instance;

        private readonly List<Entry> _entries = new List<Entry>();

        #endregion

        #region Constructor

        private Model()
        {
            ReadEntries();
        }

        #endregion

        #region Main Methods

        public static void Initialize()
        {
            _instance = new Model();
        }

        public void RemoveEntry(Entry entry)
        {
            _entries.Remove(entry);

            WriteEntries();
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);

            WriteEntries();
        }

        private void WriteEntries()
        {
            using (var tw = new StreamWriter(DataFilePath))
            {
                var ser = new XmlSerializer(typeof(EntryList));
                ser.Serialize(tw, new EntryList(TrainingEntries, BiodataEntries));
            }
        }

        private void ReadEntries()
        {
            _entries.Clear();

            var serializer = new XmlSerializer(typeof (EntryList));
            using (var stringReader = new StringReader(File.ReadAllText(DataFilePath)))
            using (var reader = XmlReader.Create(stringReader))
            {
                _entries.AddRange(((EntryList) serializer.Deserialize(reader)).AllEntries);
            }
        }

        #endregion
    }
}
