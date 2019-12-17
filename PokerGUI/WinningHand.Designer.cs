namespace PokerGUI
{
    partial class winningHandForm
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
            this.winningPlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.winningCard5 = new System.Windows.Forms.PictureBox();
            this.winningCard4 = new System.Windows.Forms.PictureBox();
            this.winningCard3 = new System.Windows.Forms.PictureBox();
            this.winningCard2 = new System.Windows.Forms.PictureBox();
            this.winningCard1 = new System.Windows.Forms.PictureBox();
            this.potSizeLabel = new System.Windows.Forms.Label();
            this.winningPlayerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // winningPlayerGroupBox
            // 
            this.winningPlayerGroupBox.Controls.Add(this.winningCard5);
            this.winningPlayerGroupBox.Controls.Add(this.winningCard4);
            this.winningPlayerGroupBox.Controls.Add(this.winningCard3);
            this.winningPlayerGroupBox.Controls.Add(this.winningCard2);
            this.winningPlayerGroupBox.Controls.Add(this.winningCard1);
            this.winningPlayerGroupBox.Location = new System.Drawing.Point(13, 38);
            this.winningPlayerGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.winningPlayerGroupBox.MaximumSize = new System.Drawing.Size(1391, 403);
            this.winningPlayerGroupBox.MinimumSize = new System.Drawing.Size(1391, 403);
            this.winningPlayerGroupBox.Name = "winningPlayerGroupBox";
            this.winningPlayerGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.winningPlayerGroupBox.Size = new System.Drawing.Size(1391, 403);
            this.winningPlayerGroupBox.TabIndex = 6;
            this.winningPlayerGroupBox.TabStop = false;
            this.winningPlayerGroupBox.Text = "Player:";
            // 
            // winningCard5
            // 
            this.winningCard5.Location = new System.Drawing.Point(1100, 60);
            this.winningCard5.Name = "winningCard5";
            this.winningCard5.Size = new System.Drawing.Size(207, 309);
            this.winningCard5.TabIndex = 5;
            this.winningCard5.TabStop = false;
            // 
            // winningCard4
            // 
            this.winningCard4.Location = new System.Drawing.Point(856, 60);
            this.winningCard4.Name = "winningCard4";
            this.winningCard4.Size = new System.Drawing.Size(207, 309);
            this.winningCard4.TabIndex = 4;
            this.winningCard4.TabStop = false;
            // 
            // winningCard3
            // 
            this.winningCard3.Location = new System.Drawing.Point(605, 60);
            this.winningCard3.Name = "winningCard3";
            this.winningCard3.Size = new System.Drawing.Size(207, 309);
            this.winningCard3.TabIndex = 3;
            this.winningCard3.TabStop = false;
            // 
            // winningCard2
            // 
            this.winningCard2.Location = new System.Drawing.Point(348, 60);
            this.winningCard2.Name = "winningCard2";
            this.winningCard2.Size = new System.Drawing.Size(207, 309);
            this.winningCard2.TabIndex = 2;
            this.winningCard2.TabStop = false;
            // 
            // winningCard1
            // 
            this.winningCard1.Location = new System.Drawing.Point(90, 60);
            this.winningCard1.Name = "winningCard1";
            this.winningCard1.Size = new System.Drawing.Size(207, 309);
            this.winningCard1.TabIndex = 1;
            this.winningCard1.TabStop = false;
            // 
            // potSizeLabel
            // 
            this.potSizeLabel.AutoSize = true;
            this.potSizeLabel.Location = new System.Drawing.Point(20, 9);
            this.potSizeLabel.Name = "potSizeLabel";
            this.potSizeLabel.Size = new System.Drawing.Size(98, 25);
            this.potSizeLabel.TabIndex = 8;
            this.potSizeLabel.Text = "Pot Size:";
            // 
            // winningHandForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 498);
            this.Controls.Add(this.potSizeLabel);
            this.Controls.Add(this.winningPlayerGroupBox);
            this.Name = "winningHandForm";
            this.Text = "Winning Hand";
            this.winningPlayerGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winningCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winningCard1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox winningPlayerGroupBox;
        private System.Windows.Forms.PictureBox winningCard5;
        private System.Windows.Forms.PictureBox winningCard4;
        private System.Windows.Forms.PictureBox winningCard3;
        private System.Windows.Forms.PictureBox winningCard2;
        private System.Windows.Forms.PictureBox winningCard1;
        private System.Windows.Forms.Label potSizeLabel;
    }
}