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


namespace uk.org.riseley.puttySessionManager
{
    public partial class HotkeyChooser : Form
    {
        private Form parentWindow;
        public HotkeyChooser(Form parent)
        {
            parentWindow = parent;
            InitializeComponent();
            hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (hotkeyCheckBox.Checked == false)
                hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
            this.Close();
        }

        private void hotkeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hotkeyCheckBox.Checked == false)
            {
                bool result = HotkeyController.UnregisterHotKey(parentWindow);
                if (result == false)
                {
                    MessageBox.Show(this, "Failed to unregister hotkey"
                                   , "Warning"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Warning);
                }
                hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
            }
            else
            {
                if ( hotKeyTextBox.Text.Length != 1 ) {
                    MessageBox.Show(this, "Hotkey must be specified"
                                   , "Warning"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Warning);                    
                    hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
                    hotkeyCheckBox.Checked = false;
                }
                else
                {
                    char newHotkey = hotKeyTextBox.Text.ToUpper().ToCharArray(0,1)[0];
                    bool result = HotkeyController.RegisterHotkey(parentWindow, newHotkey, HotkeyController.HotKeyId.HKID_NEW);
                    if (result == false)
                    {
                        MessageBox.Show(this, "Failed to register hotkey"
                                       , "Warning"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Warning);
                        hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
                        hotkeyCheckBox.Checked = false;
                    } else 
                    {
                        Properties.Settings.Default.HotkeyNewSession = hotKeyTextBox.Text.ToUpper();
                        hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
                    }
                }
                
            }
        }       
    }
}