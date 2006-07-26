using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class SessionNameForm
        : Form
    {
        public SessionNameForm()
        {
            InitializeComponent();
        }

        public SessionNameForm(string sessionName)
            : this()
        {
            sessionNameTextBox.Text = sessionName;
        }

        public string getSessionName()
        {
            return sessionNameTextBox.Text;
        }     
    }
}