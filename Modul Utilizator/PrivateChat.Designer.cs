namespace Modul_Utilizator
{
    partial class PrivateChat
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
            this.mButtonSend = new System.Windows.Forms.Button();
            this.mTextBoxMessageReceived = new System.Windows.Forms.RichTextBox();
            this.mTextSendTextBox = new System.Windows.Forms.TextBox();
            this.mButtonIstoric = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mButtonSend
            // 
            this.mButtonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButtonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButtonSend.Location = new System.Drawing.Point(531, 353);
            this.mButtonSend.Margin = new System.Windows.Forms.Padding(4);
            this.mButtonSend.Name = "mButtonSend";
            this.mButtonSend.Size = new System.Drawing.Size(121, 54);
            this.mButtonSend.TabIndex = 9;
            this.mButtonSend.Text = "Send";
            this.mButtonSend.UseVisualStyleBackColor = true;
            this.mButtonSend.Click += new System.EventHandler(this.mButtonSend_Click);
            // 
            // mTextBoxMessageReceived
            // 
            this.mTextBoxMessageReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxMessageReceived.BackColor = System.Drawing.Color.White;
            this.mTextBoxMessageReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.mTextBoxMessageReceived.Location = new System.Drawing.Point(6, 4);
            this.mTextBoxMessageReceived.Margin = new System.Windows.Forms.Padding(4);
            this.mTextBoxMessageReceived.Name = "mTextBoxMessageReceived";
            this.mTextBoxMessageReceived.ReadOnly = true;
            this.mTextBoxMessageReceived.Size = new System.Drawing.Size(755, 341);
            this.mTextBoxMessageReceived.TabIndex = 7;
            this.mTextBoxMessageReceived.Text = "";
            this.mTextBoxMessageReceived.TextChanged += new System.EventHandler(this.mTextBoxMessageReceived_TextChanged);
            // 
            // mTextSendTextBox
            // 
            this.mTextSendTextBox.Location = new System.Drawing.Point(6, 353);
            this.mTextSendTextBox.Multiline = true;
            this.mTextSendTextBox.Name = "mTextSendTextBox";
            this.mTextSendTextBox.Size = new System.Drawing.Size(518, 46);
            this.mTextSendTextBox.TabIndex = 10;
            this.mTextSendTextBox.TextChanged += new System.EventHandler(this.mTextSendTextBox_TextChanged);
            this.mTextSendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTextSendTextBox_KeyDown);
            // 
            // mButtonIstoric
            // 
            this.mButtonIstoric.Cursor = System.Windows.Forms.Cursors.No;
            this.mButtonIstoric.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButtonIstoric.Location = new System.Drawing.Point(659, 353);
            this.mButtonIstoric.Name = "mButtonIstoric";
            this.mButtonIstoric.Size = new System.Drawing.Size(102, 54);
            this.mButtonIstoric.TabIndex = 11;
            this.mButtonIstoric.Text = "Istoric";
            this.mButtonIstoric.UseVisualStyleBackColor = true;
            this.mButtonIstoric.Click += new System.EventHandler(this.mButtonIstoric_Click);
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 412);
            this.Controls.Add(this.mButtonIstoric);
            this.Controls.Add(this.mTextSendTextBox);
            this.Controls.Add(this.mButtonSend);
            this.Controls.Add(this.mTextBoxMessageReceived);
            this.Name = "PrivateChat";
            this.Text = "PrivateChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button mButtonSend;
        public System.Windows.Forms.RichTextBox mTextBoxMessageReceived;
        private System.Windows.Forms.TextBox mTextSendTextBox;
        private System.Windows.Forms.Button mButtonIstoric;
    }
}