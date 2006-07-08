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
using System.Windows.Forms;

namespace uk.org.riseley.puttySessionManager.model
{
    public class CopySessionRequest
    {
        public CopySessionRequest()
        {
            initialiseLists();
        }

        public enum CopySessionOptions 
        { 
              COPY_ALL
            , COPY_INCLUDE
            , COPY_EXCLUDE 
        };

        public enum AttribGroups
        {
            COLOURS
          , DEFAULT_USERNAME
          , FONT
          , KEEP_ALIVES
          , PROTOCOL_PORT
          , SCROLLBACK
          , SELECTION_CHARS
          , SESSION_FOLDER
          , SSH_PORT_FORWARDS
        };

        private List<string> attribColours = new List<string>();
        private List<string> attribDefaultUsername = new List<string>();
        private List<string> attribFont = new List<string>();
        private List<string> attribKeepAlives = new List<string>();
        private List<string> attribProtocolPort = new List<string>();
        private List<string> attribScrollback = new List<string>();
        private List<string> attribSelectionChars = new List<string>();
        private List<string> attribSessionFolder = new List<string>();
        private List<string> attribSshPortForwards = new List<string>();

        private Dictionary<string, AttribGroups> dictAllAttribs = new Dictionary<string, AttribGroups>();
        private Dictionary<AttribGroups, List<string>> dictAllAttribGroups = new Dictionary<AttribGroups, List<string>>();

        private Session sessionTemplate;

        public Session SessionTemplate
        {
            set { sessionTemplate = value; }
            get { return sessionTemplate; }
        }

        private List<string> selectedAttributes;

        public List<string> SelectedAttributes
        {
            set { selectedAttributes = value; }
            get { return selectedAttributes; }        
        }

        private void initialiseLists()
        {
            initialiseColours();
            initialiseDefaultUsername();
            initialiseFont();
            initialiseKeepAlives();           
            initialiseProtocolPort();
            initialiseScrollback();
            initialiseSelectionChars();
            initialiseSessionFolder();
            initialiseSshPortForwards();

            // Consolidate the attributes
            initialiseDictionaries();
        }

        private void initialiseColours()
        {
            for (int i = 0; i <= 20; i++)
            {
                attribColours.Add("Colour" + i);
            }
        }

        private void initialiseDefaultUsername()
        {
            attribDefaultUsername.Add("UserName");
        }

        private void initialiseFont()
        {
            attribFont.Add("Font");
            attribFont.Add("FontCharSet");
            attribFont.Add("FontHeight");
            attribFont.Add("FontIsBold");
            attribFont.Add("FontVTMode");
            attribFont.Add("WideBoldFont");
            attribFont.Add("WideBoldFontCharSet");
            attribFont.Add("WideBoldFontHeight");
            attribFont.Add("WideBoldFontIsBold");
            attribFont.Add("BoldFont");
            attribFont.Add("BoldFontCharSet");
            attribFont.Add("BoldFontHeight");
            attribFont.Add("BoldFontIsBold");        
        }

        private void initialiseKeepAlives()
        {
            attribKeepAlives.Add("TCPKeepalives");
        }

        private void initialiseProtocolPort()
        {
            attribProtocolPort.Add("Protocol");
            attribProtocolPort.Add("PortNumber");
        }


        private void initialiseScrollback()
        {
            attribScrollback.Add("ScrollbackLines");
            attribScrollback.Add("ScrollBar");
            attribScrollback.Add("ScrollBarFullScreen");
            attribScrollback.Add("ScrollbarOnLeft");
            attribScrollback.Add("ScrollOnDisp");
            attribScrollback.Add("ScrollOnKey");
        }

        private void initialiseSelectionChars()
        {
            attribSelectionChars.Add("Wordness0");
            attribSelectionChars.Add("Wordness32");
            attribSelectionChars.Add("Wordness64");
            attribSelectionChars.Add("Wordness96");
            attribSelectionChars.Add("Wordness128");
            attribSelectionChars.Add("Wordness160");
            attribSelectionChars.Add("Wordness192");
            attribSelectionChars.Add("Wordness224");
        }

        private void initialiseSessionFolder()
        {
            attribSessionFolder.Add("PsmPath");
        }

        private void initialiseSshPortForwards()
        {
            attribSshPortForwards.Add("PortForwardings");
        }

        private void initialiseDictionaries()
        {
            dictAllAttribGroups.Add(AttribGroups.COLOURS, attribColours);
            dictAllAttribGroups.Add(AttribGroups.DEFAULT_USERNAME, attribDefaultUsername);
            dictAllAttribGroups.Add(AttribGroups.FONT, attribFont);
            dictAllAttribGroups.Add(AttribGroups.KEEP_ALIVES, attribKeepAlives);
            dictAllAttribGroups.Add(AttribGroups.PROTOCOL_PORT, attribProtocolPort);
            dictAllAttribGroups.Add(AttribGroups.SCROLLBACK, attribScrollback);
            dictAllAttribGroups.Add(AttribGroups.SELECTION_CHARS, attribSelectionChars);
            dictAllAttribGroups.Add(AttribGroups.SESSION_FOLDER, attribSessionFolder);
            dictAllAttribGroups.Add(AttribGroups.SSH_PORT_FORWARDS, attribSshPortForwards);

            List<string> l;
            foreach (AttribGroups key in dictAllAttribGroups.Keys)
            {
                dictAllAttribGroups.TryGetValue(key,out l);
                foreach ( string attrib in l)
                {
                    dictAllAttribs.Add(attrib,key);
                }
            }
        }

        private bool isAttribInGroup(string attrib)
        {
            return dictAllAttribs.ContainsKey(attrib);
        }

        private AttribGroups findAttribGroup(string attrib)
        {
            AttribGroups og;
            dictAllAttribs.TryGetValue(attrib, out og);
            return og;
        }


        public CheckState getGroupStatus(AttribGroups ag)
        {
            List<string> attribList;
            CheckState cs = CheckState.Unchecked;
            dictAllAttribGroups.TryGetValue(ag, out attribList);
            int attribCount = 0;
            foreach ( string attrib in attribList )
            {
                if (selectedAttributes.Contains(attrib))
                {
                   attribCount++; 
                }
            }

            if ( attribCount == 0 )
                cs = CheckState.Unchecked;
            else if ( attribCount < attribList.Count )
                cs = CheckState.Indeterminate;
            else
                cs = CheckState.Checked;

            return cs;
        }        
    }
}