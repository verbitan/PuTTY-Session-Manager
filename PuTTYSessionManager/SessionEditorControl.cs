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

        protected virtual void OnExportSessions(System.EventArgs e)
        {
            if (ExportSessions != null)
            {
                ExportSessions(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

    }
}

