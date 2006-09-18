using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class UpdateForm : Form
    {
        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public UpdateForm()
        {
            InitializeComponent();
            currVersionTextBox.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            urlToolTip.SetToolTip(sfLinkLabel, sfLinkLabel.Text);
        }

        /// <summary>
        /// Event handler for the CheckChanged event for the proxyCheckBox
        /// Enable the proxy group box when the check box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void proxyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            proxyGroupBox.Enabled = proxyCheckBox.Checked;
        }

        /// <summary>
        /// Event handler for the Click event for the checkForUpdateButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void checkForUpdateButton_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            Stream stream = null;

            // Clear out the text box
            resultsTextBox.Text = "";
            resultsTextBox.Refresh();

            try
            {
                resultsTextBox.Text = "Attempting to contact update url:" + Environment.NewLine;
                resultsTextBox.Text = resultsTextBox.Text + urlTextBox.Text + Environment.NewLine;
                stream = wc.OpenRead(urlTextBox.Text);
            }
            catch (WebException we)
            {
                resultsTextBox.Text = resultsTextBox.Text + we.Message + Environment.NewLine;
                if (stream != null)
                    stream.Close();
                return;
            }
            StreamReader sr = new StreamReader(stream);
            string line = sr.ReadLine();
            resultsTextBox.Text = resultsTextBox.Text + Environment.NewLine + "Connected.";

            bool foundLatestVersion = false;
            bool foundUpdateUrl = false;
            bool foundReleaseDate = false;
            bool foundOther = false;

            for (int i = 0; i < 3 && line != null; i++)
            {
                if (line.StartsWith("LatestVersion|"))
                {
                    availVersionTextBox.Text = line.Substring(line.IndexOf('|') + 1);
                    resultsTextBox.Text = resultsTextBox.Text + Environment.NewLine + "Got latest version...";
                    foundLatestVersion = true;
                }
                else if (line.StartsWith("UpdateUrl|"))
                {
                    sfLinkLabel.Text = line.Substring(line.IndexOf('|') + 1);
                    urlToolTip.SetToolTip(sfLinkLabel, sfLinkLabel.Text);
                    resultsTextBox.Text = resultsTextBox.Text + Environment.NewLine + "Got update url...";
                    foundUpdateUrl = true;
                }
                else if (line.StartsWith("ReleaseDate|"))
                {
                    resultsTextBox.Text = resultsTextBox.Text + Environment.NewLine + "Got release date...";
                    foundReleaseDate = true;
                }
                else
                {
                    foundOther = true;
                }
                resultsTextBox.Refresh();
                line = sr.ReadLine();
            }
            sr.Close();
            stream.Close();

            if (foundLatestVersion && foundReleaseDate && foundUpdateUrl && !foundOther)
            {
                resultsTextBox.Text = resultsTextBox.Text + Environment.NewLine + "Complete.";
            }
             
        }

        private void urlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            urlTextBox.ReadOnly = urlCheckBox.Checked;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            // Clear out the text box
            resultsTextBox.Text = "";
            resultsTextBox.Refresh();
        }

        private void sfLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(sfLinkLabel.Text);
        }
    }
}