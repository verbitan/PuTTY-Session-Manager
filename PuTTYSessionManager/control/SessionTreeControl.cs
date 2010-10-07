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
using uk.org.riseley.puttySessionManager.model.eventargs;
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
        private int oldNodeIndex = -1;

        private ExportDialog ed;

        private TreeNode lastDragDestination = null;
        private DateTime lastDragDestinationTime = DateTime.Now;

        public SessionTreeControl()
            : base()
        {
            InitializeComponent();
            newSessionForm = new NewSessionForm(null);

            hkc = HotkeyController.getInstance();
            setupHotkeyDictionary();
            setupHotkeyMenuItems(this, EventArgs.Empty);
            EventHandler hkHandler = new EventHandler(setupHotkeyMenuItems);
            hkc.HotkeysRefreshed += hkHandler;

            toolTip = new ToolTip();
            toolTip.InitialDelay = 800;
            toolTip.ReshowDelay = 0;

            SessionSorter.SortOrder order = (SessionSorter.SortOrder)Properties.Settings.Default.SortOrder;
            treeView.TreeViewNodeSorter = new SessionSorter((SessionSorter.SortOrder)Properties.Settings.Default.SortOrder);
            if (order == SessionSorter.SortOrder.FOLDER_FIRST)
                foldersFirstToolStripMenuItem.Checked = true;
            else if (order == SessionSorter.SortOrder.FOLDER_IGNORE)
                ignoreFoldersToolStripMenuItem.Checked = true;
            else if (order == SessionSorter.SortOrder.FOLDER_LAST)
                foldersLastToolStripMenuItem.Checked = true;

            ed = new ExportDialog();

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
            hotkey6MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_6;
            hotkey7MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_7;
            hotkey8MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_8;
            hotkey9MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_9;
            hotkey10MenuItem.Tag = HotkeyController.HotKeyId.HKID_SESSION_10;

            hotkeyDictionary = new Dictionary<HotkeyController.HotKeyId, ToolStripMenuItem>();

            // Add the menu items to the dictionary
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey1MenuItem.Tag, hotkey1MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey2MenuItem.Tag, hotkey2MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey3MenuItem.Tag, hotkey3MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey4MenuItem.Tag, hotkey4MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey5MenuItem.Tag, hotkey5MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey6MenuItem.Tag, hotkey6MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey7MenuItem.Tag, hotkey7MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey8MenuItem.Tag, hotkey8MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey9MenuItem.Tag, hotkey9MenuItem);
            hotkeyDictionary.Add((HotkeyController.HotKeyId)hotkey10MenuItem.Tag, hotkey10MenuItem);
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
        /// Event handler for DragOverEvent from the tree view.
        /// Select the node under the mouse pointer to indicate the 
        /// expected drop location.
        /// Set the effect to show whether a drop is allowed
        /// Expand the node if it's a folder and we've been there for
        /// one or more seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Get the node at the mouse position.
            TreeNode targetNode = treeView.GetNodeAt(targetPoint);

            // Only if there is node under the mouse
            if (targetNode != null)
            {
                // Select the node at the mouse position
                treeView.SelectedNode = targetNode;

                // Ensure the panel scrolls if we get near the top
                if (targetPoint.Y < (targetNode.Bounds.Height / 2) &&
                    targetNode.PrevVisibleNode != null)
                {
                    targetNode.PrevVisibleNode.EnsureVisible();
                }

                // Retrieve the node that was dragged.
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));                

                // Check to see if we have a valid drop target
                if (validateDropTarget(draggedNode, targetNode))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }

                // If we are on a new object, reset our timer
                // otherwise check to see if enough time has passed and expand the destination node
                if (targetNode != lastDragDestination)
                {
                    lastDragDestination = targetNode;
                    lastDragDestinationTime = DateTime.Now;
                }
                else
                {
                    TimeSpan hoverTime = DateTime.Now.Subtract(lastDragDestinationTime);
                    if (hoverTime.TotalSeconds > 1 && targetNode.IsExpanded == false)
                    {
                        targetNode.Expand();
                    }
                }
            }
        }

        /// <summary>
        /// Ensure that the source node is allowed to be dropped 
        /// onto the target node
        /// </summary>
        /// <param name="sourceNode"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>
        private bool validateDropTarget(TreeNode sourceNode, TreeNode targetNode)        
        {
            // If the target node has no children
            // it's a session, so get it's folder 
            // parent
            if ( targetNode.FirstNode == null )
            {
                targetNode = targetNode.Parent;
            }

            // If the nodes are the same 
            // deny the drop
            if ( sourceNode == targetNode )
            {
                return false;
            }

            // If the parent of the source node
            // is the same as the target node
            // deny the drop
            if (sourceNode.Parent == targetNode)
            {
                return false;
            }

            // If the source node is a folder
            if (sourceNode.FirstNode != null)
            {             
                // If the source folder is an ancestor of the
                // target deny the drop
                TreeNode targetParent = targetNode.Parent;
                while (targetParent != null)
                {
                    if (targetParent == sourceNode)
                    {
                        return false;
                    }

                    targetParent = targetParent.Parent;
                }
            } 

            // Otherwise allow the drop
            return true;
        }


        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = treeView.GetNodeAt(targetPoint);

            // If the target node isn't a folder
            // consider this to be a drop onto the parent folder
            if (targetNode.FirstNode == null)
            {
                targetNode = targetNode.Parent;
            }

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node, 
            // and the target node is a folder
            if (validateDropTarget(draggedNode,targetNode))
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

                    // Suppress repainting the TreeView until all the objects have been created.
                    treeView.BeginUpdate();

                    // Remove the old node and add it back in
                    // in the new location
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);

                    // Update the new location for this node and/or its
                    // children
                    updateFolders(draggedNode, targetNode);

                    // Cleanup any hanging folders
                    cleanFolders(oldParent);

                    // Make sure the dragged node is visible
                    draggedNode.EnsureVisible();

                    // Fire a refresh event
                    sc.invalidateSessionList(this, false);

                    // Resume repainting the TreeView
                    treeView.EndUpdate();
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
                getSessionController().updateFolder(s);
            }
            else
            {
                s.FolderName = parent.FullPath + treeView.PathSeparator + node.Text ;
                node.Name = s.NodeKey;

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

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadSessions()
        {
            // Suppress repainting the TreeView until all the objects have been created.
            treeView.BeginUpdate();

            if (Properties.Settings.Default.DisplayTreeIcons)
                treeView.ImageList = treeImageList;
            else
                treeView.ImageList = null;

            // Store the root node and path
            TreeNode rootNode = treeView.Nodes[0];
            string rootPath = rootNode.FullPath;
            string pathSep = treeView.PathSeparator;
            char[] pathSepArr = pathSep.ToCharArray();

            // Clear out the current tree
            rootNode.Nodes.Clear();

            // Create the root node tag if it doesn't already exist
            if (rootNode.Tag == null)
            {
                Session rootSession = new Session(rootPath, rootPath, true);
                rootNode.Tag = rootSession;
                rootNode.Name = rootSession.NodeKey;
            }

            foreach (Session s in getSessionController().getSessionList())
            {
                TreeNode newNode = createNode(s);

                if (s.FolderName == null || s.FolderName.Equals("") || s.FolderName.Equals(rootPath))
                {
                    rootNode.Nodes.Add(newNode);
                }
                else
                {
                    TreeNode currnode = rootNode;
                    string path = null;
                    foreach (string folder in s.FolderName.Split(pathSepArr))
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
                        string folderKey = Session.getFolderKey(path);
                        if (currnode.Nodes.ContainsKey(folderKey))
                        {
                            currnode = currnode.Nodes[folderKey];
                        }
                        else
                        {
                            Session sess = new Session(folder, path, true);

                            TreeNode folderNode = createNode(sess);

                            currnode.Nodes.Add(folderNode);
                            currnode = folderNode;
                        }

                    }

                    currnode.Nodes.Add(newNode);
                }
            }
            // Expand the first node
            rootNode.Expand();

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
            OnLaunchSession(new LaunchSessionEventArgs(s));
        }

        private void launchSessionSystrayMenuItem_Click(object sender, EventArgs e)
        {
            Session s = (Session)((ToolStripMenuItem)sender).Tag;
            OnLaunchSession(new LaunchSessionEventArgs(s));
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Session s = (Session)e.Node.Tag;
            if (s.IsFolder == false)
            {
                OnLaunchSession(new LaunchSessionEventArgs(s));
            }
        }

        private void lockSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockSessionsToolStripMenuItem.Checked)
            {
                treeView.AllowDrop = false;
            }
            else
            {
                treeView.AllowDrop = true;
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
                    newFolderMenuItem.Enabled = true;
                    setSessionAsHotkeyToolStripMenuItem.Enabled = hotkeysEnabled;
                    foreach (ToolStripMenuItem menuItem in hotkeyDictionary.Values)
                    {
                        menuItem.Visible = hotkeysEnabled; ;
                    }
                    renameMenuItem.Enabled = true;
                    launchFolderAndSubfoldersToolStripMenuItem.Enabled = false;
                    launchFolderToolStripMenuItem.Enabled = false;
                    launchSessionMenuItem.Enabled = true;
                    launchFilezillaToolStripMenuItem.Enabled = true;
                    launchWinSCPToolStripMenuItem.Enabled = true;
                    expandTreeToolStripMenuItem.Enabled = false;
                    collapseTreeToolStripMenuItem.Enabled = false;
                }
                else
                {
                    setSessionAsHotkeyToolStripMenuItem.Enabled = false;
                    foreach (ToolStripMenuItem menuItem in hotkeyDictionary.Values)
                    {
                        menuItem.Visible = false;
                    }

                    launchSessionMenuItem.Enabled = false;
                    launchFilezillaToolStripMenuItem.Enabled = false;
                    launchWinSCPToolStripMenuItem.Enabled = false;
                    launchFolderAndSubfoldersToolStripMenuItem.Enabled = true;
                    launchFolderToolStripMenuItem.Enabled = true;

                    if (treeView.SelectedNode.Parent == null)
                    {
                        newFolderMenuItem.Enabled = false;
                        renameMenuItem.Enabled = false;
                    }
                    else
                    {
                        newFolderMenuItem.Enabled = true;
                        renameMenuItem.Enabled = true;
                    }
                    expandTreeToolStripMenuItem.Enabled = true;
                    collapseTreeToolStripMenuItem.Enabled = true;
                }
                launchFilezillaToolStripMenuItem.Visible = Properties.Settings.Default.FileZillaEnabled;
                launchWinSCPToolStripMenuItem.Visible = Properties.Settings.Default.WinSCPEnabled;
            }
        }

        private void newFolderMenuItem_Click(object sender, EventArgs e)
        {

            FolderForm ff = new FolderForm();
            if (ff.ShowDialog() == DialogResult.OK)
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

                // Create the folder node
                TreeNode foldernode = createNode(sess);

                // Add the selected node back to the folder
                foldernode.Nodes.Add(selectedNode);

                // Now add the node to the parent
                parent.Nodes.Add(foldernode);

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
                MessageBox.Show("\"" + treeView.PathSeparator + "\" may not be used in folder name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Check to see if the session name is valid
        /// </summary>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        private bool validateSessionName(string sessionName)
        {
            if (sessionName.Equals(""))
            {
                MessageBox.Show("Session name must be supplied", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (getSessionController().findSessionByName(sessionName) != null)
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

        public override void getSessionMenuItems(ContextMenuStrip cms, ToolStripItemCollection parent)
        {
            parent.Clear();
            addSessionMenuItemsFolder(cms,parent,treeView.Nodes[0].Nodes);
        }

        private void addSessionMenuItemsFolder(ContextMenuStrip cms, ToolStripItemCollection parent, TreeNodeCollection nodes)
        {
            IEnumerator ie = nodes.GetEnumerator();

            while (ie.MoveNext())
            {
                TreeNode node = (TreeNode)ie.Current;
                Session s = (Session)node.Tag;
                if (s.IsFolder)
                {
                    ToolStripMenuItem folder = new ToolStripMenuItem(s.SessionDisplayText);
                    folder.Tag = s;
                    folder.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    // Copy the style of the parent context menu
                    if (folder.DropDown is ToolStripDropDownMenu)
                    {
                        ToolStripDropDownMenu dropDown = folder.DropDown as ToolStripDropDownMenu;
                        dropDown.ShowCheckMargin = cms.ShowCheckMargin;
                        dropDown.ShowImageMargin = cms.ShowImageMargin;
                    }
                    folder.MouseUp += new MouseEventHandler(launchSessionSystrayMenuItem_MouseUp);
                    parent.Add(folder);                    
                    addSessionMenuItemsFolder(cms, folder.DropDownItems, node.Nodes);
                }
                else
                {
                    ToolStripMenuItem session = new ToolStripMenuItem(s.SessionDisplayText, null, launchSessionSystrayMenuItem_Click);
                    session.Tag = s;
                    session.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    parent.Add(session);
                }
            }
        }

        void launchSessionSystrayMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem parent = sender as ToolStripMenuItem;
                bool launchSessions = false;
                bool launchSubfolders = false;
                if (e.Button == MouseButtons.Right)
                {
                    launchSessions = true;
                    launchSubfolders = false;
                }
                else if ( e.Button == MouseButtons.Middle )
                {
                    launchSessions = true;
                    launchSubfolders = true;
                }
                if ( launchSessions == true )
                {
                    List<Session> sl = getChildSessions(parent,launchSubfolders);
                    if (confirmNumberOfSessions(sl))
                        launchFolderSessions(sl);
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
            if (sl == null || sl.Count == 0)
                return;

            foreach (Session s in sl)
            {
                OnLaunchSession(new LaunchSessionEventArgs(s));
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
                s = sc.findDefaultSession();

                // If that doesn't work get the first child session, if 
                // one exists
                if (s == null && getSelectedSessions().Count > 0)
                {
                    s = getSelectedSessions()[0];
                }

                // If we still don't have a session error and return
                if (s == null)
                {
                    MessageBox.Show("You must create at least one session in PuTTY first!"
                        , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                        Session newSession = getSessionController().findSessionByName(nsr.SessionName);

                        // If we can't find the session immediately after creating it - something
                        // has gone wrong - so just refresh the sessions including the tree
                        if (newSession == null)
                        {
                            // Refresh the session list in the system tray
                            sc.invalidateSessionList(this, true);
                        }
                        else
                        {
                            TreeNode newNode = createNode(newSession);

                            // Add the new node
                            ta[0].Nodes.Add(newNode);

                            // Select the new node
                            ta[0].Expand();

                            // Refresh the session list in the system tray
                            sc.invalidateSessionList(this, false);
                        }

                    }

                    if (nsr.LaunchSession == true)
                    {
                        String errMsg = getSessionController().launchSession(nsr.SessionName);
                        if (errMsg.Equals("") == false)
                        {
                            MessageBox.Show("PuTTY Failed to start.\nCheck the PuTTY location in System Tray -> Options.\n" +
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

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the session
            Session s = getSelectedSession(true);

            // Check we are not renaming the default session
            Session defaultSession = getSessionController().findDefaultSession();
            if (defaultSession != null && defaultSession.Equals(s))
            {
                MessageBox.Show("Cannot rename the default session"
                        , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display the rename requester
            RenameNameForm rnf = new RenameNameForm(s.SessionDisplayText, s.IsFolder);

            if (rnf.ShowDialog() == DialogResult.OK)
            {
                // Get the new name
                string newName = rnf.getName();

                // Find the selected node
                TreeNode selectedNode = treeView.SelectedNode;

                // Find it's parent
                TreeNode parent = selectedNode.Parent;
                
                // Create the new session object
                Session newSession = null;

                if (s.IsFolder == false)
                {
                    if (validateSessionName(newName))
                    {
                        // Try to rename the session
                        bool result = getSessionController().renameSession(s, newName, this);

                        // Check it worked
                        if (result == false)
                        {
                            MessageBox.Show("Failed to rename session"
                                , "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Create the new session object
                        newSession = getSessionController().findSessionByName(newName);

                    }
                }
                else if (s.IsFolder == true)
                {

                    // Get the new folder name and the new full path
                    string newPath = parent.FullPath + treeView.PathSeparator + newName;

                    if (validateFolderName(newName, newPath))
                    {
                        // Set up the new folder session
                        newSession = new Session(newName, newPath, true);
                    }
                }

                if ( newSession != null )
                {
                    // Suppress repainting the TreeView until all the objects have been created.
                    treeView.BeginUpdate();

                    selectedNode.Tag  = newSession;
                    selectedNode.Text = newSession.SessionDisplayText;
                    selectedNode.Name = newSession.NodeKey;

                    if (newSession.IsFolder)
                    {
                        // Refresh the paths of all the child nodes
                        updateFolders(selectedNode, parent);
                    }

                    // Fire a refresh event
                    sc.invalidateSessionList(this, false);

                    // Begin repainting the TreeView.
                    treeView.EndUpdate();                    
                }
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

        private List<Session> getChildSessions(ToolStripMenuItem parent, bool includeSubfolders)
        {
            List<Session> sl = new List<Session>();

            // Get the session
            Session s = (Session)parent.Tag;

            if (s.IsFolder == true)
            {
                IEnumerator ie = parent.DropDown.Items.GetEnumerator();
                ToolStripMenuItem curr = null;
                while (ie.MoveNext())
                {
                    curr = (ToolStripMenuItem)ie.Current;
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

        private void setupHotkeyMenuItems(object sender, EventArgs e)
        {
            bool hotkeysEnabled = hkc.isFavouriteSessionHotkeysEnabled();
            ToolStripMenuItem tsmi;
            Session s;
            foreach (HotkeyController.HotKeyId hkid in hotkeyDictionary.Keys)
            {
                hotkeyDictionary.TryGetValue(hkid, out tsmi);
                s = hkc.getSessionFromHotkey((HotkeyController.HotKeyId)tsmi.Tag);

                if (hotkeysEnabled && hkc.isSessionHotkeyEnabled(hkid))
                    tsmi.Enabled = true;
                else
                    tsmi.Enabled = false;

                if (s != null)
                    tsmi.ToolTipText = s.SessionDisplayText;
                else
                    tsmi.ToolTipText = "";

                tsmi.Text = hkc.getModifier().Description + " " + hkc.getHotKeyFromId(hkid);
            }
        }

        private void hotkeyMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            HotkeyController.HotKeyId hkid = (HotkeyController.HotKeyId)tsmi.Tag;
            Session s = getSelectedSession();
            hkc.saveSessionnameToHotkey(ParentForm, hkid, s);
        }

        /// <summary>
        /// Event handler for MouseMove from the tree view.
        /// Enable the tooltip if the node is a session not a folder
        /// If a tool tip is active and we have moved off the tree
        /// then disable the tool tip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_MouseMove(object sender, MouseEventArgs e)
        {
            // If we have disable tooltips return
            if (Properties.Settings.Default.ToolTipsEnabled == false)
                return;

            TreeNode tn = treeView.GetNodeAt(e.X, e.Y);
            if (tn != null)
            {
                int currentNodeIndex = tn.Index;
                if (currentNodeIndex != oldNodeIndex)
                {
                    oldNodeIndex = currentNodeIndex;
                    if (toolTip != null && toolTip.Active)
                        toolTip.Active = false; //turn it off

                    // Find the session
                    Session s = (Session)tn.Tag;

                    if (s.IsFolder == false)
                    {
                        toolTip.SetToolTip(treeView, s.ToolTipText);
                        toolTip.Active = true; //make it active so it can show
                    }
                }
            }
            else
            {
                if (toolTip != null && toolTip.Active)
                {
                    oldNodeIndex = -1;
                    toolTip.Active = false; //turn it off
                }
            }
        }

        /// <summary>
        /// Event handler for the sortOrderToolStripMenuItems click event
        /// Determines which toolstripmenuitem sent the event, defines a
        /// sorter based on that, and sorts the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionSorter.SortOrder order = SessionSorter.SortOrder.FOLDER_IGNORE;
            if (sender == foldersFirstToolStripMenuItem)
            {
                order = SessionSorter.SortOrder.FOLDER_FIRST;
                ignoreFoldersToolStripMenuItem.Checked = false;
                foldersLastToolStripMenuItem.Checked = false;
            }
            else if (sender == ignoreFoldersToolStripMenuItem)
            {
                order = SessionSorter.SortOrder.FOLDER_IGNORE;
                foldersFirstToolStripMenuItem.Checked = false;
                foldersLastToolStripMenuItem.Checked = false;
            }
            else if (sender == foldersLastToolStripMenuItem)
            {
                order = SessionSorter.SortOrder.FOLDER_LAST;
                foldersFirstToolStripMenuItem.Checked = false;
                ignoreFoldersToolStripMenuItem.Checked = false;
            }

            SessionSorter sorter = new SessionSorter(order);
            treeView.BeginUpdate();
            treeView.TreeViewNodeSorter = sorter;
            treeView.EndUpdate();
            Properties.Settings.Default.SortOrder = (int)order;
        }

        /// <summary>
        /// Event handler for key up event from the tree view
        /// If ENTER is pressed and the selected session isn't 
        /// a folder , launch that session
        /// Also add a handler for CTRL Left and Right arrows
        /// to expand and collapse child nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_KeyUp(object sender, KeyEventArgs e)
        {
            // Only grab the key up event for enter if
            // the key down event also occured in this 
            // control
            if (e.KeyCode == Keys.Enter && enterPressed)
            {
                // Don't launch subfolders by default
                bool getSubfolders = false;

                // If the CRTL key has been pressed , 
                // launch subfolders
                if (e.Modifiers == Keys.Control)
                    getSubfolders = true;

                List<Session> sl = getSelectedSessions(getSubfolders);
                if (confirmNumberOfSessions(sl))
                    launchFolderSessions(sl);

                // Reset the enter pressed flag
                // and mark the event as handled
                enterPressed = false;
                e.Handled = true;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) &&
                     e.Modifiers == Keys.Control)
            {
                // Find the selected node
                TreeNode selectedNode = treeView.SelectedNode;

                if (selectedNode != null)
                {
                    if (e.KeyCode == Keys.Right)
                    {
                        // Suppress repainting the TreeView until all the objects have been updated.
                        treeView.BeginUpdate();
                        selectedNode.ExpandAll();
                        treeView.EndUpdate();


                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        // Suppress repainting the TreeView until all the objects have been updated.
                        treeView.BeginUpdate();
                        selectedNode.Collapse(false);
                        treeView.EndUpdate();
                    }

                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                // Renames only allowed if the sessions are unlocked
                if (lockSessionsToolStripMenuItem.Checked == false)
                {
                    // Find the selected node
                    TreeNode selectedNode = treeView.SelectedNode;

                    // Renames of the top node aren't allowed
                    if (selectedNode != null && selectedNode.Parent != null)
                    {
                        Session s = (Session)selectedNode.Tag;
                        if (s != null)
                        {
                            renameToolStripMenuItem_Click(this, EventArgs.Empty);
                            e.Handled = true;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                // Deletes only allowed if the sessions are unlocked
                if (lockSessionsToolStripMenuItem.Checked == false)
                {
                    deleteSessionToolStripMenuItem_Click(this, new EventArgs());
                }
            }
            else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                OnExportSessions(new ExportSessionEventArgs(ExportSessionEventArgs.ExportType.CLIP_TYPE));
            }
        }

        /// <summary>
        /// Event handler for expandTreeToolStripMenuItem click event
        /// Will expand all child nodes of the selected node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expandTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Find the selected node
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                // Suppress repainting the TreeView until all the objects have been updated.
                treeView.BeginUpdate();

                selectedNode.ExpandAll();

                treeView.EndUpdate();

            }
        }

        /// <summary>
        /// Event handler for collapseTreeToolStripMenuItem click event
        /// Will collapse all child nodes of the selected node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void collapseTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Find the selected node
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                // Suppress repainting the TreeView until all the objects have been updated.
                treeView.BeginUpdate();

                selectedNode.Collapse(false);

                treeView.EndUpdate();
            }
        }

        private void launchFilezillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session s = getSelectedSession();
            OnLaunchSession(new LaunchSessionEventArgs(s, LaunchSessionEventArgs.PROGRAM.FILEZILLA));
        }

        private void launchWinSCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session s = getSelectedSession();
            OnLaunchSession(new LaunchSessionEventArgs(s, LaunchSessionEventArgs.PROGRAM.WINSCP));
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            sessionControl_KeyDown(sender, e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportSessionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ed.ShowDialog() == DialogResult.OK)
                OnExportSessions(new ExportSessionEventArgs(ed.getExportType()));
        }

        /// <summary>
        /// Allows the tree to be fully expanded
        /// </summary>
        public void expandFullTree()
        {
            // Suppress repainting the TreeView until all the objects have been updated.
            treeView.BeginUpdate();

            TreeNode rootNode = treeView.Nodes[0];
            if (rootNode != null)
                rootNode.ExpandAll();

            treeView.EndUpdate();
        }


        /// <summary>
        /// Method to ensure a consistent setup of new tree nodes
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private TreeNode createNode(Session s)
        {
            TreeNode newNode = new TreeNode(s.SessionDisplayText);
            newNode.Tag = s;
            newNode.ContextMenuStrip = nodeContextMenuStrip;
            if (s.IsFolder == false)
            {
                newNode.ImageIndex = IMAGE_INDEX_SESSION;
                newNode.SelectedImageIndex = IMAGE_INDEX_SESSION;
            }
            else
            {
                newNode.ImageIndex = IMAGE_INDEX_FOLDER;
                newNode.SelectedImageIndex = IMAGE_INDEX_SELECTED_FOLDER;
            }

            // Setup the key so that we can find the node again
            newNode.Name = s.NodeKey;

            return newNode;
        }

        public override void resetDialogFont()
        {
            base.resetDialogFont();
            ed.resetDialogFont();
            newSessionForm.resetDialogFont();
        }
    }
}
