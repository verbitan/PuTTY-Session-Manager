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

namespace uk.org.riseley.puttySessionManager
{
    public partial class SessionControl : UserControl, uk.org.riseley.puttySessionManager.ISessionControl
    {
        public event SessionEventHandler LaunchSession;
        public delegate void SessionEventHandler(object sender, SessionEventArgs se);

        public event System.EventHandler ShowOptions;
        public event System.EventHandler ShowAbout;
        public event System.EventHandler RefreshSessions;

        public SessionControl()
        {
           InitializeComponent();
        }

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

        protected virtual void OnRefreshSessions(System.EventArgs e)
        {
            if (RefreshSessions != null)
            {
                RefreshSessions(this, e);
            }
        }

        protected void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowOptions(System.EventArgs.Empty);
        }

        protected void refreshSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSessions();
            OnRefreshSessions(System.EventArgs.Empty);
        }

        protected void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowAbout(System.EventArgs.Empty);
        }

        public virtual void getSessionMenuItems(ToolStripMenuItem parent)
        {
        }

        protected virtual void LoadSessions()
        {
        }
    }
}
