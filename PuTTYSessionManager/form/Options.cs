/* 
 * Copyright (C) 2006,2007 David Riseley 
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
using System.IO;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class Options : Form
    {
        private Form parentWindow;
        private HotkeyChooser hkChooser;

        private SessionController sc;

        private UpdateForm uf;

        public enum ProxyMode { PROXY_IE, PROXY_NONE, PROXY_USER };

        private enum FileDialogType { PUTTY, PAGEANT, PAGEANT_KEYS, FILEZILLA, WINSCP, WINSCPINI };

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

            // Reset the WinSCP Version buttons to the saved pref
            int wsVer = Properties.Settings.Default.WinSCPVersion;
            if (wsVer == 3)
            {
                wsVer3RadioButton.Checked = true;
            }
            else if (wsVer == 4)
            {
                wsVer4RadioButton.Checked = true;
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

            // Call the wsVerRadioButton_CheckedChanged method
            // to ensure only a valid combination of protocol and
            // version is displayed
            wsVerRadioButton_CheckedChanged(this, EventArgs.Empty);

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
            if (sender == chooseDialogFontButton)
            {
                fontDialog.Font = Properties.Settings.Default.DialogFont;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    sampleDialogTextbox.Font = fontDialog.Font;
                }
            }
            else if (sender == chooseTreeFontButton)
            {
                fontDialog.Font = Properties.Settings.Default.TreeFont;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    sampleTreeTextbox.Font = fontDialog.Font;
                }
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
            String currentFile = "";
            const String allFilesFilter = "|All Files|*.*";
            switch ( fdt) 
            {
                case FileDialogType.PUTTY:
                    filename = "putty.exe";
                    currentFile = Properties.Settings.Default.PuttyLocation;
                    break;
                case FileDialogType.PAGEANT:
                    filename = "pageant.exe";
                    currentFile = Properties.Settings.Default.PageantLocation;
                    break;
                case FileDialogType.PAGEANT_KEYS:
                    filename = "*.ppk";
                    break;
                case FileDialogType.FILEZILLA:
                    filename = "FileZilla.exe";
                    currentFile = Properties.Settings.Default.FileZillaLocation;
                    break;
                case FileDialogType.WINSCP:
                    filename = "WinSCP*.exe";
                    currentFile = Properties.Settings.Default.WinSCPLocation;
                    break;
                case FileDialogType.WINSCPINI:
                    filename = "*.ini";
                    currentFile = Properties.Settings.Default.WinSCPIniLocation;
                    break;
            }

            // Attempt to set the working directory
            string directory = "";
            if ( currentFile != null && !currentFile.Equals("") )
                directory = Path.GetFullPath(currentFile);
            if (File.Exists(directory))
                openFileDialog.InitialDirectory = directory;

            // And the filename
            openFileDialog.FileName = filename;

            // And the file filter
            fileFilter = filename + "|" + filename + allFilesFilter;
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
            // General tab
            optionsToolTip.SetToolTip(autoMinimizeCheckBox, "If enabled, PSM will hide itself when a new session\n" +
                                                      "or folder of sessions is lauched");
            optionsToolTip.SetToolTip(autostartCheckBox, "Automatically start PSM on Windows login");
            optionsToolTip.SetToolTip(taskbarCheckBox, "Show PSM in the taskbar when the window is visible");

            
            // Tree tab
            optionsToolTip.SetToolTip(numericUpDown1, "Threshold for warning when using \"Launch Folder\" or \n" +
                                                      "\"Launch Folder and Subfolders\" from the tree view");
            optionsToolTip.SetToolTip(expandTreeCheckBox, "The tree view will be fully expanded on startup.\n" +
                                                          "Not recommended if you have 100's of sessions.");
            optionsToolTip.SetToolTip(chooseDialogFontButton, "Set the font for all dialogs in the application.\n" +
                                                              "Warning: This may upset the dialog layouts.\n" +
                                                              "You are advised to restart after altering this");
            optionsToolTip.SetToolTip(displayTreeIconsCheckBox, "Display icons in the tree view.\n");
            optionsToolTip.SetToolTip(toolTipsCheckBox, "Enable the display of the session information\n" +
                                                        "in tooltips in the tree view");
                                                                

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

            // WinSCP tab
            optionsToolTip.SetToolTip(useWinSCPIniCheckBox,"Pass the /ini option to WinSCP.\n" +
                                   "Use the ini file in the location specified below." );


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

        /// <summary>
        /// Display the WinSCP file chooser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locateWinSCPButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.WINSCP);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                winSCPTextBox.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Display the WinSCP ini file chooser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locateWinSCPIniButton_Click(object sender, EventArgs e)
        {
            setupOpenFileDialogue(FileDialogType.WINSCPINI);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                winSCPIniTextBox.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Listener for the Checked Changed event from the
        /// WinSCP Version radio buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wsVerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            wsFtpRadioButton.Enabled = wsVer3RadioButton.Checked;
            if (wsVer3RadioButton.Checked == true)
            {
                Properties.Settings.Default.WinSCPVersion = 3;
                wsFtpRadioButton.Enabled = false;
                // FTP is not supported in WinSCP v3.x
                // so switch preference to SFTP
                if (wsFtpRadioButton.Checked == true)
                {
                    wsSftpRadioButton.Checked = true;
                    Properties.Settings.Default.WinSCPProtocol = (int)SessionController.Protocol.SFTP;
                }
            }
            else if (wsVer4RadioButton.Checked == true)
            {
                wsFtpRadioButton.Enabled = true;
                Properties.Settings.Default.WinSCPVersion = 4;
            }
        }

        /// <summary>
        /// Event handler for displayTreeIconsCheckBox Click event
        /// Send a refresh request to the tree view when this value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayTreeIconsCheckBox_Click(object sender, EventArgs e)
        {
            sc.invalidateSessionList(this, false);
        }
    }
}