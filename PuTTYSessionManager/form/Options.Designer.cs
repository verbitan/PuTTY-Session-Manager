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
    partial class Options
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalOptionsTab = new System.Windows.Forms.TabPage();
            this.autoMinimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTipsCheckBox = new System.Windows.Forms.CheckBox();
            this.autostartCheckBox = new System.Windows.Forms.CheckBox();
            this.startupMinimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.sessionWarningLabel = new System.Windows.Forms.Label();
            this.onTopCheckBox = new System.Windows.Forms.CheckBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.sampletextTextbox = new System.Windows.Forms.TextBox();
            this.chooseFontButton = new System.Windows.Forms.Button();
            this.locatePuttyButton = new System.Windows.Forms.Button();
            this.puttyLocation = new System.Windows.Forms.TextBox();
            this.transparencyCheckBox = new System.Windows.Forms.CheckBox();
            this.pageantOptionsTab = new System.Windows.Forms.TabPage();
            this.launchPageantButton = new System.Windows.Forms.Button();
            this.removeKeyButton = new System.Windows.Forms.Button();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.keysListBox = new System.Windows.Forms.ListBox();
            this.launchPageantCheckBox = new System.Windows.Forms.CheckBox();
            this.locatePageantButton = new System.Windows.Forms.Button();
            this.pageantTextBox = new System.Windows.Forms.TextBox();
            this.thirdPartyOptionsTab = new System.Windows.Forms.TabPage();
            this.updateOptionsTab = new System.Windows.Forms.TabPage();
            this.checkForUpdateButton = new System.Windows.Forms.Button();
            this.urlCheckBox = new System.Windows.Forms.CheckBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.proxyGroupBox = new System.Windows.Forms.GroupBox();
            this.proxyPortLabel = new System.Windows.Forms.Label();
            this.proxyServerLabel = new System.Windows.Forms.Label();
            this.proxyPortTextBox = new System.Windows.Forms.TextBox();
            this.userProxyRadioButton = new System.Windows.Forms.RadioButton();
            this.directRadioButton = new System.Windows.Forms.RadioButton();
            this.ieProxyRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyServerTextBox = new System.Windows.Forms.TextBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.generalOptionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.pageantOptionsTab.SuspendLayout();
            this.updateOptionsTab.SuspendLayout();
            this.proxyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "putty.exe";
            this.openFileDialog.Filter = "putty.exe|putty.exe|All Files|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.okButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.88288F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.11712F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(381, 268);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(157, 234);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(67, 22);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalOptionsTab);
            this.tabControl1.Controls.Add(this.pageantOptionsTab);
            this.tabControl1.Controls.Add(this.thirdPartyOptionsTab);
            this.tabControl1.Controls.Add(this.updateOptionsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 216);
            this.tabControl1.TabIndex = 2;
            // 
            // generalOptionsTab
            // 
            this.generalOptionsTab.Controls.Add(this.autoMinimizeCheckBox);
            this.generalOptionsTab.Controls.Add(this.toolTipsCheckBox);
            this.generalOptionsTab.Controls.Add(this.autostartCheckBox);
            this.generalOptionsTab.Controls.Add(this.startupMinimizeCheckBox);
            this.generalOptionsTab.Controls.Add(this.numericUpDown1);
            this.generalOptionsTab.Controls.Add(this.sessionWarningLabel);
            this.generalOptionsTab.Controls.Add(this.onTopCheckBox);
            this.generalOptionsTab.Controls.Add(this.trackBar);
            this.generalOptionsTab.Controls.Add(this.sampletextTextbox);
            this.generalOptionsTab.Controls.Add(this.chooseFontButton);
            this.generalOptionsTab.Controls.Add(this.locatePuttyButton);
            this.generalOptionsTab.Controls.Add(this.puttyLocation);
            this.generalOptionsTab.Controls.Add(this.transparencyCheckBox);
            this.generalOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.generalOptionsTab.Name = "generalOptionsTab";
            this.generalOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalOptionsTab.Size = new System.Drawing.Size(367, 190);
            this.generalOptionsTab.TabIndex = 0;
            this.generalOptionsTab.Text = "General";
            this.generalOptionsTab.UseVisualStyleBackColor = true;
            // 
            // autoMinimizeCheckBox
            // 
            this.autoMinimizeCheckBox.AutoSize = true;
            this.autoMinimizeCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.MinimizeOnUse;
            this.autoMinimizeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "MinimizeOnUse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoMinimizeCheckBox.Location = new System.Drawing.Point(252, 14);
            this.autoMinimizeCheckBox.Name = "autoMinimizeCheckBox";
            this.autoMinimizeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.autoMinimizeCheckBox.Size = new System.Drawing.Size(101, 17);
            this.autoMinimizeCheckBox.TabIndex = 25;
            this.autoMinimizeCheckBox.Text = "Minimize on use";
            this.autoMinimizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // toolTipsCheckBox
            // 
            this.toolTipsCheckBox.AutoSize = true;
            this.toolTipsCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.ToolTipsEnabled;
            this.toolTipsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolTipsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "ToolTipsEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolTipsCheckBox.Location = new System.Drawing.Point(14, 37);
            this.toolTipsCheckBox.Name = "toolTipsCheckBox";
            this.toolTipsCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolTipsCheckBox.Size = new System.Drawing.Size(99, 17);
            this.toolTipsCheckBox.TabIndex = 24;
            this.toolTipsCheckBox.Text = "Enable Tooltips";
            this.toolTipsCheckBox.UseVisualStyleBackColor = true;
            // 
            // autostartCheckBox
            // 
            this.autostartCheckBox.AutoSize = true;
            this.autostartCheckBox.Location = new System.Drawing.Point(261, 37);
            this.autostartCheckBox.Name = "autostartCheckBox";
            this.autostartCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.autostartCheckBox.Size = new System.Drawing.Size(92, 17);
            this.autostartCheckBox.TabIndex = 23;
            this.autostartCheckBox.Text = "Start on logon";
            this.autostartCheckBox.UseVisualStyleBackColor = true;
            this.autostartCheckBox.CheckedChanged += new System.EventHandler(this.autostartCheckBox_CheckedChanged);
            // 
            // startupMinimizeCheckBox
            // 
            this.startupMinimizeCheckBox.AutoSize = true;
            this.startupMinimizeCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.MinimizeOnStart;
            this.startupMinimizeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "MinimizeOnStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startupMinimizeCheckBox.Location = new System.Drawing.Point(130, 14);
            this.startupMinimizeCheckBox.Name = "startupMinimizeCheckBox";
            this.startupMinimizeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startupMinimizeCheckBox.Size = new System.Drawing.Size(116, 17);
            this.startupMinimizeCheckBox.TabIndex = 22;
            this.startupMinimizeCheckBox.Text = "Minimize on startup";
            this.startupMinimizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "SubfolderSessionWarning", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(310, 112);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.SubfolderSessionWarning;
            // 
            // sessionWarningLabel
            // 
            this.sessionWarningLabel.AutoSize = true;
            this.sessionWarningLabel.Location = new System.Drawing.Point(18, 114);
            this.sessionWarningLabel.Name = "sessionWarningLabel";
            this.sessionWarningLabel.Size = new System.Drawing.Size(273, 13);
            this.sessionWarningLabel.TabIndex = 20;
            this.sessionWarningLabel.Text = "Number of sessions in subfolders to open before warning";
            // 
            // onTopCheckBox
            // 
            this.onTopCheckBox.AutoSize = true;
            this.onTopCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.AlwaysOnTop;
            this.onTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.onTopCheckBox.Location = new System.Drawing.Point(21, 14);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.onTopCheckBox.Size = new System.Drawing.Size(92, 17);
            this.onTopCheckBox.TabIndex = 19;
            this.onTopCheckBox.Text = "Always on top";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // trackBar
            // 
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyValueInt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TransparencyEnabled;
            this.trackBar.Location = new System.Drawing.Point(21, 60);
            this.trackBar.Maximum = 99;
            this.trackBar.Minimum = 20;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(332, 45);
            this.trackBar.TabIndex = 18;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar.Value = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TransparencyValueInt;
            // 
            // sampletextTextbox
            // 
            this.sampletextTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TreeFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sampletextTextbox.Font = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TreeFont;
            this.sampletextTextbox.Location = new System.Drawing.Point(121, 165);
            this.sampletextTextbox.Name = "sampletextTextbox";
            this.sampletextTextbox.ReadOnly = true;
            this.sampletextTextbox.Size = new System.Drawing.Size(232, 20);
            this.sampletextTextbox.TabIndex = 17;
            this.sampletextTextbox.Text = "Sample Text for Tree";
            this.sampletextTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chooseFontButton
            // 
            this.chooseFontButton.Location = new System.Drawing.Point(21, 163);
            this.chooseFontButton.Name = "chooseFontButton";
            this.chooseFontButton.Size = new System.Drawing.Size(98, 22);
            this.chooseFontButton.TabIndex = 16;
            this.chooseFontButton.Text = "Choose Font";
            this.chooseFontButton.UseVisualStyleBackColor = true;
            this.chooseFontButton.Click += new System.EventHandler(this.chooseFontButton_Click);
            // 
            // locatePuttyButton
            // 
            this.locatePuttyButton.Location = new System.Drawing.Point(21, 135);
            this.locatePuttyButton.Name = "locatePuttyButton";
            this.locatePuttyButton.Size = new System.Drawing.Size(98, 22);
            this.locatePuttyButton.TabIndex = 15;
            this.locatePuttyButton.Text = "Locate putty.exe";
            this.locatePuttyButton.UseVisualStyleBackColor = true;
            this.locatePuttyButton.Click += new System.EventHandler(this.locatePuttyButton_Click);
            // 
            // puttyLocation
            // 
            this.puttyLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "PuttyLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.puttyLocation.Location = new System.Drawing.Point(121, 135);
            this.puttyLocation.Name = "puttyLocation";
            this.puttyLocation.ReadOnly = true;
            this.puttyLocation.Size = new System.Drawing.Size(232, 20);
            this.puttyLocation.TabIndex = 14;
            this.puttyLocation.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.PuttyLocation;
            // 
            // transparencyCheckBox
            // 
            this.transparencyCheckBox.AutoSize = true;
            this.transparencyCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.transparencyCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TransparencyEnabled;
            this.transparencyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.transparencyCheckBox.Location = new System.Drawing.Point(119, 37);
            this.transparencyCheckBox.Name = "transparencyCheckBox";
            this.transparencyCheckBox.Size = new System.Drawing.Size(127, 17);
            this.transparencyCheckBox.TabIndex = 13;
            this.transparencyCheckBox.Text = "Enable Transparency";
            this.transparencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // pageantOptionsTab
            // 
            this.pageantOptionsTab.Controls.Add(this.launchPageantButton);
            this.pageantOptionsTab.Controls.Add(this.removeKeyButton);
            this.pageantOptionsTab.Controls.Add(this.addKeyButton);
            this.pageantOptionsTab.Controls.Add(this.keysListBox);
            this.pageantOptionsTab.Controls.Add(this.launchPageantCheckBox);
            this.pageantOptionsTab.Controls.Add(this.locatePageantButton);
            this.pageantOptionsTab.Controls.Add(this.pageantTextBox);
            this.pageantOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.pageantOptionsTab.Name = "pageantOptionsTab";
            this.pageantOptionsTab.Size = new System.Drawing.Size(367, 190);
            this.pageantOptionsTab.TabIndex = 2;
            this.pageantOptionsTab.Text = "Pageant";
            this.pageantOptionsTab.UseVisualStyleBackColor = true;
            // 
            // launchPageantButton
            // 
            this.launchPageantButton.Location = new System.Drawing.Point(17, 161);
            this.launchPageantButton.Name = "launchPageantButton";
            this.launchPageantButton.Size = new System.Drawing.Size(109, 23);
            this.launchPageantButton.TabIndex = 22;
            this.launchPageantButton.Text = "Launch Now";
            this.launchPageantButton.UseVisualStyleBackColor = true;
            this.launchPageantButton.Click += new System.EventHandler(this.launchPageantButton_Click);
            // 
            // removeKeyButton
            // 
            this.removeKeyButton.Location = new System.Drawing.Point(17, 99);
            this.removeKeyButton.Name = "removeKeyButton";
            this.removeKeyButton.Size = new System.Drawing.Size(109, 23);
            this.removeKeyButton.TabIndex = 21;
            this.removeKeyButton.Text = "Remove Key";
            this.removeKeyButton.UseVisualStyleBackColor = true;
            this.removeKeyButton.Click += new System.EventHandler(this.removeKeyButton_Click);
            // 
            // addKeyButton
            // 
            this.addKeyButton.Location = new System.Drawing.Point(17, 70);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(109, 23);
            this.addKeyButton.TabIndex = 20;
            this.addKeyButton.Text = "Add Key";
            this.addKeyButton.UseVisualStyleBackColor = true;
            this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
            // 
            // keysListBox
            // 
            this.keysListBox.FormattingEnabled = true;
            this.keysListBox.HorizontalScrollbar = true;
            this.keysListBox.Location = new System.Drawing.Point(132, 40);
            this.keysListBox.Name = "keysListBox";
            this.keysListBox.Size = new System.Drawing.Size(217, 121);
            this.keysListBox.TabIndex = 19;
            // 
            // launchPageantCheckBox
            // 
            this.launchPageantCheckBox.AutoSize = true;
            this.launchPageantCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.LaunchPageantOnStart;
            this.launchPageantCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "LaunchPageantOnStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.launchPageantCheckBox.Location = new System.Drawing.Point(197, 167);
            this.launchPageantCheckBox.Name = "launchPageantCheckBox";
            this.launchPageantCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.launchPageantCheckBox.Size = new System.Drawing.Size(152, 17);
            this.launchPageantCheckBox.TabIndex = 18;
            this.launchPageantCheckBox.Text = "Launch Pageant at startup";
            this.launchPageantCheckBox.UseVisualStyleBackColor = true;
            // 
            // locatePageantButton
            // 
            this.locatePageantButton.Location = new System.Drawing.Point(17, 11);
            this.locatePageantButton.Name = "locatePageantButton";
            this.locatePageantButton.Size = new System.Drawing.Size(109, 24);
            this.locatePageantButton.TabIndex = 17;
            this.locatePageantButton.Text = "Locate pageant.exe";
            this.locatePageantButton.UseVisualStyleBackColor = true;
            this.locatePageantButton.Click += new System.EventHandler(this.locatePagentButton_Click);
            // 
            // pageantTextBox
            // 
            this.pageantTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "PageantLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pageantTextBox.Location = new System.Drawing.Point(132, 14);
            this.pageantTextBox.Name = "pageantTextBox";
            this.pageantTextBox.ReadOnly = true;
            this.pageantTextBox.Size = new System.Drawing.Size(217, 20);
            this.pageantTextBox.TabIndex = 16;
            this.pageantTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.PageantLocation;
            // 
            // thirdPartyOptionsTab
            // 
            this.thirdPartyOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.thirdPartyOptionsTab.Name = "thirdPartyOptionsTab";
            this.thirdPartyOptionsTab.Size = new System.Drawing.Size(367, 190);
            this.thirdPartyOptionsTab.TabIndex = 3;
            this.thirdPartyOptionsTab.Text = "Third Party Apps";
            this.thirdPartyOptionsTab.UseVisualStyleBackColor = true;
            // 
            // updateOptionsTab
            // 
            this.updateOptionsTab.Controls.Add(this.checkForUpdateButton);
            this.updateOptionsTab.Controls.Add(this.urlCheckBox);
            this.updateOptionsTab.Controls.Add(this.urlTextBox);
            this.updateOptionsTab.Controls.Add(this.urlLabel);
            this.updateOptionsTab.Controls.Add(this.proxyGroupBox);
            this.updateOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.updateOptionsTab.Name = "updateOptionsTab";
            this.updateOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateOptionsTab.Size = new System.Drawing.Size(367, 190);
            this.updateOptionsTab.TabIndex = 1;
            this.updateOptionsTab.Text = "Update";
            this.updateOptionsTab.UseVisualStyleBackColor = true;
            // 
            // checkForUpdateButton
            // 
            this.checkForUpdateButton.Location = new System.Drawing.Point(128, 163);
            this.checkForUpdateButton.Name = "checkForUpdateButton";
            this.checkForUpdateButton.Size = new System.Drawing.Size(111, 22);
            this.checkForUpdateButton.TabIndex = 27;
            this.checkForUpdateButton.Text = "Check for update...";
            this.checkForUpdateButton.UseVisualStyleBackColor = true;
            this.checkForUpdateButton.Click += new System.EventHandler(this.checkForUpdateButton_Click);
            // 
            // urlCheckBox
            // 
            this.urlCheckBox.AutoSize = true;
            this.urlCheckBox.Checked = true;
            this.urlCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.urlCheckBox.Location = new System.Drawing.Point(30, 7);
            this.urlCheckBox.Name = "urlCheckBox";
            this.urlCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.urlCheckBox.Size = new System.Drawing.Size(94, 17);
            this.urlCheckBox.TabIndex = 1;
            this.urlCheckBox.Text = "Use default url";
            this.urlCheckBox.UseVisualStyleBackColor = true;
            this.urlCheckBox.CheckedChanged += new System.EventHandler(this.urlCheckBox_CheckedChanged);
            // 
            // urlTextBox
            // 
            this.urlTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "UpdateUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.urlTextBox.Location = new System.Drawing.Point(93, 27);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(229, 20);
            this.urlTextBox.TabIndex = 2;
            this.urlTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.UpdateUrl;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(31, 30);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(56, 13);
            this.urlLabel.TabIndex = 15;
            this.urlLabel.Text = "Update url";
            // 
            // proxyGroupBox
            // 
            this.proxyGroupBox.Controls.Add(this.proxyPortLabel);
            this.proxyGroupBox.Controls.Add(this.proxyServerLabel);
            this.proxyGroupBox.Controls.Add(this.proxyPortTextBox);
            this.proxyGroupBox.Controls.Add(this.userProxyRadioButton);
            this.proxyGroupBox.Controls.Add(this.directRadioButton);
            this.proxyGroupBox.Controls.Add(this.ieProxyRadioButton);
            this.proxyGroupBox.Controls.Add(this.proxyServerTextBox);
            this.proxyGroupBox.Location = new System.Drawing.Point(6, 53);
            this.proxyGroupBox.Name = "proxyGroupBox";
            this.proxyGroupBox.Size = new System.Drawing.Size(355, 108);
            this.proxyGroupBox.TabIndex = 21;
            this.proxyGroupBox.TabStop = false;
            this.proxyGroupBox.Text = "Proxy Settings";
            // 
            // proxyPortLabel
            // 
            this.proxyPortLabel.AutoSize = true;
            this.proxyPortLabel.Location = new System.Drawing.Point(271, 87);
            this.proxyPortLabel.Name = "proxyPortLabel";
            this.proxyPortLabel.Size = new System.Drawing.Size(26, 13);
            this.proxyPortLabel.TabIndex = 25;
            this.proxyPortLabel.Text = "Port";
            // 
            // proxyServerLabel
            // 
            this.proxyServerLabel.AutoSize = true;
            this.proxyServerLabel.Location = new System.Drawing.Point(119, 87);
            this.proxyServerLabel.Name = "proxyServerLabel";
            this.proxyServerLabel.Size = new System.Drawing.Size(67, 13);
            this.proxyServerLabel.TabIndex = 24;
            this.proxyServerLabel.Text = "Proxy Server";
            // 
            // proxyPortTextBox
            // 
            this.proxyPortTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "ProxyPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.proxyPortTextBox.Location = new System.Drawing.Point(274, 64);
            this.proxyPortTextBox.MaxLength = 5;
            this.proxyPortTextBox.Name = "proxyPortTextBox";
            this.proxyPortTextBox.Size = new System.Drawing.Size(75, 20);
            this.proxyPortTextBox.TabIndex = 7;
            this.proxyPortTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.ProxyPort;
            // 
            // userProxyRadioButton
            // 
            this.userProxyRadioButton.AutoSize = true;
            this.userProxyRadioButton.Location = new System.Drawing.Point(11, 65);
            this.userProxyRadioButton.Name = "userProxyRadioButton";
            this.userProxyRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userProxyRadioButton.Size = new System.Drawing.Size(105, 17);
            this.userProxyRadioButton.TabIndex = 5;
            this.userProxyRadioButton.Text = "Use HTTP Proxy";
            this.userProxyRadioButton.UseVisualStyleBackColor = true;
            this.userProxyRadioButton.CheckedChanged += new System.EventHandler(this.proxyRadioButton_CheckedChanged);
            // 
            // directRadioButton
            // 
            this.directRadioButton.AutoSize = true;
            this.directRadioButton.Location = new System.Drawing.Point(6, 42);
            this.directRadioButton.Name = "directRadioButton";
            this.directRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.directRadioButton.Size = new System.Drawing.Size(110, 17);
            this.directRadioButton.TabIndex = 4;
            this.directRadioButton.Text = "Direct Connection";
            this.directRadioButton.UseVisualStyleBackColor = true;
            this.directRadioButton.CheckedChanged += new System.EventHandler(this.proxyRadioButton_CheckedChanged);
            // 
            // ieProxyRadioButton
            // 
            this.ieProxyRadioButton.AutoSize = true;
            this.ieProxyRadioButton.Checked = true;
            this.ieProxyRadioButton.Location = new System.Drawing.Point(18, 19);
            this.ieProxyRadioButton.Name = "ieProxyRadioButton";
            this.ieProxyRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ieProxyRadioButton.Size = new System.Drawing.Size(98, 17);
            this.ieProxyRadioButton.TabIndex = 3;
            this.ieProxyRadioButton.TabStop = true;
            this.ieProxyRadioButton.Text = "Use IE Settings";
            this.ieProxyRadioButton.UseVisualStyleBackColor = true;
            this.ieProxyRadioButton.CheckedChanged += new System.EventHandler(this.proxyRadioButton_CheckedChanged);
            // 
            // proxyServerTextBox
            // 
            this.proxyServerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "ProxyServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.proxyServerTextBox.Location = new System.Drawing.Point(122, 64);
            this.proxyServerTextBox.Name = "proxyServerTextBox";
            this.proxyServerTextBox.Size = new System.Drawing.Size(145, 20);
            this.proxyServerTextBox.TabIndex = 6;
            this.proxyServerTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.ProxyServer;
            // 
            // fontDialog
            // 
            this.fontDialog.Font = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TreeFont;
            this.fontDialog.ShowColor = true;
            this.fontDialog.ShowEffects = false;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 268);
            this.Controls.Add(this.tableLayoutPanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(389, 302);
            this.Name = "Options";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.TopMost = true;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.generalOptionsTab.ResumeLayout(false);
            this.generalOptionsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.pageantOptionsTab.ResumeLayout(false);
            this.pageantOptionsTab.PerformLayout();
            this.updateOptionsTab.ResumeLayout(false);
            this.updateOptionsTab.PerformLayout();
            this.proxyGroupBox.ResumeLayout(false);
            this.proxyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalOptionsTab;
        private System.Windows.Forms.TabPage updateOptionsTab;
        private System.Windows.Forms.CheckBox toolTipsCheckBox;
        private System.Windows.Forms.CheckBox autostartCheckBox;
        private System.Windows.Forms.CheckBox startupMinimizeCheckBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label sessionWarningLabel;
        private System.Windows.Forms.CheckBox onTopCheckBox;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox sampletextTextbox;
        private System.Windows.Forms.Button chooseFontButton;
        private System.Windows.Forms.Button locatePuttyButton;
        private System.Windows.Forms.TextBox puttyLocation;
        private System.Windows.Forms.CheckBox transparencyCheckBox;
        private System.Windows.Forms.GroupBox proxyGroupBox;
        private System.Windows.Forms.RadioButton ieProxyRadioButton;
        private System.Windows.Forms.TextBox proxyServerTextBox;
        private System.Windows.Forms.CheckBox urlCheckBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.RadioButton userProxyRadioButton;
        private System.Windows.Forms.RadioButton directRadioButton;
        private System.Windows.Forms.Label proxyPortLabel;
        private System.Windows.Forms.Label proxyServerLabel;
        private System.Windows.Forms.TextBox proxyPortTextBox;
        private System.Windows.Forms.Button checkForUpdateButton;
        private System.Windows.Forms.TabPage pageantOptionsTab;
        private System.Windows.Forms.Button locatePageantButton;
        private System.Windows.Forms.TextBox pageantTextBox;
        private System.Windows.Forms.TabPage thirdPartyOptionsTab;
        private System.Windows.Forms.ListBox keysListBox;
        private System.Windows.Forms.CheckBox launchPageantCheckBox;
        private System.Windows.Forms.Button removeKeyButton;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.Button launchPageantButton;
        private System.Windows.Forms.CheckBox autoMinimizeCheckBox;
    }
}