using System;

namespace TrainingLog
{
    public class Utils
    {
        public enum Index
        {
            Terrible, Bad, Okay, Good, Fantastic, Count, None
        }

        public enum Sport
        {
            Running, Biking, Squash, Other, Count
        }

        public enum EnduranceType
        {
            Easy, Interval, Fartlek, Base, Long, Tempo, Count
        }

        public enum SquashType
        {
            Solo, Training, Club, Match, Count
        }

        public enum TrainingType
        {
            None
        }

        public const double SignificancePercentage = 0.05;

        public const string DataFilePath = "training.log";

        //public static FileStream GetDataFileAppend()
        //{
        //    return File.Open(DataFilePath, FileMode.Append);
        //    File.a
        //}
    }
}
