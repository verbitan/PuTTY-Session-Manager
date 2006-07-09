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
using System.Collections;

namespace uk.org.riseley.puttySessionManager
{
    public partial class CopySessionForm : Form
    {
        private Form parentWindow;
        private SessionController sc;
        private CopySessionRequest csr;
        private Dictionary<CopySessionRequest.AttribGroups, CheckBox> checkboxDictionary;

        public CopySessionForm(Form parent)
        {
            parentWindow = parent;
            sc = SessionController.getInstance();
            InitializeComponent();
            SessionController.SessionsRefreshedEventHandler scHandler = new SessionController.SessionsRefreshedEventHandler(this.SessionsRefreshed);
            sc.SessionsRefreshed += scHandler;
            csr = new CopySessionRequest();
            tagCheckboxes();
            tagRadioButtons();
            createDictonary();
            copyAllRadioButton.Checked = true;
        }

        private void tagCheckboxes()
        {
            coloursCheckBox.Tag = CopySessionRequest.AttribGroups.COLOURS;
            userNameCheckBox.Tag = CopySessionRequest.AttribGroups.DEFAULT_USERNAME;
            scrollBackCheckBox.Tag = CopySessionRequest.AttribGroups.SCROLLBACK;
            fontCheckBox.Tag = CopySessionRequest.AttribGroups.FONT;
            protocoCheckBox.Tag = CopySessionRequest.AttribGroups.PROTOCOL_PORT;
            portForwardCheckBox.Tag = CopySessionRequest.AttribGroups.SSH_PORT_FORWARDS;
            keepalivesCheckBox.Tag = CopySessionRequest.AttribGroups.KEEP_ALIVES;
            selectionCheckBox.Tag = CopySessionRequest.AttribGroups.SELECTION_CHARS;
            folderCheckBox.Tag = CopySessionRequest.AttribGroups.SESSION_FOLDER;
        }

        private void tagRadioButtons()
        {
            copyAllRadioButton.Tag = CopySessionRequest.CopySessionOptions.COPY_ALL;
            includeRadioButton.Tag = CopySessionRequest.CopySessionOptions.COPY_INCLUDE;
            excludeRadioButton.Tag = CopySessionRequest.CopySessionOptions.COPY_EXCLUDE;
        }

        private void createDictonary()
        {
            checkboxDictionary = new Dictionary<CopySessionRequest.AttribGroups, CheckBox>();
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)coloursCheckBox.Tag, coloursCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)userNameCheckBox.Tag, userNameCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)scrollBackCheckBox.Tag, scrollBackCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)fontCheckBox.Tag, fontCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)protocoCheckBox.Tag, protocoCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)portForwardCheckBox.Tag, portForwardCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)keepalivesCheckBox.Tag, keepalivesCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)selectionCheckBox.Tag, selectionCheckBox);
            checkboxDictionary.Add((CopySessionRequest.AttribGroups)folderCheckBox.Tag, folderCheckBox);
        }

        private void loadList()
        {
            sessionComboBox.Items.AddRange(sc.getSessionList().ToArray());
            Session s = sc.findDefaultSession(false);
            if (s != null)
            {
                sessionComboBox.SelectedItem = s;
                attributeListBox.Items.AddRange(sc.getSessionAttributes(s).ToArray());
            }
        }

        private void clearList()
        {
            sessionComboBox.Items.Clear();
            attributeListBox.Items.Clear();
        }

        public void SessionsRefreshed(Object sender, EventArgs e)
        {
            clearList();
            loadList();
        }

        public CopySessionRequest getCopySessionRequest()
        {
            return csr;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            /*if (sessionnameTextBox.Text.Equals(""))
            {
                MessageBox.Show("You must specify a session name."
                  , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else if (sc.findSession(sessionnameTextBox.Text) != null)
            {
                MessageBox.Show("Session: " + sessionnameTextBox.Text +
                                " already exists.\nPlease choose another name."
                  , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to create: " + sessionnameTextBox.Text 
                            ,"Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    DialogResult = DialogResult.None;
             
            }*/

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton) sender;
            if ( rb == copyAllRadioButton )
            {
                attributesGroupBox.Enabled = !(copyAllRadioButton.Checked);
            }

            if ( rb.Checked == true )
                csr.CopyOptions = (CopySessionRequest.CopySessionOptions)rb.Tag;
        }

        private void sessionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Suspend redraw
            SuspendLayout();

            // Save the list of selected items
            string[] selectedItems = new string[attributeListBox.SelectedItems.Count];
            attributeListBox.SelectedItems.CopyTo(selectedItems, 0);

            // Clear the existing list
            attributeListBox.Items.Clear();

            // Import the attributes from the new selected session
            attributeListBox.Items.AddRange(sc.getSessionAttributes((Session)sessionComboBox.SelectedItem).ToArray());

            // Attempt to reselect the item
            foreach (string s in selectedItems)
            {
                attributeListBox.SelectedItems.Add(s);
            }

            // Resume redraw
            ResumeLayout();

        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < attributeListBox.Items.Count; i++)
                attributeListBox.SelectedIndices.Add(i);
            csr.SelectedAttributes = getSelectedAttributes();
        }

        private void selectNoneButton_Click(object sender, EventArgs e)
        {
            attributeListBox.SelectedIndices.Clear();
            csr.SelectedAttributes = getSelectedAttributes();
        }

        private void invertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < attributeListBox.Items.Count; i++)
            {
                if (attributeListBox.SelectedIndices.Contains(i))
                    attributeListBox.SelectedIndices.Remove(i);
                else
                    attributeListBox.SelectedIndices.Add(i);
            }
            csr.SelectedAttributes = getSelectedAttributes();
        }


        private List<string> getSelectedAttributes()
        {
            string[] selectedAttribs = new string[attributeListBox.SelectedItems.Count];
            attributeListBox.SelectedItems.CopyTo(selectedAttribs, 0);
            List<string> sl = new List<string>();
            sl.AddRange(selectedAttribs);
            return sl;
        }

        private void attributeListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            csr.SelectedAttributes = getSelectedAttributes();

            foreach (CheckBox cb in checkboxDictionary.Values)
            {
                cb.CheckState = csr.getGroupStatus((CopySessionRequest.AttribGroups)cb.Tag);
            }
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            bool buttonChecked = cb.Checked;
            CopySessionRequest.AttribGroups ag = (CopySessionRequest.AttribGroups)cb.Tag;
            List<string> attribs = csr.getAttribs(ag);
            int index = -1;

            foreach (string s in attribs)
            {
                index = attributeListBox.Items.IndexOf(s);
                if (index >= 0)
                {
                    if (buttonChecked == true)
                    {
                        attributeListBox.SelectedIndices.Add(index);
                    }
                    else if (buttonChecked == false)
                    {
                        attributeListBox.SelectedIndices.Remove(index);
                    }
                }
            }

            csr.SelectedAttributes = getSelectedAttributes();
        }

 
    }
}