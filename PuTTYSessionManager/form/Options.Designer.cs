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
            this.components = new System.ComponentModel.Container();
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
            this.puttyTextBox = new System.Windows.Forms.TextBox();
            this.transparencyCheckBox = new System.Windows.Forms.CheckBox();
            this.pageantOptionsTab = new System.Windows.Forms.TabPage();
            this.launchPageantButton = new System.Windows.Forms.Button();
            this.removeKeyButton = new System.Windows.Forms.Button();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.keysListBox = new System.Windows.Forms.ListBox();
            this.locatePageantButton = new System.Windows.Forms.Button();
            this.launchPageantCheckBox = new System.Windows.Forms.CheckBox();
            this.pageantTextBox = new System.Windows.Forms.TextBox();
            this.filezillaOptionsTab = new System.Windows.Forms.TabPage();
            this.sshAuthCheckBox = new System.Windows.Forms.CheckBox();
            this.protocolGroupBox = new System.Windows.Forms.GroupBox();
            this.fzSessionInfoRadioButton = new System.Windows.Forms.RadioButton();
            this.fzFtpsRadioButton = new System.Windows.Forms.RadioButton();
            this.fzSftpRadioButton = new System.Windows.Forms.RadioButton();
            this.fzFtpRadioButton = new System.Windows.Forms.RadioButton();
            this.locateFileZillaButton = new System.Windows.Forms.Button();
            this.enableFileZillaCheckBox = new System.Windows.Forms.CheckBox();
            this.filezillaTextBox = new System.Windows.Forms.TextBox();
            this.winSCPOptionsTab = new System.Windows.Forms.TabPage();
            this.winSCPIniTextBox = new System.Windows.Forms.TextBox();
            this.locateWinSCPIniButton = new System.Windows.Forms.Button();
            this.enableWinSCPCheckBox = new System.Windows.Forms.CheckBox();
            this.useWinSCPIniCheckBox = new System.Windows.Forms.CheckBox();
            this.wsVerGroupBox = new System.Windows.Forms.GroupBox();
            this.wsVer4RadioButton = new System.Windows.Forms.RadioButton();
            this.wsVer3RadioButton = new System.Windows.Forms.RadioButton();
            this.wsProtoGroupBox = new System.Windows.Forms.GroupBox();
            this.wsPrefGroupBox = new System.Windows.Forms.GroupBox();
            this.wsprefScpRadioButton = new System.Windows.Forms.RadioButton();
            this.wsprefSftpRadioButton = new System.Windows.Forms.RadioButton();
            this.wsSessionInfoRadioButton = new System.Windows.Forms.RadioButton();
            this.wsScpRadioButton = new System.Windows.Forms.RadioButton();
            this.wsSftpRadioButton = new System.Windows.Forms.RadioButton();
            this.wsFtpRadioButton = new System.Windows.Forms.RadioButton();
            this.locateWinSCPButton = new System.Windows.Forms.Button();
            this.winSCPTextBox = new System.Windows.Forms.TextBox();
            this.updateOptionsTab = new System.Windows.Forms.TabPage();
            this.checkForUpdateButton = new System.Windows.Forms.Button();
            this.urlCheckBox = new System.Windows.Forms.CheckBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.proxyGroupBox = new System.Windows.Forms.GroupBox();
            this.proxyPortLabel = new System.Windows.Forms.Label();
            this.proxyServerLabel = new System.Windows.Forms.Label();
            this.proxyPortTextBox = new System.Windows.Forms.TextBox();
            this.userProxyRadioButton = new System.Windows.Forms.RadioButton();
            this.directRadioButton = new System.Windows.Forms.RadioButton();
            this.ieProxyRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyServerTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.optionsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.expandTreeCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.generalOptionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.pageantOptionsTab.SuspendLayout();
            this.filezillaOptionsTab.SuspendLayout();
            this.protocolGroupBox.SuspendLayout();
            this.winSCPOptionsTab.SuspendLayout();
            this.wsVerGroupBox.SuspendLayout();
            this.wsProtoGroupBox.SuspendLayout();
            this.wsPrefGroupBox.SuspendLayout();
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
            this.tableLayoutPanel.Size = new System.Drawing.Size(381, 312);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(157, 274);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(67, 22);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalOptionsTab);
            this.tabControl1.Controls.Add(this.pageantOptionsTab);
            this.tabControl1.Controls.Add(this.filezillaOptionsTab);
            this.tabControl1.Controls.Add(this.winSCPOptionsTab);
            this.tabControl1.Controls.Add(this.updateOptionsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 252);
            this.tabControl1.TabIndex = 2;
            // 
            // generalOptionsTab
            // 
            this.generalOptionsTab.Controls.Add(this.expandTreeCheckBox);
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
            this.generalOptionsTab.Controls.Add(this.puttyTextBox);
            this.generalOptionsTab.Controls.Add(this.transparencyCheckBox);
            this.generalOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.generalOptionsTab.Name = "generalOptionsTab";
            this.generalOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalOptionsTab.Size = new System.Drawing.Size(367, 226);
            this.generalOptionsTab.TabIndex = 0;
            this.generalOptionsTab.Text = "General";
            this.generalOptionsTab.UseVisualStyleBackColor = true;
            // 
            // autoMinimizeCheckBox
            // 
            this.autoMinimizeCheckBox.AutoSize = true;
            this.autoMinimizeCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.MinimizeOnUse;
            this.autoMinimizeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "MinimizeOnUse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoMinimizeCheckBox.Location = new System.Drawing.Point(262, 37);
            this.autoMinimizeCheckBox.Name = "autoMinimizeCheckBox";
            this.autoMinimizeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.autoMinimizeCheckBox.Size = new System.Drawing.Size(91, 17);
            this.autoMinimizeCheckBox.TabIndex = 25;
            this.autoMinimizeCheckBox.Text = "&Auto Minimize";
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
            this.toolTipsCheckBox.Text = "&Enable Tooltips";
            this.toolTipsCheckBox.UseVisualStyleBackColor = true;
            // 
            // autostartCheckBox
            // 
            this.autostartCheckBox.AutoSize = true;
            this.autostartCheckBox.Location = new System.Drawing.Point(21, 14);
            this.autostartCheckBox.Name = "autostartCheckBox";
            this.autostartCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.autostartCheckBox.Size = new System.Drawing.Size(92, 17);
            this.autostartCheckBox.TabIndex = 23;
            this.autostartCheckBox.Text = "Start on lo&gon";
            this.autostartCheckBox.UseVisualStyleBackColor = true;
            this.autostartCheckBox.CheckedChanged += new System.EventHandler(this.autostartCheckBox_CheckedChanged);
            // 
            // startupMinimizeCheckBox
            // 
            this.startupMinimizeCheckBox.AutoSize = true;
            this.startupMinimizeCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.MinimizeOnStart;
            this.startupMinimizeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "MinimizeOnStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startupMinimizeCheckBox.Location = new System.Drawing.Point(140, 14);
            this.startupMinimizeCheckBox.Name = "startupMinimizeCheckBox";
            this.startupMinimizeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startupMinimizeCheckBox.Size = new System.Drawing.Size(116, 17);
            this.startupMinimizeCheckBox.TabIndex = 22;
            this.startupMinimizeCheckBox.Text = "Minimize on &startup";
            this.startupMinimizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "SubfolderSessionWarning", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(310, 139);
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
            this.sessionWarningLabel.Location = new System.Drawing.Point(18, 141);
            this.sessionWarningLabel.Name = "sessionWarningLabel";
            this.sessionWarningLabel.Size = new System.Drawing.Size(273, 13);
            this.sessionWarningLabel.TabIndex = 20;
            this.sessionWarningLabel.Text = "&Number of sessions in subfolders to open before warning";
            // 
            // onTopCheckBox
            // 
            this.onTopCheckBox.AutoSize = true;
            this.onTopCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.AlwaysOnTop;
            this.onTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.onTopCheckBox.Location = new System.Drawing.Point(261, 14);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.onTopCheckBox.Size = new System.Drawing.Size(92, 17);
            this.onTopCheckBox.TabIndex = 19;
            this.onTopCheckBox.Text = "Always on &top";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // trackBar
            // 
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyValueInt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TransparencyEnabled;
            this.trackBar.Location = new System.Drawing.Point(21, 87);
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
            this.sampletextTextbox.Location = new System.Drawing.Point(121, 164);
            this.sampletextTextbox.Name = "sampletextTextbox";
            this.sampletextTextbox.ReadOnly = true;
            this.sampletextTextbox.Size = new System.Drawing.Size(232, 20);
            this.sampletextTextbox.TabIndex = 17;
            this.sampletextTextbox.Text = "Sample Text for Tree";
            this.sampletextTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chooseFontButton
            // 
            this.chooseFontButton.Location = new System.Drawing.Point(21, 162);
            this.chooseFontButton.Name = "chooseFontButton";
            this.chooseFontButton.Size = new System.Drawing.Size(98, 22);
            this.chooseFontButton.TabIndex = 16;
            this.chooseFontButton.Text = "&Choose Font";
            this.chooseFontButton.UseVisualStyleBackColor = true;
            this.chooseFontButton.Click += new System.EventHandler(this.chooseFontButton_Click);
            // 
            // locatePuttyButton
            // 
            this.locatePuttyButton.Location = new System.Drawing.Point(21, 189);
            this.locatePuttyButton.Name = "locatePuttyButton";
            this.locatePuttyButton.Size = new System.Drawing.Size(98, 22);
            this.locatePuttyButton.TabIndex = 15;
            this.locatePuttyButton.Text = "&Locate putty.exe";
            this.locatePuttyButton.UseVisualStyleBackColor = true;
            this.locatePuttyButton.Click += new System.EventHandler(this.locatePuttyButton_Click);
            // 
            // puttyTextBox
            // 
            this.puttyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "PuttyLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.puttyTextBox.Location = new System.Drawing.Point(121, 190);
            this.puttyTextBox.Name = "puttyTextBox";
            this.puttyTextBox.ReadOnly = true;
            this.puttyTextBox.Size = new System.Drawing.Size(232, 20);
            this.puttyTextBox.TabIndex = 14;
            this.puttyTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.PuttyLocation;
            // 
            // transparencyCheckBox
            // 
            this.transparencyCheckBox.AutoSize = true;
            this.transparencyCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.transparencyCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TransparencyEnabled;
            this.transparencyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.transparencyCheckBox.Location = new System.Drawing.Point(129, 60);
            this.transparencyCheckBox.Name = "transparencyCheckBox";
            this.transparencyCheckBox.Size = new System.Drawing.Size(127, 17);
            this.transparencyCheckBox.TabIndex = 13;
            this.transparencyCheckBox.Text = "Enable Trans&parency";
            this.transparencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // pageantOptionsTab
            // 
            this.pageantOptionsTab.Controls.Add(this.launchPageantButton);
            this.pageantOptionsTab.Controls.Add(this.removeKeyButton);
            this.pageantOptionsTab.Controls.Add(this.addKeyButton);
            this.pageantOptionsTab.Controls.Add(this.keysListBox);
            this.pageantOptionsTab.Controls.Add(this.locatePageantButton);
            this.pageantOptionsTab.Controls.Add(this.launchPageantCheckBox);
            this.pageantOptionsTab.Controls.Add(this.pageantTextBox);
            this.pageantOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.pageantOptionsTab.Name = "pageantOptionsTab";
            this.pageantOptionsTab.Size = new System.Drawing.Size(367, 226);
            this.pageantOptionsTab.TabIndex = 2;
            this.pageantOptionsTab.Text = "Pageant";
            this.pageantOptionsTab.UseVisualStyleBackColor = true;
            // 
            // launchPageantButton
            // 
            this.launchPageantButton.Location = new System.Drawing.Point(16, 14);
            this.launchPageantButton.Name = "launchPageantButton";
            this.launchPageantButton.Size = new System.Drawing.Size(109, 23);
            this.launchPageantButton.TabIndex = 22;
            this.launchPageantButton.Text = "Launch &Now";
            this.launchPageantButton.UseVisualStyleBackColor = true;
            this.launchPageantButton.Click += new System.EventHandler(this.launchPageantButton_Click);
            // 
            // removeKeyButton
            // 
            this.removeKeyButton.Location = new System.Drawing.Point(17, 99);
            this.removeKeyButton.Name = "removeKeyButton";
            this.removeKeyButton.Size = new System.Drawing.Size(109, 23);
            this.removeKeyButton.TabIndex = 21;
            this.removeKeyButton.Text = "&Remove Key";
            this.removeKeyButton.UseVisualStyleBackColor = true;
            this.removeKeyButton.Click += new System.EventHandler(this.removeKeyButton_Click);
            // 
            // addKeyButton
            // 
            this.addKeyButton.Location = new System.Drawing.Point(17, 70);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(109, 23);
            this.addKeyButton.TabIndex = 20;
            this.addKeyButton.Text = "&Add Key";
            this.addKeyButton.UseVisualStyleBackColor = true;
            this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
            // 
            // keysListBox
            // 
            this.keysListBox.FormattingEnabled = true;
            this.keysListBox.HorizontalScrollbar = true;
            this.keysListBox.Location = new System.Drawing.Point(132, 44);
            this.keysListBox.Name = "keysListBox";
            this.keysListBox.Size = new System.Drawing.Size(217, 108);
            this.keysListBox.TabIndex = 19;
            // 
            // locatePageantButton
            // 
            this.locatePageantButton.Location = new System.Drawing.Point(17, 156);
            this.locatePageantButton.Name = "locatePageantButton";
            this.locatePageantButton.Size = new System.Drawing.Size(110, 24);
            this.locatePageantButton.TabIndex = 17;
            this.locatePageantButton.Text = "&Locate pageant.exe";
            this.locatePageantButton.UseVisualStyleBackColor = true;
            this.locatePageantButton.Click += new System.EventHandler(this.locatePagentButton_Click);
            // 
            // launchPageantCheckBox
            // 
            this.launchPageantCheckBox.AutoSize = true;
            this.launchPageantCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.LaunchPageantOnStart;
            this.launchPageantCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "LaunchPageantOnStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.launchPageantCheckBox.Location = new System.Drawing.Point(197, 14);
            this.launchPageantCheckBox.Name = "launchPageantCheckBox";
            this.launchPageantCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.launchPageantCheckBox.Size = new System.Drawing.Size(152, 17);
            this.launchPageantCheckBox.TabIndex = 18;
            this.launchPageantCheckBox.Text = "Launch Pageant at &startup";
            this.launchPageantCheckBox.UseVisualStyleBackColor = true;
            // 
            // pageantTextBox
            // 
            this.pageantTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "PageantLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pageantTextBox.Location = new System.Drawing.Point(132, 158);
            this.pageantTextBox.Name = "pageantTextBox";
            this.pageantTextBox.ReadOnly = true;
            this.pageantTextBox.Size = new System.Drawing.Size(217, 20);
            this.pageantTextBox.TabIndex = 16;
            this.pageantTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.PageantLocation;
            // 
            // filezillaOptionsTab
            // 
            this.filezillaOptionsTab.Controls.Add(this.sshAuthCheckBox);
            this.filezillaOptionsTab.Controls.Add(this.protocolGroupBox);
            this.filezillaOptionsTab.Controls.Add(this.locateFileZillaButton);
            this.filezillaOptionsTab.Controls.Add(this.enableFileZillaCheckBox);
            this.filezillaOptionsTab.Controls.Add(this.filezillaTextBox);
            this.filezillaOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.filezillaOptionsTab.Name = "filezillaOptionsTab";
            this.filezillaOptionsTab.Size = new System.Drawing.Size(367, 226);
            this.filezillaOptionsTab.TabIndex = 3;
            this.filezillaOptionsTab.Text = "FileZilla";
            this.filezillaOptionsTab.UseVisualStyleBackColor = true;
            // 
            // sshAuthCheckBox
            // 
            this.sshAuthCheckBox.AutoSize = true;
            this.sshAuthCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaAttemptKeyAuth;
            this.sshAuthCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sshAuthCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sshAuthCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaAttemptKeyAuth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sshAuthCheckBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaEnabled;
            this.sshAuthCheckBox.Location = new System.Drawing.Point(18, 79);
            this.sshAuthCheckBox.Name = "sshAuthCheckBox";
            this.sshAuthCheckBox.Size = new System.Drawing.Size(178, 17);
            this.sshAuthCheckBox.TabIndex = 22;
            this.sshAuthCheckBox.Text = "Attempt SSH Key Auth for SFTP";
            this.sshAuthCheckBox.UseVisualStyleBackColor = true;
            this.sshAuthCheckBox.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // protocolGroupBox
            // 
            this.protocolGroupBox.Controls.Add(this.fzSessionInfoRadioButton);
            this.protocolGroupBox.Controls.Add(this.fzFtpsRadioButton);
            this.protocolGroupBox.Controls.Add(this.fzSftpRadioButton);
            this.protocolGroupBox.Controls.Add(this.fzFtpRadioButton);
            this.protocolGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.protocolGroupBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaEnabled;
            this.protocolGroupBox.Location = new System.Drawing.Point(239, 13);
            this.protocolGroupBox.Name = "protocolGroupBox";
            this.protocolGroupBox.Size = new System.Drawing.Size(114, 119);
            this.protocolGroupBox.TabIndex = 20;
            this.protocolGroupBox.TabStop = false;
            this.protocolGroupBox.Text = "Protocol";
            // 
            // fzSessionInfoRadioButton
            // 
            this.fzSessionInfoRadioButton.AutoSize = true;
            this.fzSessionInfoRadioButton.Checked = true;
            this.fzSessionInfoRadioButton.Location = new System.Drawing.Point(6, 19);
            this.fzSessionInfoRadioButton.Name = "fzSessionInfoRadioButton";
            this.fzSessionInfoRadioButton.Size = new System.Drawing.Size(105, 17);
            this.fzSessionInfoRadioButton.TabIndex = 3;
            this.fzSessionInfoRadioButton.TabStop = true;
            this.fzSessionInfoRadioButton.Text = "Use Session Info";
            this.fzSessionInfoRadioButton.UseVisualStyleBackColor = true;
            this.fzSessionInfoRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // fzFtpsRadioButton
            // 
            this.fzFtpsRadioButton.AutoSize = true;
            this.fzFtpsRadioButton.Location = new System.Drawing.Point(6, 88);
            this.fzFtpsRadioButton.Name = "fzFtpsRadioButton";
            this.fzFtpsRadioButton.Size = new System.Drawing.Size(76, 17);
            this.fzFtpsRadioButton.TabIndex = 2;
            this.fzFtpsRadioButton.TabStop = true;
            this.fzFtpsRadioButton.Text = "FTPS(990)";
            this.fzFtpsRadioButton.UseVisualStyleBackColor = true;
            this.fzFtpsRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // fzSftpRadioButton
            // 
            this.fzSftpRadioButton.AutoSize = true;
            this.fzSftpRadioButton.Location = new System.Drawing.Point(6, 65);
            this.fzSftpRadioButton.Name = "fzSftpRadioButton";
            this.fzSftpRadioButton.Size = new System.Drawing.Size(70, 17);
            this.fzSftpRadioButton.TabIndex = 1;
            this.fzSftpRadioButton.TabStop = true;
            this.fzSftpRadioButton.Text = "SFTP(22)";
            this.fzSftpRadioButton.UseVisualStyleBackColor = true;
            this.fzSftpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // fzFtpRadioButton
            // 
            this.fzFtpRadioButton.AutoSize = true;
            this.fzFtpRadioButton.Location = new System.Drawing.Point(6, 42);
            this.fzFtpRadioButton.Name = "fzFtpRadioButton";
            this.fzFtpRadioButton.Size = new System.Drawing.Size(66, 17);
            this.fzFtpRadioButton.TabIndex = 0;
            this.fzFtpRadioButton.TabStop = true;
            this.fzFtpRadioButton.Text = "FTP (21)";
            this.fzFtpRadioButton.UseVisualStyleBackColor = true;
            this.fzFtpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // locateFileZillaButton
            // 
            this.locateFileZillaButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.locateFileZillaButton.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaEnabled;
            this.locateFileZillaButton.Location = new System.Drawing.Point(18, 156);
            this.locateFileZillaButton.Name = "locateFileZillaButton";
            this.locateFileZillaButton.Size = new System.Drawing.Size(115, 24);
            this.locateFileZillaButton.TabIndex = 19;
            this.locateFileZillaButton.Text = "&Locate FileZilla.exe";
            this.locateFileZillaButton.UseVisualStyleBackColor = true;
            this.locateFileZillaButton.Click += new System.EventHandler(this.locateFileZillaButton_Click);
            // 
            // enableFileZillaCheckBox
            // 
            this.enableFileZillaCheckBox.AutoSize = true;
            this.enableFileZillaCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaEnabled;
            this.enableFileZillaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enableFileZillaCheckBox.Location = new System.Drawing.Point(18, 32);
            this.enableFileZillaCheckBox.Name = "enableFileZillaCheckBox";
            this.enableFileZillaCheckBox.Size = new System.Drawing.Size(154, 17);
            this.enableFileZillaCheckBox.TabIndex = 0;
            this.enableFileZillaCheckBox.Text = "Enable FileZilla 2.x Support";
            this.enableFileZillaCheckBox.UseVisualStyleBackColor = true;
            // 
            // filezillaTextBox
            // 
            this.filezillaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.filezillaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "FileZillaEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.filezillaTextBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaEnabled;
            this.filezillaTextBox.Location = new System.Drawing.Point(139, 159);
            this.filezillaTextBox.Name = "filezillaTextBox";
            this.filezillaTextBox.ReadOnly = true;
            this.filezillaTextBox.Size = new System.Drawing.Size(214, 20);
            this.filezillaTextBox.TabIndex = 18;
            this.filezillaTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.FileZillaLocation;
            // 
            // winSCPOptionsTab
            // 
            this.winSCPOptionsTab.Controls.Add(this.winSCPIniTextBox);
            this.winSCPOptionsTab.Controls.Add(this.locateWinSCPIniButton);
            this.winSCPOptionsTab.Controls.Add(this.enableWinSCPCheckBox);
            this.winSCPOptionsTab.Controls.Add(this.useWinSCPIniCheckBox);
            this.winSCPOptionsTab.Controls.Add(this.wsVerGroupBox);
            this.winSCPOptionsTab.Controls.Add(this.wsProtoGroupBox);
            this.winSCPOptionsTab.Controls.Add(this.locateWinSCPButton);
            this.winSCPOptionsTab.Controls.Add(this.winSCPTextBox);
            this.winSCPOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.winSCPOptionsTab.Name = "winSCPOptionsTab";
            this.winSCPOptionsTab.Size = new System.Drawing.Size(367, 226);
            this.winSCPOptionsTab.TabIndex = 4;
            this.winSCPOptionsTab.Text = "WinSCP";
            this.winSCPOptionsTab.UseVisualStyleBackColor = true;
            // 
            // winSCPIniTextBox
            // 
            this.winSCPIniTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.winSCPIniTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPIniLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.winSCPIniTextBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.winSCPIniTextBox.Location = new System.Drawing.Point(159, 128);
            this.winSCPIniTextBox.Name = "winSCPIniTextBox";
            this.winSCPIniTextBox.ReadOnly = true;
            this.winSCPIniTextBox.Size = new System.Drawing.Size(192, 20);
            this.winSCPIniTextBox.TabIndex = 30;
            this.winSCPIniTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPIniLocation;
            // 
            // locateWinSCPIniButton
            // 
            this.locateWinSCPIniButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.locateWinSCPIniButton.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.locateWinSCPIniButton.Location = new System.Drawing.Point(16, 125);
            this.locateWinSCPIniButton.Name = "locateWinSCPIniButton";
            this.locateWinSCPIniButton.Size = new System.Drawing.Size(134, 24);
            this.locateWinSCPIniButton.TabIndex = 29;
            this.locateWinSCPIniButton.Text = "&Locate WinSCP ini file";
            this.locateWinSCPIniButton.UseVisualStyleBackColor = true;
            this.locateWinSCPIniButton.Click += new System.EventHandler(this.locateWinSCPIniButton_Click);
            // 
            // enableWinSCPCheckBox
            // 
            this.enableWinSCPCheckBox.AutoSize = true;
            this.enableWinSCPCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.enableWinSCPCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enableWinSCPCheckBox.Location = new System.Drawing.Point(16, 21);
            this.enableWinSCPCheckBox.Name = "enableWinSCPCheckBox";
            this.enableWinSCPCheckBox.Size = new System.Drawing.Size(142, 17);
            this.enableWinSCPCheckBox.TabIndex = 23;
            this.enableWinSCPCheckBox.Text = "Enable WinSCP Support";
            this.enableWinSCPCheckBox.UseVisualStyleBackColor = true;
            // 
            // useWinSCPIniCheckBox
            // 
            this.useWinSCPIniCheckBox.AutoSize = true;
            this.useWinSCPIniCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPIniEnabled;
            this.useWinSCPIniCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPIniEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useWinSCPIniCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useWinSCPIniCheckBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.useWinSCPIniCheckBox.Location = new System.Drawing.Point(16, 99);
            this.useWinSCPIniCheckBox.Name = "useWinSCPIniCheckBox";
            this.useWinSCPIniCheckBox.Size = new System.Drawing.Size(117, 17);
            this.useWinSCPIniCheckBox.TabIndex = 28;
            this.useWinSCPIniCheckBox.Text = "Use WinSCP ini file";
            this.useWinSCPIniCheckBox.UseVisualStyleBackColor = true;
            // 
            // wsVerGroupBox
            // 
            this.wsVerGroupBox.Controls.Add(this.wsVer4RadioButton);
            this.wsVerGroupBox.Controls.Add(this.wsVer3RadioButton);
            this.wsVerGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.wsVerGroupBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.wsVerGroupBox.Location = new System.Drawing.Point(16, 47);
            this.wsVerGroupBox.Name = "wsVerGroupBox";
            this.wsVerGroupBox.Size = new System.Drawing.Size(134, 42);
            this.wsVerGroupBox.TabIndex = 27;
            this.wsVerGroupBox.TabStop = false;
            this.wsVerGroupBox.Text = "WinSCP Version";
            // 
            // wsVer4RadioButton
            // 
            this.wsVer4RadioButton.AutoSize = true;
            this.wsVer4RadioButton.Location = new System.Drawing.Point(60, 19);
            this.wsVer4RadioButton.Name = "wsVer4RadioButton";
            this.wsVer4RadioButton.Size = new System.Drawing.Size(41, 17);
            this.wsVer4RadioButton.TabIndex = 1;
            this.wsVer4RadioButton.Text = "4.X";
            this.wsVer4RadioButton.UseVisualStyleBackColor = true;
            this.wsVer4RadioButton.CheckedChanged += new System.EventHandler(this.wsVerRadioButton_CheckedChanged);
            // 
            // wsVer3RadioButton
            // 
            this.wsVer3RadioButton.AutoSize = true;
            this.wsVer3RadioButton.Checked = true;
            this.wsVer3RadioButton.Location = new System.Drawing.Point(13, 19);
            this.wsVer3RadioButton.Name = "wsVer3RadioButton";
            this.wsVer3RadioButton.Size = new System.Drawing.Size(41, 17);
            this.wsVer3RadioButton.TabIndex = 0;
            this.wsVer3RadioButton.TabStop = true;
            this.wsVer3RadioButton.Text = "3.X";
            this.wsVer3RadioButton.UseVisualStyleBackColor = true;
            this.wsVer3RadioButton.CheckedChanged += new System.EventHandler(this.wsVerRadioButton_CheckedChanged);
            // 
            // wsProtoGroupBox
            // 
            this.wsProtoGroupBox.Controls.Add(this.wsPrefGroupBox);
            this.wsProtoGroupBox.Controls.Add(this.wsSessionInfoRadioButton);
            this.wsProtoGroupBox.Controls.Add(this.wsScpRadioButton);
            this.wsProtoGroupBox.Controls.Add(this.wsSftpRadioButton);
            this.wsProtoGroupBox.Controls.Add(this.wsFtpRadioButton);
            this.wsProtoGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.wsProtoGroupBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.wsProtoGroupBox.Location = new System.Drawing.Point(159, 11);
            this.wsProtoGroupBox.Name = "wsProtoGroupBox";
            this.wsProtoGroupBox.Size = new System.Drawing.Size(192, 105);
            this.wsProtoGroupBox.TabIndex = 26;
            this.wsProtoGroupBox.TabStop = false;
            this.wsProtoGroupBox.Text = "Protocol";
            // 
            // wsPrefGroupBox
            // 
            this.wsPrefGroupBox.Controls.Add(this.wsprefScpRadioButton);
            this.wsPrefGroupBox.Controls.Add(this.wsprefSftpRadioButton);
            this.wsPrefGroupBox.Location = new System.Drawing.Point(5, 36);
            this.wsPrefGroupBox.Name = "wsPrefGroupBox";
            this.wsPrefGroupBox.Size = new System.Drawing.Size(106, 64);
            this.wsPrefGroupBox.TabIndex = 4;
            this.wsPrefGroupBox.TabStop = false;
            this.wsPrefGroupBox.Text = "Preferred Protocol";
            // 
            // wsprefScpRadioButton
            // 
            this.wsprefScpRadioButton.AutoSize = true;
            this.wsprefScpRadioButton.Location = new System.Drawing.Point(13, 39);
            this.wsprefScpRadioButton.Name = "wsprefScpRadioButton";
            this.wsprefScpRadioButton.Size = new System.Drawing.Size(64, 17);
            this.wsprefScpRadioButton.TabIndex = 4;
            this.wsprefScpRadioButton.Text = "SCP(22)";
            this.wsprefScpRadioButton.UseVisualStyleBackColor = true;
            this.wsprefScpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // wsprefSftpRadioButton
            // 
            this.wsprefSftpRadioButton.AutoSize = true;
            this.wsprefSftpRadioButton.Checked = true;
            this.wsprefSftpRadioButton.Location = new System.Drawing.Point(13, 17);
            this.wsprefSftpRadioButton.Name = "wsprefSftpRadioButton";
            this.wsprefSftpRadioButton.Size = new System.Drawing.Size(70, 17);
            this.wsprefSftpRadioButton.TabIndex = 3;
            this.wsprefSftpRadioButton.TabStop = true;
            this.wsprefSftpRadioButton.Text = "SFTP(22)";
            this.wsprefSftpRadioButton.UseVisualStyleBackColor = true;
            this.wsprefSftpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // wsSessionInfoRadioButton
            // 
            this.wsSessionInfoRadioButton.AutoSize = true;
            this.wsSessionInfoRadioButton.Checked = true;
            this.wsSessionInfoRadioButton.Location = new System.Drawing.Point(6, 19);
            this.wsSessionInfoRadioButton.Name = "wsSessionInfoRadioButton";
            this.wsSessionInfoRadioButton.Size = new System.Drawing.Size(105, 17);
            this.wsSessionInfoRadioButton.TabIndex = 3;
            this.wsSessionInfoRadioButton.TabStop = true;
            this.wsSessionInfoRadioButton.Text = "Use Session Info";
            this.wsSessionInfoRadioButton.UseVisualStyleBackColor = true;
            this.wsSessionInfoRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // wsScpRadioButton
            // 
            this.wsScpRadioButton.AutoSize = true;
            this.wsScpRadioButton.Location = new System.Drawing.Point(122, 64);
            this.wsScpRadioButton.Name = "wsScpRadioButton";
            this.wsScpRadioButton.Size = new System.Drawing.Size(64, 17);
            this.wsScpRadioButton.TabIndex = 2;
            this.wsScpRadioButton.TabStop = true;
            this.wsScpRadioButton.Text = "SCP(22)";
            this.wsScpRadioButton.UseVisualStyleBackColor = true;
            this.wsScpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // wsSftpRadioButton
            // 
            this.wsSftpRadioButton.AutoSize = true;
            this.wsSftpRadioButton.Location = new System.Drawing.Point(122, 42);
            this.wsSftpRadioButton.Name = "wsSftpRadioButton";
            this.wsSftpRadioButton.Size = new System.Drawing.Size(70, 17);
            this.wsSftpRadioButton.TabIndex = 1;
            this.wsSftpRadioButton.TabStop = true;
            this.wsSftpRadioButton.Text = "SFTP(22)";
            this.wsSftpRadioButton.UseVisualStyleBackColor = true;
            this.wsSftpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // wsFtpRadioButton
            // 
            this.wsFtpRadioButton.AutoSize = true;
            this.wsFtpRadioButton.Location = new System.Drawing.Point(122, 19);
            this.wsFtpRadioButton.Name = "wsFtpRadioButton";
            this.wsFtpRadioButton.Size = new System.Drawing.Size(66, 17);
            this.wsFtpRadioButton.TabIndex = 0;
            this.wsFtpRadioButton.TabStop = true;
            this.wsFtpRadioButton.Text = "FTP (21)";
            this.wsFtpRadioButton.UseVisualStyleBackColor = true;
            this.wsFtpRadioButton.CheckedChanged += new System.EventHandler(this.protocolRadioButton_CheckedChanged);
            // 
            // locateWinSCPButton
            // 
            this.locateWinSCPButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.locateWinSCPButton.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.locateWinSCPButton.Location = new System.Drawing.Point(16, 155);
            this.locateWinSCPButton.Name = "locateWinSCPButton";
            this.locateWinSCPButton.Size = new System.Drawing.Size(134, 24);
            this.locateWinSCPButton.TabIndex = 25;
            this.locateWinSCPButton.Text = "&Locate WinSCP*.exe";
            this.locateWinSCPButton.UseVisualStyleBackColor = true;
            this.locateWinSCPButton.Click += new System.EventHandler(this.locateWinSCPButton_Click);
            // 
            // winSCPTextBox
            // 
            this.winSCPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.winSCPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "WinSCPLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.winSCPTextBox.Enabled = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPEnabled;
            this.winSCPTextBox.Location = new System.Drawing.Point(159, 158);
            this.winSCPTextBox.Name = "winSCPTextBox";
            this.winSCPTextBox.ReadOnly = true;
            this.winSCPTextBox.Size = new System.Drawing.Size(192, 20);
            this.winSCPTextBox.TabIndex = 24;
            this.winSCPTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.WinSCPLocation;
            // 
            // updateOptionsTab
            // 
            this.updateOptionsTab.Controls.Add(this.checkForUpdateButton);
            this.updateOptionsTab.Controls.Add(this.urlCheckBox);
            this.updateOptionsTab.Controls.Add(this.urlLabel);
            this.updateOptionsTab.Controls.Add(this.proxyGroupBox);
            this.updateOptionsTab.Controls.Add(this.urlTextBox);
            this.updateOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.updateOptionsTab.Name = "updateOptionsTab";
            this.updateOptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateOptionsTab.Size = new System.Drawing.Size(367, 226);
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
            this.checkForUpdateButton.Text = "&Check for update...";
            this.checkForUpdateButton.UseVisualStyleBackColor = true;
            this.checkForUpdateButton.Click += new System.EventHandler(this.checkForUpdateButton_Click);
            // 
            // urlCheckBox
            // 
            this.urlCheckBox.AutoSize = true;
            this.urlCheckBox.Checked = true;
            this.urlCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.urlCheckBox.Location = new System.Drawing.Point(28, 6);
            this.urlCheckBox.Name = "urlCheckBox";
            this.urlCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.urlCheckBox.Size = new System.Drawing.Size(94, 17);
            this.urlCheckBox.TabIndex = 1;
            this.urlCheckBox.Text = "Use &default url";
            this.urlCheckBox.UseVisualStyleBackColor = true;
            this.urlCheckBox.CheckedChanged += new System.EventHandler(this.urlCheckBox_CheckedChanged);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(47, 30);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(56, 13);
            this.urlLabel.TabIndex = 15;
            this.urlLabel.Text = "&Update url";
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
            this.userProxyRadioButton.Text = "Use &HTTP Proxy";
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
            this.directRadioButton.Text = "Direct &Connection";
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
            this.ieProxyRadioButton.Text = "Use &IE Settings";
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
            // urlTextBox
            // 
            this.urlTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "UpdateUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.urlTextBox.Location = new System.Drawing.Point(109, 27);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(229, 20);
            this.urlTextBox.TabIndex = 2;
            this.urlTextBox.Text = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.UpdateUrl;
            // 
            // optionsToolTip
            // 
            this.optionsToolTip.IsBalloon = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(105, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Use Session Info";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 88);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "FTPS(990)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "SFTP(22)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 42);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(66, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "FTP (21)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // fontDialog
            // 
            this.fontDialog.Font = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TreeFont;
            this.fontDialog.ShowColor = true;
            this.fontDialog.ShowEffects = false;
            // 
            // expandTreeCheckBox
            // 
            this.expandTreeCheckBox.AutoSize = true;
            this.expandTreeCheckBox.Checked = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.ExpandTreeOnStartup;
            this.expandTreeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "ExpandTreeOnStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.expandTreeCheckBox.Location = new System.Drawing.Point(119, 37);
            this.expandTreeCheckBox.Name = "expandTreeCheckBox";
            this.expandTreeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expandTreeCheckBox.Size = new System.Drawing.Size(137, 17);
            this.expandTreeCheckBox.TabIndex = 26;
            this.expandTreeCheckBox.Text = "E&xpand Tree on startup";
            this.expandTreeCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 312);
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
            this.filezillaOptionsTab.ResumeLayout(false);
            this.filezillaOptionsTab.PerformLayout();
            this.protocolGroupBox.ResumeLayout(false);
            this.protocolGroupBox.PerformLayout();
            this.winSCPOptionsTab.ResumeLayout(false);
            this.winSCPOptionsTab.PerformLayout();
            this.wsVerGroupBox.ResumeLayout(false);
            this.wsVerGroupBox.PerformLayout();
            this.wsProtoGroupBox.ResumeLayout(false);
            this.wsProtoGroupBox.PerformLayout();
            this.wsPrefGroupBox.ResumeLayout(false);
            this.wsPrefGroupBox.PerformLayout();
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
        private System.Windows.Forms.TextBox puttyTextBox;
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
        private System.Windows.Forms.TabPage filezillaOptionsTab;
        private System.Windows.Forms.ListBox keysListBox;
        private System.Windows.Forms.CheckBox launchPageantCheckBox;
        private System.Windows.Forms.Button removeKeyButton;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.Button launchPageantButton;
        private System.Windows.Forms.CheckBox autoMinimizeCheckBox;
        private System.Windows.Forms.Button locateFileZillaButton;
        private System.Windows.Forms.TextBox filezillaTextBox;
        private System.Windows.Forms.CheckBox enableFileZillaCheckBox;
        private System.Windows.Forms.GroupBox protocolGroupBox;
        private System.Windows.Forms.RadioButton fzSessionInfoRadioButton;
        private System.Windows.Forms.RadioButton fzFtpsRadioButton;
        private System.Windows.Forms.RadioButton fzSftpRadioButton;
        private System.Windows.Forms.RadioButton fzFtpRadioButton;
        private System.Windows.Forms.ToolTip optionsToolTip;
        private System.Windows.Forms.CheckBox sshAuthCheckBox;
        private System.Windows.Forms.TabPage winSCPOptionsTab;
        private System.Windows.Forms.GroupBox wsProtoGroupBox;
        private System.Windows.Forms.RadioButton wsSessionInfoRadioButton;
        private System.Windows.Forms.RadioButton wsScpRadioButton;
        private System.Windows.Forms.RadioButton wsSftpRadioButton;
        private System.Windows.Forms.RadioButton wsFtpRadioButton;
        private System.Windows.Forms.Button locateWinSCPButton;
        private System.Windows.Forms.CheckBox enableWinSCPCheckBox;
        private System.Windows.Forms.TextBox winSCPTextBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox wsPrefGroupBox;
        private System.Windows.Forms.RadioButton wsprefScpRadioButton;
        private System.Windows.Forms.RadioButton wsprefSftpRadioButton;
        private System.Windows.Forms.GroupBox wsVerGroupBox;
        private System.Windows.Forms.RadioButton wsVer4RadioButton;
        private System.Windows.Forms.RadioButton wsVer3RadioButton;
        private System.Windows.Forms.Button locateWinSCPIniButton;
        private System.Windows.Forms.CheckBox useWinSCPIniCheckBox;
        private System.Windows.Forms.TextBox winSCPIniTextBox;
        private System.Windows.Forms.CheckBox expandTreeCheckBox;
    }
}