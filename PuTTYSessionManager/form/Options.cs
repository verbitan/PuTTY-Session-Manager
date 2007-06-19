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
        }

        private void locatePuttyButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.puttyLocation.Text = openFileDialog.FileName;
            }
        }

        private void chooseFontButton_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.sampletextTextbox.Font = fontDialog.Font;
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
    }
}