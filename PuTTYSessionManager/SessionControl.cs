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
    public partial class SessionControl : UserControl
    {
        public event LaunchSessionEventHandler LaunchSession;
        public event System.EventHandler ExportSessions;
        public event System.EventHandler NewSession;
        public event DeleteSessionsEventHandler DeleteSessions;
 
        public delegate void LaunchSessionEventHandler(object sender, LaunchSessionEventArgs se);
        public delegate void DeleteSessionsEventHandler(object sender, CancelEventArgs ce);

        protected SessionController sc;

        public SessionControl()
        {
            sc = SessionController.getInstance();
            InitializeComponent();
            SessionController.SessionsRefreshedEventHandler scHandler = new SessionController.SessionsRefreshedEventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
        }

        protected virtual void OnLaunchSession(LaunchSessionEventArgs se)
        {
            if (LaunchSession != null)
            {
                LaunchSession(this, se);
            }
        }

        protected virtual void OnExportSessions(EventArgs e)
        {
            if (ExportSessions != null)
            {
                ExportSessions(this, e);
            }
        }

        protected virtual void OnNewSession(EventArgs e)
        {
            if (NewSession != null)
            {
                NewSession(this, e);
            }
        }

        protected virtual void OnDeleteSessions(CancelEventArgs ce)
        {
            if (DeleteSessions != null)
            {
                DeleteSessions(this, ce);
            }
        }

        public virtual void getSessionMenuItems(ToolStripMenuItem parent)
        {
        }

        protected virtual void LoadSessions()
        {
        }

        public virtual List<Session> getSelectedSessions()
        {
            List<Session> sl = new List<Session>();
            return sl;
        }

        protected SessionController getSessionController()
        {
            return sc;
        }

        public void SessionsRefreshed(Object sender, RefreshSessionsEventArgs e)
        {
            if ( !(sender.Equals(this) && e.RefreshSource == false) )
                LoadSessions();
        }
        
        public bool ContextMenuVisible
        {
            get
            {
                return (this.ContextMenuStrip == null? false:true);
            }

            set
            {
                if (value == false)
                    this.ContextMenuStrip = null;
                else
                    this.ContextMenuStrip = this.contextMenuStrip;
            }
        }

        private void refreshSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sc.invalidateSessionList(this, true);
        }
    }
}
