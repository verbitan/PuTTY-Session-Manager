namespace uk.org.riseley.puttySessionManager.control
{
    partial class OptionsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.locateFileButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.sessionGroupBox = new System.Windows.Forms.GroupBox();
            this.urlRadioButton = new System.Windows.Forms.RadioButton();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.urlGroupBox = new System.Windows.Forms.GroupBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ignoreCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.validateButton = new System.Windows.Forms.Button();
            this.sessionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionGroupBox.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.urlGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // locateFileButton
            // 
            this.locateFileButton.Location = new System.Drawing.Point(6, 21);
            this.locateFileButton.Name = "locateFileButton";
            this.locateFileButton.Size = new System.Drawing.Size(75, 23);
            this.locateFileButton.TabIndex = 0;
            this.locateFileButton.Text = "Locate File";
            this.locateFileButton.UseVisualStyleBackColor = true;
            this.locateFileButton.Click += new System.EventHandler(this.locateFileButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(87, 23);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(384, 20);
            this.fileTextBox.TabIndex = 1;
            // 
            // sessionGroupBox
            // 
            this.sessionGroupBox.Controls.Add(this.urlRadioButton);
            this.sessionGroupBox.Controls.Add(this.fileRadioButton);
            this.sessionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionGroupBox.Location = new System.Drawing.Point(3, 3);
            this.sessionGroupBox.Name = "sessionGroupBox";
            this.tableLayoutPanel1.SetRowSpan(this.sessionGroupBox, 2);
            this.sessionGroupBox.Size = new System.Drawing.Size(181, 116);
            this.sessionGroupBox.TabIndex = 2;
            this.sessionGroupBox.TabStop = false;
            this.sessionGroupBox.Text = "Choose Session Location";
            // 
            // urlRadioButton
            // 
            this.urlRadioButton.AutoSize = true;
            this.urlRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.urlRadioButton.Location = new System.Drawing.Point(105, 81);
            this.urlRadioButton.Name = "urlRadioButton";
            this.urlRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.urlRadioButton.Size = new System.Drawing.Size(70, 17);
            this.urlRadioButton.TabIndex = 1;
            this.urlRadioButton.Text = "HTTP Url";
            this.urlRadioButton.UseVisualStyleBackColor = true;
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fileRadioButton.Checked = true;
            this.fileRadioButton.Location = new System.Drawing.Point(132, 24);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileRadioButton.Size = new System.Drawing.Size(41, 17);
            this.fileRadioButton.TabIndex = 0;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "File";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            this.fileRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.locateFileButton);
            this.fileGroupBox.Controls.Add(this.fileTextBox);
            this.fileGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileGroupBox.Location = new System.Drawing.Point(190, 3);
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.Size = new System.Drawing.Size(485, 55);
            this.fileGroupBox.TabIndex = 3;
            this.fileGroupBox.TabStop = false;
            this.fileGroupBox.Text = "File Location";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "CSV Files|*.csv|All files|*.*";
            this.openFileDialog1.Title = "Select Session Export";
            // 
            // urlGroupBox
            // 
            this.urlGroupBox.Controls.Add(this.urlTextBox);
            this.urlGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlGroupBox.Enabled = false;
            this.urlGroupBox.Location = new System.Drawing.Point(190, 64);
            this.urlGroupBox.Name = "urlGroupBox";
            this.urlGroupBox.Size = new System.Drawing.Size(485, 55);
            this.urlGroupBox.TabIndex = 4;
            this.urlGroupBox.TabStop = false;
            this.urlGroupBox.Text = "HTTP Url";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(6, 19);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(465, 20);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.Text = "http://";
            // 
            // optionsGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.optionsGroupBox, 2);
            this.optionsGroupBox.Controls.Add(this.label1);
            this.optionsGroupBox.Controls.Add(this.sessionComboBox);
            this.optionsGroupBox.Controls.Add(this.ignoreCheckBox);
            this.optionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGroupBox.Location = new System.Drawing.Point(3, 125);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(672, 52);
            this.optionsGroupBox.TabIndex = 5;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Synchronization Options";
            // 
            // ignoreCheckBox
            // 
            this.ignoreCheckBox.AutoSize = true;
            this.ignoreCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ignoreCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ignoreCheckBox.Name = "ignoreCheckBox";
            this.ignoreCheckBox.Size = new System.Drawing.Size(241, 17);
            this.ignoreCheckBox.TabIndex = 0;
            this.ignoreCheckBox.Text = "Ignore local sessions not present in remote list";
            this.ignoreCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.72861F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.27139F));
            this.tableLayoutPanel1.Controls.Add(this.outputTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.urlGroupBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.optionsGroupBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.fileGroupBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sessionGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(678, 269);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(190, 183);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(485, 83);
            this.outputTextBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.validateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 83);
            this.panel1.TabIndex = 6;
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(6, 30);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(170, 23);
            this.validateButton.TabIndex = 0;
            this.validateButton.Text = "Load and validate session list";
            this.validateButton.UseVisualStyleBackColor = true;
            // 
            // sessionComboBox
            // 
            this.sessionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionComboBox.FormattingEnabled = true;
            this.sessionComboBox.Location = new System.Drawing.Point(389, 17);
            this.sessionComboBox.Name = "sessionComboBox";
            this.sessionComboBox.Size = new System.Drawing.Size(269, 21);
            this.sessionComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Session Template";
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(678, 269);
            this.sessionGroupBox.ResumeLayout(false);
            this.sessionGroupBox.PerformLayout();
            this.fileGroupBox.ResumeLayout(false);
            this.fileGroupBox.PerformLayout();
            this.urlGroupBox.ResumeLayout(false);
            this.urlGroupBox.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button locateFileButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.GroupBox sessionGroupBox;
        private System.Windows.Forms.RadioButton urlRadioButton;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.GroupBox fileGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox urlGroupBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox ignoreCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sessionComboBox;
    }
}
