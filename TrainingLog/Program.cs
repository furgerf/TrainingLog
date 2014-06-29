using System;
using System.Windows.Forms;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm.Initialize();
            Application.Run();
        }
    }
}
