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
namespace uk.org.riseley.puttySessionManager.form
{
    partial class UpdateForm
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
            this.components = new System.ComponentModel.Container();
            this.checkForUpdateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.currVersionLabel = new System.Windows.Forms.Label();
            this.currVersionTextBox = new System.Windows.Forms.TextBox();
            this.availVersionLabel = new System.Windows.Forms.Label();
            this.availVersionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sfLinkLabel = new System.Windows.Forms.LinkLabel();
            this.urlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkForUpdateButton
            // 
            this.checkForUpdateButton.Location = new System.Drawing.Point(151, 232);
            this.checkForUpdateButton.Name = "checkForUpdateButton";
            this.checkForUpdateButton.Size = new System.Drawing.Size(114, 23);
            this.checkForUpdateButton.TabIndex = 0;
            this.checkForUpdateButton.Text = "Check For Update";
            this.checkForUpdateButton.UseVisualStyleBackColor = true;
            this.checkForUpdateButton.Click += new System.EventHandler(this.checkForUpdateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(271, 232);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Controls.Add(this.resultsTextBox);
            this.resultsGroupBox.Location = new System.Drawing.Point(12, 9);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(473, 126);
            this.resultsGroupBox.TabIndex = 11;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Update results";
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTextBox.Location = new System.Drawing.Point(3, 16);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsTextBox.Size = new System.Drawing.Size(467, 107);
            this.resultsTextBox.TabIndex = 0;
            // 
            // currVersionLabel
            // 
            this.currVersionLabel.AutoSize = true;
            this.currVersionLabel.Location = new System.Drawing.Point(9, 148);
            this.currVersionLabel.Name = "currVersionLabel";
            this.currVersionLabel.Size = new System.Drawing.Size(79, 13);
            this.currVersionLabel.TabIndex = 14;
            this.currVersionLabel.Text = "Current Version";
            // 
            // currVersionTextBox
            // 
            this.currVersionTextBox.Location = new System.Drawing.Point(107, 145);
            this.currVersionTextBox.Name = "currVersionTextBox";
            this.currVersionTextBox.ReadOnly = true;
            this.currVersionTextBox.Size = new System.Drawing.Size(378, 20);
            this.currVersionTextBox.TabIndex = 13;
            // 
            // availVersionLabel
            // 
            this.availVersionLabel.AutoSize = true;
            this.availVersionLabel.Location = new System.Drawing.Point(9, 174);
            this.availVersionLabel.Name = "availVersionLabel";
            this.availVersionLabel.Size = new System.Drawing.Size(88, 13);
            this.availVersionLabel.TabIndex = 16;
            this.availVersionLabel.Text = "Available Version";
            // 
            // availVersionTextBox
            // 
            this.availVersionTextBox.Location = new System.Drawing.Point(107, 171);
            this.availVersionTextBox.Name = "availVersionTextBox";
            this.availVersionTextBox.ReadOnly = true;
            this.availVersionTextBox.Size = new System.Drawing.Size(378, 20);
            this.availVersionTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Update Link";
            // 
            // sfLinkLabel
            // 
            this.sfLinkLabel.Location = new System.Drawing.Point(107, 198);
            this.sfLinkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.sfLinkLabel.Name = "sfLinkLabel";
            this.sfLinkLabel.Size = new System.Drawing.Size(378, 17);
            this.sfLinkLabel.TabIndex = 26;
            this.sfLinkLabel.TabStop = true;
            this.sfLinkLabel.Text = "http://puttysm.sourceforge.net";
            this.sfLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sfLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sfLinkLabel_LinkClicked);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(497, 270);
            this.Controls.Add(this.sfLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availVersionLabel);
            this.Controls.Add(this.availVersionTextBox);
            this.Controls.Add(this.currVersionLabel);
            this.Controls.Add(this.currVersionTextBox);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkForUpdateButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(505, 304);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(505, 304);
            this.Name = "UpdateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Check For Update";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.resultsGroupBox.ResumeLayout(false);
            this.resultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkForUpdateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.Label currVersionLabel;
        private System.Windows.Forms.TextBox currVersionTextBox;
        private System.Windows.Forms.Label availVersionLabel;
        private System.Windows.Forms.TextBox availVersionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel sfLinkLabel;
        private System.Windows.Forms.ToolTip urlToolTip;
    }
}