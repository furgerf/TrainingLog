using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TrainingLog.Entries;
using TrainingLog.Forms;

namespace TrainingLog
{
    public class Model
    {
        #region Public Fields

        public event EventHandler<EntryChangedEventArgs> EntriesChanged;

        public static Model Instance { get { if (_instance == null) throw new Exception(); return _instance; } }

        public Entry[] Entries { get { return _entries.ToArray(); } }
        public TrainingEntry[] CompetitionEntries { get { return _entries.Where(e => e.EntryName.Equals("Competition")).OrderBy(e => e.Date).Cast<TrainingEntry>().ToArray(); } }
        public BiodataEntry[] BiodataEntries { get { return _entries.Where(e => e is BiodataEntry).OrderBy(e => e.Date).Cast<BiodataEntry>().ToArray(); } }
        public TrainingEntry[] TrainingEntries { get { return _entries.Where(e => e is TrainingEntry).OrderBy(e => e.Date).Cast<TrainingEntry>().ToArray(); } }
        public NonSportEntry[] NonSportEntries { get { return _entries.Where(e => e is NonSportEntry).OrderBy(e => e.Date).Cast<NonSportEntry>().ToArray(); } }
        public Equipment[] Equipment { get { return _equipments.ToArray(); } }

        #endregion

        #region Private Fields

        private static Model _instance;

        private readonly List<Entry> _entries = new List<Entry>();

        private readonly List<Equipment> _equipments = new List<Equipment>(); 

        private readonly string _trainingPath;
        private readonly string _biodataPath;
        private readonly string _nonSportPath;
        private readonly string _equipmentPath;

        #endregion

        #region Constructor

        private Model(string trainingPath, string biodataPath, string nonSportPath, string equipmentPath)
        {
            _trainingPath = trainingPath;
            _biodataPath = biodataPath;
            _nonSportPath = nonSportPath;
            _equipmentPath = equipmentPath;

            ReadEntries();
        }

        #endregion

        #region Main Methods

        public static void Initialize(string trainingPath, string biodataPath, string nonSportPath, string equipmentPath)
        {
            _instance = new Model(trainingPath, biodataPath, nonSportPath, equipmentPath);
        }

        public void RemoveEntry(Entry entry)
        {
            _entries.Remove(entry);

            WriteEntries(entry.GetType());

            if (EntriesChanged != null)
                EntriesChanged(this, new EntryChangedEventArgs(false, entry));
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);

            WriteEntries(entry.GetType());

            if (EntriesChanged != null)
                EntriesChanged(this, new EntryChangedEventArgs(true, entry));
        }

        public void RemoveEntry(Equipment entry)
        {
            _equipments.Remove(entry);

            WriteEntries(entry.GetType());

            // no need to fire event
        }

        public void AddEntry(Equipment entry)
        {
            _equipments.Add(entry);

            WriteEntries(entry.GetType());

            // no need to fire event
        }

        public void WriteEntries(Type entryType, string path = null)
        {
            EntryList el;

            if (entryType == typeof(TrainingEntry))
            {
                if (path == null)
                    path = MainForm.Instance.Settings.TrainingPath;
                el = new EntryList(TrainingEntries);
            }
            else if (entryType == typeof(BiodataEntry))
            {
                if (path == null)
                    path = MainForm.Instance.Settings.BiodataPath;
                el = new EntryList(BiodataEntries);
            }
            else if (entryType == typeof (NonSportEntry))
            {
                if (path == null)
                    path = MainForm.Instance.Settings.NonSportPath;
                el = new EntryList(NonSportEntries);
            }else if (entryType == typeof (Equipment))
            {
                if (path == null)
                    path = MainForm.Instance.Settings.EquipmentPath;
                el = new EntryList(Equipment);
            }
            else
                throw new Exception("Invalid type: " + entryType.Name);

            using (var tw = new StreamWriter(path))
            {
                var ser = new XmlSerializer(typeof(EntryList));
                ser.Serialize(tw, el);
            }
        }

        private void ReadEntries()
        {
            _entries.Clear();

            var serializer = new XmlSerializer(typeof (EntryList));

            using (var stringReader = new StringReader(File.ReadAllText(_trainingPath)))
            using (var reader = XmlReader.Create(stringReader))
            {
                _entries.AddRange(((EntryList)serializer.Deserialize(reader)).AllEntries);
            }
            using (var stringReader = new StringReader(File.ReadAllText(_biodataPath)))
            using (var reader = XmlReader.Create(stringReader))
            {
                _entries.AddRange(((EntryList)serializer.Deserialize(reader)).AllEntries);
            }
            using (var stringReader = new StringReader(File.ReadAllText(_nonSportPath)))
            using (var reader = XmlReader.Create(stringReader))
            {
                _entries.AddRange(((EntryList)serializer.Deserialize(reader)).AllEntries);
            }
            using (var stringReader = new StringReader(File.ReadAllText(_equipmentPath)))
            using (var reader = XmlReader.Create(stringReader))
            {
                _equipments.AddRange(((EntryList)serializer.Deserialize(reader)).EquipmentEntries);
            }
        }

        #endregion
    }
}
