namespace uk.org.riseley.puttySessionManager.form
{
    partial class UpdateForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkForUpdateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.proxyServerLabel = new System.Windows.Forms.Label();
            this.proxyUsernameLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.proxyPasswordLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.proxyGroupBox = new System.Windows.Forms.GroupBox();
            this.proxyCheckBox = new System.Windows.Forms.CheckBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.urlCheckBox = new System.Windows.Forms.CheckBox();
            this.currVersionLabel = new System.Windows.Forms.Label();
            this.currVersionTextBox = new System.Windows.Forms.TextBox();
            this.availVersionLabel = new System.Windows.Forms.Label();
            this.availVersionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sfLinkLabel = new System.Windows.Forms.LinkLabel();
            this.urlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.proxyGroupBox.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkForUpdateButton
            // 
            this.checkForUpdateButton.Location = new System.Drawing.Point(80, 426);
            this.checkForUpdateButton.Name = "checkForUpdateButton";
            this.checkForUpdateButton.Size = new System.Drawing.Size(114, 23);
            this.checkForUpdateButton.TabIndex = 0;
            this.checkForUpdateButton.Text = "Check For Update";
            this.checkForUpdateButton.UseVisualStyleBackColor = true;
            this.checkForUpdateButton.Click += new System.EventHandler(this.checkForUpdateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(200, 426);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 20);
            this.textBox1.TabIndex = 3;
            // 
            // proxyServerLabel
            // 
            this.proxyServerLabel.AutoSize = true;
            this.proxyServerLabel.Location = new System.Drawing.Point(6, 24);
            this.proxyServerLabel.Name = "proxyServerLabel";
            this.proxyServerLabel.Size = new System.Drawing.Size(99, 13);
            this.proxyServerLabel.TabIndex = 4;
            this.proxyServerLabel.Text = "HTTP Proxy Server";
            // 
            // proxyUsernameLabel
            // 
            this.proxyUsernameLabel.AutoSize = true;
            this.proxyUsernameLabel.Location = new System.Drawing.Point(50, 50);
            this.proxyUsernameLabel.Name = "proxyUsernameLabel";
            this.proxyUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.proxyUsernameLabel.TabIndex = 6;
            this.proxyUsernameLabel.Text = "Username";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(163, 20);
            this.textBox2.TabIndex = 5;
            // 
            // proxyPasswordLabel
            // 
            this.proxyPasswordLabel.AutoSize = true;
            this.proxyPasswordLabel.Location = new System.Drawing.Point(50, 76);
            this.proxyPasswordLabel.Name = "proxyPasswordLabel";
            this.proxyPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.proxyPasswordLabel.TabIndex = 8;
            this.proxyPasswordLabel.Text = "Password";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(111, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(163, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // proxyGroupBox
            // 
            this.proxyGroupBox.Controls.Add(this.proxyServerLabel);
            this.proxyGroupBox.Controls.Add(this.proxyPasswordLabel);
            this.proxyGroupBox.Controls.Add(this.textBox1);
            this.proxyGroupBox.Controls.Add(this.textBox3);
            this.proxyGroupBox.Controls.Add(this.textBox2);
            this.proxyGroupBox.Controls.Add(this.proxyUsernameLabel);
            this.proxyGroupBox.Enabled = false;
            this.proxyGroupBox.Location = new System.Drawing.Point(27, 38);
            this.proxyGroupBox.Name = "proxyGroupBox";
            this.proxyGroupBox.Size = new System.Drawing.Size(288, 109);
            this.proxyGroupBox.TabIndex = 9;
            this.proxyGroupBox.TabStop = false;
            this.proxyGroupBox.Text = "HTTP Proxy Details";
            // 
            // proxyCheckBox
            // 
            this.proxyCheckBox.AutoSize = true;
            this.proxyCheckBox.Location = new System.Drawing.Point(27, 15);
            this.proxyCheckBox.Name = "proxyCheckBox";
            this.proxyCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.proxyCheckBox.Size = new System.Drawing.Size(120, 17);
            this.proxyCheckBox.TabIndex = 10;
            this.proxyCheckBox.Text = "Enable HTTP Proxy";
            this.proxyCheckBox.UseVisualStyleBackColor = true;
            this.proxyCheckBox.CheckedChanged += new System.EventHandler(this.proxyCheckBox_CheckedChanged);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(86, 175);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(229, 20);
            this.urlTextBox.TabIndex = 9;
            this.urlTextBox.Text = "http://puttysm.sourceforge.net/update.txt";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(24, 178);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(56, 13);
            this.urlLabel.TabIndex = 10;
            this.urlLabel.Text = "Update url";
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Controls.Add(this.resultsTextBox);
            this.resultsGroupBox.Location = new System.Drawing.Point(27, 203);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(288, 126);
            this.resultsGroupBox.TabIndex = 11;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Update results";
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTextBox.Location = new System.Drawing.Point(3, 16);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsTextBox.Size = new System.Drawing.Size(282, 107);
            this.resultsTextBox.TabIndex = 0;
            // 
            // urlCheckBox
            // 
            this.urlCheckBox.AutoSize = true;
            this.urlCheckBox.Checked = true;
            this.urlCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.urlCheckBox.Location = new System.Drawing.Point(23, 155);
            this.urlCheckBox.Name = "urlCheckBox";
            this.urlCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.urlCheckBox.Size = new System.Drawing.Size(94, 17);
            this.urlCheckBox.TabIndex = 12;
            this.urlCheckBox.Text = "Use default url";
            this.urlCheckBox.UseVisualStyleBackColor = true;
            this.urlCheckBox.CheckedChanged += new System.EventHandler(this.urlCheckBox_CheckedChanged);
            // 
            // currVersionLabel
            // 
            this.currVersionLabel.AutoSize = true;
            this.currVersionLabel.Location = new System.Drawing.Point(24, 342);
            this.currVersionLabel.Name = "currVersionLabel";
            this.currVersionLabel.Size = new System.Drawing.Size(79, 13);
            this.currVersionLabel.TabIndex = 14;
            this.currVersionLabel.Text = "Current Version";
            // 
            // currVersionTextBox
            // 
            this.currVersionTextBox.Location = new System.Drawing.Point(129, 339);
            this.currVersionTextBox.Name = "currVersionTextBox";
            this.currVersionTextBox.ReadOnly = true;
            this.currVersionTextBox.Size = new System.Drawing.Size(186, 20);
            this.currVersionTextBox.TabIndex = 13;
            // 
            // availVersionLabel
            // 
            this.availVersionLabel.AutoSize = true;
            this.availVersionLabel.Location = new System.Drawing.Point(24, 367);
            this.availVersionLabel.Name = "availVersionLabel";
            this.availVersionLabel.Size = new System.Drawing.Size(88, 13);
            this.availVersionLabel.TabIndex = 16;
            this.availVersionLabel.Text = "Available Version";
            // 
            // availVersionTextBox
            // 
            this.availVersionTextBox.Location = new System.Drawing.Point(129, 364);
            this.availVersionTextBox.Name = "availVersionTextBox";
            this.availVersionTextBox.ReadOnly = true;
            this.availVersionTextBox.Size = new System.Drawing.Size(186, 20);
            this.availVersionTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Update Link";
            // 
            // sfLinkLabel
            // 
            this.sfLinkLabel.Location = new System.Drawing.Point(126, 392);
            this.sfLinkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.sfLinkLabel.Name = "sfLinkLabel";
            this.sfLinkLabel.Size = new System.Drawing.Size(189, 17);
            this.sfLinkLabel.TabIndex = 26;
            this.sfLinkLabel.TabStop = true;
            this.sfLinkLabel.Text = "http://puttysm.sourceforge.net";
            this.sfLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sfLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sfLinkLabel_LinkClicked);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(350, 461);
            this.Controls.Add(this.sfLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availVersionLabel);
            this.Controls.Add(this.availVersionTextBox);
            this.Controls.Add(this.currVersionLabel);
            this.Controls.Add(this.currVersionTextBox);
            this.Controls.Add(this.urlCheckBox);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.proxyCheckBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.proxyGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkForUpdateButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 495);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 495);
            this.Name = "UpdateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Check For Update";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.proxyGroupBox.ResumeLayout(false);
            this.proxyGroupBox.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.resultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkForUpdateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label proxyServerLabel;
        private System.Windows.Forms.Label proxyUsernameLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label proxyPasswordLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox proxyGroupBox;
        private System.Windows.Forms.CheckBox proxyCheckBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.CheckBox urlCheckBox;
        private System.Windows.Forms.Label currVersionLabel;
        private System.Windows.Forms.TextBox currVersionTextBox;
        private System.Windows.Forms.Label availVersionLabel;
        private System.Windows.Forms.TextBox availVersionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel sfLinkLabel;
        private System.Windows.Forms.ToolTip urlToolTip;
    }
}