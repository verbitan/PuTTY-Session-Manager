/* 
 * Copyright (C) 2008 David Riseley 
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using uk.org.riseley.puttySessionManager.model;
using uk.org.riseley.puttySessionManager.model.eventargs;
using uk.org.riseley.puttySessionManager.controller;

namespace uk.org.riseley.puttySessionManager.control
{
    public partial class OptionsControl : UserControl
    {
        private CsvSessionImportImpl csvImporter;

        /// <summary>
        /// Event handler for the SyncSessionsLoaded event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SyncSessionsLoadedEventHandler(object sender, SyncSessionsLoadedEventArgs e);

        /// <summary>
        /// This event is fired when a list of session to sync has been loaded 
        /// </summary>
        [Description("Fires when sessions have been successfully loaded")]
        public event SyncSessionsLoadedEventHandler SyncSessionsLoaded;
        

        /// <summary>
        /// Constructor for OptionsControl
        /// </summary>
        public OptionsControl()
        {
            InitializeComponent();
            csvImporter = new CsvSessionImportImpl();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionList"></param>
        /// <param name="selectedSession"></param>
        internal void loadList(Session[] sessionList, Session selectedSession )
        {
            sessionComboBox.Items.AddRange(sessionList);
            if (selectedSession != null)
            {
                sessionComboBox.SelectedItem = selectedSession;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locateFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateButton_Click(object sender, EventArgs e)
        {
            List<Session> sl = null;

            try
            {
                String url = "";
                if (fileRadioButton.Checked == true)
                {
                    url = fileTextBox.Text;
                }
                else if (urlRadioButton.Checked == true)
                {
                    url = urlTextBox.Text;
                }

                sl = csvImporter.loadSessions(url);
            }
            catch (Exception ex)
            {
                outputTextBox.Text = ex.Message;
                return;
            }

            int count = 0;
            if (sl != null)
            {
                count = sl.Count;
                outputTextBox.Text = count + " sessions loaded...";
                Session sessionTemplate = (Session)sessionComboBox.SelectedItem;
                SyncSessionsLoadedEventArgs ea = new SyncSessionsLoadedEventArgs(sl, sessionTemplate,ignoreCheckBox.Checked);
                OnSyncSessionsLoaded (this, ea);
            }
        }

        /// <summary>
        /// Fire the SyncSessionsLoaded event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnSyncSessionsLoaded(Object sender, SyncSessionsLoadedEventArgs e)
        {
            if (SyncSessionsLoaded != null)
                SyncSessionsLoaded(sender, e);
        }
    }
}
