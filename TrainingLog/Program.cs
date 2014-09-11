using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TrainingLog.Entries;
using TrainingLog.Forms;

namespace TrainingLog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //var eq = new List<Equipment>();
            //eq.Add(new Equipment("Asics Gel Kayano 20", "asics_gel_kayano_20", Common.Sport.Running));
            //var eqa = eq.ToArray();
            //var el = new EntryList(eqa);

            //using (var tw = new StreamWriter("foo.xml"))
            //{
            //    var ser = new XmlSerializer(typeof(EntryList));
            //    ser.Serialize(tw, el);
            //}

            //var serializer = new XmlSerializer(typeof(EntryList));
            //Equipment[] eq;

            //using (var stringReader = new StringReader(File.ReadAllText("foo.xml")))
            //using (var reader = XmlReader.Create(stringReader))
            //{
            //    eq = ((EntryList)serializer.Deserialize(reader)).EquipmentEntries;
            //}

            //foreach (var e in eq)
            //    e.LoadImage();





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm.Initialize();
            //new NewEquipmentForm(eq[0]).Show();
            Application.Run();
        }
    }
}
