namespace PokerGUI
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
            this.foldButton = new System.Windows.Forms.Button();
            this.betButton = new System.Windows.Forms.Button();
            this.betTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.communityGroupBox = new System.Windows.Forms.GroupBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.playersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // handGroupBox
            // 
            this.handGroupBox.Location = new System.Drawing.Point(3, 517);
            this.handGroupBox.Name = "handGroupBox";
            this.handGroupBox.Size = new System.Drawing.Size(1040, 275);
            this.handGroupBox.TabIndex = 0;
            this.handGroupBox.TabStop = false;
            this.handGroupBox.Text = "Hand";
            // 
            // foldButton
            // 
            this.foldButton.Location = new System.Drawing.Point(842, 442);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(201, 69);
            this.foldButton.TabIndex = 1;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = true;
            // 
            // betButton
            // 
            this.betButton.Location = new System.Drawing.Point(626, 442);
            this.betButton.Name = "betButton";
            this.betButton.Size = new System.Drawing.Size(201, 69);
            this.betButton.TabIndex = 2;
            this.betButton.Text = "Bet";
            this.betButton.UseVisualStyleBackColor = true;
            // 
            // betTextBox
            // 
            this.betTextBox.Location = new System.Drawing.Point(626, 410);
            this.betTextBox.Name = "betTextBox";
            this.betTextBox.Size = new System.Drawing.Size(201, 26);
            this.betTextBox.TabIndex = 3;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(556, 413);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(69, 20);
            this.amountLabel.TabIndex = 4;
            this.amountLabel.Text = "Amount:";
            // 
            // communityGroupBox
            // 
            this.communityGroupBox.Location = new System.Drawing.Point(0, 0);
            this.communityGroupBox.Name = "communityGroupBox";
            this.communityGroupBox.Size = new System.Drawing.Size(1043, 268);
            this.communityGroupBox.TabIndex = 5;
            this.communityGroupBox.TabStop = false;
            this.communityGroupBox.Text = "Community";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(842, 364);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(201, 69);
            this.checkButton.TabIndex = 6;
            this.checkButton.Text = "Check/Match";
            this.checkButton.UseVisualStyleBackColor = true;
            // 
            // playersListBox
            // 
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 20;
            this.playersListBox.Location = new System.Drawing.Point(12, 274);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(324, 244);
            this.playersListBox.TabIndex = 7;
            // 
            // PokerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 804);
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
    }
}

