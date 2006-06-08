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

        private bool isSessionListCurrent = false;
        private List<Session> sessionList;

        public SessionController()
        {
            isSessionListCurrent = false;
        }

        public List<Session> getSessionList()
        {
            if (isSessionListCurrent == false)
            {
                sessionList = getSessionListFromRegistry();
                isSessionListCurrent = true;
            }
            return sessionList;
        }

        public void invalidateSessionList()
        {
            isSessionListCurrent = false;
        }

        private List<Session> getSessionListFromRegistry()
        {
            List<Session> sessionList = new List<Session>();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY);

            foreach (string keyName in rk.GetSubKeyNames())
            {
                RegistryKey sessKey = rk.OpenSubKey(keyName);
                String psmpath = (String)sessKey.GetValue(PUTTY_PSM_FOLDER_VALUE);
                sessKey.Close();

                Session s = new Session(keyName, psmpath, false);
                
                sessionList.Add(s);
            }
            rk.Close();

            sessionList.Sort();

            return sessionList;
        }

        public void saveFolderToRegistry(Session s)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PUTTY_SESSIONS_REG_KEY + "\\" + s.SessionName, true);
            rk.SetValue(PUTTY_PSM_FOLDER_VALUE, s.FolderName, RegistryValueKind.String);
            rk.Close();
        }
    }

    

}
