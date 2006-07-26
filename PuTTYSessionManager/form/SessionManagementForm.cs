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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using uk.org.riseley.puttySessionManager.model;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class SessionManagementForm : Form
    {
        protected SessionController sc;
        private NewSessionForm nsf;

        private const string SAVE_FILE_DIALOG_TITLE = "Export PuTTY Sessions To File";


        public SessionManagementForm()
        {
            InitializeComponent();
            sc = SessionController.getInstance();
            nsf = new NewSessionForm(this);
        }


        protected DialogResult backupSessions(List<Session> selectedSessions )
        {
            DialogResult dr = MessageBox.Show("Do you want to backup " + selectedSessions.Count + " sessions to a file?"
                    , "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                exportSessions(selectedSessions);
            }
            
            return dr;            
        }

        protected void exportSessions(List<Session> selectedSessions)
        {
            if (selectedSessions.Count == 0)
            {
                MessageBox.Show("You must select some sessions to export!"
                    , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                saveFileDialog1.Title = SAVE_FILE_DIALOG_TITLE + ": " +
                                        selectedSessions.Count + " sessions selected";
            }
            if (DialogResult.OK == saveFileDialog1.ShowDialog(this))
            {

                bool result = false;
                String errorMessage = "Unknown Error";
                try
                {
                    result = sc.saveSessionsToFile(
                                         selectedSessions,
                                         saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    result = false;
                    
                }
                if ( result == false )
                    MessageBox.Show("Failed to export sessions:\n" +
                                errorMessage
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void newSession(List<Session> selectedSessions)
        {
            if (selectedSessions.Count > 0)
            {
                // Pick the first selected session to be the template 
                Session template = selectedSessions[0];
                NewSessionRequest nsr = new NewSessionRequest(template, template.FolderName, "", "", true, false);
                nsf.setNewSessionRequest(nsr);
            }

            if (nsf.ShowDialog() == DialogResult.OK)
            {
                NewSessionRequest nsr = nsf.getNewSessionRequest();
                bool result = sc.createNewSession(nsr, this);
                if (result == false)
                    MessageBox.Show("Failed to create new session: " + nsr.SessionName
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if ( nsr.LaunchSession == true )
                    {
                         String errMsg = sc.launchSession(nsr.SessionName);
                         if (errMsg.Equals("") == false)
                         {
                             MessageBox.Show("PuTTY Failed to start. Check the PuTTY location.\n" +
                                 errMsg
                                 , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                    }   
                }

            }
        }

        protected bool deleteSessions(List<Session> selectedSessions, object sender)
        {
            if (selectedSessions.Count == 0)
            {
                MessageBox.Show("You must select some sessions to delete!"
                    , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (sc.findDefaultSession(selectedSessions, true) != null)
            {
                if ( MessageBox.Show("Are you sure you want to delete the default session?"
                        , "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No )
                    return false;
            }
            DialogResult dr = backupSessions(selectedSessions);
            if ( dr == DialogResult.Cancel ) 
            {
                return false;
            }

            if (MessageBox.Show("Are you sure you want to delete " + selectedSessions.Count + " sessions?"
                    , "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool result = sc.deleteSessions(selectedSessions, sender);
                if (result == false)
                    MessageBox.Show("Failed to delete sessions - you may need to refresh the session list"
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }

            return false;
        }

        protected void formClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        protected void closeSessionManagementForm(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}