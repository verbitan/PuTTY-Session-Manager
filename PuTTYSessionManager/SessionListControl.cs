/* 
 * Copyright (C) 2006 David Riseley 
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
using Microsoft.Win32;
using uk.org.riseley.puttySessionManager.model;

namespace uk.org.riseley.puttySessionManager
{
    public partial class SessionListControl : UserControl
    {
        public event SessionEventHandler LaunchSession;
        public delegate void SessionEventHandler(object sender, SessionEventArgs se);

        public event System.EventHandler ShowOptions;
        public event System.EventHandler ShowAbout;

        protected virtual void OnLaunchSession(SessionEventArgs se)
        {
            if (LaunchSession != null)
            {
                LaunchSession(this, se);
            }
        }

        protected virtual void OnShowOptions(System.EventArgs e)
        {
            if (ShowOptions != null)
            {
                ShowOptions(this, e);
            }
        }

        protected virtual void OnShowAbout(System.EventArgs e)
        {
            if (ShowAbout != null)
            {
                ShowAbout(this, e);
            }
        }

        public SessionListControl()
        {
            InitializeComponent();
            LoadList();
        }


        private void LoadList()
        {

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(Session.PUTTY_SESSIONS_REG_KEY);

            // Suppress repainting the ListBox until all the objects have been created.
            listBox1.BeginUpdate();

            // Clear out the current tree
            listBox1.Items.Clear();

            foreach (string keyName in rk.GetSubKeyNames())
            {
                RegistryKey sessKey = rk.OpenSubKey(keyName);

                String pempath = (String)sessKey.GetValue(Session.PUTTY_PSM_FOLDER_VALUE);

                Session s = new Session(keyName, pempath, false);

                listBox1.Items.Add(s);

                sessKey.Close();
            }
            rk.Close();

            // Sort the list
            listBox1.Sorted = true;

            // Select the first session
            if ( listBox1.Items.Count > 0 )
                listBox1.SelectedIndex = 0;

            // Begin repainting the TreeView.
            listBox1.EndUpdate();

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Session s = (Session)((ListBox)sender).SelectedItem;
            if ( s != null )
                OnLaunchSession(new SessionEventArgs(s.SessionDisplayText));
            else
                OnLaunchSession(new SessionEventArgs());
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowOptions(System.EventArgs.Empty);
        }

        private void refreshSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowAbout(System.EventArgs.Empty);
        }
    }
}
