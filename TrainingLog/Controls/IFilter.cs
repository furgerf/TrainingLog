using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Controls
{
    public interface IFilter
    {
        //void Initialize(GLItemCollection list, Common.MarkItem markItem, Common.ApplyItemVisibility applyItemVisibility, int enumColumnIndex, object defaultValue = null);

        //bool IsItemVisible(GLItem item);

        bool IsEntryVisible(Entry entry);

        //void ApplyFilter();

        Control GetControl();
    }
}
