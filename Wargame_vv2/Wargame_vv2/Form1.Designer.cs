namespace Wargame_vv2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox6 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            pictureBox4 = new PictureBox();
            label3 = new Label();
            button2 = new Button();
            pictureBox5 = new PictureBox();
            label4 = new Label();
            pictureBox7 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox6);
            panel1.Location = new Point(45, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(650, 650);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(650, 650);
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1035, 40);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(5, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(41, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 3;
            label1.Text = "Wargame";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(990, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(255, 58);
            label2.Name = "label2";
            label2.Size = new Size(236, 35);
            label2.TabIndex = 5;
            label2.Text = "- unavailable -";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.CadetBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(738, 233);
            button1.Name = "button1";
            button1.Size = new Size(240, 79);
            button1.TabIndex = 6;
            button1.Text = "play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(728, 470);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(268, 278);
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe Script", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(748, 514);
            label3.Name = "label3";
            label3.Size = new Size(230, 190);
            label3.TabIndex = 11;
            label3.Text = resources.GetString("label3.Text");
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.CadetBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(738, 355);
            button2.Name = "button2";
            button2.Size = new Size(240, 79);
            button2.TabIndex = 12;
            button2.Text = "rules";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.MouseEnter += button2_MouseEnter;
            button2.MouseLeave += button2_MouseLeave;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(889, 357);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(75, 75);
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(738, 133);
            label4.Name = "label4";
            label4.Size = new Size(45, 59);
            label4.TabIndex = 13;
            label4.Text = "-";
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(903, 124);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(75, 75);
            pictureBox7.TabIndex = 14;
            pictureBox7.TabStop = false;
            pictureBox7.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 800);
            Controls.Add(pictureBox7);
            Controls.Add(label4);
            Controls.Add(pictureBox5);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(pictureBox4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Wargame";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private PictureBox pictureBox3;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private PictureBox pictureBox4;
        private Label label3;
        private Button button2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Label label4;
        private PictureBox pictureBox7;
    }
}
