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

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class Options : Form
    {
        private Form parentWindow;
        private HotkeyChooser hkChooser;

        private SessionController sc;

        private UpdateForm uf;

        public enum ProxyMode { PROXY_IE, PROXY_NONE, PROXY_USER };

        private enum FileDialogType { PUTTY, PAGEANT, PAGEANT_KEYS, FILEZILLA, WINSCP };

        public Options(Form parentWindow)
        {
            this.parentWindow = parentWindow;
            InitializeComponent();
            hkChooser = new HotkeyChooser(parentWindow);
            sc = SessionController.getInstance();
            autostartCheckBox.Checked = sc.isAutoStartEnabled();

            // Create the update form
            uf = new UpdateForm();

            // Reset the proxy mode button to the save pref
            ProxyMode pm = (ProxyMode)Properties.Settings.Default.ProxyMode;
            if (pm == ProxyMode.PROXY_IE)
            {
                ieProxyRadioButton.Checked = true;
            }
            else if (pm == ProxyMode.PROXY_NONE)
            {
                directRadioButton.Checked = true;
            }
            else if (pm == ProxyMode.PROXY_USER)
            {
                userProxyRadioButton.Checked = true;
            }
            proxyServerTextBox.ReadOnly = !userProxyRadioButton.Checked;
            proxyPortTextBox.ReadOnly = !userProxyRadioButton.Checked;

            // Check if the update url is changed
            if (!urlTextBox.Text.Equals(Properties.Settings.Default.DefaultUpdateUrl))
                urlCheckBox.Checked = false;

            // Initialise the key list from the properties
            foreach (String key in Properties.Settings.Default.PageantKeyList)
            {
                keysListBox.Items.Add(key);
            }

            if (Properties.Settings.Default.LaunchPageantOnStart)
                sc.launchPageant();

            // Reset the filezilla protocol button to the save pref
            SessionController.Protocol fp = (SessionController.Protocol)Properties.Settings.Default.FileZillaProtocol;
            if (fp == SessionController.Protocol.FTP)
            {
                fzFtpRadioButton.Checked = true;
            }
            else if (fp == SessionController.Protocol.FTPS)
            {
                fzFtpsRadioButton.Checked = true;
            }
            else if (fp == SessionController.Protocol.SFTP)
            {
                fzSftpRadioButton.Checked = true;
            }
            else if (fp == SessionController.Protocol.AUTO)
            {
                fzSessionInfoRadioButton.Checked = true;
            }

            // Reset the WinSCP protocol buttons to the saved pref
            SessionController.Protocol wp = (SessionController.Protocol)Properties.Settings.Default.WinSCPProtocol;
            if (wp == SessionController.Protocol.FTP)
            {
                wsFtpRadioButton.Checked = true;
            }
            else if (wp == SessionController.Protocol.SCP)
            {
                wsScpRadioButton.Checked = true;
            }
            else if (wp == SessionController.Protocol.SFTP)
            {
                wsSftpRadioButton.Checked = true;
            }
            else if (wp == SessionController.Protocol.AUTO)
            {
                wsSessionInfoRadioButton.Checked = true;
            }

            // Reset the WinSCP pref protocol buttons to the saved pref
            SessionController.Protocol wpp = (SessionController.Protocol)Properties.Settings.Default.WinSCPPrefProtocol;
            if (wpp == SessionController.Protocol.SFTP)
            {
                wsprefSftpRadioButton.Checked = true;
            }
            else if (wpp == SessionController.Protocol.SCP)
            {
                wsprefScpRadioButton.Checked = true;
            }

            setupToolTips();
        }

        private void locatePuttyButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.PUTTY);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                puttyTextBox.Text = openFileDialog.FileName;
            }
        }

        private void chooseFontButton_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                sampletextTextbox.Font = fontDialog.Font;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void autostartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool result = sc.setAutoStart(autostartCheckBox.Checked);
            if (result == false)
            {
                MessageBox.Show(this, "Failed to set \"Start on logon\" preference"
                               , "Warning"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Warning);
            }
        }

        private void urlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            urlTextBox.ReadOnly = urlCheckBox.Checked;
            if (urlCheckBox.Checked == true)
                urlTextBox.Text = Properties.Settings.Default.DefaultUpdateUrl;
        }

        private void proxyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ieProxyRadioButton.Checked == true)
            {
                Properties.Settings.Default.ProxyMode = (int)ProxyMode.PROXY_IE;
            }
            else if (directRadioButton.Checked == true)
            {
                Properties.Settings.Default.ProxyMode = (int)ProxyMode.PROXY_NONE;
            }
            else if (userProxyRadioButton.Checked == true)
            {
                Properties.Settings.Default.ProxyMode = (int)ProxyMode.PROXY_USER;                
            }
            proxyServerTextBox.ReadOnly = !userProxyRadioButton.Checked;
            proxyPortTextBox.ReadOnly = !userProxyRadioButton.Checked;
        }

        private void checkForUpdateButton_Click(object sender, EventArgs e)
        {
            uf.ShowDialog();
        }

        private void locatePagentButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.PAGEANT);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pageantTextBox.Text = openFileDialog.FileName;
            }
        }

        private void setupOpenFileDialogue(FileDialogType fdt) 
        {
            String filename = "";
            String fileFilter = "";
            const String allFilesFilter = "|All Files|*.*";
            switch ( fdt) 
            {
                case FileDialogType.PUTTY:
                    filename = "putty.exe";
                    fileFilter = filename + "|" + filename + allFilesFilter;
                    break;
                case FileDialogType.PAGEANT:
                    filename = "pageant.exe";
                    fileFilter = filename + "|" + filename + allFilesFilter;
                    break;
                case FileDialogType.PAGEANT_KEYS:
                    filename = "";
                    fileFilter = "*.ppk|*.ppk" + allFilesFilter;
                    break;
                case FileDialogType.FILEZILLA:
                    filename = "FileZilla.exe";
                    fileFilter = filename + "|" + filename + allFilesFilter;
                    break;
                case FileDialogType.WINSCP:
                    filename = "WinSCP*.exe";
                    fileFilter = filename + "|" + filename + allFilesFilter;
                    break;
            }
            openFileDialog.FileName = filename;
            openFileDialog.Filter = fileFilter;
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.PAGEANT_KEYS);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.PageantKeyList.Add(openFileDialog.FileName);
                keysListBox.Items.Add(openFileDialog.FileName);                
            }
        }

        private void removeKeyButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PageantKeyList.Remove(keysListBox.SelectedItem.ToString());
            keysListBox.Items.Remove(keysListBox.SelectedItem);            
        }

        private void launchPageantButton_Click(object sender, EventArgs e)
        {
            String errMsg = sc.launchPageant();
            if (errMsg.Equals("") == false)
            {
                MessageBox.Show("Pageant Failed to start. Check the Pageant location.\n" +
                                errMsg
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Provide some tool tip help for various options
        /// </summary>
        private void setupToolTips()
        {
            // Options tab
            optionsToolTip.SetToolTip(autoMinimizeCheckBox, "If enabled, PSM will hide itself when a new session\n" +
                                                      "or folder of sessions is lauched");
            optionsToolTip.SetToolTip(autostartCheckBox, "Automatically start PSM on Windows login");

            // Pageant tab
            optionsToolTip.SetToolTip(addKeyButton, "Add an SSH private key(s) that will be opened\n" +
                                              "when pageant launches");
            optionsToolTip.SetToolTip(removeKeyButton, "Remove selected key from the list");
            optionsToolTip.SetToolTip(launchPageantCheckBox, "Automatically launch Pageant, with the keys listed below,\n" +
                                                             "when PSM starts");


            // Filezilla tab
            optionsToolTip.SetToolTip(enableFileZillaCheckBox, "Add support for FileZilla 2.x.\nFileZilla sessions can " +
                                  "be launched from the Session Tree.\nNOTE: FileZilla 3.x is NOT currently supported.");
            optionsToolTip.SetToolTip(fzSessionInfoRadioButton, "Use SFTP and the specified port for sessions defined as SSH,\n" +
                                  "otherwise default to FTP on port 21");
            optionsToolTip.SetToolTip(sshAuthCheckBox, "Attempt to use Pageant authentication for any SFTP sessions,\n" +
                                  "otherwise prompt for a password");

            // Update tab
        }

        /// <summary>
        /// Update the FileZillaProtocol setting when any of the radio buttons
        /// are clicked
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e"></param>
        private void protocolRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fzFtpRadioButton.Checked == true)
            {
                Properties.Settings.Default.FileZillaProtocol = (int)SessionController.Protocol.FTP;
            }
            else if (fzFtpsRadioButton.Checked == true)
            {
                Properties.Settings.Default.FileZillaProtocol = (int)SessionController.Protocol.FTPS;
            }
            else if (fzSftpRadioButton.Checked == true)
            {
                Properties.Settings.Default.FileZillaProtocol = (int)SessionController.Protocol.SFTP;
            }
            else if (fzSessionInfoRadioButton.Checked == true)
            {
                Properties.Settings.Default.FileZillaProtocol = (int)SessionController.Protocol.AUTO;
            }

            wsPrefGroupBox.Enabled = wsSessionInfoRadioButton.Checked;

            if (wsSessionInfoRadioButton.Checked == true)
            {
                Properties.Settings.Default.WinSCPProtocol = (int)SessionController.Protocol.AUTO;                
                if (wsprefScpRadioButton.Checked == true)
                {
                    Properties.Settings.Default.WinSCPPrefProtocol = (int)SessionController.Protocol.SCP;
                }
                else if (wsprefSftpRadioButton.Checked == true)
                {
                    Properties.Settings.Default.WinSCPPrefProtocol = (int)SessionController.Protocol.SFTP;
                }
            }
            else if (wsSftpRadioButton.Checked == true)
            {
                Properties.Settings.Default.WinSCPProtocol = (int)SessionController.Protocol.SFTP;
            }
            else if (wsScpRadioButton.Checked == true)
            {
                Properties.Settings.Default.WinSCPProtocol = (int)SessionController.Protocol.SCP;
            }
            else if (wsFtpRadioButton.Checked == true)
            {
                Properties.Settings.Default.WinSCPProtocol = (int)SessionController.Protocol.FTP;
            }
        }

        /// <summary>
        /// Display the filezilla file chooser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locateFileZillaButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.FILEZILLA);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filezillaTextBox.Text = openFileDialog.FileName;
            }
        }

        private void locateWinSCPButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.WINSCP);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                winSCPTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}