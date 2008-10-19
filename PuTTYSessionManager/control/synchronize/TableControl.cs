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
    public partial class TableControl : UserControl
    {
        private SessionController sc;

        private List<Session> sessionList;
        private Session templateSession;
        private bool ignoreExistingSessions = false;

        private const string ACTION_UPDATE = "Update";
        private const string ACTION_IGNORE = "Ignore";

        private enum STATUS
        {
             NEW
           , DELETED
           , MODIFIED
           , UNMODIFIED
        };

        /// <summary>
        /// Event handler for the SyncSessionsRequested event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SyncSessionsRequestedEventHandler(object sender, SyncSessionsRequestedEventArgs e);

        /// <summary>
        /// This event is fired when a the user wishes to sync sessions 
        /// </summary>
        [Description("Fires when sessions have been successfully loaded")]
        public event SyncSessionsRequestedEventHandler SyncSessionsRequested;


        public TableControl()
        {
            InitializeComponent();
            sc = SessionController.getInstance();
        }

        public void LoadSessions(SyncSessionsLoadedEventArgs ea)
        {
            DataGridViewRow dgvr = null;
           
            sessionList = ea.SessionList;
            templateSession = ea.SessionTemplate;
            ignoreExistingSessions = ea.IgnoreExistingSessions;

            Dictionary<String,Session> sessionsDictionary = new Dictionary<string,Session>();

            dataGridView1.SuspendLayout();
            dataGridView1.Rows.Clear();

            foreach (Session s in sessionList)
            {
                Session existingSession = sc.findSessionByKey(s.SessionKey);
                dgvr = new DataGridViewRow();
                dgvr.CreateCells(dataGridView1, getCellValues(s,existingSession));
                dgvr.Tag = s;
                dataGridView1.Rows.Add(dgvr);
                sessionsDictionary.Add(s.SessionKey,s);
            }

            if (ea.IgnoreExistingSessions == false)
            {
                foreach (Session s in sc.getSessionList())
                {
                    if (!sessionsDictionary.ContainsKey(s.SessionKey))
                    {
                        dgvr = new DataGridViewRow();
                        dgvr.CreateCells(dataGridView1, getCellValues(null,s));
                        dgvr.Tag = s;
                        dataGridView1.Rows.Add(dgvr);
                    }
                }
            }

            dataGridView1.ResumeLayout();
        }

        private String [] getCellValues( Session newSession , Session existingSession )
        {
            STATUS s = getStatus(newSession, existingSession);

            string sessionName = "";
            string newSessionFolder = "";
            string existingSessionFolder = "";
            string newSessionHostname = "";
            string existingSessionHostname = "";

            if (newSession != null)
            {
                sessionName = newSession.SessionDisplayText;
                newSessionFolder = newSession.FolderDisplayText;
                newSessionHostname = newSession.Hostname;
            }

            if (existingSession != null)
            {
                sessionName = existingSession.SessionDisplayText;
                existingSessionFolder = existingSession.FolderDisplayText;
                existingSessionHostname = existingSession.Hostname;
            }

            String[] cellValues = new String[] {    sessionName
                                                  , existingSessionFolder
                                                  , newSessionFolder
                                                  , existingSessionHostname
                                                  , newSessionHostname
                                                  , getStatusDescription(s)
                                                  , getAction(s)
                                                };
            return cellValues;                                                              
        }


        private String getStatusDescription (STATUS s)
        {
            switch (s)
            {
                case STATUS.DELETED:    { return "Deleted"; }
                case STATUS.NEW:        { return "New"; }
                case STATUS.MODIFIED:   { return "Changed"; }
                case STATUS.UNMODIFIED: { return "Unchanged"; }
                default:                { return "Unchanged"; }
            }
        }

        private String getAction(STATUS s)
        {
            switch (s)
            {
                case STATUS.DELETED:    { return ACTION_UPDATE; }
                case STATUS.NEW:        { return ACTION_UPDATE; }
                case STATUS.MODIFIED:   { return ACTION_UPDATE; }
                case STATUS.UNMODIFIED: { return ACTION_IGNORE; }
                default:                { return ACTION_IGNORE; }
            }
        }

        private STATUS getStatus( Session newSession , Session existingSession )
        {
            if ( newSession == null )
                return STATUS.DELETED;
            else if ( existingSession == null )
                return STATUS.NEW;
            else if ( (newSession.Hostname.Equals   ( existingSession.Hostname ) ) &&
                      (newSession.FolderName.Equals ( existingSession.FolderName)) )
                return STATUS.UNMODIFIED;
            else
                return STATUS.MODIFIED;
        }

        private void amendActions(string action)
        {
            dataGridView1.SuspendLayout();
            foreach (DataGridViewRow dvgr in dataGridView1.Rows)
            {
                if (dvgr.Selected)
                {
                    dvgr.Cells["actionColumn"].Value = action;
                }
            }
            dataGridView1.ResumeLayout();
        }
       

        private void resetButton_Click(object sender, EventArgs e)
        {
            LoadSessions(new SyncSessionsLoadedEventArgs(sessionList, templateSession, ignoreExistingSessions));
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            amendActions(ACTION_UPDATE);
        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            amendActions(ACTION_IGNORE);
        }

        private void removeUnchangedButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            // First find all the rows to remove
            foreach (DataGridViewRow dvgr in dataGridView1.Rows)
            {
                if (dvgr.Cells["statusColumn"].Value.Equals("Unchanged"))
                    rowsToRemove.Add(dvgr);
            }

            // Then susupend the layout and remove the rows
            dataGridView1.SuspendLayout();
            foreach (DataGridViewRow dvgr in rowsToRemove)
            {
                dataGridView1.Rows.Remove(dvgr);
            }
            dataGridView1.ResumeLayout();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {

        }
    }
}
