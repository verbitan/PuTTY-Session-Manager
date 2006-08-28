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
using uk.org.riseley.puttySessionManager.controller;
using uk.org.riseley.puttySessionManager.control;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class SessionManagerForm : SessionManagementForm
    {
        private Options optionsDialog;
        private AboutBox aboutDialog;
        private SessionEditorForm sessionEditor;
        private HotkeyChooser hotKeyChooser;

        private SessionControl currentSessionControl;
        private SessionControl hiddenSessionControl;

        private HotkeyController hkc;

        public SessionManagerForm()
            : base()
        {
            InitializeComponent();
            hkc = HotkeyController.getInstance();
            LoadLayout();
            SessionController.SessionsRefreshedEventHandler scHandler = new SessionController.SessionsRefreshedEventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
        }

        private void LoadLayout()
        {
            optionsDialog = new Options(this);
            aboutDialog = new AboutBox();
            sessionEditor = new SessionEditorForm();
            hotKeyChooser = new HotkeyChooser(this);

            // Restore the size of the application
            this.ClientSize = Properties.Settings.Default.WindowSize;

            // Restore the location of the application
            Point savedLocation = Properties.Settings.Default.Location;

            // Get the screen that will display the point
            Screen display = Screen.FromPoint(savedLocation);

            // Check that the selected display contains the point
            // if not - restore the application in the top left hand corner
            if (display != null && display.Bounds.Contains(savedLocation))
                this.DesktopLocation = Properties.Settings.Default.Location;
            else
                this.DesktopLocation = new Point(0, 0);

            displayTreeToolStripMenuItem.Checked = Properties.Settings.Default.DisplayTree;
            if (Properties.Settings.Default.HotkeyNewEnabled)
                hkc.RegisterHotkey(this, Properties.Settings.Default.HotkeyNewSession.ToCharArray(0, 1)[0], HotkeyController.HotKeyId.HKID_NEW);
            sc.invalidateSessionList(this, true); 
            setDisplay();
        }

        private void SaveSize()
        {
            Properties.Settings.Default.WindowSize = this.ClientSize;
            Properties.Settings.Default.Location = this.DesktopLocation;
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
                systrayIcon.Visible = false;
                optionsDialog.Close();
                aboutDialog.Close();
                sessionEditor.Close();
                hotKeyChooser.Close();
                Application.Exit();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
            if ( this.Visible == true && this.WindowState == FormWindowState.Minimized )
                 this.WindowState = FormWindowState.Normal;
        }


        private void SessionManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
            else
            {
                hkc.UnregisterHotKey(this);
                SaveSize();
                Properties.Settings.Default.Save();
            }
        }


        private void sessionControl_LaunchSession(object sender, LaunchSessionEventArgs se)
        {

            String errMsg = sc.launchSession(se.sessionName);
            if (errMsg.Equals("") == false)
            {
                MessageBox.Show("PuTTY Failed to start. Check the PuTTY location.\n" +
                                errMsg
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayTreeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            setDisplay();
        }

        private void setDisplay()
        {

            if (displayTreeToolStripMenuItem.Checked == true)
            {
                currentSessionControl = sessionTreeControl1;
                hiddenSessionControl = sessionListControl1;
            }
            else
            {
                currentSessionControl = sessionListControl1;
                hiddenSessionControl = sessionTreeControl1;            
            }

            this.SuspendLayout();
            
            currentSessionControl.Enabled = true;
            currentSessionControl.Visible = true;
            hiddenSessionControl.Enabled = false;
            hiddenSessionControl.Visible = false;                     
                       
            this.ResumeLayout(true);

            currentSessionControl.getSessionMenuItems(loadSessionToolStripMenuItem);

            Properties.Settings.Default.DisplayTree = displayTreeToolStripMenuItem.Checked;

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == hkc.WM_HOTKEY)
                processHotKey((int) m.WParam);               
            base.WndProc(ref m);
        }

        private void processHotKey(int id)
        {
            String sessionName = "";
            switch (id)
            {
                case (int) HotkeyController.HotKeyId.HKID_NEW:
                    sessionName = "";
                    break;
                case (int)HotkeyController.HotKeyId.HKID_SESSION_1:
                    sessionName = Session.convertSessionKeyToDisplay(Properties.Settings.Default.FavouriteSession1);
                    break;
                case (int)HotkeyController.HotKeyId.HKID_SESSION_2:
                    sessionName = Session.convertSessionKeyToDisplay(Properties.Settings.Default.FavouriteSession2); 
                    break;
                case (int)HotkeyController.HotKeyId.HKID_SESSION_3:
                    sessionName = Session.convertSessionKeyToDisplay(Properties.Settings.Default.FavouriteSession3); 
                    break;
                case (int)HotkeyController.HotKeyId.HKID_SESSION_4:
                    sessionName = Session.convertSessionKeyToDisplay(Properties.Settings.Default.FavouriteSession4); 
                    break;
                case (int)HotkeyController.HotKeyId.HKID_SESSION_5:
                    sessionName = Session.convertSessionKeyToDisplay(Properties.Settings.Default.FavouriteSession5); 
                    break;
            }
            sessionControl_LaunchSession(this, new LaunchSessionEventArgs(sessionName));
        }

        public void SessionsRefreshed(object sender, RefreshSessionsEventArgs re)
        {
            currentSessionControl.getSessionMenuItems(loadSessionToolStripMenuItem);          
        }

        private void refreshSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sc.invalidateSessionList(this, true); 
        }

        private void sessionControl_ShowAbout(object sender, EventArgs e)
        {
            aboutDialog.ShowDialog();
        }

        private void sessionControl_ShowOptions(object sender, EventArgs e)
        {
            optionsDialog.ShowDialog();
        }

        private void sessionEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sessionEditor.Show();
        }

        private void sessionHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hotKeyChooser.Show();
        }

        private void sessionTreeControl1_ExportSessions(object sender, EventArgs e)
        {
            exportSessions(currentSessionControl.getSelectedSessions());
        }

        private void sessionTreeControl1_BackupSessions(object sender, EventArgs e)
        {
            backupSessions(currentSessionControl.getSelectedSessions());
        }

        private void sessionTreeControl1_DeleteSessions(object sender, CancelEventArgs ce)
        {
            bool result = deleteSessions(currentSessionControl.getSelectedSessions(), sender);
            // if the delete failed or aborted cancel the event
            ce.Cancel = !(result);
        }
    }
}