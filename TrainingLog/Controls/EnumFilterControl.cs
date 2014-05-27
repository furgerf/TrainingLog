using System;
using System.Windows.Forms;
using GlacialComponents.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Controls
{
    public partial class EnumFilterControl : UserControl, IFilter
    {
        #region Public Fields

        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                label1.Text = _labelText;
            }
        }

        public Func<Entry, string> DataFromEntry { get; set; }

        public string[] Items
        {
            get { return _items; }
            set
            {
                if (value == null)
                    return;
                _items = value;
                comData.Items.Clear();
                foreach (var s in _items)
                    comData.Items.Add(s);
                comData.SelectedIndex = 0;
            }
        }

        public int EnumColumnIndex { get; set; }

        #endregion

        #region Private Fields

        private Action _onFilterChanged;
        
        private string _labelText;

        private bool _initialized;
        private string[] _items;

        public const string All = "All";

        #endregion

        #region Constructor

        public EnumFilterControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Main Methods

        public void Initialize(GLItemCollection list, Common.MarkItem markItem,
                               Common.ApplyItemVisibility applyItemVisibility, int enumColumnIndex,
                               object defaultValue = null)
        {
            throw new NotImplementedException();
            //if (!(defaultValue is Type))
            //    throw new Exception();

            //_onFilterChanged = () =>
            //{
            //    if (!_initialized)
            //        return;

            //    foreach (GLItem o in list)
            //        markItem(o, IsItemVisible(o));

            //    applyItemVisibility();
            //};

            //foreach (var s in Enum.GetNames((Type)defaultValue))
            //    comData.Items.Add(s);

            //EnumColumnIndex = enumColumnIndex;
            //_initialized = true;
        }

        public bool IsItemVisible(GLItem item)
        {
            throw new NotImplementedException();
            //DateTime? date = null;

            //if (item.SubItems[EnumColumnIndex].Control is DateTimePicker)
            //    date = (item.SubItems[EnumColumnIndex].Control as DateTimePicker).Value;

            //if (item.SubItems[EnumColumnIndex].Control is ColorDatePicker)
            //    date = (item.SubItems[EnumColumnIndex].Control as ColorDatePicker).Value;

            //if (date == null)
            //    throw new Exception("Don\'t know where the date control is!");

            //return (dtpDate.Value.CompareTo(date) == 0) || (dtpDate.Value.CompareTo(date) < 0 ^ !LabelText);
        }

        public bool IsEntryVisible(Entry entry)
        {
            if (!(entry is TrainingEntry))
                return true;

            if (DataFromEntry == null)
                throw new Exception();

            return comData.Text.Equals(All) || comData.Text.Equals(DataFromEntry(entry));
        }

        public void ApplyFilter()
        {
            if (_onFilterChanged != null)
                _onFilterChanged();
        }

        public Control GetControl()
        {
            return comData;
        }

        #endregion

        #region Event Handling

        #endregion
    }
}
