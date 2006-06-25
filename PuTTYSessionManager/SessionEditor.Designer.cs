namespace uk.org.riseley.puttySessionManager
{
    partial class SessionEditor
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
            this.sessionEditorControl1 = new uk.org.riseley.puttySessionManager.SessionEditorControl();
            this.SuspendLayout();
            // 
            // sessionEditorControl1
            // 
            this.sessionEditorControl1.ContextMenuVisible = true;
            this.sessionEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.sessionEditorControl1.Name = "sessionEditorControl1";
            this.sessionEditorControl1.Size = new System.Drawing.Size(545, 419);
            this.sessionEditorControl1.TabIndex = 0;
            // 
            // SessionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 419);
            this.Controls.Add(this.sessionEditorControl1);
            this.MinimumSize = new System.Drawing.Size(553, 187);
            this.Name = "SessionEditor";
            this.Text = "Session Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private SessionEditorControl sessionEditorControl1;




    }
}