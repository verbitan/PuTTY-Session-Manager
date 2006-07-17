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
    public partial class SessionEditorForm : SessionManagementForm
    {
        private CopySessionForm csf;
 
        public SessionEditorForm()
            : base()
        {
            InitializeComponent();
            csf = new CopySessionForm(this);
        }

        private void sessionEditorControl1_ExportSessions(object sender, EventArgs e)
        {
            exportSessions(sessionEditorControl1, sender, e);
        }

        private void sessionEditorControl1_NewSession(object sender, EventArgs e)
        {
            newSession(sessionEditorControl1, sender, e);
        }

        private void sessionEditorControl1_DeleteSessions(object sender, EventArgs e)
        {
            deleteSessions(sessionEditorControl1, sender, e);
        }

        private void sessionEditorControl1_CopySessionAttributes(object sender, EventArgs e)
        {
            List<Session> sl = sessionEditorControl1.getSelectedSessionsList();
            if (sl.Count == 0)
            {
                MessageBox.Show("You must select some target sessions!"
                    , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pass in the target sessions
            csf.setTargetSessions(sl);

            if (csf.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Attributes copied successfully"
                        , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }            
        }

        private void SessionEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formClosing(sender, e);
        }

        private void sessionEditorControl1_CloseSessionEditor(object sender, EventArgs e)
        {
            closeSessionManagementForm(sender, e);
        }
    }
}