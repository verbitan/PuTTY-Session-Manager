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
using System.Text;

namespace uk.org.riseley.puttySessionManager.model
{

    public class Session : IEquatable<Session>, IComparable<Session>
    {
        public const string SESSIONS_FOLDER_NAME = "Sessions";
        public const string PATH_SEPARATOR = "\\";

        private const string KEY_SESSION = "SESSION|";
        private const string KEY_FOLDER = "FOLDER|";

        private string sessionName = "";
        public string SessionName
        {
            get { return sessionName; }
            private set { sessionName = value; }
        }

        private string sessionDisplayText = "";
        public string SessionDisplayText
        {
            get { return sessionDisplayText; }
            private set { sessionDisplayText = value; }
        }

        private string folderName = "";
        public string FolderName
        {
            get { return folderName; }
            set { folderName = value; }
        }

        private bool isFolder = false;
        public bool IsFolder
        {
            get { return isFolder; }
            private set { isFolder = value; }
        }

        public Session(string regKey, string folderName, bool isFolder)
        {
            SessionName = regKey;
            SessionDisplayText = convertSessionKeyToDisplay(regKey);
            string folderCellValue;
            if (folderName == null || folderName.Equals("") || folderName.Equals(SESSIONS_FOLDER_NAME))
            {
                FolderName = SESSIONS_FOLDER_NAME;
                folderCellValue = "";
            }
            else
            {
                FolderName = folderName;
                folderCellValue = FolderName.Remove(0, (SESSIONS_FOLDER_NAME.Length + PATH_SEPARATOR.Length));
            }
            IsFolder = isFolder;
            cellValues = new String[] { SessionDisplayText, folderCellValue };
        }

        public override string ToString()
        {
            return SessionDisplayText;
        }

        public int CompareTo(Session s)
        {
            return this.SessionName.CompareTo(s.SessionName);
        }

        public bool Equals(Session s)
        {
            return (this.SessionName.Equals(s.SessionName));
        }

        public static String convertSessionKeyToDisplay(string key)
        {
            return key.Replace("%20", " ");
        }

        public static String convertDisplayToSessionKey(string display)
        {
            return display.Replace(" ", "%20");
        }

        private string[] cellValues;
        public string[] getCellValues()
        {
            return cellValues;
        }

        public string getKey()
        {
            if (IsFolder == true)
                return KEY_FOLDER + FolderName;
            else
                return KEY_SESSION + SessionName;
        }

        public static string getFolderKey(string folder)
        {
            return KEY_FOLDER + folder;
        }

        private string toolTipText = "";
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        private string hostname = "";

        public string Hostname
        {
            get { return hostname; }
            set { hostname = value; }
        }
        private string username = "";

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string protocol = "";

        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        private int portnumber = -1;

        public int Portnumber
        {
            get { return portnumber; }
            set { portnumber = value; }
        }

        private string portforwards;

        public string Portforwards
        {
            get { return portforwards; }
            set { portforwards = value; }
        }

        private string remotecommand;

        public string Remotecommand
        {
            get { return remotecommand; }
            set { remotecommand = value; }
        }

        public void setToolTip()
        {
            string hn = Hostname;
            string un = Username;

            // Check if the hostname is set
            if (hn == null || hn.Equals(""))
                hn = "[NONE SET]";

            // Ignore the default username if the hostname contains an @
            if (hn != null && hn.Contains("@"))
                un = null;
            else if (un != null && !(un.Equals("")))
                un = un + "@";

            // Set the port number to null if default for the protocol
            string port = ":" + Portnumber;
            if (Protocol != null &&
               ((Protocol.Equals("ssh") && Portnumber == 22) ||
                (Protocol.Equals("telnet") && Portnumber == 23) ||
                (Protocol.Equals("rlogin") && Portnumber == 513) ||
                 Portnumber == -1))
            {
                port = "";
            }

            // Build the connection string
            String connection = Protocol + "://" + un + hn + port;

            // Now build the full tooltip text
            if (SessionDisplayText != null && !SessionDisplayText.Equals(""))
                ToolTipText += "Session: " + SessionDisplayText + Environment.NewLine;

            ToolTipText += connection + Environment.NewLine;

            if (remotecommand != null && !remotecommand.Equals(""))
                ToolTipText += "Remote Command: " + remotecommand + Environment.NewLine;

            if (portforwards != null && !portforwards.Equals(""))
                ToolTipText += "Port Forwards: " + portforwards + Environment.NewLine;

            // Strip off any trailing newline
            if (ToolTipText.EndsWith(Environment.NewLine))
                ToolTipText = ToolTipText.Remove(ToolTipText.LastIndexOf(Environment.NewLine));

        }
    }
}
