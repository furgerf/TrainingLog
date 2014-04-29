using System.IO;

namespace TrainingLog
{
    public class Utils
    {
        public enum Index
        {
            Terrible, Bad, Okay, Good, Fantastic, Count, None
        }

        public const string DataFilePath = "training.log";

        //public static FileStream GetDataFileAppend()
        //{
        //    return File.Open(DataFilePath, FileMode.Append);
        //    File.a
        //}
    }
}
