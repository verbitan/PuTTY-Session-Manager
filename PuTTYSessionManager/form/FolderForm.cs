using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace uk.org.riseley.puttySessionManager.form
{
    public partial class FolderForm : Form
    {
        public FolderForm()
        {
            InitializeComponent();
        }

        public FolderForm(string foldername)
            : this()
        {
            textBox1.Text = foldername;
        }

        public string getFolderName()
        {
            return textBox1.Text;
        }     
    }
}