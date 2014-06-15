using System;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Controls
{
    public partial class DateFilterControl : UserControl, IFilter
    {
        #region Public Fields

        public bool IsMinDate
        {
            get { return _isMinDate; }
            set
            {
                _isMinDate = value;
                label1.Text = IsMinDate ? "From:" : "To:";
            }
        }

        public bool IsMaxDate
        {
            get { return !_isMinDate; }
            set
            {
                _isMinDate = !value;
                label1.Text = IsMinDate ? "From:" : "To:";
            }
        }

        public DateTime Date { get { return dtpDate.Value; } }

        public int DateColumnIndex { get; set; }

        #endregion

        #region Private Fields

        //private Action _onFilterChanged;
        
        private bool _isMinDate;

        //private bool _initialized;

        #endregion

        #region Constructor

        public DateFilterControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Main Methods

        //public void Initialize(GLItemCollection list, Common.MarkItem markItem, Common.ApplyItemVisibility applyItemVisibility, int enumColumnIndex, object date = null)
        //{
        //    if (date != null)
        //        dtpDate.Value = (DateTime)date;

        //    _onFilterChanged = () =>
        //    {
        //        if (!_initialized)
        //            return;

        //        foreach (GLItem o in list)
        //            markItem(o, IsItemVisible(o));
                
        //        applyItemVisibility();
        //    };

        //    DateColumnIndex = enumColumnIndex;
        //    _initialized = true;
        //}

        //public bool IsItemVisible(GLItem item)
        //{
        //    DateTime? date = null;

        //    if (item.SubItems[DateColumnIndex].Control is DateTimePicker)
        //        date = (item.SubItems[DateColumnIndex].Control as DateTimePicker).Value;

        //    if (date == null)
        //        throw new Exception("Don\'t know where the date control is!");

        //    return (dtpDate.Value.CompareTo(date) == 0) || (dtpDate.Value.CompareTo(date) < 0 ^ !IsMinDate);
        //}

        public bool IsEntryVisible(Entry entry)
        {
            return (dtpDate.Value.CompareTo(entry.Date) == 0) || (dtpDate.Value.CompareTo(entry.Date) < 0 ^ !IsMinDate);
        }

        //public void ApplyFilter()
        //{
        //    if (_onFilterChanged != null)
        //        _onFilterChanged();
        //}

        public Control GetControl()
        {
            return dtpDate;
        }

        #endregion

        #region Event Handling

        #endregion
    }
}
