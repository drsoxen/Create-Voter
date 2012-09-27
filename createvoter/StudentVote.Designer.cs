namespace StudentVote
{
    partial class StudentVote
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
            this.label1 = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.FirstChoice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SecondChoice = new System.Windows.Forms.ComboBox();
            this.ThirdChoice = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(16, 30);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.FullNameTextBox.TabIndex = 1;
            this.FullNameTextBox.TextChanged += new System.EventHandler(this.FullNameTextBox_TextChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(16, 227);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SubmitButton.Size = new System.Drawing.Size(256, 23);
            this.SubmitButton.TabIndex = 6;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // FirstChoice
            // 
            this.FirstChoice.FormattingEnabled = true;
            this.FirstChoice.Location = new System.Drawing.Point(151, 82);
            this.FirstChoice.Name = "FirstChoice";
            this.FirstChoice.Size = new System.Drawing.Size(121, 21);
            this.FirstChoice.TabIndex = 3;
            this.FirstChoice.SelectedIndexChanged += new System.EventHandler(this.FirstChoice_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "First Choice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Second Choice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Third Choice";
            // 
            // SecondChoice
            // 
            this.SecondChoice.FormattingEnabled = true;
            this.SecondChoice.Location = new System.Drawing.Point(151, 113);
            this.SecondChoice.Name = "SecondChoice";
            this.SecondChoice.Size = new System.Drawing.Size(121, 21);
            this.SecondChoice.TabIndex = 4;
            this.SecondChoice.SelectedIndexChanged += new System.EventHandler(this.SecondChoice_SelectedIndexChanged);
            // 
            // ThirdChoice
            // 
            this.ThirdChoice.FormattingEnabled = true;
            this.ThirdChoice.Location = new System.Drawing.Point(151, 144);
            this.ThirdChoice.Name = "ThirdChoice";
            this.ThirdChoice.Size = new System.Drawing.Size(121, 21);
            this.ThirdChoice.TabIndex = 5;
            this.ThirdChoice.SelectedIndexChanged += new System.EventHandler(this.ThirdChoice_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Algonquin Login Name";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(167, 29);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.UserNameTextBox.TabIndex = 2;
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ThirdChoice);
            this.Controls.Add(this.SecondChoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FirstChoice);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Greenlight";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ComboBox FirstChoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SecondChoice;
        private System.Windows.Forms.ComboBox ThirdChoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UserNameTextBox;
    }
}

