using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using uk.org.riseley.puttySessionManager.model;

namespace uk.org.riseley.puttySessionManager.control
{
    public partial class OptionsControl : UserControl
    {
        public OptionsControl()
        {
            InitializeComponent();
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
    }
}
