namespace TicTacToe
{
    partial class Form1
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPlayer.SuspendLayout();
            this.panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBoard.Location = new System.Drawing.Point(30, 30);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(843, 847);
            this.pnlBoard.TabIndex = 0;
            // 
            // panelPlayer
            // 
            this.panelPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlayer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPlayer.Controls.Add(this.pictureBox1);
            this.panelPlayer.Controls.Add(this.label1);
            this.panelPlayer.Location = new System.Drawing.Point(881, 30);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(296, 604);
            this.panelPlayer.TabIndex = 1;
            // 
            // panelHistory
            // 
            this.panelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHistory.Controls.Add(this.label3);
            this.panelHistory.Controls.Add(this.label2);
            this.panelHistory.Location = new System.Drawing.Point(879, 663);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(297, 213);
            this.panelHistory.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rule: 4 line to win";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Menu;
            this.label2.Font = new System.Drawing.Font("PMingLiU-ExtB", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Undo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("PMingLiU-ExtB", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Redo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::TicTacToe.Properties.Resources.stuimages;
            this.pictureBox1.Location = new System.Drawing.Point(23, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 889);
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.pnlBoard);
            this.Name = "Form1";
            this.Text = "TIc Tac Toe";
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            this.panelHistory.ResumeLayout(false);
            this.panelHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

