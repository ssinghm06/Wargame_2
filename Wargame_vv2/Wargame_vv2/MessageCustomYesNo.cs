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
    public partial class MessageCustomYesNo : Form
    {
        public MessageCustomYesNo()
        {
            InitializeComponent();
        }

        private void MessageCustomYesNo_Load(object sender, EventArgs e)
        {

        }

        public string Message
        {
            get { return messageLabel.Text; }
            set { messageLabel.Text = value; }
        }

        public Image YesImage
        {
            get { return yesPictureBox.Image; }
            set
            {
                yesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                yesPictureBox.Image = value;
            }
        }

        public Image NoImage
        {
            get { return noPictureBox.Image; }
            set
            {
                noPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                noPictureBox.Image = value;
            }
        }

        public Image closeImage
        {
            get { return closePictureBox.Image; }
            set
            {
                closePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                closePictureBox.Image = value;
            }
        }

        private void noPictureBox_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void yesPictureBox_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
