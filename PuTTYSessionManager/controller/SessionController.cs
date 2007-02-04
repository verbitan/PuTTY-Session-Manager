using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using uk.org.riseley.puttySessionManager.model;
using System.Windows.Forms;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum,
  ViewAndModify = uk.org.riseley.puttySessionManager.controller.SessionController.PUTTY_SESSIONS_REG_KEY)]
[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum,
 ViewAndModify = uk.org.riseley.puttySessionManager.controller.SessionController.AUTOSTART_REG_KEY)]  

namespace uk.org.riseley.puttySessionManager.controller
{

    /// <summary>
    /// This singleton class provides the interface between the application
    /// and the registry
    /// </summary>
    public class SessionController
    {
        /// <summary>
        /// The registry value which stores the Session folder
        /// </summary>
        public const string PUTTY_PSM_FOLDER_ATTRIB = "PsmPath";

        /// <summary>
        /// The hostname registry value
        /// </summary>
        public const string PUTTY_HOSTNAME_ATTRIB = "HostName";

        /// <summary>
        /// The default username registry value
        /// </summary>
        public const string PUTTY_USERNAME_ATTRIB = "UserName";

        /// <summary>
        /// The registry key ( relative to HKCU ) that stores PuTTY sessions
        /// </summary>
        public const string PUTTY_SESSIONS_REG_KEY = "Software\\SimonTatham\\PuTTY\\Sessions";

        /// <summary>
        /// The registry key ( relative to HKCU ) that stores the Autostart entries
        /// </summary>
        public const string AUTOSTART_REG_KEY = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        /// <summary>
        /// The registry key attribute that stores the PSM Autostart entry
        /// </summary>
        public const string PSM_AUTOSTART_REG_ATTRIB = "PuTTYSessionManager";

        /// <summary>
        /// The registry key of the "Default Session"
        /// </summary>
        private const string PUTTY_DEFAULT_SESSION = "Default%20Settings";

        /// <summary>
        /// The registry export file type
        /// </summary>
        public const string FILE_TYPE_REG = "reg";

        /// <summary>
        /// The csv export file type
        /// </summary>
        public const string FILE_TYPE_CSV = "csv";

        /// <summary>
        /// The current list of all the sessions stored in the registry
        /// </summary>
        private static List<Session> sessionList = new List<Session>();

        /// <summary>
        /// The current list of all the folders which can be used to 
        /// organise sessions. Must be kept in sync with <code>sessionList</code>
        /// </summary>
        private static List<string> folderList = new List<string>();

        /// <summary>
        /// The singleton instance of this class
        /// </summary>
        private static SessionController instance = null;

        /// <summary>
        /// This event is fired when the list of sessions has been altered
        /// </summary>
        public event SessionsRefreshedEventHandler SessionsRefreshed;
        public delegate void SessionsRefreshedEventHandler(object sender, RefreshSessionsEventArgs re);

        /// <summary>
        /// Gets the singleton instance of this class
        /// </summary>
        /// <returns></returns>
        public static SessionController getInstance()
        {
            if (instance == null)
                instance = new SessionController();
            return instance;
        }

        /// <summary>
        /// Private constructor called when the singleton instance is 
        /// created.
        /// </summary>
        private SessionController()
        {
            invalidateSessionList(this, true);
        }

        /// <summary>
        /// Get the list of sessions
        /// </summary>
        /// <returns></returns>
        public List<Session> getSessionList()
        {
            return sessionList;
        }

        public List<string> getFolderList()
        {
            return folderList;
        }

        public List<string> getSessionAttributes(Session s)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName);
            List<string> attributes = new List<string>();
            if (rk != null)
            {
                attributes.AddRange(rk.GetValueNames());
                attributes.Sort();
                rk.Close();
            }
            return attributes;
        }

        public Session findDefaultSession()
        {
            return findDefaultSession(sessionList, true);
        }

        public Session findDefaultSession(bool defaultSessionOnly)
        {
            return findDefaultSession(sessionList, defaultSessionOnly);
        }

        public string findDefaultFolder()
        {
            return Session.SESSIONS_FOLDER_NAME;
        }

        public Session findDefaultSession(List<Session> sl, bool defaultSessionOnly)
        {
            Session s = findSession(sl, PUTTY_DEFAULT_SESSION);

            // If we can't find the default session
            // return the first one in the list
            if (defaultSessionOnly == false && s == null && sl.Count > 0)
                s = sl[0];

            return s;
        }

        public Session findSession(string sessionName)
        {
            return findSession(sessionList, sessionName);
        }

        public Session findSession(List<Session> sl, string sessionName)
        {
            Session s = new Session(sessionName, "", false);
            int index = sl.BinarySearch(s);
            if (index >= 0)
                s = sessionList[index];
            else
                s = null;
            return s;
        }

        public void invalidateSessionList(Object sender, bool refreshSender)
        {
            lock (sessionList)
            {
                sessionList = getSessionListFromRegistry();
                folderList = getFolderListFromSessions(sessionList);
            }
            OnSessionsRefreshed(sender, new RefreshSessionsEventArgs(refreshSender));
        }

        private List<Session> getSessionListFromRegistry()
        {
            List<Session> sl = new List<Session>();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY);

            // Check we have some sessions
            if (rk == null)
                return sl;

            foreach (string keyName in rk.GetSubKeyNames())
            {
                RegistryKey sessKey = rk.OpenSubKey(keyName);

                // Exclude keys that have no values in them
                if (sessKey.ValueCount > 0)
                {
                    String psmpath = (String)sessKey.GetValue(PUTTY_PSM_FOLDER_ATTRIB);
                    Session s = new Session(keyName, psmpath, false);

                    s.ToolTipText = getSessionToolTipText(sessKey, s.SessionDisplayText);
                    sl.Add(s);
                }
                sessKey.Close();
            }
            rk.Close();
            sl.Sort();

            return sl;
        }

        private List<string> getFolderListFromSessions(List<Session> sl)
        {
            List<string> fl = new List<string>();
            List<string> sfl = new List<string>();

            // Add the default folder
            fl.Add(Session.SESSIONS_FOLDER_NAME);

            foreach (Session s in sl)
            {
                if (fl.Contains(s.FolderName) == false)
                    fl.Add(s.FolderName);
            }

            // Add in the path elements
            foreach (string folder in fl)
            {
                string path = "";
                foreach (string subfolder in folder.Split(Session.PATH_SEPARATOR.ToCharArray()))
                {
                    if (path.Equals(""))
                        path = subfolder;
                    else
                        path = path + Session.PATH_SEPARATOR + subfolder;

                    if (fl.Contains(path) == false && 
                        sfl.Contains(path) == false)
                        sfl.Add(path);
                }
            }

            fl.AddRange(sfl.ToArray());

            fl.Sort();

            return fl;
        
        }

        public void saveFolderToRegistry(Session s)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, true);
            if (rk != null)
            {
                rk.SetValue(PUTTY_PSM_FOLDER_ATTRIB, s.FolderName, RegistryValueKind.String);
                rk.Close();
            }
        }

        protected virtual void OnSessionsRefreshed(Object sender, RefreshSessionsEventArgs e)
        {
            if (SessionsRefreshed != null)
                SessionsRefreshed(sender, e);
        }

        public int saveSessionsToFile(List<Session> sessionList, String fileName, String filetype)
        {
            int savedCount = 0;
            if (sessionList.Count == 0)
                return 0;
            using (StreamWriter sw = File.CreateText(fileName))
            {
                writeSessionExportHeader(sw, filetype);
                foreach (Session s in sessionList)
                {
                    if (saveSession(s, sw, filetype))
                        savedCount ++;
                }
                sw.Close();
            }
            return savedCount;
        }

        private bool saveSession(Session s, StreamWriter sw, String filetype)
        {
            bool result = false;
            if (filetype.Equals(FILE_TYPE_REG))
                result = saveSessionToRegExport(s, sw);
            else if ( filetype.Equals(FILE_TYPE_CSV))
                result = saveSessionToCsvExport(s,sw);
            return result;
        }

        private bool saveSessionToCsvExport(Session s, StreamWriter sw) 
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName);
            if (rk == null)
                return false;
            String hostname = "";
            String sessionName = "";
            String username = "";
            String foldername = "";
            
            Object value = rk.GetValue(PUTTY_HOSTNAME_ATTRIB);
            if ( value != null )
                hostname = value.ToString();
            sessionName = s.SessionDisplayText;

            value = rk.GetValue(PUTTY_USERNAME_ATTRIB);
            if (value != null)
                username = value.ToString();

            if ( hostname != null && hostname.Contains("@") ) 
            {
                username = hostname.Substring(0,hostname.IndexOf("@"));
                hostname = hostname.Substring(hostname.IndexOf("@") + 1);
            }
            value = rk.GetValue(PUTTY_PSM_FOLDER_ATTRIB);
            if (value != null)
                foldername = value.ToString();

            sw.WriteLine("\"" + sessionName + "\"," +
                         "\"" + foldername  + "\"," +   
                         "\"" + username    + "\"," +   
                         "\"" + hostname    + "\"" );   
            rk.Close();
            return true;
        }

        private bool saveSessionToRegExport(Session s, StreamWriter sw)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName);
            if (rk != null)
                sw.WriteLine("[" + Registry.CurrentUser.Name + "\\" + PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName + "]");
            else
                return false;
            foreach (string valueName in rk.GetValueNames())
            {
                RegistryValueKind valueKind = rk.GetValueKind(valueName);
                if (valueKind.Equals(RegistryValueKind.String))
                {
                    sw.WriteLine("\"" + valueName + "\"=\"" + rk.GetValue(valueName).ToString().Replace("\\", "\\\\") + "\"");
                }
                else if (valueKind.Equals(RegistryValueKind.DWord))
                {
                    Object o = rk.GetValue(valueName);
                    string hex = ((int)o).ToString("x8");
                    sw.WriteLine("\"" + valueName + "\"=dword:" + hex);
                }

            }
            sw.WriteLine();
            rk.Close();
            return true;
        }

        private void writeSessionExportHeader(StreamWriter sw, String filetype)
        {
            if (filetype.Equals(FILE_TYPE_REG))
            {
                sw.WriteLine("Windows Registry Editor Version 5.00");
                sw.WriteLine();
                sw.WriteLine("[" + Registry.CurrentUser.Name + "\\" + PUTTY_SESSIONS_REG_KEY + "]");
                sw.WriteLine();
            }
            else if (filetype.Equals(FILE_TYPE_CSV))
            {
                sw.WriteLine("Session Name,Folder Name,Username,Hostname");
            }
        }

        public bool createNewSession(NewSessionRequest nsr, object sender)
        {
            // Check the template session is still there
            RegistryKey template = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + nsr.SessionTemplate.SessionName, false);
            if (template == null)
                return false;

            // Check no-one has created a new session with the same name
            RegistryKey newSession = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + nsr.SessionName, false);
            if (newSession != null)
            {
                newSession.Close();
                return false;
            }

            // Create the new session 
            newSession = Registry.CurrentUser.CreateSubKey (PUTTY_SESSIONS_REG_KEY + "\\" + Session.convertDisplayToSessionKey(nsr.SessionName));

            // Copy the values
            bool hostnameSet = false;
            bool foldernameSet = false;

            object value;
            foreach (string valueName in template.GetValueNames())
            {
                
                if ( valueName.Equals ( PUTTY_HOSTNAME_ATTRIB ) ) 
                {
                    hostnameSet = true;
                    value = nsr.Hostname;
                } 
                else if ( valueName.Equals ( PUTTY_PSM_FOLDER_ATTRIB ) )
                {
                    foldernameSet = true;
                    value = nsr.SessionFolder;
                }
                else if ( nsr.CopyDefaultUsername == false &&
                            valueName.Equals (PUTTY_USERNAME_ATTRIB) )
                {
                    value = "";
                } 
                else 
                {
                    value = template.GetValue(valueName);
                }

                newSession.SetValue(valueName,value,template.GetValueKind(valueName));
            }

            // Set the hostname if it hasn't already been set
            if ( hostnameSet == false )
                newSession.SetValue(PUTTY_HOSTNAME_ATTRIB, nsr.Hostname, RegistryValueKind.String);

            // Set the foldername if it hasn't already been set
            if ( foldernameSet == false )
                newSession.SetValue(PUTTY_PSM_FOLDER_ATTRIB, nsr.SessionFolder, RegistryValueKind.String);

            template.Close();
            newSession.Close();

            invalidateSessionList(sender, false);

            return true;
        }

        public bool deleteSessions(List<Session> sl, object sender)
        {
            // Check all the sessions still exist
            RegistryKey rk;
            foreach (Session s in sl)
            {
                rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName);
                if (rk == null)
                    return false;
                rk.Close();
            }

            // Delete the sessions
            foreach (Session s in sl)
            {
                Registry.CurrentUser.DeleteSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, false);
            }

            invalidateSessionList(sender, false);

            return true;
        }

        public string launchSession(string sessionName)
        {
            String puttyExec = Properties.Settings.Default.PuttyLocation;
            Process p = new Process();
            p.StartInfo.FileName = puttyExec;
            p.StartInfo.Arguments = "-load \"" + sessionName + "\"";

            bool result = false;
            String errMsg = "";
            try
            {
                result = p.Start();
            }
            catch (Exception ex)
            {
                result = false;
                errMsg = ex.Message;
            }
            p.Close();

            return errMsg;
        }

        public bool renameSession(Session s, string newSessionName)
        {
            // Check the old session isn't the default session
            if (s.SessionName.Equals(PUTTY_DEFAULT_SESSION))
                return false;
            
            // Check the current session is still there
            RegistryKey current = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, false);
            if (current == null)
                return false;

            // Check no-one has created a new session with the same name
            RegistryKey newSession = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + newSessionName, false);
            if (newSession != null)
            {
                newSession.Close();
                return false;
            }

            // Create the new session
            newSession = Registry.CurrentUser.CreateSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + Session.convertDisplayToSessionKey(newSessionName));
            if (newSession == null)
                return false;

            // Copy all the attributes
            object value;
            foreach (string valueName in current.GetValueNames())
            {
                value = current.GetValue(valueName);
                newSession.SetValue(valueName, value, current.GetValueKind(valueName));
            }

            // Close the new session
            newSession.Close();

            // Close the current session;
            current.Close();

            // Delete the current session
            Registry.CurrentUser.DeleteSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName);

            return true;
        }

        public bool isDefaultSessionName ( string sessionName )
        {
            if ( Session.convertDisplayToSessionKey(sessionName).Equals( PUTTY_DEFAULT_SESSION ))
                return true;
            else 
                return false;

        }

        public bool copySessionAttributes(CopySessionRequest csr)
        {
            // Check the template session is still there
            RegistryKey template = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + csr.SessionTemplate.SessionName, false);
            if (template == null)
                return false;

            // Check all the target sessions still exist
            foreach (Session s in csr.TargetSessions)
            {
                RegistryKey targetSession = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, false);
                if (targetSession == null)
                {
                    template.Close();
                    return false;
                }
                else
                {
                    targetSession.Close();
                }
            }

            // Copy all the attributes
            foreach (Session s in csr.TargetSessions)
            {
                RegistryKey targetSession = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, true);
                object value;
                bool copy;
                foreach (string valueName in template.GetValueNames())
                {
                    copy = false;
                    // Never copy the hostname onto the default session
                    if (s.SessionName.Equals(SessionController.PUTTY_DEFAULT_SESSION) &&
                        valueName.Equals(SessionController.PUTTY_HOSTNAME_ATTRIB))
                        copy = false;                        
                    else if ((csr.CopyOptions == CopySessionRequest.CopySessionOptions.COPY_ALL ) &&
                         !(valueName.Equals(SessionController.PUTTY_HOSTNAME_ATTRIB))&&
                         !(valueName.Equals(SessionController.PUTTY_PSM_FOLDER_ATTRIB))
                        )
                        copy = true;
                    else if ((csr.CopyOptions == CopySessionRequest.CopySessionOptions.COPY_EXCLUDE) &&
                         !(valueName.Equals(SessionController.PUTTY_HOSTNAME_ATTRIB)) &&                        
                         !(valueName.Equals(SessionController.PUTTY_PSM_FOLDER_ATTRIB)) &&
                         !(csr.SelectedAttributes.Contains(valueName)))
                        copy = true;
                    else if (csr.CopyOptions == CopySessionRequest.CopySessionOptions.COPY_INCLUDE)
                        copy = csr.SelectedAttributes.Contains(valueName);

                    if (copy == true)
                    {
                        value = template.GetValue(valueName);
                        targetSession.SetValue(valueName, value, template.GetValueKind(valueName));
                    }
                }
                targetSession.Close();
             
            }
            
            // Close the template session;
            template.Close();

            return true;
        }

        /// <summary>
        /// Build the tool tip text for a session
        /// </summary>
        /// <param name="s">The session to use</param>
        /// <returns></returns>
        private string getSessionToolTipText(RegistryKey rk, string sessionname)
        {
            string tooltip = "";
            int portnumber = -1;

            if (rk != null )
            {
                // Get all the values from the registry that we are interested in
                string hostname = (string)rk.GetValue(PUTTY_HOSTNAME_ATTRIB);
                string username = (string)rk.GetValue(PUTTY_USERNAME_ATTRIB);
                string portforwards = (string)rk.GetValue ("PortForwardings");
                string protocol = (string)rk.GetValue("Protocol");
                string remotecommand = (string)rk.GetValue("RemoteCommand");

                // Get the port number
                object portnumberObject = rk.GetValue("PortNumber");
                // Only attempt to cast to an int if the object is not null
                if ( portnumberObject != null )
                    portnumber = (int)portnumberObject;

                // Close the registry key
                rk.Close();

                // Check if the hostname is set
                if (hostname == null || hostname.Equals(""))
                    hostname = "[NONE SET]";

                // Ignore the default username if the hostname contains an @
                if (hostname != null && hostname.Contains("@"))
                    username = null;
                else if ( username != null && !(username.Equals("")))
                    username = username + "@";

                // Set the port number to null if default for the protocol
                string port = ":" + portnumber;
                if (  protocol != null &&
                    ((protocol.Equals("ssh") && portnumber == 22) ||
                     (protocol.Equals("telnet") && portnumber == 23) ||
                     (protocol.Equals("rlogin") && portnumber == 513) ||
                      portnumber == -1 ))
                {
                    port = "";
                }

                // Build the connection string
                String connection = protocol + "://" + username + hostname + port;

                // Now build the full tooltip text
                if (sessionname != null && !sessionname.Equals(""))
                    tooltip += "Session: " + sessionname + Environment.NewLine;
                tooltip += connection + Environment.NewLine;
                if (remotecommand != null && !remotecommand.Equals(""))
                    tooltip += "Remote Command: " + remotecommand + Environment.NewLine;
                if (portforwards != null && !portforwards.Equals(""))
                    tooltip += "Port Forwards: " + portforwards + Environment.NewLine;
                
                // Strip off any trailing newline
                if (tooltip.EndsWith(Environment.NewLine))
                    tooltip = tooltip.Remove(tooltip.LastIndexOf(Environment.NewLine));
            }
            return tooltip;
        }

        /// <summary>
        /// Check whether auto start on logon is enabled in the registry
        /// </summary>
        /// <returns></returns>
        public bool isAutoStartEnabled()
        {
            bool retval = false;
            
            // Open the autostart registry key
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(AUTOSTART_REG_KEY);

            // Check if the PSM attribute exists
            if (rk.GetValue(PSM_AUTOSTART_REG_ATTRIB) != null)
                retval = true;

            // Clost the registry key
            rk.Close();

            return retval;                
        }

        /// <summary>
        /// Adds or removes a key from the registry to automatically
        /// start Putty Session Manager on logon
        /// </summary>
        /// <param name="enabled">Enable or disable auto start</param>
        public void setAutoStart(bool enabled)
        {
            // Open the autostart registry key
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(AUTOSTART_REG_KEY,true);

            // If we are enabling autstart set the value to the current exec path
            if (enabled)
                rk.SetValue(PSM_AUTOSTART_REG_ATTRIB, "\"" + Application.ExecutablePath + "\"", RegistryValueKind.String);
            // otherwise delete it
            else
                rk.DeleteValue(PSM_AUTOSTART_REG_ATTRIB, false);

            // Close the value
            rk.Close();
        }


    }
}
