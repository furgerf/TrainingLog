using System;

namespace TrainingLog.Forms
{
    public struct EntryListColumn
    {
        #region Public Fields

        public string Header { get; private set; }

        public int Width
        {
            get { return _width; }
            set
            {
                if (FixedSize) throw new Exception("cannot change width");
                _width = value;
            }
        }

        public bool FixedSize { get; private set; }

        #endregion

        #region Public Fields

        private int _width;

        #endregion

        #region Constructor

        public EntryListColumn(string header, int width, bool fixedSize = false)
            : this()
        {
            Header = header;
            // fixedSize must be false before width is set!
            Width = width;
            FixedSize = fixedSize;
        }

        #endregion
    }
}
