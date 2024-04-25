namespace Wargame_vv2
{
    partial class ResultBox
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
            messageLabel = new Label();
            replayPictureBox = new PictureBox();
            exitPictureBox = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)replayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exitPictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // messageLabel
            // 
            messageLabel.BackColor = Color.OldLace;
            messageLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.ForeColor = Color.Sienna;
            messageLabel.Location = new Point(0, 0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(256, 52);
            messageLabel.TabIndex = 5;
            messageLabel.Text = "messageLabel";
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // replayPictureBox
            // 
            replayPictureBox.Location = new Point(40, 78);
            replayPictureBox.Name = "replayPictureBox";
            replayPictureBox.Size = new Size(65, 65);
            replayPictureBox.TabIndex = 6;
            replayPictureBox.TabStop = false;
            replayPictureBox.Click += replayPictureBox_Click;
            // 
            // exitPictureBox
            // 
            exitPictureBox.Location = new Point(153, 78);
            exitPictureBox.Name = "exitPictureBox";
            exitPictureBox.Size = new Size(65, 65);
            exitPictureBox.TabIndex = 7;
            exitPictureBox.TabStop = false;
            exitPictureBox.Click += exitPictureBox_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.OldLace;
            panel1.Controls.Add(messageLabel);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 52);
            panel1.TabIndex = 8;
            // 
            // ResultBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            ClientSize = new Size(256, 165);
            Controls.Add(exitPictureBox);
            Controls.Add(replayPictureBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResultBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ResultBox";
            Load += ResultBox_Load;
            ((System.ComponentModel.ISupportInitialize)replayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)exitPictureBox).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label messageLabel;
        private PictureBox replayPictureBox;
        private PictureBox exitPictureBox;
        private Panel panel1;
    }
}