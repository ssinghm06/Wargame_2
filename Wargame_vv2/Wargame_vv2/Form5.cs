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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            this.BackColor = Color.OldLace;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1170, 180);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Form1.CaricaImmagine("regole1.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Form1.CaricaImmagine("back.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = Form1.CaricaImmagine("regole3.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = Form1.CaricaImmagine("regole2.png");
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Image = Form1.CaricaImmagine("regole4.png");
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.Image = Form1.CaricaImmagine("regole5.png");
            pictureBox7.BackColor = Color.Black;
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.Image = Form1.CaricaImmagine("winner.png");
            pictureBox9.BackColor = Color.Black;
            pictureBox14.BackColor = Color.Black;
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.Image = Form1.CaricaImmagine("guerriero.png");
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.Image = Form1.CaricaImmagine("cavaliere.png");
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox12.Image = Form1.CaricaImmagine("arciere.png");
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.Image = Form1.CaricaImmagine("mago.png");
            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.Image = Form1.CaricaImmagine("guerriero.png");
            pictureBox16.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox16.Image = Form1.CaricaImmagine("cavaliere.png");
            pictureBox17.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox17.Image = Form1.CaricaImmagine("arciere.png");
            pictureBox18.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox18.Image = Form1.CaricaImmagine("mago.png");

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
