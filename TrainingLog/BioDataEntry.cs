using System;
using System.Text;

namespace TrainingLog
{
    public class BioDataEntry : Entry
    {
        #region Public Fields

        public int RestingHeartRate { get; set; }

        public decimal Weight { get; set; }

        public TimeSpan SleepDuration { get; set; }

        public Utils.Index SleepQuality { get; set; }

        public String Nibbles { get; set; }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public BioDataEntry() : base("BioDataEntry")
        {
            
        }

        #endregion

        #region Main Methods

        private bool SetAttribute(string attribute, string value)
        {
            try
            {
                switch (attribute)
                {
                    case "RestingHeartRate":
                        RestingHeartRate = int.Parse(value);
                        return true;
                    case "Weight":
                        Weight = decimal.Parse(value);
                        return true;
                    case "SleepDuration":
                        SleepDuration = TimeSpan.Parse(value);
                        return true;
                    case "SleepQuality":
                        Utils.Index foo;
                        if (!Enum.TryParse(value, out foo))
                            throw new Exception();
                        SleepQuality = foo;
                        return true;
                    case "Nibbles":
                        Nibbles = value;
                        return true;
                    case "Note":
                        Note = value;
                        return true;
                    case "DateTime":
                        DateTime = DateTime.Parse(value);
                        return true;
                    case "Feeling":
                        if (!Enum.TryParse(value, out foo))
                            throw new Exception();
                        Feeling = foo;
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Entry TryParse(string data)
        {
            var attributes = data.Split(AttributeSeparator);

            if (attributes.Length <= 1)
                return null;

            var entry = new BioDataEntry();

            for (var i = 1; i < attributes.Length; i++)
            {
                var pair = attributes[i].Split(AttributeDividor);
                if (!entry.SetAttribute(pair[0], pair[1]))
                    return null;
            }

            return entry;
        }

        public override string LogString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(EntryName);
                
                if (RestingHeartRate != 0)
                    sb.Append(AttributeSeparator + "RestingHeartRate" + AttributeDividor + RestingHeartRate);
                if (Weight != 0)
                    sb.Append(AttributeSeparator + "Weight" + AttributeDividor + Weight);
                sb.Append(AttributeSeparator + "SleepDuration" + AttributeDividor + SleepDuration);
                sb.Append(AttributeSeparator + "SleepQuality" + AttributeDividor + SleepQuality);
                if (Nibbles != "")
                    sb.Append(AttributeSeparator + "Nibbles" + AttributeDividor + Nibbles);
                if (Note != "")
                    sb.Append(AttributeSeparator + "Note" + AttributeDividor + Note);
                sb.Append(AttributeSeparator + "DateTime" + AttributeDividor + DateTime);

                if (Feeling != Utils.Index.None)
                    sb.Append(AttributeSeparator + "Feeling" + AttributeDividor + Feeling);

                return sb.ToString();
            }
        }

        #endregion
    }
}
