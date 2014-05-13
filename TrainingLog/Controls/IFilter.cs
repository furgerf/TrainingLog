namespace TrainingLog.Controls
{
    public delegate void FilterChangedEventHandler(IFilter sender);

    public interface IFilter
    {
        event FilterChangedEventHandler Changed;

        bool IsVisible(Entry entry);   
    }
}
