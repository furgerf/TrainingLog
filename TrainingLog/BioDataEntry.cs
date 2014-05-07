using System;
using System.Text;
using System.Windows.Forms;

namespace TrainingLog
{
    public class BioDataEntry : Entry
    {
        #region Public Fields

        public int RestingHeartRate { get; set; }

        public int OwnIndex { get; set; }

        public decimal Weight { get; set; }

        public TimeSpan SleepDuration { get; set; }

        public Common.Index SleepQuality { get; set; }

        public String Nibbles { get; set; }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public BioDataEntry() : base(Common.EntryType.BioData)
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
                    case "OwnIndex":
                        OwnIndex = int.Parse(value);
                        return true;
                    case "Weight":
                        Weight = decimal.Parse(value);
                        return true;
                    case "SleepDuration":
                        SleepDuration = TimeSpan.Parse(value);
                        return true;
                    case "SleepQuality":
                        Common.Index foo;
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

        public static BioDataEntry ParseBioDataEntry(string data)
        {
            if (!data.Contains("DateTime" + AttributeDividor) || !data.Contains("SleepQuality" + AttributeDividor) || !data.Contains("SleepDuration" + AttributeDividor))
                return null;

            var attributes = data.Split(AttributeSeparator);

            if (attributes.Length <= 1)
                return null;

            var entry = new BioDataEntry
                            {
                                Nibbles = "",
                                Note = "",
                                Feeling = Common.Index.None
                            };

            for (var i = 1; i < attributes.Length; i++)
            {
                var pair = attributes[i].Split(AttributeDividor);

                if (entry.SetAttribute(pair[0], pair[1])) continue;
                MessageBox.Show("Error while parsing \"" + attributes[i] + "\".", "Parsing error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // mandatory
                sb.Append(AttributeSeparator + "DateTime" + AttributeDividor + DateTime);
                sb.Append(AttributeSeparator + "SleepDuration" + AttributeDividor + SleepDuration);
                sb.Append(AttributeSeparator + "SleepQuality" + AttributeDividor + SleepQuality);

                // optional
                if (Feeling != Common.Index.None)
                    sb.Append(AttributeSeparator + "Feeling" + AttributeDividor + Feeling);
                if (RestingHeartRate != 0)
                    sb.Append(AttributeSeparator + "RestingHeartRate" + AttributeDividor + RestingHeartRate);
                if (OwnIndex != 0)
                    sb.Append(AttributeSeparator + "OwnIndex" + AttributeDividor + OwnIndex);
                if (Weight != 0)
                    sb.Append(AttributeSeparator + "Weight" + AttributeDividor + Weight);
                if (Nibbles != "")
                    sb.Append(AttributeSeparator + "Nibbles" + AttributeDividor + Nibbles);
                if (Note != "")
                    sb.Append(AttributeSeparator + "Note" + AttributeDividor + Note);
                
                return sb.ToString();
            }
        }

        #endregion
    }
}
