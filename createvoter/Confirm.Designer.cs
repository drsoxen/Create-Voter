namespace StudentVote
{
    partial class Confirm
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
            this.NameAndJunk = new System.Windows.Forms.Label();
            this.ConnectAndSend = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.IPAdressText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameAndJunk
            // 
            this.NameAndJunk.AutoSize = true;
            this.NameAndJunk.Location = new System.Drawing.Point(9, 9);
            this.NameAndJunk.Name = "NameAndJunk";
            this.NameAndJunk.Size = new System.Drawing.Size(82, 13);
            this.NameAndJunk.TabIndex = 0;
            this.NameAndJunk.Text = "Name and Junk";
            // 
            // ConnectAndSend
            // 
            this.ConnectAndSend.Location = new System.Drawing.Point(12, 187);
            this.ConnectAndSend.Name = "ConnectAndSend";
            this.ConnectAndSend.Size = new System.Drawing.Size(101, 41);
            this.ConnectAndSend.TabIndex = 2;
            this.ConnectAndSend.Text = "Connect and Send";
            this.ConnectAndSend.UseVisualStyleBackColor = true;
            this.ConnectAndSend.Click += new System.EventHandler(this.ConectAndSend_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(170, 187);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 41);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // IPAdressText
            // 
            this.IPAdressText.AutoSize = true;
            this.IPAdressText.Location = new System.Drawing.Point(9, 240);
            this.IPAdressText.Name = "IPAdressText";
            this.IPAdressText.Size = new System.Drawing.Size(17, 13);
            this.IPAdressText.TabIndex = 3;
            this.IPAdressText.Text = "IP";
            this.IPAdressText.Click += new System.EventHandler(this.IPAdressText_Click);
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.IPAdressText);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ConnectAndSend);
            this.Controls.Add(this.NameAndJunk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Confirm";
            this.Text = "Greenlight";
            this.Activated += new System.EventHandler(this.Confirm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameAndJunk;
        private System.Windows.Forms.Button ConnectAndSend;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label IPAdressText;
    }
}

