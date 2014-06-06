using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Forms;

namespace TrainingLog.Controls
{
    public partial class ControlList : UserControl
    {
        #region Public Fields

        public int ItemHeight
        {
            get { return _itemHeight; }
            set { _itemHeight = value; }
        }

        public ColumnHeader[] Columns { get { return _columns.ToArray(); } }

        public Control[][] Items { get { return _controls.ToArray(); } }

        public delegate void OnItemsChanged();

        public event OnItemsChanged ItemsChanged;

        #endregion

        #region Private Fields

        private readonly List<ColumnHeader> _columns = new List<ColumnHeader>();

        private readonly List<Control[]> _controls = new List<Control[]>();
        
        private int _itemHeight = 20;

        private int _sortedColumnIndex = -1;

        private SortOrder _sortOrder;

        #endregion

        #region Constructor

        public ControlList()
        {
            InitializeComponent();

            // sort rows on column click
            lisHeader.ColumnClick += SortColumns;

            // so it doesn't overlay the header when scrolling
            panArea.SendToBack();

            // update scrollbar
            panArea.SizeChanged += (s, e) => UpdateScrollbar();
            ItemsChanged += UpdateScrollbar;

            //// reapply sorting when items change
            //ItemsChanged += ReapplySorting;

            // add mouse scroll wheel capability
            panArea.MouseWheel += (s, e) =>
                                      {
                                          var oldValue = vscScroll.Value;
                                          vscScroll.Value -= e.Delta;
                                          if (vscScroll.Value < 0)
                                              vscScroll.Value = 0;
                                          if (vscScroll.Value > vscScroll.Maximum)
                                              vscScroll.Value = vscScroll.Maximum;
                                          var newValue = vscScroll.Value;
                                          VscScrollScroll(s, new ScrollEventArgs(ScrollEventType.EndScroll, oldValue, newValue));
                                      };
        }

        #endregion

        #region Main Methods

        private void UpdateScrollbar()
        {
            vscScroll.Maximum = panArea.Height < Height - lisHeader.Location.Y ? 0 : panArea.Height - Height + lisHeader.Location.Y;
            vscScroll.Enabled = vscScroll.Maximum != 0;
            vscScroll.SmallChange = vscScroll.Maximum / 50;
            vscScroll.LargeChange = vscScroll.Maximum / 10;
        }

        public void ClearColumns()
        {
            lisHeader.Columns.Clear();
            _columns.Clear();
        }

        public void AddColumn(string name, int width)
        {
            foreach (var cc in _controls.SelectMany(c => c))
                cc.Parent = null;

            lisHeader.Columns.Add(name, width);
            _columns.Add(lisHeader.Columns[lisHeader.Columns.Count - 1]);
        }

        public void AddColumn(EntryListColumn column)
        {
            AddColumn(column.Header, column.Width);
        }

        public void AddColumns(string[] names, int[] widths)
        {
            if (names.Length != widths.Length)
                throw new ArgumentException();

            for (var i = 0; i < names.Length; i++)
                AddColumn(names[i], widths[i]);
        }

        public void AddColumns(EntryListColumn[] columns)
        {
            foreach (var c in columns)
                AddColumn(c.Header, c.Width);
        }

        public void AddItem(Control[] controls, bool updateControls = true)
        {
            // todo: change from adding to inserting
            if (controls.Length != _columns.Count)
                throw new ArgumentException();

            var x = 1;
            for (var i = 0; i < controls.Length; i++)
            {
                controls[i].Parent = panArea;
                controls[i].Location = new Point(x, _controls.Count * ItemHeight);
                controls[i].Size = new Size(_columns[i].Width, ItemHeight);

                x += _columns[i].Width;
            }

            _controls.Add(controls);

            if (!updateControls)
                return;

            panArea.Height = ItemHeight * _controls.Count < vscScroll.Height ? vscScroll.Height : ItemHeight * _controls.Count;

            if (ItemsChanged != null)
                ItemsChanged();
        }

        public void ClearItems()
        {
            foreach (Control c in panArea.Controls)
                c.Parent = null;

            _controls.Clear();

            panArea.Height = ItemHeight * _controls.Count < vscScroll.Height ? vscScroll.Height : ItemHeight * _controls.Count;

            if (ItemsChanged != null)
                ItemsChanged();
        }

        public void RemoveItem(Control[] item)
        {
            // remove old item
            _controls.Remove(item);
            foreach (var c in item)
                c.Parent = null;

            // backup remaining controls
            var controls = new Control[_controls.Count][];
            _controls.CopyTo(controls);

            // clear controls
            ClearItems();

            // re-add controls
            foreach (var c in controls)
                AddItem(c, false);

            panArea.Height = ItemHeight * _controls.Count < vscScroll.Height ? vscScroll.Height : ItemHeight * _controls.Count;

            if (ItemsChanged != null)
                ItemsChanged();
        }

        #endregion

        #region Event Handling

        private void ControlListResize(object sender, EventArgs e)
        {
            // fix control size
            lisHeader.Width = Width - vscScroll.Width;
            panArea.Width = lisHeader.Width;
            panArea.Height = panArea.Height > Height - lisHeader.Height ? panArea.Height : Height - lisHeader.Height;
            vscScroll.Location = new Point(panArea.Width, lisHeader.Height);
            vscScroll.Height = Height - lisHeader.Height;
        }

        private void LisHeaderColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // forces column width to remain the same
            e.Cancel = true;
            e.NewWidth = _columns[e.ColumnIndex].Width;
        }

        private void VscScrollScroll(object sender, ScrollEventArgs e)
        {
            // move area
            panArea.Location = new Point(panArea.Location.X, -vscScroll.Value);
        }

        private void SortColumns(object sender, ColumnClickEventArgs e)
        {
            SortColumn(e.Column);
        }

        private void ReapplySorting()
        {
            // only reapply sorting if sorting has occured before
            if (_sortedColumnIndex < 0)
                return;

            var order = _sortOrder;
            SortColumn(_sortedColumnIndex);
            if (order == SortOrder.Descending)
                SortColumn(_sortedColumnIndex);
        }

        public void SortByDate()
        {
            DateTime d;
            if (DateTime.TryParse(_controls[0][2].Text, out d))
            {
                SortColumn(2);
                return;
            }

            for (var i = 0; i < _controls[0].Length; i++)
                if (DateTime.TryParse(_controls[0][i].Text, out d))
                {
                    SortColumn(i);
                    return;
                }
        }

        private static bool IsBefore(string a, string b, bool numeric, SortOrder order)
        {
            if (!numeric)
                return order == SortOrder.Descending ^ String.Compare(a, b, StringComparison.Ordinal) > 0;

            double c;
            double d;

            if (!double.TryParse(a, out c))
                throw new ArgumentException();
            if (!double.TryParse(b, out d))
                throw new ArgumentException();

            return order == SortOrder.Descending ^ c < d;
        }

        private void SortColumn(int column)
        {
            if (_controls.Count == 0)
                return;

            _sortOrder = _sortedColumnIndex == column ? SortOrder.Ascending : SortOrder.Descending;
            _sortedColumnIndex = column;

            if (_controls[0][_sortedColumnIndex].Tag == null)
                throw new ArgumentException();
            double d;
            var numericSort = double.TryParse(_controls[0][_sortedColumnIndex].Tag.ToString(), out d);
            if (_controls.Any(c => c[_sortedColumnIndex].Tag == null || double.TryParse(c[_sortedColumnIndex].Tag.ToString(), out d) != numericSort))
                throw new ArgumentException();

            // insertion sort
            var newControls = new List<Control[]>();
            
            foreach (var c in _controls)
            {
                var inserted = false;
                for (var i = 0; i < newControls.Count; i++)
                    if (c[_sortedColumnIndex].Tag.Equals(newControls[i][_sortedColumnIndex].Tag) ||
                        IsBefore(c[_sortedColumnIndex].Tag.ToString(), newControls[i][_sortedColumnIndex].Tag.ToString(),
                                 numericSort, _sortOrder))
                    {
                        newControls.Insert(i, c);
                        inserted = true;
                        break;
                    }

                if (!inserted)
                    newControls.Add(c);
            }

            ClearItems();
            foreach (var c in newControls)
                AddItem(c);
        }

        #endregion
    }
}
