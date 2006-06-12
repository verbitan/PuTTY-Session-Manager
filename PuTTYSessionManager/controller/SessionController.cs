using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
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

        public event EventHandler SessionsRefreshed;

        public static SessionController getInstance()
        {
            if (instance == null)
                instance = new SessionController();
            return instance;
        }

        private SessionController()
        {
            invalidateSessionList();
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

        public void invalidateSessionList()
        {
            lock (sessionList)
            {
                sessionList = getSessionListFromRegistry();
            }
            OnSessionsRefreshed(EventArgs.Empty);
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

        protected virtual void OnSessionsRefreshed(EventArgs e)
        {
            if (SessionsRefreshed != null)
                SessionsRefreshed(this, e);
        }

    }

    

}
