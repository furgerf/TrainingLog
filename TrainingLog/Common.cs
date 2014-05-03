namespace TrainingLog
{
    public class Common
    {
        public enum Index
        {
            Terrible, Bad, Okay, Good, Fantastic, Count, None
        }

        public enum Sport
        {
            Running, Cycling, Squash, Other, Count
        }

        public enum EnduranceType
        {
            Easy, Interval, Fartlek, Base, Long, Tempo, Other, Count
        }

        public enum SquashType
        {
            Solo, Training, Club, Match, Count
        }

        public enum TrainingType
        {
            None
        }

        public enum EntryType
        {
            Training, Race, BioData, Count
        }

        public const double SignificancePercentage = 0.05;

        public const string DataFilePath = "training.log";
    }
}
