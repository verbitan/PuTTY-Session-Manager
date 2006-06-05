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
using uk.org.riseley.puttySessionManager.model;

namespace uk.org.riseley.puttySessionManager
{
    partial class SessionTreeControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionTreeControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Sessions");
            this.nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.launchSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lockSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.nodeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeContextMenuStrip
            // 
            this.nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchSessionMenuItem,
            this.newSessionMenuItem,
            this.toolStripSeparator2,
            this.newFolderMenuItem,
            this.renameFolderMenuItem,
            this.toolStripSeparator3,
            this.lockSessionsToolStripMenuItem});
            this.nodeContextMenuStrip.Name = "contextMenuStrip";
            this.nodeContextMenuStrip.Size = new System.Drawing.Size(159, 126);
            // 
            // launchSessionMenuItem
            // 
            this.launchSessionMenuItem.Name = "launchSessionMenuItem";
            this.launchSessionMenuItem.Size = new System.Drawing.Size(158, 22);
            this.launchSessionMenuItem.Text = "Launch Session";
            this.launchSessionMenuItem.Click += new System.EventHandler(this.launchSessionMenuItem_Click);
            // 
            // newSessionMenuItem
            // 
            this.newSessionMenuItem.Name = "newSessionMenuItem";
            this.newSessionMenuItem.Size = new System.Drawing.Size(158, 22);
            this.newSessionMenuItem.Text = "New Session";
            this.newSessionMenuItem.Click += new System.EventHandler(this.newSessionMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // newFolderMenuItem
            // 
            this.newFolderMenuItem.Enabled = false;
            this.newFolderMenuItem.Name = "newFolderMenuItem";
            this.newFolderMenuItem.Size = new System.Drawing.Size(158, 22);
            this.newFolderMenuItem.Text = "New Folder";
            this.newFolderMenuItem.Click += new System.EventHandler(this.newFolderMenuItem_Click);
            // 
            // renameFolderMenuItem
            // 
            this.renameFolderMenuItem.Enabled = false;
            this.renameFolderMenuItem.Name = "renameFolderMenuItem";
            this.renameFolderMenuItem.Size = new System.Drawing.Size(158, 22);
            this.renameFolderMenuItem.Text = "Rename Folder";
            this.renameFolderMenuItem.Click += new System.EventHandler(this.renameFolderMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // lockSessionsToolStripMenuItem
            // 
            this.lockSessionsToolStripMenuItem.Checked = true;
            this.lockSessionsToolStripMenuItem.CheckOnClick = true;
            this.lockSessionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockSessionsToolStripMenuItem.Name = "lockSessionsToolStripMenuItem";
            this.lockSessionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.lockSessionsToolStripMenuItem.Text = "Lock Sessions";
            this.lockSessionsToolStripMenuItem.Click += new System.EventHandler(this.lockSessionsToolStripMenuItem_Click);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "Folder.gif");
            this.treeImageList.Images.SetKeyName(1, "SelectedFolder.gif");
            this.treeImageList.Images.SetKeyName(2, "Putty.gif");
            // 
            // treeView
            // 
            this.treeView.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::uk.org.riseley.puttySessionManager.Properties.Settings.Default, "TreeFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = global::uk.org.riseley.puttySessionManager.Properties.Settings.Default.TreeFont;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeImageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.ContextMenuStrip = this.nodeContextMenuStrip;
            treeNode1.Name = "SessionsNode";
            treeNode1.Text = "Sessions";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.SelectedImageIndex = 1;
            this.treeView.Size = new System.Drawing.Size(205, 414);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            // 
            // SessionTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView);
            this.DoubleBuffered = true;
            this.Name = "SessionTreeControl";
            this.Size = new System.Drawing.Size(205, 414);
            this.nodeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem launchSessionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSessionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderMenuItem;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem renameFolderMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem lockSessionsToolStripMenuItem;
    }
}
