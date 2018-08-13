namespace Modul_Utilizator
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
            this.mButtonEnable = new System.Windows.Forms.Button();
            this.mButtonDisable = new System.Windows.Forms.Button();
            this.mTextBoxUserForBan = new System.Windows.Forms.TextBox();
            this.mTextBoxReceiveLogs = new System.Windows.Forms.TextBox();
            this.mButtonLogs = new System.Windows.Forms.Button();
            this.mTextBoxReceiveMessages = new System.Windows.Forms.TextBox();
            this.mTextBoxInput = new System.Windows.Forms.TextBox();
            this.mButtonSend = new System.Windows.Forms.Button();
            this.mListBoxUsersList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // mButtonEnable
            // 
            this.mButtonEnable.Location = new System.Drawing.Point(243, 494);
            this.mButtonEnable.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonEnable.Name = "mButtonEnable";
            this.mButtonEnable.Size = new System.Drawing.Size(84, 28);
            this.mButtonEnable.TabIndex = 21;
            this.mButtonEnable.Text = "Enable";
            this.mButtonEnable.UseVisualStyleBackColor = true;
            // 
            // mButtonDisable
            // 
            this.mButtonDisable.Location = new System.Drawing.Point(156, 494);
            this.mButtonDisable.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonDisable.Name = "mButtonDisable";
            this.mButtonDisable.Size = new System.Drawing.Size(84, 28);
            this.mButtonDisable.TabIndex = 20;
            this.mButtonDisable.Text = "Disable";
            this.mButtonDisable.UseVisualStyleBackColor = true;
            this.mButtonDisable.Click += new System.EventHandler(this.mButtonDisable_Click);
            // 
            // mTextBoxUserForBan
            // 
            this.mTextBoxUserForBan.Location = new System.Drawing.Point(4, 494);
            this.mTextBoxUserForBan.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxUserForBan.Name = "mTextBoxUserForBan";
            this.mTextBoxUserForBan.Size = new System.Drawing.Size(143, 22);
            this.mTextBoxUserForBan.TabIndex = 19;
            this.mTextBoxUserForBan.Text = "Username";
            this.mTextBoxUserForBan.TextChanged += new System.EventHandler(this.mTextBoxUserForBan_TextChanged);
            // 
            // mTextBoxReceiveLogs
            // 
            this.mTextBoxReceiveLogs.Location = new System.Drawing.Point(4, 80);
            this.mTextBoxReceiveLogs.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxReceiveLogs.Multiline = true;
            this.mTextBoxReceiveLogs.Name = "mTextBoxReceiveLogs";
            this.mTextBoxReceiveLogs.ReadOnly = true;
            this.mTextBoxReceiveLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTextBoxReceiveLogs.Size = new System.Drawing.Size(321, 406);
            this.mTextBoxReceiveLogs.TabIndex = 18;
            // 
            // mButtonLogs
            // 
            this.mButtonLogs.Location = new System.Drawing.Point(4, 13);
            this.mButtonLogs.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonLogs.Name = "mButtonLogs";
            this.mButtonLogs.Size = new System.Drawing.Size(323, 59);
            this.mButtonLogs.TabIndex = 14;
            this.mButtonLogs.Text = "Logs";
            this.mButtonLogs.UseVisualStyleBackColor = true;
            // 
            // mTextBoxReceiveMessages
            // 
            this.mTextBoxReceiveMessages.Location = new System.Drawing.Point(335, 13);
            this.mTextBoxReceiveMessages.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxReceiveMessages.Multiline = true;
            this.mTextBoxReceiveMessages.Name = "mTextBoxReceiveMessages";
            this.mTextBoxReceiveMessages.ReadOnly = true;
            this.mTextBoxReceiveMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTextBoxReceiveMessages.Size = new System.Drawing.Size(574, 473);
            this.mTextBoxReceiveMessages.TabIndex = 13;
            // 
            // mTextBoxInput
            // 
            this.mTextBoxInput.Location = new System.Drawing.Point(335, 494);
            this.mTextBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxInput.Name = "mTextBoxInput";
            this.mTextBoxInput.Size = new System.Drawing.Size(574, 22);
            this.mTextBoxInput.TabIndex = 12;
            // 
            // mButtonSend
            // 
            this.mButtonSend.Location = new System.Drawing.Point(917, 491);
            this.mButtonSend.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonSend.Name = "mButtonSend";
            this.mButtonSend.Size = new System.Drawing.Size(145, 28);
            this.mButtonSend.TabIndex = 11;
            this.mButtonSend.Text = "Send";
            this.mButtonSend.UseVisualStyleBackColor = true;
            // 
            // mListBoxUsersList
            // 
            this.mListBoxUsersList.FormattingEnabled = true;
            this.mListBoxUsersList.ItemHeight = 16;
            this.mListBoxUsersList.Location = new System.Drawing.Point(916, 12);
            this.mListBoxUsersList.Name = "mListBoxUsersList";
            this.mListBoxUsersList.Size = new System.Drawing.Size(146, 468);
            this.mListBoxUsersList.TabIndex = 22;
            this.mListBoxUsersList.SelectedIndexChanged += new System.EventHandler(this.mListBoxUsersList_SelectedIndexChanged_1);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 532);
            this.Controls.Add(this.mListBoxUsersList);
            this.Controls.Add(this.mButtonEnable);
            this.Controls.Add(this.mButtonDisable);
            this.Controls.Add(this.mTextBoxUserForBan);
            this.Controls.Add(this.mTextBoxReceiveLogs);
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

        private System.Windows.Forms.Button mButtonEnable;
        private System.Windows.Forms.Button mButtonDisable;
        private System.Windows.Forms.TextBox mTextBoxUserForBan;
        private System.Windows.Forms.TextBox mTextBoxReceiveLogs;
        private System.Windows.Forms.Button mButtonLogs;
        public System.Windows.Forms.TextBox mTextBoxReceiveMessages;
        private System.Windows.Forms.TextBox mTextBoxInput;
        private System.Windows.Forms.Button mButtonSend;
        public System.Windows.Forms.ListBox mListBoxUsersList;
    }
}