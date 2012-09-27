namespace GroupSelector
{
    partial class MainForm
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
            this.MainForm_GroupSizeCounter = new System.Windows.Forms.NumericUpDown();
            this.MainForm_CreateGroupsButton = new System.Windows.Forms.Button();
            this.MainForm_CancelButton = new System.Windows.Forms.Button();
            this.MainForm_LaunchBallotsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_GroupSizeCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Size";
            // 
            // MainForm_GroupSizeCounter
            // 
            this.MainForm_GroupSizeCounter.Location = new System.Drawing.Point(15, 90);
            this.MainForm_GroupSizeCounter.Name = "MainForm_GroupSizeCounter";
            this.MainForm_GroupSizeCounter.Size = new System.Drawing.Size(59, 20);
            this.MainForm_GroupSizeCounter.TabIndex = 1;
            this.MainForm_GroupSizeCounter.ValueChanged += new System.EventHandler(this.MainForm_GroupSizeCounter_ValueChanged);
            // 
            // MainForm_CreateGroupsButton
            // 
            this.MainForm_CreateGroupsButton.Location = new System.Drawing.Point(15, 116);
            this.MainForm_CreateGroupsButton.Name = "MainForm_CreateGroupsButton";
            this.MainForm_CreateGroupsButton.Size = new System.Drawing.Size(139, 36);
            this.MainForm_CreateGroupsButton.TabIndex = 2;
            this.MainForm_CreateGroupsButton.Text = "Create Groups";
            this.MainForm_CreateGroupsButton.UseVisualStyleBackColor = true;
            this.MainForm_CreateGroupsButton.Click += new System.EventHandler(this.MainForm_CreateButton_Click);
            // 
            // MainForm_CancelButton
            // 
            this.MainForm_CancelButton.Location = new System.Drawing.Point(15, 182);
            this.MainForm_CancelButton.Name = "MainForm_CancelButton";
            this.MainForm_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.MainForm_CancelButton.TabIndex = 3;
            this.MainForm_CancelButton.Text = "Cancel";
            this.MainForm_CancelButton.UseVisualStyleBackColor = true;
            this.MainForm_CancelButton.Click += new System.EventHandler(this.MainForm_CancelButton_Click);
            // 
            // MainForm_LaunchBallotsButton
            // 
            this.MainForm_LaunchBallotsButton.Location = new System.Drawing.Point(15, 12);
            this.MainForm_LaunchBallotsButton.Name = "MainForm_LaunchBallotsButton";
            this.MainForm_LaunchBallotsButton.Size = new System.Drawing.Size(139, 33);
            this.MainForm_LaunchBallotsButton.TabIndex = 4;
            this.MainForm_LaunchBallotsButton.Text = "Launch Ballots";
            this.MainForm_LaunchBallotsButton.UseVisualStyleBackColor = true;
            this.MainForm_LaunchBallotsButton.Click += new System.EventHandler(this.MainForm_LaunchBallotsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 226);
            this.Controls.Add(this.MainForm_LaunchBallotsButton);
            this.Controls.Add(this.MainForm_CancelButton);
            this.Controls.Add(this.MainForm_CreateGroupsButton);
            this.Controls.Add(this.MainForm_GroupSizeCounter);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Group Creator";
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_GroupSizeCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MainForm_GroupSizeCounter;
        private System.Windows.Forms.Button MainForm_CreateGroupsButton;
        private System.Windows.Forms.Button MainForm_CancelButton;
        private System.Windows.Forms.Button MainForm_LaunchBallotsButton;
    }
}

