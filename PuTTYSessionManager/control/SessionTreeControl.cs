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
using System.Collections;
using Microsoft.Win32;
using uk.org.riseley.puttySessionManager.model;
using uk.org.riseley.puttySessionManager.controller;
using uk.org.riseley.puttySessionManager.form;


namespace uk.org.riseley.puttySessionManager.control
{
    /// <summary>
    /// This is the main control that provides the tree functionality 
    /// for PuTTY Session Manager
    /// </summary>

    public partial class SessionTreeControl : SessionControl
    {
        // Constants for image selection 
        private const int IMAGE_INDEX_FOLDER = 0;
        private const int IMAGE_INDEX_SELECTED_FOLDER = 1;
        private const int IMAGE_INDEX_SESSION = 2;


        private NewSessionForm newSessionForm;
        private HotkeyController hkc;

        private Dictionary<HotkeyController.HotKeyId, ToolStripMenuItem> hotkeyDictionary;

        private ToolTip toolTip;
        public SessionTreeControl()
            : base()
        {
            InitializeComponent();
            newSessionForm = new NewSessionForm(null);
            
            hkc = HotkeyController.getInstance();
            setupHotkeyDictionary();
            setHotkeyMenuItemsToolTips(this,EventArgs.Empty);
            EventHandler hkHandler = new EventHandler(setHotkeyMenuItemsToolTips);
            hkc.HotkeysRefreshed += hkHandler;

            toolTip = new ToolTip();
            toolTip.InitialDelay = 3000; // 3 seconds delay
            toolTip.ReshowDelay  = 2000;
            toolTip.AutoPopDelay = 5000;
            toolTip.UseAnimation = true;
            toolTip.UseFading = true;
        }

        /// <summary>
        /// Adds the hotkey menu items to dictionary to facilitate iteration of 
        /// all hotkey menu items at other places in the code
        /// Also sets the HotKeyId as the Tag for each menu item
        /// </summary>
        private void setupHotkeyDictionary()
        {
            // Specify the hot key id's
            hotkey1MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_1;
            hotkey2MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_2;
            hotkey3MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_3;
            hotkey4MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_4;
            hotkey5MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_5;

            hotkeyDictionary = new Dictionary<HotkeyController.HotKeyId, ToolStripMenuItem>();

            // Add the menu items to the dictionary
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey1MenuItem.Tag, hotkey1MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey2MenuItem.Tag, hotkey2MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey3MenuItem.Tag, hotkey3MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey4MenuItem.Tag, hotkey4MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey5MenuItem.Tag, hotkey5MenuItem);        
        }

        /// <summary>
        /// Event handler for ItemDragEvent from the tree view.
        /// If the left mouse button is used call DoDragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// Event handler for DragEnterEvent from the tree view.
        /// Set the target drop effect to the effect 
        /// specified in the ItemDrag event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
       
        /// <summary>
        /// Event handler for DragOverEvent from the tree view.
        /// Select the node under the mouse pointer to indicate the 
        /// expected drop location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Get the node at the mouse position.
            TreeNode node = treeView.GetNodeAt(targetPoint);

            // Only if there is node under the mouse
            if (node != null)
            {
                // Select the node at the mouse position
                treeView.SelectedNode = node;

                // Ensure the panel scrolls if we get near the top
                if (targetPoint.Y < (node.Bounds.Height / 2) &&
                    node.PrevVisibleNode != null)
                {
                    node.PrevVisibleNode.EnsureVisible();
                }
            }
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
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

                    // Check that no folder exists at the same level
                    // with the same name
                    string newpath = targetNode.FullPath + treeView.PathSeparator + draggedNode.Text;
                    if (validateFolderName(draggedNode.Text, newpath) == false)
                    {
                        return;
                    }

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
                    sc.invalidateSessionList(this, false);
                }
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
                s.FolderName = parent.FullPath;
                node.Name = s.getKey();

                System.Collections.IEnumerator nodeEnumerator = node.Nodes.GetEnumerator();
                while (nodeEnumerator.MoveNext())
                {
                    TreeNode currNode = (TreeNode)(nodeEnumerator.Current);
                    updateFolders(currNode, currNode.Parent);
                }

            }
        }

        /// <summary>
        /// Remove any hanging folders.
        /// </summary>
        /// <param name="node"></param>
        private void cleanFolders(TreeNode node)
        {
            // Check the passed in node is valid
            if (node == null)
                return;

            // Get the session associated with the node
            Session s = ((Session)node.Tag);

            if (s.IsFolder == true && node.FirstNode == null)
            {
                // Get the parent node
                TreeNode parentNode = node.Parent;
            
                // Remove this node
                node.Remove();

                // If there is a parent node
                if (parentNode != null)
                {
                    // Get the session 
                    s = ((Session)parentNode.Tag);

                    // If it's a folder and not the root node
                    if (s.IsFolder && !(s.SessionDisplayText.Equals(Session.SESSIONS_FOLDER_NAME)))
                    {
                        cleanFolders(parentNode);
                    }
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
            {
                Session rootSession = new Session(rootPath, rootPath, true);
                rootNode.Tag = rootSession;
                rootNode.Name = rootSession.getKey();
            }

            foreach (Session s in getSessionController().getSessionList())
            {
                TreeNode newNode = new TreeNode(s.SessionDisplayText);
                newNode.Tag = s;
                newNode.ContextMenuStrip = nodeContextMenuStrip;
                newNode.ImageIndex = IMAGE_INDEX_SESSION;
                newNode.SelectedImageIndex = IMAGE_INDEX_SESSION;

                // Setup the key so that we can find the node again
                newNode.Name = s.getKey();

                if (s.FolderName == null || s.FolderName.Equals("") || s.FolderName.Equals(rootPath))
                {
                    rootNode.Nodes.Add(newNode);
                }
                else
                {
                    TreeNode currnode = rootNode;
                    string path = null;
                    foreach (string folder in s.FolderName.Split(pathSep.ToCharArray()))
                    {
                        // Is this folder the root folder,
                        // if so, skip to the next one
                        if (folder.Equals(rootPath))
                        {
                            path = folder;
                            continue;
                        }
                        else
                        {
                            path = path + pathSep + folder;
                        }

                        // Does this folder exist as a child of the current node
                        if (currnode.Nodes.ContainsKey(Session.getFolderKey(path)))
                        {
                            currnode = currnode.Nodes[Session.getFolderKey(path)];
                        }
                        else
                        {
                            Session sess = new Session(folder, path, true);
                            currnode.Nodes.Add(sess.getKey(), sess.SessionDisplayText);
                            currnode = currnode.Nodes[sess.getKey()];
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
            Session s = getSelectedSession();
            string sessionName = "";
            if ( s != null )
                sessionName = s.SessionDisplayText;
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
                setSessionAsHotkeyToolStripMenuItem.Enabled = false;
                newFolderMenuItem.Enabled = false;
                renameFolderMenuItem.Enabled = false;
                saveNewSessionToolStripMenuItem.Enabled = false;
                deleteSessionToolStripMenuItem.Enabled = false;
            }
            else
            {
                treeView.AllowDrop = true;
                newFolderMenuItem.Enabled = false;
                renameFolderMenuItem.Enabled = false;
                saveNewSessionToolStripMenuItem.Enabled = true;
                deleteSessionToolStripMenuItem.Enabled = true;
            }


        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the node that has been clicked
                treeView.SelectedNode = e.Node;

                // Get the session
                Session s = getSelectedSession(true);

                // Check if hotkeys are enabled
                bool hotkeysEnabled = hkc.isFavouriteSessionHotkeysEnabled();

                if (s.IsFolder == false)
                {
                    newFolderMenuItem.Enabled = !lockSessionsToolStripMenuItem.Checked;
                    renameSessionToolStripMenuItem.Enabled = !lockSessionsToolStripMenuItem.Checked;
                    setSessionAsHotkeyToolStripMenuItem.Enabled = !lockSessionsToolStripMenuItem.Checked && hotkeysEnabled;
                    renameFolderMenuItem.Enabled = false;
                    launchFolderAndSubfoldersToolStripMenuItem.Enabled = false;
                    launchFolderToolStripMenuItem.Enabled = false;
                    launchSessionMenuItem.Enabled = true;
                }
                else
                {
                    renameSessionToolStripMenuItem.Enabled = false;
                    setSessionAsHotkeyToolStripMenuItem.Enabled = false;
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
            if (ff.ShowDialog() == DialogResult.OK )
            {
                // Find the selected node
                TreeNode selectedNode = treeView.SelectedNode;

                // Find it's parent
                TreeNode parent = selectedNode.Parent;

                // Get the new folder name and the new full path
                string folder = ff.getFolderName();
                string newpath = parent.FullPath + treeView.PathSeparator + folder;

                // Check the new folder name is valid
                if (validateFolderName(folder, newpath) == false)
                {
                    return;
                }

                // Suppress repainting the TreeView until all the objects have been created.
                treeView.BeginUpdate();         

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
                sc.invalidateSessionList(this, false);

                // Begin repainting the TreeView.
                treeView.EndUpdate();
            }
        }

        /// <summary>
        /// Check and see if the new folder name is valid
        /// </summary>
        /// <param name="foldername">The new folder name</param>
        /// <param name="newpath">The full path of the new folder , including
        ///  the new folder name</param>
        /// <returns></returns>
        private bool validateFolderName(string foldername, string newpath)
        {
            // The folder name must not be blank
            if (foldername.Equals(""))
            {
                MessageBox.Show("Folder name must be supplied", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // The new folder name must not contain the path separator
            else if (foldername.Contains(treeView.PathSeparator))
            {
                MessageBox.Show("\""+ treeView.PathSeparator + "\" may not be used in folder name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // No folder with the same name should exist at the same level
            else if (sc.getFolderList().Contains(newpath))
            {
                MessageBox.Show("A folder with this name already exists", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool validateSessionName(string sessionName)
        {
            if (sessionName.Equals(""))
            {
                MessageBox.Show("Session name must be supplied", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (getSessionController().findSession(sessionName) != null)
            {
                MessageBox.Show("Session name must be unique", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (getSessionController().isDefaultSessionName(sessionName))
            {
                MessageBox.Show("You cannot rename the session to \"Default Settings\"", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (ff.ShowDialog() == DialogResult.OK )
            {
                // Find it's parent
                TreeNode parent = selectedNode.Parent;

                // Get the new folder name and the new full path
                string folder = ff.getFolderName();
                string newpath = parent.FullPath + treeView.PathSeparator + folder;

                if (validateFolderName(folder, newpath) == false)
                {
                    return;
                }

                // Suppress repainting the TreeView until all the objects have been created.
                treeView.BeginUpdate();

                // Remove the selected node from it's current location
                parent.Nodes.Remove(selectedNode);

                // Set up the new folder node and add it to the parent node
                Session sess = new Session(folder, newpath, true);
                selectedNode.Tag = sess;
                selectedNode.Text = sess.SessionDisplayText;
                selectedNode.Name = sess.getKey();
                parent.Nodes.Add(selectedNode);

                // Refresh the paths of all the child nodes
                updateFolders(selectedNode, parent);

                // Fire a refresh event
                sc.invalidateSessionList(this, false);

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
                    folder.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    parent.DropDownItems.Add(folder);
                    addSessionMenuItemsFolder(folder, node.Nodes);
                }
                else
                {
                    ToolStripMenuItem session = new ToolStripMenuItem(s.SessionDisplayText, null, launchSessionSystrayMenuItem_Click);
                    session.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    parent.DropDownItems.Add(session);
                }
            }
        }

        private void launchFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                List<Session> sl = getSelectedSessions(false);
                if (confirmNumberOfSessions(sl))
                    launchFolderSessions(sl);
            }
        }

        private void launchFolderSessions(List<Session> sl)
        {
            if (sl == null)
                return;

            foreach (Session s in sl)
            {
                OnLaunchSession(new LaunchSessionEventArgs(s.SessionDisplayText));
            }
        }

        private void launchFolderAndSubfoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                List<Session> sl = getSelectedSessions(true);
                if (confirmNumberOfSessions(sl))
                    launchFolderSessions(sl);
            }
        }

        private bool confirmNumberOfSessions(List<Session> sl)
        {
            int warningLevel = (int)Properties.Settings.Default.SubfolderSessionWarning;
            int sessionCount = 0;
            bool result = true;

            if (sl != null)
                sessionCount = sl.Count;
            else
                sessionCount = 0;

            if (sessionCount > warningLevel)
                result = (MessageBox.Show(this
                                   , "This will launch " + sessionCount +
                                     " sessions. Are you sure?"
                                   , "Confirm"
                                   , MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Question) == DialogResult.Yes);
            return result;

        }

        private void saveNewSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the session
            Session s = getSelectedSession(true);

            // Get the foldername
            String folderName = s.FolderName;

            // Setup the session request
            NewSessionRequest nsr;

            if (s.IsFolder == false)
            {
                nsr = new NewSessionRequest(s, folderName, "", "", true, true);
            }
            else
            {
                // Try to get the default session
                s = sc.findDefaultSession(true);

                // If that doesn't work get the first child session
                if (s == null)                   
                    s = getSelectedSessions()[0];

                nsr = new NewSessionRequest(s, folderName, "", "", true, true);
            }

            // Set the options in the form
            newSessionForm.setNewSessionRequest(nsr);

            // Show the dialog
            if (newSessionForm.ShowDialog() == DialogResult.OK)
            {
                nsr = newSessionForm.getNewSessionRequest();
                bool result = getSessionController().createNewSession(nsr, this);
                if (result == false)
                    MessageBox.Show("Failed to create new session: " + nsr.SessionName
                    , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    TreeNode[] ta = treeView.Nodes.Find(Session.getFolderKey(nsr.SessionFolder), true);
                    if (ta.Length > 0)
                    {
                        Session newSession = new Session(nsr.SessionName, nsr.SessionFolder, false);
                        TreeNode newNode = new TreeNode(newSession.SessionDisplayText);
                        newNode.Tag = newSession;
                        newNode.ContextMenuStrip = nodeContextMenuStrip;
                        newNode.ImageIndex = IMAGE_INDEX_SESSION;
                        newNode.SelectedImageIndex = IMAGE_INDEX_SESSION;

                        // Setup the key so that we can find the node again
                        newNode.Name = newSession.getKey();

                        // Add the new node
                        ta[0].Nodes.Add(newNode);

                        // Select the new node
                        ta[0].Expand();
                    }

                    if (nsr.LaunchSession == true)
                    {
                        String errMsg = getSessionController().launchSession(nsr.SessionName);
                        if (errMsg.Equals("") == false)
                        {
                            MessageBox.Show("PuTTY Failed to start. Check the PuTTY location.\n" +
                                errMsg
                                , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }

        private void refreshSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getSessionController().invalidateSessionList(this, true);
        }

        private void renameSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the session
            Session s = getSelectedSession(true);

            // Check we are not renaming the default session
            Session defaultSession = getSessionController().findDefaultSession();
            if (defaultSession != null && defaultSession.SessionName.Equals(s.SessionName))
            {
                MessageBox.Show("Cannot rename the default session"
                        , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display the session name requester
            SessionNameForm snf = new SessionNameForm(s.SessionDisplayText);

            if (snf.ShowDialog() == DialogResult.OK && validateSessionName(snf.getSessionName()))
            {
                // Try to rename the session
                bool result = getSessionController().renameSession(s, snf.getSessionName());

                // Check it worked
                if (result == false)
                {
                    MessageBox.Show("Failed to rename session"
                        , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create the new session object
                Session newSession = new Session(Session.convertDisplayToSessionKey(snf.getSessionName()), s.FolderName, false);

                // Suppress repainting the TreeView until all the objects have been created.
                treeView.BeginUpdate();

                // Update the selected node
                treeView.SelectedNode.Tag = newSession;
                treeView.SelectedNode.Text = newSession.SessionDisplayText;
                treeView.SelectedNode.Name = newSession.getKey();

                // Fire a refresh event
                sc.invalidateSessionList(this, false);

                // Begin repainting the TreeView.
                treeView.EndUpdate();
            }
        }

        private void deleteSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelEventArgs ce = new CancelEventArgs();
            OnDeleteSessions(ce);

            // If the delete was cancelled then return
            if (ce.Cancel)
                return;

            // Otherwise update the tree to delete the selected nodes
            deleteSelectedSessions();
        }

        private void deleteSelectedSessions()
        {
            // Suppress repainting the TreeView until all the objects have been removed.
            treeView.BeginUpdate();

            // Find the selected node
            TreeNode selectedNode = treeView.SelectedNode;

            // Find it's parent node
            TreeNode parentNode = selectedNode.Parent;

            // Delete any child nodes
            if (selectedNode.Nodes.Count > 0)
                selectedNode.Nodes.Clear();

            // Now remove the node itself
            if (parentNode != null)
                selectedNode.Remove();
             
            // Clean folders
            cleanFolders(parentNode);

            // Notfiy others of the change
            getSessionController().invalidateSessionList(this, false);

            // Resume repainting the TreeView
            treeView.EndUpdate();
        }

        public override List<Session> getSelectedSessions()
        {
            return getSelectedSessions(true);
        }

        private List<Session> getSelectedSessions(bool includeSubfolders)
        {
            List<Session> sl = new List<Session>();

            // Find the selected node
            TreeNode selectedNode = treeView.SelectedNode;

            // Add all the child nodes
            sl.AddRange(getChildSessions(selectedNode, includeSubfolders));

            return sl;
        }

        private List<Session> getChildSessions(TreeNode parent, bool includeSubfolders)
        {
            List<Session> sl = new List<Session>();

            // Get the session
            Session s = (Session)parent.Tag;

            if (s.IsFolder == true)
            {
                IEnumerator ie = parent.Nodes.GetEnumerator();
                TreeNode curr = null;
                while (ie.MoveNext())
                {
                    curr = (TreeNode)ie.Current;
                    s = (Session)curr.Tag;
                    if (s.IsFolder == true)
                    {
                        if (includeSubfolders == true)
                        {
                            sl.AddRange(getChildSessions(curr, includeSubfolders));
                        }
                    }
                    else
                    {
                        sl.Add(s);
                    }
                }

            }
            else
            {
                sl.Add(s);
            }

            return sl;
        }

        // Returns selected session
        // will return null if selected session is a folder
        // and getFolder is false
        private Session getSelectedSession(bool getFolder)
        {
            // Find the selected node
            TreeNode selectedNode = treeView.SelectedNode;
            Session s = null;

            if (selectedNode != null)
                s = (Session)selectedNode.Tag;

            if (getFolder == false && s.IsFolder == true)
                s = null;

            return s;
        }

        // Returns selected session
        // will return null if selected session is a folder
        private Session getSelectedSession()
        {
            return getSelectedSession(false);
        }

        private void exportSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnExportSessions(e);
        }

        private void setHotkeyMenuItemsToolTips(object sender, EventArgs e)
        {
            bool hotkeysEnabled = hkc.isFavouriteSessionHotkeysEnabled();
            ToolStripMenuItem tsmi;
            Session s;
            foreach (HotkeyController.HotKeyId hkid in hotkeyDictionary.Keys)
            {
                hotkeyDictionary.TryGetValue(hkid, out tsmi);
                s = hkc.getSessionFromHotkey((HotkeyController.HotKeyId)tsmi.Tag);
                tsmi.Enabled = hotkeysEnabled;
                if (s != null)
                    tsmi.ToolTipText = s.SessionDisplayText;
                else
                    tsmi.ToolTipText = "";
            }
        }

        private void hotkeyMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            HotkeyController.HotKeyId hkid = (HotkeyController.HotKeyId)tsmi.Tag;
            Session s = getSelectedSession();
            hkc.saveSessionnameToHotkey(ParentForm, hkid, s);
        }

        /// <summary>
        /// Event handler for NodeMouseHover from the tree view.
        /// Retrieve the tool tip text from the session if the node
        /// that is pointed to is not a folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">contains the node are we hovering over</param>
        private void treeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            // If the tool tip is active on another node
            // disable it
            if (toolTip.Active == true)
                toolTip.Active = false;

            // Find the session
            Session s = (Session)e.Node.Tag;

            // If there is a session and it's not a folder
            // set the tool tip text and display it
            if (s != null && s.IsFolder == false)
            {
                toolTip.SetToolTip(e.Node.TreeView, s.ToolTipText);
                toolTip.Active = true;
            }
        }

        /// <summary>
        /// Event handler for MouseMove from the tree view.
        /// If a tool tip is active and we have moved off the tree
        /// then disable the tool tip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the node at the mouse position.
            TreeNode node = treeView.GetNodeAt(e.X,e.Y);
            if (node == null && toolTip.Active == true)
                toolTip.Active = false;
        }

    }
}
