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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using uk.org.riseley.puttySessionManager.model;
using System.Collections;


namespace uk.org.riseley.puttySessionManager
{
    public partial class SessionTreeControl : SessionControl, uk.org.riseley.puttySessionManager.ISessionControl
    {

        private const int IMAGE_INDEX_FOLDER = 0;
        private const int IMAGE_INDEX_SELECTED_FOLDER = 1;
        private const int IMAGE_INDEX_SESSION = 2;

        public SessionTreeControl()
            : base()
        {
            InitializeComponent();
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            //else if (e.Button == MouseButtons.Right)
            //{
            //    DoDragDrop(e.Item, DragDropEffects.Copy);
            //}
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeView.SelectedNode = treeView.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = treeView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node, 
            // and the target node is a folder
            if (!draggedNode.Equals(targetNode) &&
                !ContainsNode(draggedNode, targetNode) &&
                ((Session)targetNode.Tag).IsFolder)
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    // Capture the old parent node
                    TreeNode oldParent = draggedNode.Parent;

                    // Remove the old node and add it back in
                    // in the new location
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);

                    // Update the new location for this node and/or its
                    // children
                    updateFolders(draggedNode, targetNode);

                    // Cleanup any hanging folders
                    cleanFolders(oldParent);

                    // Fire a refresh event
                    OnRefreshSessions(new RefreshSessionsEventArgs(false));
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                //targetNode.Expand();
            }
        }

        // Save the changed folder information for a node and 
        // all its children
        private void updateFolders(TreeNode node, TreeNode parent)
        {
            // If the node is a session update the new location
            Session s = ((Session)node.Tag);
            if (s.IsFolder == false)
            {
                s.FolderName = parent.FullPath;
                getSessionController().saveFolderToRegistry(s);
            }
            else
            {
                System.Collections.IEnumerator nodeEnumerator = node.Nodes.GetEnumerator();

                while (nodeEnumerator.MoveNext())
                {
                    TreeNode currNode = (TreeNode)(nodeEnumerator.Current);
                    updateFolders(currNode, currNode.Parent);
                }

            }
        }

        // Remove any hanging folders
        private void cleanFolders(TreeNode node)
        {
            Session s = ((Session)node.Tag);
            TreeNode parentNode = node.Parent;
            if (s.IsFolder == true && node.FirstNode == null)
            {
                node.Remove();
                s = ((Session)parentNode.Tag);
                if (s.IsFolder && !(s.SessionDisplayText.Equals(Session.SESSIONS_FOLDER_NAME)))
                {
                    cleanFolders(parentNode);
                }
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        protected override void LoadSessions()
        {

            // Suppress repainting the TreeView until all the objects have been created.
            treeView.BeginUpdate();

            // Store the root node and path
            TreeNode rootNode = treeView.Nodes[0];
            string rootPath = rootNode.FullPath;
            string pathSep = treeView.PathSeparator;

            // Clear out the current tree
            rootNode.Nodes.Clear();

            // Create the root node tag if it doesn't already exist
            if (rootNode.Tag == null)
                rootNode.Tag = new Session(rootPath, rootPath, true);

            foreach (Session s in getSessionController().getSessionList())
            {
                TreeNode newNode = new TreeNode(s.SessionDisplayText);
                newNode.Tag = s;
                newNode.ContextMenuStrip = nodeContextMenuStrip;
                newNode.ImageIndex = IMAGE_INDEX_SESSION;
                newNode.SelectedImageIndex = IMAGE_INDEX_SESSION;

                if (s.FolderName == null || s.FolderName.Equals("") || s.FolderName.Equals(rootPath))
                {
                    rootNode.Nodes.Add(newNode);
                }
                else
                {
                    TreeNode currnode = rootNode;
                    foreach (string folder in s.FolderName.Split(pathSep.ToCharArray()))
                    {
                        // Is this folder the root folder,
                        // if so, skip to the next one
                        if (folder.Equals(rootPath))
                            continue;

                        // Does this folder exist as a child of the current node
                        if (currnode.Nodes.ContainsKey(folder))
                        {
                            currnode = currnode.Nodes[folder];
                        }
                        else
                        {
                            Session sess = new Session(folder, s.FolderName, true);
                            currnode.Nodes.Add(folder, sess.SessionDisplayText);
                            currnode = currnode.Nodes[folder];
                            currnode.Tag = sess;
                            currnode.ContextMenuStrip = nodeContextMenuStrip;
                            currnode.ImageIndex = IMAGE_INDEX_FOLDER;
                            currnode.SelectedImageIndex = IMAGE_INDEX_SELECTED_FOLDER;
                        }

                    }

                    currnode.Nodes.Add(newNode);
                }
            }

            this.treeView.Sort();
            // Begin repainting the TreeView.
            treeView.EndUpdate();
        }

        private void newSessionMenuItem_Click(object sender, EventArgs e)
        {
            OnLaunchSession(new LaunchSessionEventArgs());
        }

        private void launchSessionMenuItem_Click(object sender, EventArgs e)
        {
            Session s = (Session)treeView.SelectedNode.Tag;
            string sessionName = s.SessionDisplayText;
            OnLaunchSession(new LaunchSessionEventArgs(sessionName));
        }

        private void launchSessionSystrayMenuItem_Click(object sender, EventArgs e)
        {
            string sessionName = ((ToolStripMenuItem)sender).Text; 
            OnLaunchSession(new LaunchSessionEventArgs(sessionName));
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Session s = (Session)e.Node.Tag;
            if (s.IsFolder == false)
            {
                OnLaunchSession(new LaunchSessionEventArgs(s.SessionDisplayText));
            }
        }

        private void lockSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockSessionsToolStripMenuItem.Checked)
            {
                treeView.AllowDrop = false;
                newFolderMenuItem.Enabled = false;
                renameFolderMenuItem.Enabled = false;
            }
            else
            {
                treeView.AllowDrop = true;
                newFolderMenuItem.Enabled = false;
                renameFolderMenuItem.Enabled = false;
            }


        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = e.Node;
                Session s = (Session)e.Node.Tag;
                if (s.IsFolder == false)
                {
                    newFolderMenuItem.Enabled = !lockSessionsToolStripMenuItem.Checked;
                    renameFolderMenuItem.Enabled = false;
                    launchFolderAndSubfoldersToolStripMenuItem.Enabled = false;
                    launchFolderToolStripMenuItem.Enabled = false;
                    launchSessionMenuItem.Enabled = true;
                }
                else
                {
                    launchSessionMenuItem.Enabled = false;
                    launchFolderAndSubfoldersToolStripMenuItem.Enabled = true;
                    launchFolderToolStripMenuItem.Enabled = true;

                    if (lockSessionsToolStripMenuItem.Checked == true)
                    {
                        newFolderMenuItem.Enabled = false;
                        renameFolderMenuItem.Enabled = false;
                    }
                    else
                    {
                        newFolderMenuItem.Enabled = false;

                        if (treeView.SelectedNode.Parent == null)
                            renameFolderMenuItem.Enabled = false;
                        else
                            renameFolderMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void newFolderMenuItem_Click(object sender, EventArgs e)
        {

            FolderForm ff = new FolderForm();
            if (ff.ShowDialog() == DialogResult.OK && validateFolderName(ff.getFolderName()))
            {
                // Suppress repainting the TreeView until all the objects have been created.
                treeView.BeginUpdate();

                // Find the selected node
                TreeNode selectedNode = treeView.SelectedNode;

                // Find it's parent
                TreeNode parent = selectedNode.Parent;

                // Get the new folder name and the new full path
                string folder = ff.getFolderName();
                string newpath = parent.FullPath + treeView.PathSeparator + folder;

                // Remove the selected node from it's current location
                parent.Nodes.Remove(selectedNode);

                // Set up the new folder node and add it to the parent node
                Session sess = new Session(folder, newpath, true);
                parent.Nodes.Add(folder, sess.SessionDisplayText);
                TreeNode foldernode = parent.Nodes[folder];
                foldernode.Tag = sess;
                foldernode.ContextMenuStrip = nodeContextMenuStrip;
                foldernode.ImageIndex = IMAGE_INDEX_FOLDER;
                foldernode.SelectedImageIndex = IMAGE_INDEX_SELECTED_FOLDER;

                // Now add the selected node back to the folder
                foldernode.Nodes.Add(selectedNode);

                // Refresh the paths of all the child nodes
                updateFolders(selectedNode, foldernode);

                // Fire a refresh event
                OnRefreshSessions(new RefreshSessionsEventArgs(false));

                // Begin repainting the TreeView.
                treeView.EndUpdate();
            }
        }

        private bool validateFolderName(string foldername)
        {
            if (foldername.Contains("\\"))
            {
                MessageBox.Show("\"\\\" may not be used in folder name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (foldername.Equals(""))
            {
                MessageBox.Show("Folder name must be supplied", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void renameFolderMenuItem_Click(object sender, EventArgs e)
        {
            // Find the selected node
            TreeNode selectedNode = treeView.SelectedNode;

            // Display the folder requester
            FolderForm ff = new FolderForm(selectedNode.Text);

            if (ff.ShowDialog() == DialogResult.OK && validateFolderName(ff.getFolderName()))
            {
                // Suppress repainting the TreeView until all the objects have been created.
                treeView.BeginUpdate();

                // Find it's parent
                TreeNode parent = selectedNode.Parent;

                // Get the new folder name and the new full path
                string folder = ff.getFolderName();
                string newpath = parent.FullPath + treeView.PathSeparator + folder;

                // Remove the selected node from it's current location
                parent.Nodes.Remove(selectedNode);

                // Set up the new folder node and add it to the parent node
                Session sess = new Session(folder, newpath, true);
                selectedNode.Tag = sess;
                selectedNode.Text = sess.SessionDisplayText;
                parent.Nodes.Add(selectedNode);

                // Refresh the paths of all the child nodes
                updateFolders(selectedNode, parent);

                // Fire a refresh event
                OnRefreshSessions(new RefreshSessionsEventArgs(false));

                // Begin repainting the TreeView.
                treeView.EndUpdate();
            }

        }

        public override void getSessionMenuItems(ToolStripMenuItem parent)
        {
            parent.DropDownItems.Clear();
            addSessionMenuItemsFolder(parent, treeView.Nodes[0].Nodes); 
        }

        private void addSessionMenuItemsFolder(ToolStripMenuItem parent, TreeNodeCollection nodes)
        {
            IEnumerator ie = nodes.GetEnumerator();

            while (ie.MoveNext())
            {
                TreeNode node = (TreeNode)ie.Current;
                Session s = (Session)node.Tag;
                if (s.IsFolder)
                {
                    ToolStripMenuItem folder = new ToolStripMenuItem(s.SessionDisplayText);
                    parent.DropDownItems.Add(folder);
                    addSessionMenuItemsFolder(folder, node.Nodes);
                }
                else
                {
                    parent.DropDownItems.Add(new ToolStripMenuItem(s.SessionDisplayText, null, launchSessionSystrayMenuItem_Click));
                }
            }
        }

        private void launchFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                if (confirmNumberOfSessions(treeView.SelectedNode, false))
                    launchFolderSessions(treeView.SelectedNode, false);
            }
        }


        private void launchFolderSessions(TreeNode folder, bool launchSubfolders)
        {
            IEnumerator ie = folder.Nodes.GetEnumerator();

            while (ie.MoveNext())
            {
                TreeNode node = (TreeNode)ie.Current;
                Session s = (Session)node.Tag;
                if (s.IsFolder && launchSubfolders)
                {
                    launchFolderSessions(node, launchSubfolders);
                }
                else if (s.IsFolder == false)
                {
                    OnLaunchSession(new LaunchSessionEventArgs(s.SessionDisplayText));
                }
            }
        }

        private void launchFolderAndSubfoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                if (confirmNumberOfSessions(treeView.SelectedNode, true))
                    launchFolderSessions(treeView.SelectedNode, true);
            }
        }

        private bool confirmNumberOfSessions(TreeNode folder, bool countSubfolders)
        {
            int warningLevel = (int)Properties.Settings.Default.SubfolderSessionWarning;
            int sessionCount = 0;
            bool result = true;

            sessionCount = getSessionCount(sessionCount, folder, countSubfolders);

            if (sessionCount > warningLevel)
                result = (MessageBox.Show(this
                                   , "This will launch " + sessionCount +
                                     " sessions. Are you sure?"
                                   , "Confirm"
                                   , MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Question) == DialogResult.Yes);
            return result;

        }

        private int getSessionCount(int currentCount, TreeNode folder, bool countSubfolders)
        {
            IEnumerator ie = folder.Nodes.GetEnumerator();
            TreeNode currentNode = null;
            while (ie.MoveNext())
            {
                currentNode = (TreeNode)ie.Current;
                if (currentNode.Nodes.Count == 0)
                    currentCount++;
                else if (countSubfolders == true)
                    currentCount = getSessionCount(currentCount, currentNode, countSubfolders);
            }
            return currentCount;
        }


    }
}
