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
using System.Collections;

namespace uk.org.riseley.puttySessionManager
{
    public partial class SessionEditorControl : uk.org.riseley.puttySessionManager.SessionControl
    {

        public event System.EventHandler ExportSessions;
        public event System.EventHandler NewSession;
        public event System.EventHandler DeleteSessions;
        public event System.EventHandler CopySessionAttributes;
        public event System.EventHandler CloseSessionEditor;

        public SessionEditorControl()
        {
            InitializeComponent();
        }

        
        protected override void LoadSessions()
        {
            DataGridViewRow dgvr = null;

            dataGridView1.SuspendLayout();
            dataGridView1.Rows.Clear();

            foreach (Session s in getSessionController().getSessionList())
            {

                dgvr = new DataGridViewRow();
                dgvr.CreateCells(dataGridView1, s.getCellValues());
                dgvr.Tag = s;
                dataGridView1.Rows.Add(dgvr);

            }

            dataGridView1.ResumeLayout();
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

        protected virtual void OnDeleteSessions(EventArgs e)
        {
            if (DeleteSessions != null)
            {
                DeleteSessions(this, e);
            }
        }

        protected virtual void OnCopySessionAttributes(EventArgs e)
        {
            if (CopySessionAttributes != null)
            {
                CopySessionAttributes(this, e);
            }
        }

        protected virtual void OnCloseSessionEditor(EventArgs e)
        {
            if (CloseSessionEditor != null)
            {
                CloseSessionEditor(this, e);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            OnExportSessions(e);
        }

        public Session[] getSelectedSessions()
        {
            Session[] sarr = new Session[dataGridView1.SelectedRows.Count];
            int i=0;

            IEnumerator ie = dataGridView1.SelectedRows.GetEnumerator();
            while ( ie.MoveNext() )
            {
                DataGridViewRow dgvr = (DataGridViewRow)ie.Current;
                sarr[i] = (Session)dgvr.Tag;
                i++;
            }
            return sarr;
        }

        public List<Session> getSelectedSessionsList()
        {
            List<Session> sl = new List<Session> ();
            sl.AddRange(getSelectedSessions());
            return sl;
        }


        private void newSessionButton_Click(object sender, EventArgs e)
        {
            OnNewSession(e);
        }

        private void deleteSesssionsButton_Click(object sender, EventArgs e)
        {
            OnDeleteSessions(e);
        }

        private void copySessionAttribButton_Click(object sender, EventArgs e)
        {
            OnCopySessionAttributes(e);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            OnCloseSessionEditor(e);
        }

    }
}

