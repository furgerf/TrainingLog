namespace TrainingLog.Forms
{
    public struct EntryListColumn
    {
        public EntryListColumn(string header, int width) : this()
        {
            Width = width;
            Header = header;
        }

        public string Header { get; private set; }

        public int Width { get; set; }
    }
}
