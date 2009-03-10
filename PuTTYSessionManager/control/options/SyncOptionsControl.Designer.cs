/* 
 * Copyright (C) 2009 David Riseley 
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
namespace uk.org.riseley.puttySessionManager.control.options
{
    partial class SyncOptionsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.locateFileButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.sessionGroupBox = new System.Windows.Forms.GroupBox();
            this.sessionLocationTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.urlRadioButton = new System.Windows.Forms.RadioButton();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.fileLocationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.urlGroupBox = new System.Windows.Forms.GroupBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionComboBox = new System.Windows.Forms.ComboBox();
            this.ignoreCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.validateButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.sessionGroupBox.SuspendLayout();
            this.sessionLocationTableLayout.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.fileLocationTableLayoutPanel.SuspendLayout();
            this.urlGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.optionsTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // locateFileButton
            // 
            this.locateFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.locateFileButton.Location = new System.Drawing.Point(3, 4);
            this.locateFileButton.Name = "locateFileButton";
            this.locateFileButton.Size = new System.Drawing.Size(75, 23);
            this.locateFileButton.TabIndex = 0;
            this.locateFileButton.Text = "Locate File";
            this.locateFileButton.UseVisualStyleBackColor = true;
            this.locateFileButton.Click += new System.EventHandler(this.locateFileButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTextBox.Location = new System.Drawing.Point(84, 6);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(392, 20);
            this.fileTextBox.TabIndex = 1;
            // 
            // sessionGroupBox
            // 
            this.sessionGroupBox.Controls.Add(this.sessionLocationTableLayout);
            this.sessionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionGroupBox.Location = new System.Drawing.Point(3, 3);
            this.sessionGroupBox.Name = "sessionGroupBox";
            this.optionsTableLayout.SetRowSpan(this.sessionGroupBox, 2);
            this.sessionGroupBox.Size = new System.Drawing.Size(181, 106);
            this.sessionGroupBox.TabIndex = 2;
            this.sessionGroupBox.TabStop = false;
            this.sessionGroupBox.Text = "Choose Session Location";
            // 
            // sessionLocationTableLayout
            // 
            this.sessionLocationTableLayout.ColumnCount = 1;
            this.sessionLocationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sessionLocationTableLayout.Controls.Add(this.fileRadioButton, 0, 0);
            this.sessionLocationTableLayout.Controls.Add(this.urlRadioButton, 0, 1);
            this.sessionLocationTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionLocationTableLayout.Location = new System.Drawing.Point(3, 16);
            this.sessionLocationTableLayout.Name = "sessionLocationTableLayout";
            this.sessionLocationTableLayout.RowCount = 2;
            this.sessionLocationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sessionLocationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sessionLocationTableLayout.Size = new System.Drawing.Size(175, 87);
            this.sessionLocationTableLayout.TabIndex = 2;
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fileRadioButton.Checked = true;
            this.fileRadioButton.Location = new System.Drawing.Point(131, 9);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.fileRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileRadioButton.Size = new System.Drawing.Size(41, 25);
            this.fileRadioButton.TabIndex = 0;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "File";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            this.fileRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // urlRadioButton
            // 
            this.urlRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.urlRadioButton.AutoSize = true;
            this.urlRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.urlRadioButton.Location = new System.Drawing.Point(102, 52);
            this.urlRadioButton.Name = "urlRadioButton";
            this.urlRadioButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.urlRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.urlRadioButton.Size = new System.Drawing.Size(70, 25);
            this.urlRadioButton.TabIndex = 1;
            this.urlRadioButton.Text = "HTTP Url";
            this.urlRadioButton.UseVisualStyleBackColor = true;
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.fileLocationTableLayoutPanel);
            this.fileGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileGroupBox.Location = new System.Drawing.Point(190, 3);
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.Size = new System.Drawing.Size(485, 51);
            this.fileGroupBox.TabIndex = 3;
            this.fileGroupBox.TabStop = false;
            this.fileGroupBox.Text = "File Location";
            // 
            // fileLocationTableLayoutPanel
            // 
            this.fileLocationTableLayoutPanel.ColumnCount = 2;
            this.fileLocationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fileLocationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fileLocationTableLayoutPanel.Controls.Add(this.fileTextBox, 1, 0);
            this.fileLocationTableLayoutPanel.Controls.Add(this.locateFileButton, 0, 0);
            this.fileLocationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileLocationTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.fileLocationTableLayoutPanel.Name = "fileLocationTableLayoutPanel";
            this.fileLocationTableLayoutPanel.RowCount = 1;
            this.fileLocationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fileLocationTableLayoutPanel.Size = new System.Drawing.Size(479, 32);
            this.fileLocationTableLayoutPanel.TabIndex = 2;
            // 
            // urlGroupBox
            // 
            this.urlGroupBox.Controls.Add(this.urlTextBox);
            this.urlGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlGroupBox.Enabled = false;
            this.urlGroupBox.Location = new System.Drawing.Point(190, 60);
            this.urlGroupBox.Name = "urlGroupBox";
            this.urlGroupBox.Size = new System.Drawing.Size(485, 49);
            this.urlGroupBox.TabIndex = 4;
            this.urlGroupBox.TabStop = false;
            this.urlGroupBox.Text = "HTTP Url";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTextBox.Location = new System.Drawing.Point(3, 16);
            this.urlTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(479, 20);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.Text = "http://";
            // 
            // optionsGroupBox
            // 
            this.optionsTableLayout.SetColumnSpan(this.optionsGroupBox, 2);
            this.optionsGroupBox.Controls.Add(this.label1);
            this.optionsGroupBox.Controls.Add(this.sessionComboBox);
            this.optionsGroupBox.Controls.Add(this.ignoreCheckBox);
            this.optionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGroupBox.Location = new System.Drawing.Point(3, 115);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(672, 50);
            this.optionsGroupBox.TabIndex = 5;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Synchronization Options";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Session Template";
            // 
            // sessionComboBox
            // 
            this.sessionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sessionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionComboBox.FormattingEnabled = true;
            this.sessionComboBox.Location = new System.Drawing.Point(389, 17);
            this.sessionComboBox.Name = "sessionComboBox";
            this.sessionComboBox.Size = new System.Drawing.Size(269, 21);
            this.sessionComboBox.TabIndex = 1;
            // 
            // ignoreCheckBox
            // 
            this.ignoreCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ignoreCheckBox.AutoSize = true;
            this.ignoreCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ignoreCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ignoreCheckBox.Name = "ignoreCheckBox";
            this.ignoreCheckBox.Size = new System.Drawing.Size(241, 17);
            this.ignoreCheckBox.TabIndex = 0;
            this.ignoreCheckBox.Text = "Ignore local sessions not present in remote list";
            this.ignoreCheckBox.UseVisualStyleBackColor = true;
            // 
            // optionsTableLayout
            // 
            this.optionsTableLayout.ColumnCount = 2;
            this.optionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.72861F));
            this.optionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.27139F));
            this.optionsTableLayout.Controls.Add(this.validateButton, 0, 3);
            this.optionsTableLayout.Controls.Add(this.outputTextBox, 1, 3);
            this.optionsTableLayout.Controls.Add(this.urlGroupBox, 1, 1);
            this.optionsTableLayout.Controls.Add(this.optionsGroupBox, 0, 2);
            this.optionsTableLayout.Controls.Add(this.fileGroupBox, 1, 0);
            this.optionsTableLayout.Controls.Add(this.sessionGroupBox, 0, 0);
            this.optionsTableLayout.Controls.Add(this.clearButton, 0, 4);
            this.optionsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayout.Location = new System.Drawing.Point(0, 0);
            this.optionsTableLayout.Name = "optionsTableLayout";
            this.optionsTableLayout.RowCount = 5;
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.optionsTableLayout.Size = new System.Drawing.Size(678, 264);
            this.optionsTableLayout.TabIndex = 6;
            // 
            // validateButton
            // 
            this.validateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.validateButton.Location = new System.Drawing.Point(8, 188);
            this.validateButton.MaximumSize = new System.Drawing.Size(170, 23);
            this.validateButton.MinimumSize = new System.Drawing.Size(170, 23);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(170, 23);
            this.validateButton.TabIndex = 0;
            this.validateButton.Text = "Load and validate session list";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(190, 171);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.optionsTableLayout.SetRowSpan(this.outputTextBox, 2);
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(485, 90);
            this.outputTextBox.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clearButton.Location = new System.Drawing.Point(9, 217);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(169, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear session list";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // SyncOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.optionsTableLayout);
            this.Name = "SyncOptionsControl";
            this.Size = new System.Drawing.Size(678, 264);
            this.sessionGroupBox.ResumeLayout(false);
            this.sessionLocationTableLayout.ResumeLayout(false);
            this.sessionLocationTableLayout.PerformLayout();
            this.fileGroupBox.ResumeLayout(false);
            this.fileLocationTableLayoutPanel.ResumeLayout(false);
            this.fileLocationTableLayoutPanel.PerformLayout();
            this.urlGroupBox.ResumeLayout(false);
            this.urlGroupBox.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.optionsTableLayout.ResumeLayout(false);
            this.optionsTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button locateFileButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.GroupBox sessionGroupBox;
        private System.Windows.Forms.RadioButton urlRadioButton;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.GroupBox fileGroupBox;
        private System.Windows.Forms.GroupBox urlGroupBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox ignoreCheckBox;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayout;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sessionComboBox;
        private System.Windows.Forms.TableLayoutPanel sessionLocationTableLayout;
        private System.Windows.Forms.TableLayoutPanel fileLocationTableLayoutPanel;
        private System.Windows.Forms.Button clearButton;
    }
}
