using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wargame_vv2
{
    public partial class Form2 : Form
    {
        private int progresso = 0;

        Form1 form1 = new Form1();

        public Form2()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = form1.CaricaImmagine("sfondo.png");

            this.BackColor = Color.CadetBlue;

            // un po di grafica
            pictureBox1.BackColor = Color.BurlyWood;
            pictureBox2.BackColor = Color.BurlyWood;
            pictureBox3.BackColor = Color.BurlyWood;
            pictureBox4.BackColor = Color.Transparent;

            label1.BackColor = Color.BurlyWood;
            label1.ForeColor = Color.DarkSlateGray;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = form1.CaricaImmagine("war.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = form1.CaricaImmagine("flag.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = form1.CaricaImmagine("random.gif");

            label3.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Black;

            pictureBox4.BackColor = Color.Transparent;

            panel2.BackColor = Color.Coral;
            panel2.Width = 0;

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            form1.customMessageBox = form1.CustomMessageBox();

            DialogResult risposta = form1.customMessageBox.ShowDialog();

            if (risposta == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                timer1.Start();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            progresso += r.Next(1, 21);

            if (progresso > 100)
                progresso = 100;

            //progressBar1.Value = secondo;
            int panelWidth = (int)((float)progresso / 100 * panel1.Width);

            panelWidth = Math.Min(panelWidth, panel1.Width);
            panel2.Width = panelWidth;

            label2.Text = progresso.ToString() + "%";

            if (progresso >= 100)
            {
                timer1.Stop();
                this.Hide();

                Form1 Gioco = new Form1();
                Gioco.Show();
            }
        }
    }
}
