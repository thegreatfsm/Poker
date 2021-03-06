﻿namespace PokerGUI
{
    partial class PokerGUI
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
            this.handGroupBox = new System.Windows.Forms.GroupBox();
            this.playerCard2 = new System.Windows.Forms.PictureBox();
            this.playerCard1 = new System.Windows.Forms.PictureBox();
            this.foldButton = new System.Windows.Forms.Button();
            this.betButton = new System.Windows.Forms.Button();
            this.betTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.communityGroupBox = new System.Windows.Forms.GroupBox();
            this.communityCard5 = new System.Windows.Forms.PictureBox();
            this.communityCard4 = new System.Windows.Forms.PictureBox();
            this.communityCard3 = new System.Windows.Forms.PictureBox();
            this.communityCard2 = new System.Windows.Forms.PictureBox();
            this.communityCard1 = new System.Windows.Forms.PictureBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.playersListBox = new System.Windows.Forms.ListBox();
            this.handGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard1)).BeginInit();
            this.communityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // handGroupBox
            // 
            this.handGroupBox.Controls.Add(this.playerCard2);
            this.handGroupBox.Controls.Add(this.playerCard1);
            this.handGroupBox.Location = new System.Drawing.Point(88, 612);
            this.handGroupBox.Name = "handGroupBox";
            this.handGroupBox.Size = new System.Drawing.Size(1040, 275);
            this.handGroupBox.TabIndex = 0;
            this.handGroupBox.TabStop = false;
            this.handGroupBox.Text = "Hand";
            // 
            // playerCard2
            // 
            this.playerCard2.Location = new System.Drawing.Point(567, 21);
            this.playerCard2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerCard2.Name = "playerCard2";
            this.playerCard2.Size = new System.Drawing.Size(155, 246);
            this.playerCard2.TabIndex = 1;
            this.playerCard2.TabStop = false;
            // 
            // playerCard1
            // 
            this.playerCard1.Location = new System.Drawing.Point(336, 21);
            this.playerCard1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerCard1.Name = "playerCard1";
            this.playerCard1.Size = new System.Drawing.Size(155, 246);
            this.playerCard1.TabIndex = 0;
            this.playerCard1.TabStop = false;
            // 
            // foldButton
            // 
            this.foldButton.Location = new System.Drawing.Point(927, 537);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(201, 69);
            this.foldButton.TabIndex = 1;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = true;
            this.foldButton.Click += new System.EventHandler(this.FoldButton_Click);
            // 
            // betButton
            // 
            this.betButton.Location = new System.Drawing.Point(711, 537);
            this.betButton.Name = "betButton";
            this.betButton.Size = new System.Drawing.Size(201, 69);
            this.betButton.TabIndex = 2;
            this.betButton.Text = "Bet";
            this.betButton.UseVisualStyleBackColor = true;
            this.betButton.Click += new System.EventHandler(this.BetButton_Click);
            // 
            // betTextBox
            // 
            this.betTextBox.Location = new System.Drawing.Point(711, 505);
            this.betTextBox.Name = "betTextBox";
            this.betTextBox.Size = new System.Drawing.Size(201, 26);
            this.betTextBox.TabIndex = 3;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(641, 508);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(69, 20);
            this.amountLabel.TabIndex = 4;
            this.amountLabel.Text = "Amount:";
            // 
            // communityGroupBox
            // 
            this.communityGroupBox.Controls.Add(this.communityCard5);
            this.communityGroupBox.Controls.Add(this.communityCard4);
            this.communityGroupBox.Controls.Add(this.communityCard3);
            this.communityGroupBox.Controls.Add(this.communityCard2);
            this.communityGroupBox.Controls.Add(this.communityCard1);
            this.communityGroupBox.Location = new System.Drawing.Point(85, 0);
            this.communityGroupBox.Name = "communityGroupBox";
            this.communityGroupBox.Size = new System.Drawing.Size(1043, 268);
            this.communityGroupBox.TabIndex = 5;
            this.communityGroupBox.TabStop = false;
            this.communityGroupBox.Text = "Community";
            // 
            // communityCard5
            // 
            this.communityCard5.Location = new System.Drawing.Point(827, 15);
            this.communityCard5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.communityCard5.Name = "communityCard5";
            this.communityCard5.Size = new System.Drawing.Size(155, 247);
            this.communityCard5.TabIndex = 5;
            this.communityCard5.TabStop = false;
            // 
            // communityCard4
            // 
            this.communityCard4.Location = new System.Drawing.Point(644, 15);
            this.communityCard4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.communityCard4.Name = "communityCard4";
            this.communityCard4.Size = new System.Drawing.Size(155, 247);
            this.communityCard4.TabIndex = 4;
            this.communityCard4.TabStop = false;
            // 
            // communityCard3
            // 
            this.communityCard3.Location = new System.Drawing.Point(456, 15);
            this.communityCard3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.communityCard3.Name = "communityCard3";
            this.communityCard3.Size = new System.Drawing.Size(155, 247);
            this.communityCard3.TabIndex = 3;
            this.communityCard3.TabStop = false;
            // 
            // communityCard2
            // 
            this.communityCard2.Location = new System.Drawing.Point(263, 15);
            this.communityCard2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.communityCard2.Name = "communityCard2";
            this.communityCard2.Size = new System.Drawing.Size(155, 247);
            this.communityCard2.TabIndex = 2;
            this.communityCard2.TabStop = false;
            // 
            // communityCard1
            // 
            this.communityCard1.Location = new System.Drawing.Point(70, 15);
            this.communityCard1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.communityCard1.Name = "communityCard1";
            this.communityCard1.Size = new System.Drawing.Size(155, 247);
            this.communityCard1.TabIndex = 1;
            this.communityCard1.TabStop = false;
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(927, 459);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(201, 69);
            this.checkButton.TabIndex = 6;
            this.checkButton.Text = "Check/Match";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // playersListBox
            // 
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 20;
            this.playersListBox.Location = new System.Drawing.Point(12, 274);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(623, 324);
            this.playersListBox.TabIndex = 7;
            // 
            // PokerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 899);
            this.Controls.Add(this.playersListBox);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.communityGroupBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.betTextBox);
            this.Controls.Add(this.betButton);
            this.Controls.Add(this.foldButton);
            this.Controls.Add(this.handGroupBox);
            this.Name = "PokerGUI";
            this.Text = "Poker";
            this.Load += new System.EventHandler(this.PokerGUI_Load);
            this.handGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard1)).EndInit();
            this.communityGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.communityCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.communityCard1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.GroupBox handGroupBox;
        private System.Windows.Forms.Button foldButton;
        private System.Windows.Forms.Button betButton;
        private System.Windows.Forms.TextBox betTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.GroupBox communityGroupBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.ListBox playersListBox;
        private System.Windows.Forms.PictureBox playerCard1;
        private System.Windows.Forms.PictureBox playerCard2;
        private System.Windows.Forms.PictureBox communityCard5;
        private System.Windows.Forms.PictureBox communityCard4;
        private System.Windows.Forms.PictureBox communityCard3;
        private System.Windows.Forms.PictureBox communityCard2;
        private System.Windows.Forms.PictureBox communityCard1;
    }
}

