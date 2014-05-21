using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;

namespace TrainingLog.Forms
{
    public partial class StatisticsForm : Form
    {
        #region Public Fields

        public static StatisticsForm GetInstance
        {
            get { return _instance ?? (_instance = new StatisticsForm()); }
        }

        #endregion

        #region Private Fields

        private static StatisticsForm _instance;

        private Size ScreenSize
        {
            get { return WindowState == FormWindowState.Maximized ? Screen.PrimaryScreen.WorkingArea.Size : ClientSize; }
        }

        private TrainingEntry[] FilteredTrainingEntries
        {
            get
            {
                var invisible =
                    (from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)
                        .ToList();
                return Model.Instance.TrainingEntries.Except(invisible).ToArray();
            }
        }

        private readonly IFilter[] _filters;

        private readonly List<TabPage> _pages = new List<TabPage>(); 

        #endregion

        #region Constructor

        public StatisticsForm()
        {
            InitializeComponent();

            ((DateTimePicker)dfcFrom.GetControl()).Value = DateTime.Today.Subtract(new TimeSpan(31 * 6, 0, 0, 0));
            ((DateTimePicker)dfcTo.GetControl()).Value = DateTime.Today;

            _filters = new IFilter[] {dfcFrom, dfcTo};

            var ent = FilteredTrainingEntries.Cast<Entry>().OrderByDescending(entry => entry.Date).ToArray();

            var graph = new Graph(Graph.GraphType.TrainingDurationZoneData, ent, e =>
                                                {
                                                    var zd = ((TrainingEntry)e).HrZones ?? ZoneData.Empty();
                                                    var res = new[] { new DataPoint(), new DataPoint(), new DataPoint(), new DataPoint(), new DataPoint() };

                                                    for (var i = 0; i < 5; i++)
                                                    {
                                                        //var dur = zd.Zones[i];
                                                        var dur = TimeSpan.FromSeconds(zd.Duration.TotalSeconds / 5);

                                                        res[i].SetValueXY(e.Date ?? DateTime.MaxValue,
                                                                          new DateTime(1, 1, 1, dur.Hours, dur.Minutes, dur.Seconds));
                                                    }

                                                    return res;
                                                }) { Title = "Duration with Zone Data per day" };
            AddGraph(graph);
        }

        #endregion

        #region Main Methods

        private void AddGraph(Graph graph)
        {
            var page = new TabPage {Text = graph.Title};
            _pages.Add(page);

            // location/size
            graph.Chart.Location = new Point(0,0);
            graph.Chart.Size = page.Size;
            page.SizeChanged += (s, e) => graph.Chart.Size = page.Size;

            // add controls
            page.Controls.Add(graph.Chart);
            tabTabs.Controls.Add(page);
        }

        #endregion

        #region Event Handling

        private void StatisticsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void StatisticsFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void StatisticsFormSizeChanged(object sender, EventArgs e)
        {
            grpFilter.Width = ScreenSize.Width - 2 * grpFilter.Location.X;

            tabTabs.Size = new Size(ScreenSize.Width - 2 * tabTabs.Location.X, ScreenSize.Height - tabTabs.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14));
        }

        #endregion
    }
}
