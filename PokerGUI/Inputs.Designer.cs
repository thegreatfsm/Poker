namespace PokerGUI
{
    partial class Inputs
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
            this.playersLabel = new System.Windows.Forms.Label();
            this.playersText = new System.Windows.Forms.TextBox();
            this.bankRollText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(12, 54);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(112, 33);
            this.playersLabel.TabIndex = 0;
            this.playersLabel.Text = "Players";
            // 
            // playersText
            // 
            this.playersText.Location = new System.Drawing.Point(110, 51);
            this.playersText.Name = "playersText";
            this.playersText.Size = new System.Drawing.Size(281, 31);
            this.playersText.TabIndex = 1;
            // 
            // bankRollText
            // 
            this.bankRollText.Location = new System.Drawing.Point(110, 101);
            this.bankRollText.Name = "bankRollText";
            this.bankRollText.Size = new System.Drawing.Size(281, 31);
            this.bankRollText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bankrolls";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(41, 178);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(328, 68);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Inputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 284);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.bankRollText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playersText);
            this.Controls.Add(this.playersLabel);
            this.Name = "Inputs";
            this.Text = "Inputs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.TextBox playersText;
        private System.Windows.Forms.TextBox bankRollText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startButton;
    }
}