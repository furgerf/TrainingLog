﻿using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TrainingLog.Forms
{
    public partial class MainForm : Form
    {
        #region Public Fields

        public static MainForm Instance { get; private set; }

        public bool CloseForms { get; private set; }

        public Settings Settings { get; private set; }

        #endregion

        #region Constructor

        private MainForm()
        {
            if (Instance != null)
                throw new Exception("Shouldn\'t have been initialized before!");

            InitializeComponent();

            Instance = this;

            if (File.Exists(Settings.SettingsPath))
                Settings = Settings.LoadSettings();
            else
            {
                MessageBox.Show(
                    "Settings.xml could not be found. Please select valid settings file. It is recommended that it is moved to the directory of the executable",
                    "Settings not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var fd = new OpenFileDialog
                {InitialDirectory = Directory.GetCurrentDirectory(), Filter = "Settings file|settings.xml"};

                if (fd.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("No settings loaded, closing application...", "Exit", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    ButExitClick();
                    return;
                }
                Settings = Settings.LoadSettings(fd.FileName);
            }

            if (File.Exists(Settings.TrainingPath) && File.Exists(Settings.BiodataPath) && File.Exists(Settings.NonSportPath))
                Model.Initialize(Settings.TrainingPath, Settings.BiodataPath, Settings.NonSportPath);
            else
            {
                if (!File.Exists(Settings.TrainingPath))
                {
                    MessageBox.Show(
                        "Training log could not be found. Please select a valid log.", "Log not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    var dlg = new OpenFileDialog { InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString(), Filter = "XML-Files|*.xml" };

                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("No log loaded, closing application...", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ButExitClick();
                        return;
                    }

                    Settings.TrainingPath = dlg.FileName;
                }
                if (!File.Exists(Settings.BiodataPath))
                {
                    MessageBox.Show(
                        "Biodata log could not be found. Please select a valid log.", "Log not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    var dlg = new OpenFileDialog { InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString(), Filter = "XML-Files|*.xml" };

                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("No log loaded, closing application...", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ButExitClick();
                        return;
                    }

                    Settings.BiodataPath = dlg.FileName;
                }
                if (!File.Exists(Settings.NonSportPath))
                {
                    MessageBox.Show(
                        "Nonsport log could not be found. Please select a valid log.", "Log not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    var dlg = new OpenFileDialog { InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString(), Filter = "XML-Files|*.xml" };

                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("No log loaded, closing application...", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ButExitClick();
                        return;
                    }

                    Settings.NonSportPath = dlg.FileName;
                }

                Model.Initialize(Settings.TrainingPath, Settings.BiodataPath, Settings.NonSportPath);
            }

            EventHandler onFormHide = (s, e) =>
                                          {
                                              if (((Form) s).Visible) return;
                                              Instance.Show();
                                              Instance.BringToFront();
                                          };

            TrainingEntryForm.Instance.VisibleChanged += onFormHide;
            BiodataEntryForm.Instance.VisibleChanged += onFormHide;
            NonSportEntryForm.Instance.VisibleChanged += onFormHide;
            TrainingLogForm.Instance.VisibleChanged += onFormHide;
            StatisticsForm.Instance.VisibleChanged += onFormHide;
            SettingsForm.Instance.VisibleChanged += onFormHide;

            Closed += (s, e) => Application.Exit();

            ButShowStatisticsClick();
            //ButShowLogClick();
            //ButSettingsClick();
        }

        #endregion
        
        #region Methods

        public static void Initialize()
        {
            new MainForm();
        }

        #endregion
        
        #region Event Handling

        private void ButAddTrainingClick(object sender = null, EventArgs e = null)
        {
            Hide();
            TrainingEntryForm.Instance.Show();
            TrainingEntryForm.Instance.BringToFront();
        }

        private void ButAddBiodataClick(object sender = null, EventArgs e = null)
        {
            Hide();
            BiodataEntryForm.Instance.Show();
            BiodataEntryForm.Instance.BringToFront();
        }

        private void ButManageNonsportClick(object sender, EventArgs e)
        {
            Hide();
            NonSportEntryForm.Instance.Show();
            NonSportEntryForm.Instance.BringToFront();
        }

        private void ButShowLogClick(object sender = null, EventArgs e = null)
        {
            Hide();
            TrainingLogForm.Instance.Show();
            TrainingLogForm.Instance.BringToFront();
        }

        private void ButShowStatisticsClick(object sender = null, EventArgs e = null)
        {
            Hide();
            StatisticsForm.Instance.Show();
            StatisticsForm.Instance.BringToFront();
        }

        private void ButSettingsClick(object sender = null, EventArgs e = null)
        {
            Hide();
            SettingsForm.Instance.Show();
            SettingsForm.Instance.BringToFront();
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForms = true;

            TrainingEntryForm.Instance.Close();
            BiodataEntryForm.Instance.Close();
            NonSportEntryForm.Instance.Close();
            TrainingLogForm.Instance.Close();
            StatisticsForm.Instance.Close();
            SettingsForm.Instance.Close();
        }

        private void ButExitClick(object sender = null, EventArgs e = null)
        {
            Close();
        }

        #endregion
    }
}
