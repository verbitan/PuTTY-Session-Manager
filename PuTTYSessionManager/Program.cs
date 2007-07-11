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
using System.Windows.Forms;
using uk.org.riseley.puttySessionManager.form;
using Microsoft.Win32;

namespace uk.org.riseley.puttySessionManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Instantiate the application context
            PsmApplicationContext appContext = new PsmApplicationContext();

            // Start the main event loop
            Application.Run(appContext);           
        }
    }

    /// <summary>
    /// Application context class to handle the application lifecycle
    /// for PSM
    /// </summary>
    class PsmApplicationContext : ApplicationContext
    {
        /// <summary>
        /// The single SessionManagerForm instance
        /// </summary>
        private SessionManagerForm smf;

        /// <summary>
        /// Constructor for the PsmApplicationContext
        /// </summary>
        public PsmApplicationContext()
        {
            // Upgrade settings from a previous release
            if (Properties.Settings.Default.UpgradeRequired == true)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            // Instantiate the SessionManagerForm           
            smf = new SessionManagerForm();

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            // Attempt to handle session ending ( logoff / shutdown ) events
            SystemEvents.SessionEnding += new SessionEndingEventHandler(OnSessionEnding);

		    // Only make the form visible if the required
            smf.Visible = !(Properties.Settings.Default.MinimizeOnStart);
            
        }

        /// <summary>
        /// Event handler for the application exit event
        /// Attempt to save the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event handler for the SessionEnding event
        /// Attempt to save the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSessionEnding(object sender, SessionEndingEventArgs e)
        {           
            Properties.Settings.Default.Save();
        }
    }

}