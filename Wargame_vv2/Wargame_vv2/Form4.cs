using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wargame_vv2
{
    public partial class Form4 : Form
    {
        private SoundPlayer suono;
        private bool musica = true;

        public Form4()
        {
            InitializeComponent();

            this.BackColor = Color.OldLace;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1170, 180);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Form1.CaricaImmagine("back.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Form1.CaricaImmagine("viking.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = Form1.CaricaImmagine("yellow.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = Form1.CaricaImmagine("fight.png");
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Image = Form1.CaricaImmagine("sound.png");

            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.Image = Form1.CaricaImmagine("on.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //suono = Form1.CaricaSuono("chiusura_baule.wav");
            //if (suono != null)
            //    suono.Play();

            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (musica)
            {
                pictureBox5.Image = Form1.CaricaImmagine("no-sound.png");
                pictureBox6.Image = Form1.CaricaImmagine("off.png");
                musica = false;
            }
            else
            {
                pictureBox5.Image = Form1.CaricaImmagine("sound.png");
                pictureBox6.Image = Form1.CaricaImmagine("on.png");
                musica = true;
            }
        }
    }
}
