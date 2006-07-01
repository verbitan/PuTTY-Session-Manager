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
    public partial class CopySessionForm : Form
    {
        private Form parentWindow;
        private SessionController sc;

        public CopySessionForm(Form parent)
        {
            parentWindow = parent;
            sc = SessionController.getInstance();
            InitializeComponent();
            SessionController.SessionsRefreshedEventHandler scHandler = new SessionController.SessionsRefreshedEventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
        }

        private void loadList()
        {
            sessionComboBox.Items.AddRange(sc.getSessionList().ToArray());
            sessionComboBox.SelectedItem = sc.findDefaultSession();
        }

        private void clearList()
        {
            sessionComboBox.Items.Clear();
        }

        public void SessionsRefreshed(Object sender, EventArgs e)
        {
            clearList();
            loadList();
        }

        public void getCopySessionRequest()
        {
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            /*if (sessionnameTextBox.Text.Equals(""))
            {
                MessageBox.Show("You must specify a session name."
                  , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else if (sc.findSession(sessionnameTextBox.Text) != null)
            {
                MessageBox.Show("Session: " + sessionnameTextBox.Text +
                                " already exists.\nPlease choose another name."
                  , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to create: " + sessionnameTextBox.Text 
                            ,"Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    DialogResult = DialogResult.None;
             
            }*/

        }

        private void copyAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            attributesGroupBox.Enabled = !(copyAllRadioButton.Checked);
        }

    }
}