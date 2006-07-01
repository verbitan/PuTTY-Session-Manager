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
    partial class CopySessionForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.copyAllRadioButton = new System.Windows.Forms.RadioButton();
            this.includeRadioButton = new System.Windows.Forms.RadioButton();
            this.attributesGroupBox = new System.Windows.Forms.GroupBox();
            this.userNameCheckBox = new System.Windows.Forms.CheckBox();
            this.scrollBackCheckBox = new System.Windows.Forms.CheckBox();
            this.coloursCheckBox = new System.Windows.Forms.CheckBox();
            this.excludeRadioButton = new System.Windows.Forms.RadioButton();
            this.protocoCheckBox = new System.Windows.Forms.CheckBox();
            this.fontCheckBox = new System.Windows.Forms.CheckBox();
            this.selectionCheckBox = new System.Windows.Forms.CheckBox();
            this.keepalivesCheckBox = new System.Windows.Forms.CheckBox();
            this.portForwardCheckBox = new System.Windows.Forms.CheckBox();
            this.folderCheckBox = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.attributesGroupBox.SuspendLayout();
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
            this.sessionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sessionComboBox.DisplayMember = "Default Settings";
            this.sessionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionComboBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.sessionComboBox.FormattingEnabled = true;
            this.sessionComboBox.Location = new System.Drawing.Point(148, 30);
            this.sessionComboBox.Name = "sessionComboBox";
            this.sessionComboBox.Size = new System.Drawing.Size(295, 21);
            this.sessionComboBox.TabIndex = 12;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(148, 276);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(229, 276);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // copyAllRadioButton
            // 
            this.copyAllRadioButton.AutoSize = true;
            this.copyAllRadioButton.Checked = true;
            this.copyAllRadioButton.Location = new System.Drawing.Point(45, 61);
            this.copyAllRadioButton.Name = "copyAllRadioButton";
            this.copyAllRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.copyAllRadioButton.Size = new System.Drawing.Size(192, 17);
            this.copyAllRadioButton.TabIndex = 18;
            this.copyAllRadioButton.TabStop = true;
            this.copyAllRadioButton.Text = "Copy all attributes except hostname";
            this.copyAllRadioButton.UseVisualStyleBackColor = true;
            this.copyAllRadioButton.CheckedChanged += new System.EventHandler(this.copyAllRadioButton_CheckedChanged);
            // 
            // includeRadioButton
            // 
            this.includeRadioButton.AutoSize = true;
            this.includeRadioButton.Location = new System.Drawing.Point(77, 107);
            this.includeRadioButton.Name = "includeRadioButton";
            this.includeRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.includeRadioButton.Size = new System.Drawing.Size(160, 17);
            this.includeRadioButton.TabIndex = 19;
            this.includeRadioButton.Text = "Copy only selected attributes";
            this.includeRadioButton.UseVisualStyleBackColor = true;
            // 
            // attributesGroupBox
            // 
            this.attributesGroupBox.Controls.Add(this.listBox1);
            this.attributesGroupBox.Controls.Add(this.folderCheckBox);
            this.attributesGroupBox.Controls.Add(this.portForwardCheckBox);
            this.attributesGroupBox.Controls.Add(this.keepalivesCheckBox);
            this.attributesGroupBox.Controls.Add(this.selectionCheckBox);
            this.attributesGroupBox.Controls.Add(this.fontCheckBox);
            this.attributesGroupBox.Controls.Add(this.protocoCheckBox);
            this.attributesGroupBox.Controls.Add(this.userNameCheckBox);
            this.attributesGroupBox.Controls.Add(this.scrollBackCheckBox);
            this.attributesGroupBox.Controls.Add(this.coloursCheckBox);
            this.attributesGroupBox.Enabled = false;
            this.attributesGroupBox.Location = new System.Drawing.Point(15, 130);
            this.attributesGroupBox.Name = "attributesGroupBox";
            this.attributesGroupBox.Size = new System.Drawing.Size(428, 140);
            this.attributesGroupBox.TabIndex = 20;
            this.attributesGroupBox.TabStop = false;
            this.attributesGroupBox.Text = "Attributes";
            // 
            // userNameCheckBox
            // 
            this.userNameCheckBox.AutoSize = true;
            this.userNameCheckBox.Location = new System.Drawing.Point(6, 42);
            this.userNameCheckBox.Name = "userNameCheckBox";
            this.userNameCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userNameCheckBox.Size = new System.Drawing.Size(111, 17);
            this.userNameCheckBox.TabIndex = 2;
            this.userNameCheckBox.Text = "Default Username";
            this.userNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // scrollBackCheckBox
            // 
            this.scrollBackCheckBox.AutoSize = true;
            this.scrollBackCheckBox.Location = new System.Drawing.Point(174, 19);
            this.scrollBackCheckBox.Name = "scrollBackCheckBox";
            this.scrollBackCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.scrollBackCheckBox.Size = new System.Drawing.Size(76, 17);
            this.scrollBackCheckBox.TabIndex = 1;
            this.scrollBackCheckBox.Text = "Scrollback";
            this.scrollBackCheckBox.UseVisualStyleBackColor = true;
            // 
            // coloursCheckBox
            // 
            this.coloursCheckBox.AutoSize = true;
            this.coloursCheckBox.Location = new System.Drawing.Point(56, 19);
            this.coloursCheckBox.Name = "coloursCheckBox";
            this.coloursCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.coloursCheckBox.Size = new System.Drawing.Size(61, 17);
            this.coloursCheckBox.TabIndex = 0;
            this.coloursCheckBox.Text = "Colours";
            this.coloursCheckBox.UseVisualStyleBackColor = true;
            // 
            // excludeRadioButton
            // 
            this.excludeRadioButton.AutoSize = true;
            this.excludeRadioButton.Location = new System.Drawing.Point(15, 84);
            this.excludeRadioButton.Name = "excludeRadioButton";
            this.excludeRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.excludeRadioButton.Size = new System.Drawing.Size(222, 17);
            this.excludeRadioButton.TabIndex = 21;
            this.excludeRadioButton.Text = "Exclude hostname and selected attributes";
            this.excludeRadioButton.UseVisualStyleBackColor = true;
            // 
            // protocoCheckBox
            // 
            this.protocoCheckBox.AutoSize = true;
            this.protocoCheckBox.Location = new System.Drawing.Point(22, 111);
            this.protocoCheckBox.Name = "protocoCheckBox";
            this.protocoCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.protocoCheckBox.Size = new System.Drawing.Size(95, 17);
            this.protocoCheckBox.TabIndex = 3;
            this.protocoCheckBox.Text = "Protocol / Port";
            this.protocoCheckBox.UseVisualStyleBackColor = true;
            // 
            // fontCheckBox
            // 
            this.fontCheckBox.AutoSize = true;
            this.fontCheckBox.Location = new System.Drawing.Point(70, 65);
            this.fontCheckBox.Name = "fontCheckBox";
            this.fontCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fontCheckBox.Size = new System.Drawing.Size(47, 17);
            this.fontCheckBox.TabIndex = 4;
            this.fontCheckBox.Text = "Font";
            this.fontCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectionCheckBox
            // 
            this.selectionCheckBox.AutoSize = true;
            this.selectionCheckBox.Location = new System.Drawing.Point(126, 42);
            this.selectionCheckBox.Name = "selectionCheckBox";
            this.selectionCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectionCheckBox.Size = new System.Drawing.Size(124, 17);
            this.selectionCheckBox.TabIndex = 5;
            this.selectionCheckBox.Text = "Selection Characters";
            this.selectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // keepalivesCheckBox
            // 
            this.keepalivesCheckBox.AutoSize = true;
            this.keepalivesCheckBox.Location = new System.Drawing.Point(39, 88);
            this.keepalivesCheckBox.Name = "keepalivesCheckBox";
            this.keepalivesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.keepalivesCheckBox.Size = new System.Drawing.Size(78, 17);
            this.keepalivesCheckBox.TabIndex = 6;
            this.keepalivesCheckBox.Text = "Keepalives";
            this.keepalivesCheckBox.UseVisualStyleBackColor = true;
            // 
            // portForwardCheckBox
            // 
            this.portForwardCheckBox.AutoSize = true;
            this.portForwardCheckBox.Location = new System.Drawing.Point(134, 88);
            this.portForwardCheckBox.Name = "portForwardCheckBox";
            this.portForwardCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.portForwardCheckBox.Size = new System.Drawing.Size(116, 17);
            this.portForwardCheckBox.TabIndex = 7;
            this.portForwardCheckBox.Text = "SSH Port Forwards";
            this.portForwardCheckBox.UseVisualStyleBackColor = true;
            // 
            // folderCheckBox
            // 
            this.folderCheckBox.AutoSize = true;
            this.folderCheckBox.Location = new System.Drawing.Point(155, 65);
            this.folderCheckBox.Name = "folderCheckBox";
            this.folderCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.folderCheckBox.Size = new System.Drawing.Size(95, 17);
            this.folderCheckBox.TabIndex = 8;
            this.folderCheckBox.Text = "Session Folder";
            this.folderCheckBox.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(263, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 108);
            this.listBox1.TabIndex = 9;
            // 
            // CopySessionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(459, 311);
            this.ControlBox = false;
            this.Controls.Add(this.excludeRadioButton);
            this.Controls.Add(this.attributesGroupBox);
            this.Controls.Add(this.includeRadioButton);
            this.Controls.Add(this.copyAllRadioButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.chooseSessionLabel);
            this.Controls.Add(this.sessionComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopySessionForm";
            this.ShowInTaskbar = false;
            this.Text = "Copy Session Attributes";
            this.attributesGroupBox.ResumeLayout(false);
            this.attributesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chooseSessionLabel;
        private System.Windows.Forms.ComboBox sessionComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton copyAllRadioButton;
        private System.Windows.Forms.RadioButton includeRadioButton;
        private System.Windows.Forms.GroupBox attributesGroupBox;
        private System.Windows.Forms.RadioButton excludeRadioButton;
        private System.Windows.Forms.CheckBox coloursCheckBox;
        private System.Windows.Forms.CheckBox userNameCheckBox;
        private System.Windows.Forms.CheckBox scrollBackCheckBox;
        private System.Windows.Forms.CheckBox fontCheckBox;
        private System.Windows.Forms.CheckBox protocoCheckBox;
        private System.Windows.Forms.CheckBox portForwardCheckBox;
        private System.Windows.Forms.CheckBox keepalivesCheckBox;
        private System.Windows.Forms.CheckBox selectionCheckBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox folderCheckBox;
    }
}