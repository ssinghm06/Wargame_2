namespace Wargame_vv2
{
    partial class MessageCustomYesNo
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
            panel1 = new Panel();
            messageLabel = new Label();
            closePictureBox = new PictureBox();
            noPictureBox = new PictureBox();
            yesPictureBox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yesPictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGoldenrod;
            panel1.Controls.Add(messageLabel);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 35);
            panel1.TabIndex = 0;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(3, 5);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(139, 23);
            messageLabel.TabIndex = 4;
            messageLabel.Text = "messageLabel";
            // 
            // closePictureBox
            // 
            closePictureBox.BackColor = Color.DarkGoldenrod;
            closePictureBox.Location = new Point(225, 5);
            closePictureBox.Name = "closePictureBox";
            closePictureBox.Size = new Size(25, 25);
            closePictureBox.TabIndex = 1;
            closePictureBox.TabStop = false;
            closePictureBox.Click += closePictureBox_Click;
            // 
            // noPictureBox
            // 
            noPictureBox.Location = new Point(38, 67);
            noPictureBox.Name = "noPictureBox";
            noPictureBox.Size = new Size(65, 65);
            noPictureBox.TabIndex = 2;
            noPictureBox.TabStop = false;
            noPictureBox.Click += noPictureBox_Click;
            // 
            // yesPictureBox
            // 
            yesPictureBox.Location = new Point(152, 67);
            yesPictureBox.Name = "yesPictureBox";
            yesPictureBox.Size = new Size(65, 65);
            yesPictureBox.TabIndex = 3;
            yesPictureBox.TabStop = false;
            yesPictureBox.Click += yesPictureBox_Click;
            // 
            // MessageCustomYesNo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            ClientSize = new Size(256, 165);
            Controls.Add(yesPictureBox);
            Controls.Add(noPictureBox);
            Controls.Add(closePictureBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MessageCustomYesNo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MessageCustomYesNo";
            Load += MessageCustomYesNo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)noPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)yesPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox closePictureBox;
        private Label messageLabel;
        private PictureBox noPictureBox;
        private PictureBox yesPictureBox;
    }
}