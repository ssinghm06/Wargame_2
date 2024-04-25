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
    public partial class ResultBox : Form
    {
        public ResultBox()
        {
            InitializeComponent();
        }

        private void ResultBox_Load(object sender, EventArgs e)
        {

        }

        private void replayPictureBox_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void exitPictureBox_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        public string Message
        {
            get { return messageLabel.Text; }
            set { messageLabel.Text = value; }
        }

        public Image ReplayImage
        {
            get { return replayPictureBox.Image; }
            set
            {
                replayPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                replayPictureBox.Image = value;
            }
        }

        public Image ExitImage
        {
            get { return exitPictureBox.Image; }
            set
            {
                exitPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                exitPictureBox.Image = value;
            }
        }
    }
}
