namespace MailSendForReset
{
    partial class MailForResetPass
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
            this.mTextBoxMailName = new System.Windows.Forms.TextBox();
            this.mLabelMailName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mButtonSend
            // 
            this.mButtonSend.Location = new System.Drawing.Point(425, 207);
            this.mButtonSend.Name = "mButtonSend";
            this.mButtonSend.Size = new System.Drawing.Size(100, 60);
            this.mButtonSend.TabIndex = 0;
            this.mButtonSend.Text = "Ok";
            this.mButtonSend.UseVisualStyleBackColor = true;
            this.mButtonSend.Click += new System.EventHandler(this.mButtonSend_Click);
            // 
            // mTextBoxMailName
            // 
            this.mTextBoxMailName.Location = new System.Drawing.Point(351, 139);
            this.mTextBoxMailName.Name = "mTextBoxMailName";
            this.mTextBoxMailName.Size = new System.Drawing.Size(239, 22);
            this.mTextBoxMailName.TabIndex = 1;
            this.mTextBoxMailName.TextChanged += new System.EventHandler(this.mTextBoxMailName_TextChanged);
            // 
            // mLabelMailName
            // 
            this.mLabelMailName.AutoSize = true;
            this.mLabelMailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLabelMailName.Location = new System.Drawing.Point(88, 132);
            this.mLabelMailName.Name = "mLabelMailName";
            this.mLabelMailName.Size = new System.Drawing.Size(188, 29);
            this.mLabelMailName.TabIndex = 2;
            this.mLabelMailName.Text = "Scrie aici mailul:";
            // 
            // MailForResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mLabelMailName);
            this.Controls.Add(this.mTextBoxMailName);
            this.Controls.Add(this.mButtonSend);
            this.Name = "MailForResetPass";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mButtonSend;
        private System.Windows.Forms.TextBox mTextBoxMailName;
        private System.Windows.Forms.Label mLabelMailName;
    }
}

