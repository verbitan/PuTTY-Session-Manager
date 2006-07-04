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
namespace uk.org.riseley.puttySessionManager
{
    partial class NewSessionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chooseSessionLabel = new System.Windows.Forms.Label();
            this.sessionComboBox = new System.Windows.Forms.ComboBox();
            this.hostnameTextBox = new System.Windows.Forms.TextBox();
            this.hostnameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sessionNameLabel = new System.Windows.Forms.Label();
            this.sessionnameTextBox = new System.Windows.Forms.TextBox();
            this.copyUsernameCheckBox = new System.Windows.Forms.CheckBox();
            this.sessionFolderLabel = new System.Windows.Forms.Label();
            this.sessionFolderComboBox = new System.Windows.Forms.ComboBox();
            this.launchSessionCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chooseSessionLabel
            // 
            this.chooseSessionLabel.AutoSize = true;
            this.chooseSessionLabel.Location = new System.Drawing.Point(12, 33);
            this.chooseSessionLabel.Name = "chooseSessionLabel";
            this.chooseSessionLabel.Size = new System.Drawing.Size(130, 13);
            this.chooseSessionLabel.TabIndex = 13;
            this.chooseSessionLabel.Text = "Choose Session Template";
            // 
            // sessionComboBox
            // 
            this.sessionComboBox.DisplayMember = "Default Settings";
            this.sessionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionComboBox.FormattingEnabled = true;
            this.sessionComboBox.Location = new System.Drawing.Point(148, 30);
            this.sessionComboBox.Name = "sessionComboBox";
            this.sessionComboBox.Size = new System.Drawing.Size(295, 21);
            this.sessionComboBox.TabIndex = 7;
            this.sessionComboBox.SelectionChangeCommitted += new System.EventHandler(this.sessionComboBox_SelectionChangeCommitted);
            // 
            // hostnameTextBox
            // 
            this.hostnameTextBox.Location = new System.Drawing.Point(148, 84);
            this.hostnameTextBox.Name = "hostnameTextBox";
            this.hostnameTextBox.Size = new System.Drawing.Size(295, 20);
            this.hostnameTextBox.TabIndex = 1;
            this.hostnameTextBox.TextChanged += new System.EventHandler(this.hostnameTextBox_TextChanged);
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.AutoSize = true;
            this.hostnameLabel.Location = new System.Drawing.Point(29, 87);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(113, 13);
            this.hostnameLabel.TabIndex = 15;
            this.hostnameLabel.Text = "Enter Hostname String";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(148, 173);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(229, 173);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // sessionNameLabel
            // 
            this.sessionNameLabel.AutoSize = true;
            this.sessionNameLabel.Location = new System.Drawing.Point(39, 113);
            this.sessionNameLabel.Name = "sessionNameLabel";
            this.sessionNameLabel.Size = new System.Drawing.Size(103, 13);
            this.sessionNameLabel.TabIndex = 19;
            this.sessionNameLabel.Text = "Enter Session Name";
            // 
            // sessionnameTextBox
            // 
            this.sessionnameTextBox.Location = new System.Drawing.Point(148, 110);
            this.sessionnameTextBox.MaxLength = 60;
            this.sessionnameTextBox.Name = "sessionnameTextBox";
            this.sessionnameTextBox.Size = new System.Drawing.Size(295, 20);
            this.sessionnameTextBox.TabIndex = 2;
            // 
            // copyUsernameCheckBox
            // 
            this.copyUsernameCheckBox.AutoSize = true;
            this.copyUsernameCheckBox.Checked = true;
            this.copyUsernameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyUsernameCheckBox.Location = new System.Drawing.Point(97, 143);
            this.copyUsernameCheckBox.Name = "copyUsernameCheckBox";
            this.copyUsernameCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.copyUsernameCheckBox.Size = new System.Drawing.Size(138, 17);
            this.copyUsernameCheckBox.TabIndex = 3;
            this.copyUsernameCheckBox.Text = "Copy Default Username";
            this.copyUsernameCheckBox.UseVisualStyleBackColor = true;
            // 
            // sessionFolderLabel
            // 
            this.sessionFolderLabel.AutoSize = true;
            this.sessionFolderLabel.Location = new System.Drawing.Point(27, 60);
            this.sessionFolderLabel.Name = "sessionFolderLabel";
            this.sessionFolderLabel.Size = new System.Drawing.Size(115, 13);
            this.sessionFolderLabel.TabIndex = 23;
            this.sessionFolderLabel.Text = "Choose Session Folder";
            // 
            // sessionFolderComboBox
            // 
            this.sessionFolderComboBox.DisplayMember = "Default Settings";
            this.sessionFolderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionFolderComboBox.FormattingEnabled = true;
            this.sessionFolderComboBox.Location = new System.Drawing.Point(148, 57);
            this.sessionFolderComboBox.Name = "sessionFolderComboBox";
            this.sessionFolderComboBox.Size = new System.Drawing.Size(295, 21);
            this.sessionFolderComboBox.TabIndex = 8;
            // 
            // launchSessionCheckBox
            // 
            this.launchSessionCheckBox.AutoSize = true;
            this.launchSessionCheckBox.Checked = true;
            this.launchSessionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.launchSessionCheckBox.Location = new System.Drawing.Point(241, 143);
            this.launchSessionCheckBox.Name = "launchSessionCheckBox";
            this.launchSessionCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.launchSessionCheckBox.Size = new System.Drawing.Size(127, 17);
            this.launchSessionCheckBox.TabIndex = 4;
            this.launchSessionCheckBox.Text = "Launch Session Now";
            this.launchSessionCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewSessionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(459, 220);
            this.ControlBox = false;
            this.Controls.Add(this.launchSessionCheckBox);
            this.Controls.Add(this.sessionFolderLabel);
            this.Controls.Add(this.sessionFolderComboBox);
            this.Controls.Add(this.copyUsernameCheckBox);
            this.Controls.Add(this.sessionNameLabel);
            this.Controls.Add(this.sessionnameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.hostnameLabel);
            this.Controls.Add(this.hostnameTextBox);
            this.Controls.Add(this.chooseSessionLabel);
            this.Controls.Add(this.sessionComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewSessionForm";
            this.ShowInTaskbar = false;
            this.Text = "New Session";
            this.Shown += new System.EventHandler(this.NewSessionForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chooseSessionLabel;
        private System.Windows.Forms.ComboBox sessionComboBox;
        private System.Windows.Forms.TextBox hostnameTextBox;
        private System.Windows.Forms.Label hostnameLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label sessionNameLabel;
        private System.Windows.Forms.TextBox sessionnameTextBox;
        private System.Windows.Forms.CheckBox copyUsernameCheckBox;
        private System.Windows.Forms.Label sessionFolderLabel;
        private System.Windows.Forms.ComboBox sessionFolderComboBox;
        private System.Windows.Forms.CheckBox launchSessionCheckBox;
    }
}