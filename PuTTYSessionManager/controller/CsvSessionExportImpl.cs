/* 
 * Copyright (C) 2007 David Riseley 
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
using uk.org.riseley.puttySessionManager.model;
using System.IO;

namespace uk.org.riseley.puttySessionManager.controller
{
    class CsvSessionExportImpl : SessionExportInterface
    {
        /// <summary>
        /// The file type for this provider
        /// </summary>
        private const string EXPORT_FILE_TYPE = "csv";

        /// <summary>
        /// The file description for this provider
        /// </summary>
        private const string EXPORT_FILE_DESCRIPTION = "CSV File";

        #region SessionExportInterface Members

           /// <summary>
        /// Get a description for the file type
        /// </summary>
        /// <returns></returns>
        public string getFileTypeDescription()
        {
            return EXPORT_FILE_DESCRIPTION;
        }

        /// <summary>
        /// Get the file extension
        /// </summary>
        /// <returns></returns>
        public string getFileTypeExtension()
        {
            return EXPORT_FILE_TYPE;
        }

        /// <summary>
        /// Create an export of the sessions in this providers type
        /// This may throw an exception if there are File I/O issues
        /// </summary>
        /// <param name="sessionList">The list of sessions to store</param>
        /// <param name="fileName">The file name to store the backup in </param>
        /// <returns>Count of exported sessions</returns>
        public int saveSessionsToFile(List<Session> sessionList, string fileName)
        {
            int savedCount = 0;
            if (sessionList.Count == 0)
                return 0;

            using (StreamWriter sw = File.CreateText(fileName))
            {
                writeSessionExportHeader(sw);
                foreach (Session s in sessionList)
                {
                    if (saveSession(s, sw))
                        savedCount++;
                }
                sw.Close();
            }
            return savedCount;
        }

        #endregion

        /// <summary>
        /// Write the file header to the stream
        /// </summary>
        /// <param name="sw"></param>
        private void writeSessionExportHeader(StreamWriter sw)
        {
            sw.WriteLine("\"Session Name\",\"Folder Name\",\"Username\",\"Hostname\"");
        }

        /// <summary>
        /// Save a single session to the stream
        /// </summary>
        /// <param name="s">The session to save</param>
        /// <param name="sw"></param>
        /// <returns>true if sucessful, false otherwise</returns>
        private bool saveSession(Session s, StreamWriter sw)
        {
            String hostname = s.Hostname;
            String sessionName = s.SessionDisplayText;
            String username = s.Username;
            String foldername = s.FolderName;

            if (hostname != null && hostname.Contains("@"))
            {
                username = hostname.Substring(0, hostname.IndexOf("@"));
                hostname = hostname.Substring(hostname.IndexOf("@") + 1);
            }
            if (foldername == null || foldername.ToString().Equals(""))
                foldername = Session.SESSIONS_FOLDER_NAME;

            sw.WriteLine("\"" + sessionName.Replace("\"", "\"\"") + "\"," +
                         "\"" + foldername.Replace("\"", "\"\"") + "\"," +
                         "\"" + username.Replace("\"", "\"\"") + "\"," +
                         "\"" + hostname.Replace("\"", "\"\"") + "\"");

            return true;
        }
    }
}
