using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using uk.org.riseley.puttySessionManager.model;
using uk.org.riseley.puttySessionManager.controller;

namespace uk.org.riseley.puttySessionManager.control
{
    public partial class OptionsControl : UserControl
    {
        private CsvSessionImportImpl csvImporter;

        public OptionsControl()
        {
            InitializeComponent();
            csvImporter = new CsvSessionImportImpl();            
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fileRadioButton.Checked == true)
            {
                fileGroupBox.Enabled = true;
                urlGroupBox.Enabled = false;
            }
            else
            {
                fileGroupBox.Enabled = false;
                urlGroupBox.Enabled = true;
            }

        }

        internal void loadList(Session[] sessionList, Session selectedSession )
        {
            sessionComboBox.Items.AddRange(sessionList);
            if (selectedSession != null)
            {
                sessionComboBox.SelectedItem = selectedSession;
            }
        }

        private void locateFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            List<Session> sl = new List<Session>();

            try
            {
                if (fileRadioButton.Checked == true)
                {
                    sl = csvImporter.loadSessions(fileTextBox.Text);
                }
                else if (urlRadioButton.Checked == true)
                {
                    sl = csvImporter.loadSessions(urlTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                outputTextBox.Text = ex.Message;
                return;
            }

            int count = 0;
            if (sl != null)
                count = sl.Count;

            outputTextBox.Text = sl.Count + " sessions loaded...";
        }
    }
}
