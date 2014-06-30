using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TrainingLog.Entries;

namespace TrainingLog
{
    public class Model
    {
        #region Public Fields

        public event EventHandler<EntryChangedEventArgs> EntriesChanged;

        public static Model Instance { get { if (_instance == null) throw new Exception(); return _instance; } }

        public Entry[] Entries { get { return _entries.ToArray(); } }
        public RaceEntry[] RaceEntries { get { return _entries.Where(e => e is RaceEntry).OrderBy(e => e.Date).Cast<RaceEntry>().ToArray(); } }
        public BiodataEntry[] BiodataEntries { get { return _entries.Where(e => e is BiodataEntry).OrderBy(e => e.Date).Cast<BiodataEntry>().ToArray(); } }
        public TrainingEntry[] TrainingEntries { get { return _entries.Where(e => e is TrainingEntry).OrderBy(e => e.Date).Cast<TrainingEntry>().ToArray(); } }
        public NonSportEntry[] NonSportEntries { get { return _entries.Where(e => e is NonSportEntry).OrderBy(e => e.Date).Cast<NonSportEntry>().ToArray(); } }

        #endregion

        #region Private Fields

        private static Model _instance;

        private readonly List<Entry> _entries = new List<Entry>();

        private readonly string _logPath;

        #endregion

        #region Constructor

        private Model(string path)
        {
            _logPath = path;
            ReadEntries();
        }

        #endregion

        #region Main Methods

        public static void Initialize(string path)
        {
            _instance = new Model(path);
        }

        public void RemoveEntry(Entry entry)
        {
            _entries.Remove(entry);

            WriteEntries();

            if (EntriesChanged != null)
                EntriesChanged(this, new EntryChangedEventArgs(false, entry));
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);

            WriteEntries();

            if (EntriesChanged != null)
                EntriesChanged(this, new EntryChangedEventArgs(true, entry));
        }

        public void WriteEntries(string path = null)
        {
            using (var tw = new StreamWriter(path ?? _logPath))
            {
                var ser = new XmlSerializer(typeof(EntryList));
                ser.Serialize(tw, new EntryList(TrainingEntries, BiodataEntries, NonSportEntries));
            }
        }

        private void ReadEntries()
        {
            _entries.Clear();

            var serializer = new XmlSerializer(typeof (EntryList));
            using (var stringReader = new StringReader(File.ReadAllText(_logPath)))
            using (var reader = XmlReader.Create(stringReader))
            {
                _entries.AddRange(((EntryList) serializer.Deserialize(reader)).AllEntries);
            }
        }

        #endregion
    }
}
