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
            this.Location = new Point(88, 122);

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

            if (Form4.Italiano)
            {
                label1.Text = "How to play";
                label2.Text = "Select the character with whom you want to perform the action";
                label5.Text = "Now you can:\r\n--If you have chosen the wizard:\r\n-Select one of your allies to heal.\r\n--Otherwise:\r\n-Click the \"defense\" button to defend yourself.\r\n-Select an opponent character to attack";
                label7.Text = "If you have chosen to attack an\r\nopponent character or\r\nheal one of your allies,\r\nyou can choose between:\r\n-basic attack\r\n(less damage and fewer AP)\r\n-heavy attack\r\n(more damage and more AP)\r\nNote: for the wizard, the\r\ntwo attacks correspond to \r\ngreater and lesser healing";
                label8.Text = "Who wins?";
                label9.Text = "The battle ends when either\r\nthe player or the bot\r\nhas only the wizard alive\r\nor when all members\r\nof a team are dead.\r\nThe eliminated team will disappear from the board";
                label10.Text = "Abilities";
                label11.Text = "The warrior has no abilities\r\nbut deals more damage \r\nthan everyone else\r\n";
                label12.Text = "The knight has the \r\nchance to deal double\r\ndamage with each\r\nof his attacks";
                label13.Text = "The archer deals damage over time:\r\nfor each of his attacks, \r\nthe enemy will take damage\r\nagain in the next turn";
                label14.Text = "The wizard can heal allies,\r\nbut he cannot attack";
                label15.Text = "Statistics";
                label17.Text = "Warrior";
                label16.Text = "HP: 700\r\nLight Attack: 100 HP | 10 AP\r\nHeavy Attack: 300 HP | 25 AP\r\n";
                label18.Text = "Knight";
                label19.Text = "HP: 950\r\nLight Attack: 70 HP | 12 AP\r\nHeavy Attack: 125 HP | 22 AP\r\n";
                label20.Text = "Archer";
                label21.Text = "HP: 400\r\nLight Attack: 75 HP | 5 AP\r\nHeavy Attack: 100 HP | 10 AP\r\n";
                label22.Text = "Wizard";
                label23.Text = "HP: 1200\r\nLesser Healing : 200 HP | 15 AP\r\nGreater Healing: 500 HP | 25 AP\r\n";
                label24.Text = "Note: all characters start the battle with 50 AP\r\nand recover 5 AP each turn.";
            }
            else
            {
                label1.Text = "Come giocare";
                label2.Text = "Seleziona il personaggio con cui vuoi eseguire l'azione";
                label5.Text = "Ora puoi:\r\n--Se hai scelto il mago:\r\n    -Selezionare un tuo \r\n      alleato per poterlo curare\r\n--altrimenti:\r\n   -Cliccare il pulsante \"difesa\"\r\n     per difenderti\r\n   -Selezionare un personaggio\r\n     avversario per attaccarlo";
                label7.Text = "Se hai scelto di attaccare un\r\npersonaggio avversario o\r\ndi curare un tuo alleato,\r\npuoi scegliere tra un:\r\n-attacco base\r\n  (meno danni e meno PA)\r\n-attacco pesante\r\n   (più danni e più PA)\r\nNota: per il mago i due attacchi\r\ncorrispondono alla cura \r\nmaggiore e minore";
                label8.Text = "Chi vince?";
                label9.Text = "La battaglia finisce quando\r\nil giocatore o il bot\r\nhanno in vita solo il mago\r\noppure quando tutti\r\ni membri di una squadra sono \r\nmorti.\r\nLa squadra eliminata scomparirà\r\ndal tabellone";
                label10.Text = "Abilità";
                label11.Text = "Il guerriero non ha abilità\r\nma infligge più danni \r\ndi tutti\r\n";
                label12.Text = "Il cavaliere ha la \r\nprobabilità di infliggere\r\ndanni doppi ad ogni\r\nsuo attacco\r\n";
                label13.Text = "L'arciere fa danno nel tempo:\r\nper ogni suo attacco, al turno \r\nsuccessivo il nemico prenderà\r\nnuovamente danno\r\n";
                label14.Text = "Il mago può curare gli alleati\r\nma tuttavia, non può attaccare";
                label15.Text = "Statistiche";
                label17.Text = "Guerriero";
                label16.Text = "PS: 700\r\nAttacco base: 100 PS | 10 PA\r\nAttacco pesante: 300 PS | 25 PA\r\n";
                label18.Text = "Cavaliere";
                label19.Text = "PS: 950\r\nAttacco base: 70 PS | 12 PA\r\nAttacco pesante: 125 PS | 22 PA\r\n";
                label20.Text = "Arciere";
                label21.Text = "PS: 400\r\nAttacco base: 75 PS | 5 PA\r\nAttacco pesante: 100 PS | 10 PA\r\n";
                label22.Text = "Mago";
                label23.Text = "PS: 1200\r\nCura minore: 200 PS | 15 PA\r\nCura maggiore: 500 PS | 25 PA\r\n";
                label24.Text = "Nota: tutti i personaggi iniziano la battaglia con\r\n50 PA e ad ogni turno ne recuperano 5.\r\n";
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AudioPlayer.CaricaAudio("settingsClick.wav");
            AudioPlayer.PlayAudio();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
