using System;

namespace TrainingLog.Forms
{
    public struct EntryListColumn
    {
        public EntryListColumn(string header, Type type, int width) : this()
        {
            Width = width;
            Type = type;
            Header = header;
        }

        public Type Type { get; private set; }

        public string Header { get; private set; }

        public int Width { get; private set; }
    }
}
