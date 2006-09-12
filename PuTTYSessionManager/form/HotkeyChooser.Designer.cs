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
namespace uk.org.riseley.puttySessionManager.form
{
    partial class HotkeyChooser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minimizeWindowHKLabel = new System.Windows.Forms.Label();
            this.minimizeWindowHKTextbox = new System.Windows.Forms.TextBox();
            this.minimizeWindowHKCheckbox = new System.Windows.Forms.CheckBox();
            this.favSessCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.newSessionHKLabel = new System.Windows.Forms.Label();
            this.newSessionHKTextbox = new System.Windows.Forms.TextBox();
            this.newSessionHKCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minimizeWindowHKLabel);
            this.groupBox1.Controls.Add(this.minimizeWindowHKTextbox);
            this.groupBox1.Controls.Add(this.minimizeWindowHKCheckbox);
            this.groupBox1.Controls.Add(this.favSessCheckBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.newSessionHKLabel);
            this.groupBox1.Controls.Add(this.newSessionHKTextbox);
            this.groupBox1.Controls.Add(this.newSessionHKCheckbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // minimizeWindowHKLabel
            // 
            this.minimizeWindowHKLabel.AutoSize = true;
            this.minimizeWindowHKLabel.Location = new System.Drawing.Point(200, 40);
            this.minimizeWindowHKLabel.Name = "minimizeWindowHKLabel";
            this.minimizeWindowHKLabel.Size = new System.Drawing.Size(35, 13);
            this.minimizeWindowHKLabel.TabIndex = 23;
            this.minimizeWindowHKLabel.Text = "Win +";
            // 
            // minimizeWindowHKTextbox
            // 
            this.minimizeWindowHKTextbox.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyMinimizeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.minimizeWindowHKTextbox.Location = new System.Drawing.Point(241, 37);
            this.minimizeWindowHKTextbox.MaxLength = 1;
            this.minimizeWindowHKTextbox.Name = "minimizeWindowHKTextbox";
            this.minimizeWindowHKTextbox.ReadOnly = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyMinimizeEnabled;
            this.minimizeWindowHKTextbox.Size = new System.Drawing.Size(30, 20);
            this.minimizeWindowHKTextbox.TabIndex = 22;
            this.minimizeWindowHKTextbox.Text = "Q";
            this.minimizeWindowHKTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minimizeWindowHKCheckbox
            // 
            this.minimizeWindowHKCheckbox.AutoSize = true;
            this.minimizeWindowHKCheckbox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyMinimizeEnabled;
            this.minimizeWindowHKCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeWindowHKCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyMinimizeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.minimizeWindowHKCheckbox.Location = new System.Drawing.Point(13, 39);
            this.minimizeWindowHKCheckbox.Name = "minimizeWindowHKCheckbox";
            this.minimizeWindowHKCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.minimizeWindowHKCheckbox.Size = new System.Drawing.Size(181, 17);
            this.minimizeWindowHKCheckbox.TabIndex = 21;
            this.minimizeWindowHKCheckbox.Text = "Enable Minimize Window Hotkey";
            this.minimizeWindowHKCheckbox.UseVisualStyleBackColor = true;
            this.minimizeWindowHKCheckbox.Click += new System.EventHandler(this.hotkeyCheckbox_Click);
            // 
            // favSessCheckBox
            // 
            this.favSessCheckBox.AutoSize = true;
            this.favSessCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.favSessCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.favSessCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.favSessCheckBox.Location = new System.Drawing.Point(6, 60);
            this.favSessCheckBox.Name = "favSessCheckBox";
            this.favSessCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.favSessCheckBox.Size = new System.Drawing.Size(188, 17);
            this.favSessCheckBox.TabIndex = 20;
            this.favSessCheckBox.Text = "Enable Favourite Session Hotkeys";
            this.favSessCheckBox.UseVisualStyleBackColor = true;
            this.favSessCheckBox.CheckedChanged += new System.EventHandler(this.favSessCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Win + 5";
            // 
            // comboBox5
            // 
            this.comboBox5.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(59, 188);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(295, 21);
            this.comboBox5.TabIndex = 18;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Win + 4";
            // 
            // comboBox4
            // 
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(59, 164);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(295, 21);
            this.comboBox4.TabIndex = 16;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Win + 3";
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(59, 137);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(295, 21);
            this.comboBox3.TabIndex = 14;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Win + 2";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(59, 110);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(295, 21);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Win + 1";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyFavouriteEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.DisplayMember = "Default Settings";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyFavouriteEnabled;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(295, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // newSessionHKLabel
            // 
            this.newSessionHKLabel.AutoSize = true;
            this.newSessionHKLabel.Location = new System.Drawing.Point(200, 17);
            this.newSessionHKLabel.Name = "newSessionHKLabel";
            this.newSessionHKLabel.Size = new System.Drawing.Size(35, 13);
            this.newSessionHKLabel.TabIndex = 9;
            this.newSessionHKLabel.Text = "Win +";
            // 
            // newSessionHKTextbox
            // 
            this.newSessionHKTextbox.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyNewEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.newSessionHKTextbox.Location = new System.Drawing.Point(241, 14);
            this.newSessionHKTextbox.MaxLength = 1;
            this.newSessionHKTextbox.Name = "newSessionHKTextbox";
            this.newSessionHKTextbox.ReadOnly = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyNewEnabled;
            this.newSessionHKTextbox.Size = new System.Drawing.Size(30, 20);
            this.newSessionHKTextbox.TabIndex = 8;
            this.newSessionHKTextbox.Text = "N";
            this.newSessionHKTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newSessionHKCheckbox
            // 
            this.newSessionHKCheckbox.AutoSize = true;
            this.newSessionHKCheckbox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.HotkeyNewEnabled;
            this.newSessionHKCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newSessionHKCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "HotkeyNewEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.newSessionHKCheckbox.Location = new System.Drawing.Point(33, 16);
            this.newSessionHKCheckbox.Name = "newSessionHKCheckbox";
            this.newSessionHKCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.newSessionHKCheckbox.Size = new System.Drawing.Size(161, 17);
            this.newSessionHKCheckbox.TabIndex = 7;
            this.newSessionHKCheckbox.Text = "Enable New Session Hotkey";
            this.newSessionHKCheckbox.UseVisualStyleBackColor = true;
            this.newSessionHKCheckbox.Click += new System.EventHandler(this.hotkeyCheckbox_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.okButton, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.35354F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.64646F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(369, 261);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(151, 230);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(67, 22);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // HotkeyChooser
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 261);
            this.Controls.Add(this.tableLayoutPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(369, 252);
            this.Name = "HotkeyChooser";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Session Hotkeys";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeyChooser_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox newSessionHKCheckbox;
        private System.Windows.Forms.TextBox newSessionHKTextbox;
        private System.Windows.Forms.Label newSessionHKLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox favSessCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label minimizeWindowHKLabel;
        private System.Windows.Forms.TextBox minimizeWindowHKTextbox;
        private System.Windows.Forms.CheckBox minimizeWindowHKCheckbox;
    }
}