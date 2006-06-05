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
    public partial class SessionManagerForm : Form
    {
        private Options optionsDialog = new Options();
        private AboutBox aboutDialog  = new AboutBox();

        private SessionControl currentSessionControl;

        public SessionManagerForm()
        {
            InitializeComponent();
            LoadLayout();
        }

        private void LoadLayout()
        {
            this.ClientSize = Properties.Settings.Default.WindowSize;
            this.Location = Properties.Settings.Default.Location;
            displayTreeToolStripMenuItem.Checked = Properties.Settings.Default.DisplayTree;
            setDisplay();
        }

        private void SaveSize()
        {
            Properties.Settings.Default.WindowSize = this.ClientSize;
            Properties.Settings.Default.Location = this.Location;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confirmExit();
        }

        private void confirmExit()
        {
            if (MessageBox.Show(this, "Exit application?"
                                   , "Exit"
                                   , MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SessionManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            confirmExit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
            else
                this.WindowState = FormWindowState.Normal;
        }


        private void SessionManagerForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            SaveSize();
            Properties.Settings.Default.Save();
        }


        private void sessionControl_LaunchSession(object sender, SessionEventArgs se)
        {
            String puttyExec = Properties.Settings.Default.PuttyLocation;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = puttyExec;
            p.StartInfo.Arguments = "-load \"" + se.sessionName + "\"";

            bool result = false;
            String errMsg = "";
            try
            {
                result = p.Start();
            }
            catch (Exception ex)
            {
                result = false;
                errMsg = ex.Message;
                //throw;
            }
            if (!result)
            {
                MessageBox.Show("PuTTY Failed to start. Check the PuTTY location.\n" +
                                errMsg
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            p.Close();

        }

        private void sessionControl_ShowAbout(object sender, EventArgs e)
        {
            aboutDialog.ShowDialog();
        }

        private void sessionControl_ShowOptions(object sender, EventArgs e)
        {
            optionsDialog.ShowDialog();
        }

        private void displayTreeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            setDisplay();
        }

        private void setDisplay()
        {
            this.SuspendLayout();
            sessionTreeControl1.Enabled = displayTreeToolStripMenuItem.Checked;
            sessionTreeControl1.Visible = displayTreeToolStripMenuItem.Checked;
            sessionListControl1.Enabled = !displayTreeToolStripMenuItem.Checked;
            sessionListControl1.Visible = !displayTreeToolStripMenuItem.Checked;

            
            if (sessionListControl1.Enabled)
            {
                currentSessionControl = sessionListControl1;
            }
            else
            {
                currentSessionControl = sessionTreeControl1;
            }

            currentSessionControl.getSessionMenuItems(loadSessionToolStripMenuItem);

            Properties.Settings.Default.DisplayTree = displayTreeToolStripMenuItem.Checked;
            this.ResumeLayout(true);
        }

        private void sessionControl_RefreshSessions(object sender, EventArgs e)
        {
            currentSessionControl.getSessionMenuItems(loadSessionToolStripMenuItem);          
        }
    }
}