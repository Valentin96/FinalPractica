namespace MailForResetPassword
{
    partial class MailSendReset
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
            this.mButtonMail = new System.Windows.Forms.Button();
            this.mLabelMailName = new System.Windows.Forms.Label();
            this.mTextBoxMail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mButtonMail
            // 
            this.mButtonMail.Location = new System.Drawing.Point(320, 237);
            this.mButtonMail.Name = "mButtonMail";
            this.mButtonMail.Size = new System.Drawing.Size(172, 53);
            this.mButtonMail.TabIndex = 0;
            this.mButtonMail.Text = "Ok";
            this.mButtonMail.UseVisualStyleBackColor = true;
            // 
            // mLabelMailName
            // 
            this.mLabelMailName.AutoSize = true;
            this.mLabelMailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLabelMailName.Location = new System.Drawing.Point(99, 106);
            this.mLabelMailName.Name = "mLabelMailName";
            this.mLabelMailName.Size = new System.Drawing.Size(183, 29);
            this.mLabelMailName.TabIndex = 1;
            this.mLabelMailName.Text = "Scrie mailul tau:";
            // 
            // mTextBoxMail
            // 
            this.mTextBoxMail.Location = new System.Drawing.Point(320, 113);
            this.mTextBoxMail.Name = "mTextBoxMail";
            this.mTextBoxMail.Size = new System.Drawing.Size(305, 22);
            this.mTextBoxMail.TabIndex = 2;
            this.mTextBoxMail.TextChanged += new System.EventHandler(this.mTextBoxMail_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mTextBoxMail);
            this.Controls.Add(this.mLabelMailName);
            this.Controls.Add(this.mButtonMail);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mButtonMail;
        private System.Windows.Forms.Label mLabelMailName;
        private System.Windows.Forms.TextBox mTextBoxMail;
    }
}

