using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrainingLog
{
    public class Model
    {
        #region Public Fields

        public static Model Instance { get { return _instance ?? (_instance = new Model()); } }

        public RaceEntry[] RaceEntries { get { return _entries.Where(e => e is RaceEntry).Cast<RaceEntry>().ToArray(); } }
        public BioDataEntry[] BioDataEntries { get { return _entries.Where(e => e is BioDataEntry).Cast<BioDataEntry>().ToArray(); } }
        public TrainingEntry[] TrainingEntries { get { return _entries.Where(e => e is TrainingEntry).Cast<TrainingEntry>().ToArray(); } }

        #endregion

        #region Private Fields

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

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        private void ReadEntries()
        {
            _entries.Clear();

            var lines = File.ReadAllLines(Common.DataFilePath);

            foreach (var line in lines)
                _entries.Add(Entry.Parse(line));
        }

        #endregion
    }
}
