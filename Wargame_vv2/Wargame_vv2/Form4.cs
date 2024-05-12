using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wargame_vv2
{
    public partial class Form4 : Form
    {
        private bool musica = true;
        private static bool italiano = true;
        public static bool Italiano
        {
            get { return italiano; }
        }

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
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackgroundImage = Form1.CaricaImmagine("inglese.png");
            pictureBox9.BackColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AudioPlayer.CaricaAudio("closeChest.wav");
            AudioPlayer.PlayAudio();

            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (musica)
            {
                pictureBox5.Image = Form1.CaricaImmagine("no-sound.png");
                pictureBox6.Image = Form1.CaricaImmagine("off.png");
                musica = false;

                AudioPlayer.Mute();
            }
            else
            {
                pictureBox5.Image = Form1.CaricaImmagine("sound.png");
                pictureBox6.Image = Form1.CaricaImmagine("on.png");
                musica = true;

                AudioPlayer.Mute();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (italiano)
            {
                button1.BackgroundImage = Form1.CaricaImmagine("italiano.png");
                button1.Text = "italiano";

                AudioPlayer.CaricaAudio("italiano.wav");
                AudioPlayer.PlayAudio();

                label1.Text = "Clicca su una truppa del tuo team per muoverti";
                label2.Text = "Puoi spostarti solo nei punti evidenziati";
                label3.Text = "Invadi una casella nemica per ingaggiare una lotta";
                label4.Text = "Ora spacca qualche culo!";

                Form1.CambiaLingua(Form1.Fform1);

                italiano = false;
            }
            else
            {
                button1.BackgroundImage = Form1.CaricaImmagine("inglese.png");
                button1.Text = "english";

                AudioPlayer.CaricaAudio("inglese.wav");
                AudioPlayer.PlayAudio();

                label1.Text = "Click on a troop from your team to move";
                label2.Text = "You can only move to highlighted spots";
                label3.Text = "Invade an enemy square to engage a fight";
                label4.Text = "Now beat some ass up!";

                Form1.CambiaLingua(Form1.Fform1);

                italiano = true;
            }
        }
    }
}
