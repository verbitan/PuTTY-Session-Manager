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
using uk.org.riseley.puttySessionManager.control.options;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class Options : Form
    {
        private Form parentWindow;

        private List<ResetableOptionsControl> optionsControls;

        public Options(Form parentWindow)
        {
            this.parentWindow = parentWindow;
            InitializeComponent();

            registerControls();
            resetState();
        }

        private void registerControls()
        {
            optionsControls = new List<ResetableOptionsControl>();
            optionsControls.Add(updateOptionsControl);
            optionsControls.Add(winSCPOptionsControl);
            optionsControls.Add(fileZillaOptionsControl);
            optionsControls.Add(pageantOptionsControl);
            optionsControls.Add(treeOptionsControl);
            optionsControls.Add(generalOptionsControl1);
            generalOptionsControl1.setParentWindow(parentWindow);
        }

        private void resetState()
        {
            foreach (ResetableOptionsControl control in optionsControls)
            {
                control.resetState();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.SuspendLayout();
            Properties.Settings.Default.Reload();
            resetState();
            this.ResumeLayout();
            this.Close();
        }
    }
}