using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.IO;
using Microsoft.Win32;


[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum,
ViewAndModify = uk.org.riseley.puttySessionManager.model.SessionController.PUTTY_SESSIONS_REG_KEY)]

namespace uk.org.riseley.puttySessionManager.model
{

    public class SessionController
    {
        public const string PUTTY_SESSIONS_REG_KEY = "Software\\SimonTatham\\PuTTY\\Sessions";
        public const string PUTTY_PSM_FOLDER_VALUE = "PsmPath";

        private static List<Session> sessionList = new List<Session>();

        private static SessionController instance = null;

        public event SessionsRefreshedEventHandler SessionsRefreshed;
        public delegate void SessionsRefreshedEventHandler(object sender, RefreshSessionsEventArgs re);

        public static SessionController getInstance()
        {
            if (instance == null)
                instance = new SessionController();
            return instance;
        }

        private SessionController()
        {
            invalidateSessionList(this, true);
        }

        public List<Session> getSessionList()
        {
           return sessionList;
        }

        public Session findSesssion(string sessionName)
        {
            Session s = new Session ( sessionName ,"", false);
            int index = sessionList.BinarySearch(s);
            if ( index >= 0 )
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
            }
            OnSessionsRefreshed(sender,new RefreshSessionsEventArgs(refreshSender));
        }

        private List<Session> getSessionListFromRegistry()
        {
            List<Session> sl = new List<Session>();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY);

            foreach (string keyName in rk.GetSubKeyNames())
            {
                RegistryKey sessKey = rk.OpenSubKey(keyName);
                String psmpath = (String)sessKey.GetValue(PUTTY_PSM_FOLDER_VALUE);
                sessKey.Close();

                Session s = new Session(keyName, psmpath, false);
                
                sl.Add(s);
            }
            rk.Close();

            sl.Sort();

            return sl;
        }

        public void saveFolderToRegistry(Session s)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, true);
            rk.SetValue(PUTTY_PSM_FOLDER_VALUE, s.FolderName, RegistryValueKind.String);
            rk.Close();
        }

        protected virtual void OnSessionsRefreshed(Object sender , RefreshSessionsEventArgs e)
        {
            if (SessionsRefreshed != null)
                SessionsRefreshed(sender, e);
        }

        public bool saveSessionsToFile(Session[] sessionArray, String fileName)
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                writeSessionExportHeader(sw);
                foreach (Session s in sessionArray)
                {
                    saveSession(s, sw);
                }
                sw.Close();
            }
            return true;
        }

        private void saveSession(Session s, StreamWriter sw)
        {
            sw.WriteLine("[" + Registry.CurrentUser.Name + "\\" + PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName + "]");
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName);
            foreach (string valueName in rk.GetValueNames())
            {
                RegistryValueKind valueKind = rk.GetValueKind(valueName);
                if ( valueKind.Equals (RegistryValueKind.String)) {
                    sw.WriteLine( "\"" + valueName + "\"=\"" + rk.GetValue(valueName).ToString() + "\"" );
                } else if ( valueKind.Equals ( RegistryValueKind.DWord )) {
                    sw.WriteLine("\"" + valueName + "\"=dword:" + rk.GetValue(valueName).ToString() + "\"");
                }

            }
            sw.WriteLine();
            rk.Close();

        }

        private void writeSessionExportHeader(StreamWriter sw)
        {
            sw.WriteLine("Windows Registry Editor Version 5.00");
            sw.WriteLine();
            sw.WriteLine("[" + Registry.CurrentUser.Name + "\\" + PUTTY_SESSIONS_REG_KEY + "]");
            sw.WriteLine();
        }
    }

    

}
