namespace Modul_Utilizator
{
    partial class IstoricConversatie
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mButtonShowConversation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(788, 381);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // mButtonShowConversation
            // 
            this.mButtonShowConversation.Location = new System.Drawing.Point(320, 398);
            this.mButtonShowConversation.Name = "mButtonShowConversation";
            this.mButtonShowConversation.Size = new System.Drawing.Size(138, 40);
            this.mButtonShowConversation.TabIndex = 1;
            this.mButtonShowConversation.Text = "Arata conversatia";
            this.mButtonShowConversation.UseVisualStyleBackColor = true;
            this.mButtonShowConversation.Click += new System.EventHandler(this.mButtonShowConversation_Click);
            // 
            // IstoricConversatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mButtonShowConversation);
            this.Controls.Add(this.richTextBox1);
            this.Name = "IstoricConversatie";
            this.Text = "IstoricConversatie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button mButtonShowConversation;
    }
}