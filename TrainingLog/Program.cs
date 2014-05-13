using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
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

            using (var tw = new StreamWriter("foo.xml"))
            {
                var ser = new XmlSerializer(typeof(BioDataEntry));
                ser.Serialize(tw, new BioDataEntry()); //Model.Instance.BioDataEntries[0]);
            }

            var des = new XmlSerializer(typeof(BioDataEntry));
            var tr = new StreamReader("foo.xml");
            BioDataEntry bd;
            bd = (BioDataEntry)des.Deserialize(tr);
            tr.Close();
            var sdf = new BioDataEntry();


            //todo: machen, dass alle uninitialisierten felder null sind

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
