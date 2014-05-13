using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TrainingLog
{
    public class Model
    {
        #region Public Fields

        public static Model Instance { get { return _instance ?? (_instance = new Model()); } }

        public Entry[] Entries { get { return _entries.ToArray(); } }
        public RaceEntry[] RaceEntries { get { return _entries.Where(e => e is RaceEntry).Cast<RaceEntry>().ToArray(); } }
        public BioDataEntry[] BioDataEntries { get { return _entries.Where(e => e is BioDataEntry).Cast<BioDataEntry>().ToArray(); } }
        public TrainingEntry[] TrainingEntries { get { return _entries.Where(e => e is TrainingEntry).Cast<TrainingEntry>().ToArray(); } }

        #endregion

        #region Private Fields

        private const string DataFilePath = "training.log";

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

            var data = new string[_entries.Count];

            for (var i = 0; i < data.Length; i++)
                data[i] = _entries[i].LogString;

            File.WriteAllLines(DataFilePath, data);
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);

            File.AppendAllText(DataFilePath, entry.LogString + '\n');
        }

        private void ReadEntries()
        {
            _entries.Clear();

            var lines = File.ReadAllLines(DataFilePath);

            foreach (var line in lines)
            {
                var entry = Entry.Parse(line);
                if (entry == null)
                    MessageBox.Show("Couldn\'t parse entry \"" + line + "\".", "Invalid entry", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                else
                    _entries.Add(entry);
            }
        }

        #endregion
    }
}
