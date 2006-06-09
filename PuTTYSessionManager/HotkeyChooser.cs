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
        private SessionController sc;

        public HotkeyChooser(Form parent)
        {
            parentWindow = parent;
            sc = SessionController.getInstance();
            InitializeComponent();
            hotKeyTextBox.Text = Properties.Settings.Default.HotkeyNewSession;
            System.EventHandler scHandler = new EventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
        }

        private void loadLists()
        {
            comboBox1.Items.AddRange(sc.getSessionList().ToArray());
            comboBox1.SelectedItem = sc.findSesssion(Properties.Settings.Default.FavouriteSession1);
            comboBox2.Items.AddRange(sc.getSessionList().ToArray());
            comboBox2.SelectedItem = sc.findSesssion(Properties.Settings.Default.FavouriteSession2);
            comboBox3.Items.AddRange(sc.getSessionList().ToArray());
            comboBox3.SelectedItem = sc.findSesssion(Properties.Settings.Default.FavouriteSession3);
            comboBox4.Items.AddRange(sc.getSessionList().ToArray());
            comboBox4.SelectedItem = sc.findSesssion(Properties.Settings.Default.FavouriteSession4);
            comboBox5.Items.AddRange(sc.getSessionList().ToArray());
            comboBox5.SelectedItem = sc.findSesssion(Properties.Settings.Default.FavouriteSession5);
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

        public void SessionsRefreshed(Object sender, EventArgs e)
        {
            loadLists();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session s = (Session)((ComboBox)sender).SelectedItem;

            if (s == null || checkBox1.Checked == false)
                return;

            if (sender.Equals(comboBox1))
            {
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_1);
                if ( HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_1, HotkeyController.HotKeyId.HKID_SESSION_1) )
                    Properties.Settings.Default.FavouriteSession1 = s.SessionName;
            }
            else if (sender.Equals(comboBox2))
            {
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_2);
                if ( HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_2, HotkeyController.HotKeyId.HKID_SESSION_2) )
                    Properties.Settings.Default.FavouriteSession2 = s.SessionName;
            }
            else if (sender.Equals(comboBox3))
            {
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_3);
                if ( HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_3, HotkeyController.HotKeyId.HKID_SESSION_3) )
                    Properties.Settings.Default.FavouriteSession3 = s.SessionName;
            }
            else if (sender.Equals(comboBox4))
            {
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_4);
                if ( HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_4, HotkeyController.HotKeyId.HKID_SESSION_4) )
                    Properties.Settings.Default.FavouriteSession4 = s.SessionName;
            }
            else if (sender.Equals(comboBox5))
            {
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_5);
                if (HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_5, HotkeyController.HotKeyId.HKID_SESSION_5))
                    Properties.Settings.Default.FavouriteSession5 = s.SessionName;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_1, HotkeyController.HotKeyId.HKID_SESSION_1);
                HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_2, HotkeyController.HotKeyId.HKID_SESSION_2);
                HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_3, HotkeyController.HotKeyId.HKID_SESSION_3);
                HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_4, HotkeyController.HotKeyId.HKID_SESSION_4);
                HotkeyController.RegisterHotkey(parentWindow, HotkeyController.HotKey.HK_SESSION_5, HotkeyController.HotKeyId.HKID_SESSION_5);
            }
            else
            {
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_1);
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_2);
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_3);
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_4);
                HotkeyController.UnregisterHotKey(parentWindow, HotkeyController.HotKeyId.HKID_SESSION_5);
            }
        }
    }
}