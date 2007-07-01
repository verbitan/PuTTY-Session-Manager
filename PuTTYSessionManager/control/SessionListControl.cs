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
using uk.org.riseley.puttySessionManager.model;

namespace uk.org.riseley.puttySessionManager.control
{
    public partial class SessionListControl : SessionControl
    {

        ToolStripMenuItem[] tsmiArray;

        public SessionListControl() : base()
        {
            InitializeComponent();
        }

        
        protected override void LoadSessions()
        {
            // Suppress repainting the ListBox until all the objects have been created.
            listBox1.BeginUpdate();

            // Clear out the current tree
            listBox1.Items.Clear();

            // Add the contents of the list to the list box
            listBox1.Items.AddRange(getSessionController().getSessionList().ToArray());

            // Sort the list
            listBox1.Sorted = true;

            // Select the first session
            if ( listBox1.Items.Count > 0 )
                listBox1.SelectedIndex = 0;

            // Begin repainting the TreeView.
            listBox1.EndUpdate();

            tsmiArray = new ToolStripMenuItem[getSessionController().getSessionList().Count];
            int i=0;
            foreach (Session s in getSessionController().getSessionList())
            {
                tsmiArray[i] = new ToolStripMenuItem(s.SessionDisplayText, null, listBox1_DoubleClick);
                i++;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string sessionName = null;

            if ( sender is ListBox ) {
                Session s = (Session)((ListBox)sender).SelectedItem;
                sessionName = s.SessionDisplayText;
            }
            else if (sender is ToolStripMenuItem)
            {
                sessionName = ((ToolStripMenuItem)sender).Text;
            }

            if ( sessionName != null)
                OnLaunchSession(new LaunchSessionEventArgs(sessionName));
            else
                OnLaunchSession(new LaunchSessionEventArgs());
        }

        public override void getSessionMenuItems(ToolStripMenuItem parent)
        {
            parent.DropDownItems.Clear();
            if ( tsmiArray != null )
                parent.DropDownItems.AddRange(tsmiArray);            
        }

        public override List<Session> getSelectedSessions()
        {
            List<Session> sl = new List<Session>();
            Session s = (Session)listBox1.SelectedItem;
            if ( s != null )
                sl.Add(s);
            return sl;
        }

        /// <summary>
        /// Event handler for key press from the list view
        /// If ENTER is pressed launch that session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Session s = (Session)listBox1.SelectedItem;
                if (s != null)
                {
                    OnLaunchSession(new LaunchSessionEventArgs(s.SessionDisplayText));
                    e.Handled = true;
                }
            }
        }
    }
}
