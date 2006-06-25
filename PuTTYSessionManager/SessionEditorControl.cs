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
    public partial class SessionEditorControl : uk.org.riseley.puttySessionManager.SessionControl
    {
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
    }
}

