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

        public SessionEditorForm()
        {
            InitializeComponent();
            sc = SessionController.getInstance();           
        }

        private void sessionEditorControl1_ExportSessions(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog(this))
            {
                sc.saveSessionsToFile ( sessionEditorControl1.getSelectedSessions(),
                                        saveFileDialog1.FileName);
            }

        }   
    }
}