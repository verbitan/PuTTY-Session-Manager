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
    partial class SessionManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionManagerForm));
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sessionTreeControl1 = new uk.org.riseley.puttySessionManager.SessionTreeControl();
            this.sysTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.sysTrayContextMenu;
            resources.ApplyResources(this.systrayIcon, "systrayIcon");
            this.systrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // sessionTreeControl1
            // 
            resources.ApplyResources(this.sessionTreeControl1, "sessionTreeControl1");
            this.sessionTreeControl1.Name = "sessionTreeControl1";
            this.sessionTreeControl1.LaunchSession += new uk.org.riseley.puttySessionManager.SessionTreeControl.SessionEventHandler(this.sessionTreeControl1_LaunchSession);
            this.sessionTreeControl1.ShowAbout += new System.EventHandler(this.sessionTreeControl1_ShowAbout);
            this.sessionTreeControl1.ShowOptions += new System.EventHandler(this.sessionTreeControl1_ShowOptions);
            // 
            // sysTrayContextMenu
            // 
            this.sysTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.sysTrayContextMenu.Name = "sysTrayContextMenu";
            resources.ApplyResources(this.sysTrayContextMenu, "sysTrayContextMenu");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SessionManagerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sessionTreeControl1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Opacity", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TransparencyValueDouble", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("TopMost", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SessionManagerForm";
            this.Opacity = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TransparencyValueDouble;
            this.TopMost = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.AlwaysOnTop;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SessionManagerForm_FormClosing_1);
            this.sysTrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon systrayIcon;
        private uk.org.riseley.puttySessionManager.SessionTreeControl sessionTreeControl1;
        private System.Windows.Forms.ContextMenuStrip sysTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

