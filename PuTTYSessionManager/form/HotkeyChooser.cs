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
using System.Text.RegularExpressions;


namespace uk.org.riseley.puttySessionManager.form
{
    public partial class HotkeyChooser : Form
    {
        private Form parentWindow;
        private SessionController sc;
        private HotkeyController hkc;

        private Dictionary<HotkeyController.HotKeyId,ComboBox> comboDictionary;


        public HotkeyChooser(Form parent)
        {
            parentWindow = parent;
            sc = SessionController.getInstance();
            hkc = HotkeyController.getInstance();
            InitializeComponent();
            createComboDictionary();
            newSessionHKTextbox.Text = hkc.getHotKeyFromId(HotkeyController.HotKeyId.HKID_NEW);
            minimizeWindowHKTextbox.Text = hkc.getHotKeyFromId(HotkeyController.HotKeyId.HKID_MINIMIZE);
            SessionController.SessionsRefreshedEventHandler scHandler = new SessionController.SessionsRefreshedEventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
            EventHandler hkHandler = new EventHandler(setHotkeys);
            hkc.HotkeysRefreshed += hkHandler;
        }

        private void createComboDictionary()
        {
            comboDictionary = new Dictionary<HotkeyController.HotKeyId, ComboBox>();
            comboDictionary.Add(HotkeyController.HotKeyId.HKID_SESSION_1, comboBox1);
            comboBox1.Tag = HotkeyController.HotKeyId.HKID_SESSION_1;
            comboDictionary.Add(HotkeyController.HotKeyId.HKID_SESSION_2, comboBox2);
            comboBox2.Tag = HotkeyController.HotKeyId.HKID_SESSION_2;
            comboDictionary.Add(HotkeyController.HotKeyId.HKID_SESSION_3, comboBox3);
            comboBox3.Tag = HotkeyController.HotKeyId.HKID_SESSION_3;
            comboDictionary.Add(HotkeyController.HotKeyId.HKID_SESSION_4, comboBox4);
            comboBox4.Tag = HotkeyController.HotKeyId.HKID_SESSION_4;
            comboDictionary.Add(HotkeyController.HotKeyId.HKID_SESSION_5, comboBox5);
            comboBox5.Tag = HotkeyController.HotKeyId.HKID_SESSION_5;
        }

        private void loadLists()
        {
            Session[] sa = sc.getSessionList().ToArray();
            ComboBox c;
            foreach (HotkeyController.HotKeyId hkid in comboDictionary.Keys)
            {
                comboDictionary.TryGetValue(hkid, out c);
                c.Items.AddRange(sa);
                c.SelectedItem = hkc.getSessionFromHotkey(hkid);
            }
        }

        private void setHotkeys(object source , EventArgs e)
        {
            ComboBox c;
            foreach (HotkeyController.HotKeyId hkid in comboDictionary.Keys)
            {
                comboDictionary.TryGetValue(hkid, out c);
                c.SelectedItem = hkc.getSessionFromHotkey(hkid);
            }        
        }


        private void clearLists()
        {
            foreach (ComboBox c in comboDictionary.Values)
            {
                c.Items.Clear();
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (newSessionHKCheckbox.Checked == false)
                newSessionHKTextbox.Text = hkc.getHotKeyFromId(HotkeyController.HotKeyId.HKID_NEW);
            if (minimizeWindowHKCheckbox.Checked == false)
                minimizeWindowHKTextbox.Text = hkc.getHotKeyFromId(HotkeyController.HotKeyId.HKID_MINIMIZE);            
            this.Close();
        }

        private void hotkeyCheckbox_Click(object sender, EventArgs e)
        {
            // Get the checkbox that was clicked
            CheckBox cb = (CheckBox)sender;

            // Get the hotkey to adjust and the text box to query
            HotkeyController.HotKeyId hkid;
            TextBox tb = null;
            if (cb == newSessionHKCheckbox)
            {
                hkid = HotkeyController.HotKeyId.HKID_NEW;
                tb = newSessionHKTextbox;
            }
            else if (cb == minimizeWindowHKCheckbox)
            {
                hkid = HotkeyController.HotKeyId.HKID_MINIMIZE;
                tb = minimizeWindowHKTextbox;
            }
            else
            {
                return;
            }

            // Unregister the hotkey if the box is unticked
            if (cb.Checked == false)
            {
                bool result = hkc.UnregisterHotKey(parentWindow, hkid);
                if (result == false)
                {
                    MessageBox.Show(this, "Failed to unregister hotkey"
                                   , "Warning"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Warning);
                }
                tb.Text = hkc.getHotKeyFromId(hkid);
            }
            else
            {
                if ( tb.Text.Length != 1 ) {
                    MessageBox.Show(this, "Hotkey must be specified"
                                   , "Warning"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Warning);
                    tb.Text = hkc.getHotKeyFromId(hkid);
                    cb.Checked = false;
                } 
                else if ( Regex.IsMatch ( tb.Text, @"(?!([deflmruDERLMRU]))[a-zA-Z]" ) == false ) 
                {
                    MessageBox.Show(this, "Hotkey can only be A-Z but not D,E,F,L,M,R or U"
                                   , "Warning"
                                   , MessageBoxButtons.OK
                                   , MessageBoxIcon.Warning);
                    tb.Text = hkc.getHotKeyFromId(hkid);
                    cb.Checked = false;                
                }
                else if (newSessionHKTextbox.Text.Equals(minimizeWindowHKTextbox.Text,StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show(this, "Hotkeys must be different"
                                , "Warning"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Warning);
                    tb.Text = hkc.getHotKeyFromId(hkid);
                    cb.Checked = false;                
                }
                else
                {
                    char newHotkey = tb.Text.ToUpper().ToCharArray(0, 1)[0];
                    bool result = hkc.RegisterHotkey(parentWindow, newHotkey, hkid);
                    if (result == false)
                    {
                        MessageBox.Show(this, "Failed to register hotkey"
                                       , "Warning"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Warning);
                        tb.Text = hkc.getHotKeyFromId(hkid);
                        cb.Checked = false;
                    }
                    else
                    {
                        Properties.Settings.Default.HotkeyNewSession = newSessionHKTextbox.Text.ToUpper();
                        Properties.Settings.Default.HotkeyMinimize = minimizeWindowHKTextbox.Text.ToUpper();
                        tb.Text = hkc.getHotKeyFromId(hkid);
                    }
                }
                
            }
        }

        public void SessionsRefreshed(Object sender, EventArgs e)
        {
            clearLists();
            loadLists();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            Session s = (Session)c.SelectedItem;
            HotkeyController.HotKeyId hkid = (HotkeyController.HotKeyId)c.Tag;

            if (s == null || Properties.Settings.Default.HotkeyFavouriteEnabled == false)
                return;

            hkc.saveSessionnameToHotkey(parentWindow, hkid, s);
        }

        private void favSessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (favSessCheckBox.Checked == true)
            {
                foreach (HotkeyController.HotKeyId hkid in comboDictionary.Keys)
                {
                    hkc.RegisterHotkey(parentWindow, hkid);
                }                
            }
            else
            {
                foreach (HotkeyController.HotKeyId hkid in comboDictionary.Keys)
                {
                    hkc.UnregisterHotKey(parentWindow, hkid);
                }                
            }
            hkc.setFavouriteSessionHotkeysEnabled(favSessCheckBox.Checked);
        }

        private void HotkeyChooser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }
    }
}