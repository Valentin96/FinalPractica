namespace AdministratorForm
{
    partial class Administrator
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
            this.mButtonUnban = new System.Windows.Forms.Button();
            this.mButtonBan = new System.Windows.Forms.Button();
            this.mUserNameBan = new System.Windows.Forms.TextBox();
            this.mTextBoxLogs = new System.Windows.Forms.TextBox();
            this.mButtonLogs = new System.Windows.Forms.Button();
            this.mTextBoxReceiveMessages = new System.Windows.Forms.TextBox();
            this.mTextBoxInput = new System.Windows.Forms.TextBox();
            this.mButtonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mButtonUnban
            // 
            this.mButtonUnban.Location = new System.Drawing.Point(245, 494);
            this.mButtonUnban.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonUnban.Name = "mButtonUnban";
            this.mButtonUnban.Size = new System.Drawing.Size(84, 28);
            this.mButtonUnban.TabIndex = 21;
            this.mButtonUnban.Text = "Enable";
            this.mButtonUnban.UseVisualStyleBackColor = true;
            this.mButtonUnban.Click += new System.EventHandler(this.mButtonUnban_Click);
            // 
            // mButtonBan
            // 
            this.mButtonBan.Location = new System.Drawing.Point(158, 494);
            this.mButtonBan.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonBan.Name = "mButtonBan";
            this.mButtonBan.Size = new System.Drawing.Size(84, 28);
            this.mButtonBan.TabIndex = 20;
            this.mButtonBan.Text = "Disable";
            this.mButtonBan.UseVisualStyleBackColor = true;
            this.mButtonBan.Click += new System.EventHandler(this.mButtonBan_Click);
            // 
            // mUserNameBan
            // 
            this.mUserNameBan.Location = new System.Drawing.Point(6, 494);
            this.mUserNameBan.Margin = new System.Windows.Forms.Padding(4);
            this.mUserNameBan.Name = "mUserNameBan";
            this.mUserNameBan.Size = new System.Drawing.Size(143, 22);
            this.mUserNameBan.TabIndex = 19;
            this.mUserNameBan.Text = "Username";
            this.mUserNameBan.TextChanged += new System.EventHandler(this.mUserNameBan_TextChanged);
            // 
            // mTextBoxLogs
            // 
            this.mTextBoxLogs.Location = new System.Drawing.Point(6, 49);
            this.mTextBoxLogs.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxLogs.Multiline = true;
            this.mTextBoxLogs.Name = "mTextBoxLogs";
            this.mTextBoxLogs.ReadOnly = true;
            this.mTextBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTextBoxLogs.Size = new System.Drawing.Size(321, 437);
            this.mTextBoxLogs.TabIndex = 18;
            this.mTextBoxLogs.TextChanged += new System.EventHandler(this.mTextBoxLogs_TextChanged);
            // 
            // mButtonLogs
            // 
            this.mButtonLogs.Location = new System.Drawing.Point(6, 13);
            this.mButtonLogs.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonLogs.Name = "mButtonLogs";
            this.mButtonLogs.Size = new System.Drawing.Size(323, 28);
            this.mButtonLogs.TabIndex = 14;
            this.mButtonLogs.Text = "Logs";
            this.mButtonLogs.UseVisualStyleBackColor = true;
            this.mButtonLogs.Click += new System.EventHandler(this.mButtonLogs_Click);
            // 
            // mTextBoxReceiveMessages
            // 
            this.mTextBoxReceiveMessages.Location = new System.Drawing.Point(337, 13);
            this.mTextBoxReceiveMessages.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxReceiveMessages.Multiline = true;
            this.mTextBoxReceiveMessages.Name = "mTextBoxReceiveMessages";
            this.mTextBoxReceiveMessages.ReadOnly = true;
            this.mTextBoxReceiveMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTextBoxReceiveMessages.Size = new System.Drawing.Size(703, 473);
            this.mTextBoxReceiveMessages.TabIndex = 13;
            this.mTextBoxReceiveMessages.TextChanged += new System.EventHandler(this.mTextBoxReceiveMessages_TextChanged_1);
            // 
            // mTextBoxInput
            // 
            this.mTextBoxInput.Location = new System.Drawing.Point(337, 494);
            this.mTextBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxInput.Name = "mTextBoxInput";
            this.mTextBoxInput.Size = new System.Drawing.Size(611, 22);
            this.mTextBoxInput.TabIndex = 12;
            this.mTextBoxInput.TextChanged += new System.EventHandler(this.mTextBoxInput_TextChanged_1);
            // 
            // mButtonSend
            // 
            this.mButtonSend.Location = new System.Drawing.Point(957, 494);
            this.mButtonSend.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonSend.Name = "mButtonSend";
            this.mButtonSend.Size = new System.Drawing.Size(84, 28);
            this.mButtonSend.TabIndex = 11;
            this.mButtonSend.Text = "Send";
            this.mButtonSend.UseVisualStyleBackColor = true;
            this.mButtonSend.Click += new System.EventHandler(this.mButtonSend_Click_1);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 536);
            this.Controls.Add(this.mButtonUnban);
            this.Controls.Add(this.mButtonBan);
            this.Controls.Add(this.mUserNameBan);
            this.Controls.Add(this.mTextBoxLogs);
            this.Controls.Add(this.mButtonLogs);
            this.Controls.Add(this.mTextBoxReceiveMessages);
            this.Controls.Add(this.mTextBoxInput);
            this.Controls.Add(this.mButtonSend);
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mButtonUnban;
        private System.Windows.Forms.Button mButtonBan;
        private System.Windows.Forms.TextBox mUserNameBan;
        private System.Windows.Forms.TextBox mTextBoxLogs;
        private System.Windows.Forms.Button mButtonLogs;
        public System.Windows.Forms.TextBox mTextBoxReceiveMessages;
        private System.Windows.Forms.TextBox mTextBoxInput;
        private System.Windows.Forms.Button mButtonSend;
    }
}