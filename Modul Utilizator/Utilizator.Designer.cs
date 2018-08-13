namespace Modul_Utilizator
{
    partial class Utilizator
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
            this.mListBoxUsersList = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mTextBoxReceiveMessages = new System.Windows.Forms.RichTextBox();
            this.mTextBoxInput = new System.Windows.Forms.TextBox();
            this.mButtonSend = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mListBoxUsersList
            // 
            this.mListBoxUsersList.ContextMenuStrip = this.menu;
            this.mListBoxUsersList.FormattingEnabled = true;
            this.mListBoxUsersList.ItemHeight = 16;
            this.mListBoxUsersList.Location = new System.Drawing.Point(810, 24);
            this.mListBoxUsersList.Name = "mListBoxUsersList";
            this.mListBoxUsersList.Size = new System.Drawing.Size(145, 644);
            this.mListBoxUsersList.TabIndex = 0;
            this.mListBoxUsersList.SelectedIndexChanged += new System.EventHandler(this.mListBoxUsersList_SelectedIndexChanged);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateChatToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(158, 28);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.mContextMenuStripUserClick_Opening);
            // 
            // privateChatToolStripMenuItem
            // 
            this.privateChatToolStripMenuItem.Name = "privateChatToolStripMenuItem";
            this.privateChatToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.privateChatToolStripMenuItem.Text = "Private Chat";
            this.privateChatToolStripMenuItem.Click += new System.EventHandler(this.privateChatToolStripMenuItem_Click);
            // 
            // mTextBoxReceiveMessages
            // 
            this.mTextBoxReceiveMessages.Location = new System.Drawing.Point(12, 24);
            this.mTextBoxReceiveMessages.Name = "mTextBoxReceiveMessages";
            this.mTextBoxReceiveMessages.ReadOnly = true;
            this.mTextBoxReceiveMessages.Size = new System.Drawing.Size(781, 527);
            this.mTextBoxReceiveMessages.TabIndex = 1;
            this.mTextBoxReceiveMessages.Text = "";
            this.mTextBoxReceiveMessages.TextChanged += new System.EventHandler(this.mTextBoxReceiveMessages_TextChanged);
            // 
            // mTextBoxInput
            // 
            this.mTextBoxInput.Location = new System.Drawing.Point(13, 557);
            this.mTextBoxInput.Multiline = true;
            this.mTextBoxInput.Name = "mTextBoxInput";
            this.mTextBoxInput.Size = new System.Drawing.Size(687, 111);
            this.mTextBoxInput.TabIndex = 2;
            this.mTextBoxInput.TextChanged += new System.EventHandler(this.mTextBoxInput_TextChanged);
            this.mTextBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTextBoxInput_KeyDown);
            // 
            // mButtonSend
            // 
            this.mButtonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButtonSend.Location = new System.Drawing.Point(706, 557);
            this.mButtonSend.Name = "mButtonSend";
            this.mButtonSend.Size = new System.Drawing.Size(104, 111);
            this.mButtonSend.TabIndex = 3;
            this.mButtonSend.Text = "SEND";
            this.mButtonSend.UseVisualStyleBackColor = true;
            this.mButtonSend.Click += new System.EventHandler(this.mButtonSend_Click);
            // 
            // Utilizator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 685);
            this.Controls.Add(this.mButtonSend);
            this.Controls.Add(this.mTextBoxInput);
            this.Controls.Add(this.mTextBoxReceiveMessages);
            this.Controls.Add(this.mListBoxUsersList);
            this.Name = "Utilizator";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Utilizator_Load);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox mListBoxUsersList;
        public System.Windows.Forms.RichTextBox mTextBoxReceiveMessages;
        public System.Windows.Forms.TextBox mTextBoxInput;
        public System.Windows.Forms.Button mButtonSend;
        public System.Windows.Forms.ContextMenuStrip menu;
        public System.Windows.Forms.ToolStripMenuItem privateChatToolStripMenuItem;
    }
}

