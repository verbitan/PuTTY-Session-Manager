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

        public Options(Form parentWindow)
        {
            this.parentWindow = parentWindow;
            InitializeComponent();
            hkChooser = new HotkeyChooser(parentWindow);
            sc = SessionController.getInstance();
            autostartCheckBox.Checked = sc.isAutoStartEnabled();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.puttyLocation.Text = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
            sc.setAutoStart(autostartCheckBox.Checked);
        } 
    }
}