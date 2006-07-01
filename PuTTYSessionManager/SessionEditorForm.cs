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

namespace uk.org.riseley.puttySessionManager
{
    public partial class SessionEditorForm : Form
    {
        private SessionController sc;
        private NewSessionForm nsf;
        private CopySessionForm csf;

        public SessionEditorForm()
        {
            InitializeComponent();
            sc = SessionController.getInstance();
            nsf = new NewSessionForm(this);
            csf = new CopySessionForm(this);
        }

        private void sessionEditorControl1_ExportSessions(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog(this))
            {

                bool result = false;
                String errorMessage = "Unknown Error";
                try
                {
                    result = sc.saveSessionsToFile(
                                         sessionEditorControl1.getSelectedSessions(),
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

        private void sessionEditorControl1_NewSession(object sender, EventArgs e)
        {
            if (nsf.ShowDialog() == DialogResult.OK)
            {
                NewSessionRequest nsr = nsf.getNewSessionRequest();
                bool result = sc.createNewSession(nsr);
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

        private void sessionEditorControl1_DeleteSessions(object sender, EventArgs e)
        {
            List<Session> sl = sessionEditorControl1.getSelectedSessionsList();
            if (sc.findDefaultSession(sl) != null)
            {
                MessageBox.Show("Cannot delete default session"
                        , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Do you want to backup " + sl.Count + " sessions to a file?"
                    , "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ( dr == DialogResult.Yes)
            {
                sessionEditorControl1_ExportSessions(sender, e);
            } 
            else if ( dr == DialogResult.Cancel ) 
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete " + sl.Count + " sessions?"
                    , "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool result = sc.deleteSessions(sessionEditorControl1.getSelectedSessionsList());
                if (result == false)
                    MessageBox.Show("Failed to delete sessions"
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sessionEditorControl1_CopySessionAttributes(object sender, EventArgs e)
        {
            csf.ShowDialog();
        }   
    }
}