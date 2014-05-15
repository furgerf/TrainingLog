using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TrainingLog.Forms;

namespace TrainingLog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Model.Initialize();
            
            var data = new EntryList(Model.Instance.TrainingEntries, Model.Instance.BioDataEntries);

            var te = Model.Instance.TrainingEntries[0];
            te = new TrainingEntry();

            using (var tw = new StreamWriter("foo.xml"))
            {
                var ser = new XmlSerializer(typeof(EntryList));
                ser.Serialize(tw, data);
            }

            var xml = File.ReadAllText("foo.xml");

            var serializer = new XmlSerializer(typeof(EntryList));
            EntryList result;
            using (var stringReader = new StringReader(xml))
            using (var reader = XmlReader.Create(stringReader))
            {
                result = (EntryList)serializer.Deserialize(reader);
            }


            using (var tw = new StreamWriter("bar.xml"))
            {
                var ser = new XmlSerializer(typeof(EntryList));
                ser.Serialize(tw, result);
            }

            //var des = new XmlSerializer(typeof(List<BioDataEntry>));
            //var tr = new StreamReader("foo.xml");
            //List<BioDataEntry> bd;
            //bd = (List<BioDataEntry>)des.Deserialize(tr);
            //tr.Close();
            //var sdf = new BioDataEntry();


            //todo: machen, dass alle uninitialisierten felder null sind

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
