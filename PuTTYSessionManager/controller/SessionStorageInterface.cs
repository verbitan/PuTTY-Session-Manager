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

namespace uk.org.riseley.puttySessionManager.controller
{
    /// <summary>
    /// The contract for a session storage provider
    /// </summary>
    interface SessionStorageInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Session> getSessionList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        List<string> getSessionAttributes(Session s);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        void saveFolder(Session s);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nsr"></param>
        /// <returns></returns>
        bool createNewSession(NewSessionRequest nsr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sl"></param>
        /// <returns></returns>
        bool deleteSessions(List<Session> sl);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="newSessionName"></param>
        /// <returns></returns>
        bool renameSession(Session s, string newSessionName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csr"></param>
        /// <returns></returns>
        bool copySessionAttributes(CopySessionRequest csr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionList"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        int backupSessionsToFile(List<Session> sessionList, String fileName);
    }
}
