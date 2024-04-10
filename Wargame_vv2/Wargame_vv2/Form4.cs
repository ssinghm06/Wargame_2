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

        public Form4()
        {
            InitializeComponent();

            this.BackColor = Color.OldLace;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1170, 180);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Form1.CaricaImmagine("back.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            suono = Form1.CaricaSuono("chiusura_baule.wav");
            if (suono != null)
                suono.Play();

            this.Close();
        }
    }
}
