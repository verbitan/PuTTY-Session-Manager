using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using uk.org.riseley.puttySessionManager.controller;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class SynchronizeForm : SessionManagementForm
    {
        public SynchronizeForm()
            :base()
        {
            InitializeComponent();
            SessionController.SessionsRefreshedEventHandler scHandler = new SessionController.SessionsRefreshedEventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
        }

        private void SynchronizeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void SessionsRefreshed(Object sender, EventArgs e)
        {
            optionsControl1.loadList(sc.getSessionList().ToArray(), sc.findDefaultSession(false));
        }
    }
}