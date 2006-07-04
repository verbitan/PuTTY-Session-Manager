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
using System.Text;

namespace uk.org.riseley.puttySessionManager.model
{

    public class Session : IEquatable<Session> ,IComparable<Session>
    {
        public const string SESSIONS_FOLDER_NAME = "Sessions";

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
            if (folderName == null || folderName.Equals(""))
                FolderName = SESSIONS_FOLDER_NAME;
            else
                FolderName = folderName;
            IsFolder = isFolder;
            cellValues = new String[] { SessionDisplayText, FolderName };
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


    }
}
