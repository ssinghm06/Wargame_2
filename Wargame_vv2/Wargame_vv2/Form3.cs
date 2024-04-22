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
    public partial class Form3 : Form
    {
        // mi serve un istanza di form1 perchè senno dovrei riscrivere alcuni metodi
        // la soluzione migliore sarebbe quella di creare una classe per la gestione del gioco
        // Form1 form1 = new Form1();

        private Squadra squadraSelezionata;
        private Squadra squadraAvversaria;

        private Personaggio personaggioScelto;
        private Personaggio personaggioAvversarioScelto;

        private bool attaccoMago = false;
        private bool turno = true;

        private bool chiusura = false;

        private bool giocatoreVinto = false;

        public Form3(Squadra squadraGiocatore, Squadra squadraAvversaria)
        {
            InitializeComponent();

            Guerriero1.BackgroundImage = Form1.CaricaImmagine("guerriero.png");
            Cavaliere1.BackgroundImage = Form1.CaricaImmagine("cavaliere.png");
            Arciere1.BackgroundImage = Form1.CaricaImmagine("arciere.png");
            Mago1.BackgroundImage = Form1.CaricaImmagine("mago.png");
            Guerriero2.BackgroundImage = Form1.CaricaImmagine("guerriero.png");
            Cavaliere2.BackgroundImage = Form1.CaricaImmagine("cavaliere.png");
            Arciere2.BackgroundImage = Form1.CaricaImmagine("arciere.png");
            Mago2.BackgroundImage = Form1.CaricaImmagine("mago.png");
            AttaccoBase.BackgroundImage = Form1.CaricaImmagine("baseAttack.png");
            AttaccoPesante.BackgroundImage = Form1.CaricaImmagine("heavyAttack.png");
            Difesa.BackgroundImage = Form1.CaricaImmagine("defense.png");

            squadraSelezionata = squadraGiocatore;
            this.squadraAvversaria = squadraAvversaria;
            Guerriero1.BackgroundImageLayout = ImageLayout.Stretch;
            Guerriero1.FlatStyle = FlatStyle.Flat;
            Guerriero1.FlatAppearance.BorderSize = 0;
            Guerriero2.BackgroundImageLayout = ImageLayout.Stretch;
            Guerriero2.FlatStyle = FlatStyle.Flat;
            Guerriero2.FlatAppearance.BorderSize = 0;
            Cavaliere1.BackgroundImageLayout = ImageLayout.Stretch;
            Cavaliere1.FlatStyle = FlatStyle.Flat;
            Cavaliere1.FlatAppearance.BorderSize = 0;
            Cavaliere2.BackgroundImageLayout = ImageLayout.Stretch;
            Cavaliere2.FlatStyle = FlatStyle.Flat;
            Cavaliere2.FlatAppearance.BorderSize = 0;
            Arciere1.BackgroundImageLayout = ImageLayout.Stretch;
            Arciere1.FlatStyle = FlatStyle.Flat;
            Arciere1.FlatAppearance.BorderSize = 0;
            Arciere2.BackgroundImageLayout = ImageLayout.Stretch;
            Arciere2.FlatStyle = FlatStyle.Flat;
            Arciere2.FlatAppearance.BorderSize = 0;
            Mago1.BackgroundImageLayout = ImageLayout.Stretch;
            Mago1.FlatStyle = FlatStyle.Flat;
            Mago1.FlatAppearance.BorderSize = 0;
            Mago2.BackgroundImageLayout = ImageLayout.Stretch;
            Mago2.FlatStyle = FlatStyle.Flat;
            Mago2.FlatAppearance.BorderSize = 0;
            AttaccoBase.BackgroundImageLayout = ImageLayout.Stretch;
            AttaccoBase.FlatStyle = FlatStyle.Flat;
            AttaccoBase.FlatAppearance.BorderSize = 0;
            AttaccoPesante.BackgroundImageLayout = ImageLayout.Stretch;
            AttaccoPesante.FlatStyle = FlatStyle.Flat;
            AttaccoPesante.FlatAppearance.BorderSize = 0;
            Difesa.BackgroundImageLayout = ImageLayout.Stretch;
            Difesa.FlatStyle = FlatStyle.Flat;
            Difesa.FlatAppearance.BorderSize = 0;

            AttaccoBase.FlatAppearance.BorderColor = Color.Black;
            AttaccoBase.FlatAppearance.BorderSize = 5;
            AttaccoPesante.FlatAppearance.BorderColor = Color.Black;
            AttaccoPesante.FlatAppearance.BorderSize = 5;
            Difesa.FlatAppearance.BorderColor = Color.Black;
            Difesa.FlatAppearance.BorderSize = 5;
            Guerriero1.FlatAppearance.BorderColor = Color.Black;
            Guerriero1.FlatAppearance.BorderSize = 5;
            Guerriero2.FlatAppearance.BorderColor = Color.Black;
            Guerriero2.FlatAppearance.BorderSize = 5;
            Cavaliere1.FlatAppearance.BorderColor = Color.Black;
            Cavaliere1.FlatAppearance.BorderSize = 5;
            Cavaliere2.FlatAppearance.BorderColor = Color.Black;
            Cavaliere2.FlatAppearance.BorderSize = 5;
            Arciere1.FlatAppearance.BorderColor = Color.Black;
            Arciere1.FlatAppearance.BorderSize = 5;
            Arciere2.FlatAppearance.BorderColor = Color.Black;
            Arciere2.FlatAppearance.BorderSize = 5;
            Mago1.FlatAppearance.BorderColor = Color.Black;
            Mago1.FlatAppearance.BorderSize = 5;
            Mago2.FlatAppearance.BorderColor = Color.Black;
            Mago2.FlatAppearance.BorderSize = 5;
        }

        public void TriggerFormClosed()
        {
            FormClosedEventArgs e = new FormClosedEventArgs(CloseReason.None);
            OnFormClosed(e);
        }

        private void AbilitaPulsantiAvversari()
        {
            foreach (Personaggio p in squadraAvversaria.Squad)
            {
                if (!p.Morto)
                {
                    AbilitaPulsantePersonaggioAvversario(p);

                }
            }
        }

        private void AbilitaPulsantePersonaggioAvversario(Personaggio personaggio)
        {
            if (personaggio is Guerriero)
            {
                Guerriero2.Enabled = true;
                panel8.BackColor = Color.Red;
                label33.BackColor = Color.IndianRed;
                label32.BackColor = Color.IndianRed;
                label15.BackColor = Color.IndianRed;
                label43.BackColor = Color.IndianRed;
                label14.BackColor = Color.IndianRed;
                Guerriero2.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (personaggio is Cavaliere)
            {
                Cavaliere2.Enabled = true;
                panel7.BackColor = Color.Red;
                label31.BackColor = Color.IndianRed;
                label30.BackColor = Color.IndianRed;
                label13.BackColor = Color.IndianRed;
                label42.BackColor = Color.IndianRed;
                label12.BackColor = Color.IndianRed;
                Cavaliere2.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (personaggio is Arciere)
            {
                Arciere2.Enabled = true;
                panel6.BackColor = Color.Red;
                label29.BackColor = Color.IndianRed;
                label28.BackColor = Color.IndianRed;
                label11.BackColor = Color.IndianRed;
                label41.BackColor = Color.IndianRed;
                label10.BackColor = Color.IndianRed;
                Arciere2.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (personaggio is Mago)
            {
                Mago2.Enabled = true;
                panel5.BackColor = Color.Red;
                label27.BackColor = Color.IndianRed;
                label26.BackColor = Color.IndianRed;
                label7.BackColor = Color.IndianRed;
                label38.BackColor = Color.IndianRed;
                label6.BackColor = Color.IndianRed;
                Mago2.BackColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void DisabilitaPulsantiAvversari()
        {
            foreach (Personaggio p in squadraAvversaria.Squad)
            {
                if (p is Guerriero)
                {
                    Guerriero2.Enabled = false;
                    panel8.BackColor = Color.FromArgb(255, 128, 128);
                    label33.BackColor = Color.RosyBrown;
                    label32.BackColor = Color.RosyBrown;
                    label15.BackColor = Color.RosyBrown;
                    label43.BackColor = Color.RosyBrown;
                    label14.BackColor = Color.RosyBrown;
                    Guerriero2.BackColor = Color.FromArgb(255, 192, 192);
                }
                else if (p is Cavaliere)
                {
                    Cavaliere2.Enabled = false;
                    panel7.BackColor = Color.FromArgb(255, 128, 128);
                    label31.BackColor = Color.RosyBrown;
                    label30.BackColor = Color.RosyBrown;
                    label13.BackColor = Color.RosyBrown;
                    label42.BackColor = Color.RosyBrown;
                    label12.BackColor = Color.RosyBrown;
                    Cavaliere2.BackColor = Color.FromArgb(255, 192, 192);
                }
                else if (p is Arciere)
                {
                    Arciere2.Enabled = false;
                    panel6.BackColor = Color.FromArgb(255, 128, 128);
                    label29.BackColor = Color.RosyBrown;
                    label28.BackColor = Color.RosyBrown;
                    label11.BackColor = Color.RosyBrown;
                    label41.BackColor = Color.RosyBrown;
                    label10.BackColor = Color.RosyBrown;
                    Arciere2.BackColor = Color.FromArgb(255, 192, 192);
                }
                else if (p is Mago)
                {
                    Mago2.Enabled = false;
                    panel5.BackColor = Color.FromArgb(255, 128, 128);
                    label27.BackColor = Color.RosyBrown;
                    label26.BackColor = Color.RosyBrown;
                    label7.BackColor = Color.RosyBrown;
                    label38.BackColor = Color.RosyBrown;
                    label6.BackColor = Color.RosyBrown;
                    Mago2.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
        }

        private void AbilitaPulsantiGiocatore()
        {
            foreach (Personaggio p in squadraSelezionata.Squad)
            {
                if (!p.Morto)
                {
                    AbilitaPulsantePersonaggioGiocatore(p);
                }
            }
        }

        private void AbilitaPulsantePersonaggioGiocatore(Personaggio personaggio)
        {
            if (personaggio is Guerriero)
            {
                Guerriero1.Enabled = true;
                panel1.BackColor = Color.FromArgb(128, 255, 255);
                label2.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label3.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label18.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label19.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label34.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                Guerriero1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
            else if (personaggio is Cavaliere)
            {
                Cavaliere1.Enabled = true;
                panel2.BackColor = Color.FromArgb(128, 255, 255);
                label5.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label4.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label21.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label20.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label35.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                Cavaliere1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
            else if (personaggio is Arciere)
            {
                Arciere1.Enabled = true;
                panel3.BackColor = Color.FromArgb(128, 255, 255);
                label23.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label22.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label8.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label9.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label36.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                Arciere1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);

            }
            else if (personaggio is Mago)
            {
                Mago1.Enabled = true;
                panel4.BackColor = Color.FromArgb(128, 255, 255);
                label25.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label24.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label39.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label40.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                label37.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                Mago1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
        }

        private void DisabilitaPulsantiGiocatore()
        {
            foreach (Personaggio p in squadraSelezionata.Squad)
            {
                if (p is Guerriero)
                {
                    Guerriero1.Enabled = false;
                    panel1.BackColor = Color.FromArgb(192, 255, 255);
                    label2.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label3.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label18.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label19.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label34.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    Guerriero1.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
                }
                else if (p is Cavaliere)
                {
                    Cavaliere1.Enabled = false;
                    panel2.BackColor = Color.FromArgb(192, 255, 255);
                    label5.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label4.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label21.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label20.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label35.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    Cavaliere1.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
                }
                else if (p is Arciere)
                {
                    Arciere1.Enabled = false;
                    panel3.BackColor = Color.FromArgb(192, 255, 255);
                    label23.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label22.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label8.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label9.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label36.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    Arciere1.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
                }
                else if (p is Mago)
                {
                    Mago1.Enabled = false;
                    panel4.BackColor = Color.FromArgb(192, 255, 255);
                    label25.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label24.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label39.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label40.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    label37.BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
                    Mago1.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
                }
            }
        }

        private void AbilitaPulsantiAttacco()
        {
            AttaccoBase.BackColor = Color.Yellow;
            AttaccoPesante.BackColor = Color.Yellow;
            AttaccoBase.Enabled = true;
            AttaccoPesante.Enabled = true;
        }

        private void DisabilitaPulsantiAttacco()
        {
            AttaccoBase.BackColor = Color.FromArgb(255, 255, 192);
            AttaccoPesante.BackColor = Color.FromArgb(255, 255, 192);
            AttaccoBase.Enabled = false;
            AttaccoPesante.Enabled = false;
        }

        private void AttivaDifesaeGrafica()
        {
            Difesa.Enabled = true;
            Difesa.BackColor = Color.Yellow;
        }

        private void DisattivaDifesaeGrafica()
        {
            Difesa.Enabled = false;
            Difesa.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void DopoDifesa()
        {
            DisabilitaPulsantiAttacco();
            AbilitaPulsantiGiocatore();
            DisabilitaPulsantiAvversari();
            DisattivaDifesaeGrafica();
        }

        private void AlgoritmoBaseBot()
        {
            Random random = new Random();
            int azione = random.Next(0, 3);
            int personaggioBotIndex = random.Next(0, squadraAvversaria.Squad.Count);
            int personaggioGiocatoreIndex = random.Next(0, squadraSelezionata.Squad.Count);

            Personaggio personaggioBot = squadraAvversaria.Squad[personaggioBotIndex];
            Personaggio personaggioGiocatore = squadraSelezionata.Squad[personaggioGiocatoreIndex];

            if (!personaggioBot.Morto)
            {
                if (personaggioBot is Mago)
                {
                    if (azione == 0)
                    {
                        int alleatoIndex = random.Next(0, squadraAvversaria.Squad.Count);
                        Personaggio alleato = squadraAvversaria.Squad[alleatoIndex];

                        if (!alleato.Morto)
                        {
                            ((Mago)personaggioBot).AttaccoBase(alleato);
                            MessageBox.Show($"Cura minore eseguita da: {personaggioBot.ToString()} su: {alleato.ToString()}");
                            VerificaMorti();
                            AggiornaStat();
                        }
                        else
                        {
                            AlgoritmoBaseBot();
                        }
                    }
                    else if (azione == 1)
                    {
                        int alleatoIndex = random.Next(0, squadraAvversaria.Squad.Count);
                        Personaggio alleato = squadraAvversaria.Squad[alleatoIndex];

                        if (!alleato.Morto)
                        {
                            ((Mago)personaggioBot).AttaccoPesante(alleato);
                            MessageBox.Show($"Cura maggiore eseguita da: {personaggioBot.ToString()} su: {alleato.ToString()}");
                            VerificaMorti();
                            AggiornaStat();
                        }
                        else
                        {
                            AlgoritmoBaseBot();
                        }
                    }
                    else
                    {
                        personaggioBot.AttivaDifesa();
                        MessageBox.Show($"Difesa eseguita da: {personaggioBot.ToString()}");
                        VerificaMorti();
                        AggiornaStat();
                    }
                }
                else
                {
                    if (azione == 0)
                    {
                        personaggioBot.AttaccoBase(personaggioGiocatore);
                        MessageBox.Show($"Attacco base eseguito da: {personaggioBot.ToString()} a: {personaggioGiocatore.ToString()}");
                        VerificaMorti();
                        AggiornaStat();
                    }
                    else if (azione == 1)
                    {
                        personaggioBot.AttaccoPesante(personaggioGiocatore);
                        MessageBox.Show($"Attacco pesante eseguito da: {personaggioBot.ToString()} a: {personaggioGiocatore.ToString()}");
                        VerificaMorti();
                        AggiornaStat();
                    }
                    else
                    {
                        personaggioBot.AttivaDifesa();
                        MessageBox.Show($"Difesa eseguita da: {personaggioBot.ToString()}");
                        VerificaMorti();
                        AggiornaStat();
                    }
                }
            }
            else
            {
                AlgoritmoBaseBot();
            }
        }

        private void VerificaMorti()
        {
            foreach (Personaggio p in squadraAvversaria.Squad)
            {
                if (p.Morto)
                {
                    if (p is Guerriero)
                    {
                        Guerriero2.Enabled = false;

                    }
                    else if (p is Cavaliere)
                    {
                        Cavaliere2.Enabled = false;

                    }
                    else if (p is Arciere)
                    {
                        Arciere2.Enabled = false;

                    }
                    else if (p is Mago)
                    {
                        Mago2.Enabled = false;

                    }
                }
                else
                {
                    if (p is Guerriero)
                    {
                        Guerriero2.Enabled = true;
                    }
                    else if (p is Cavaliere)
                    {
                        Cavaliere2.Enabled = true;
                    }
                    else if (p is Arciere)
                    {
                        Arciere2.Enabled = true;
                    }
                    else if (p is Mago)
                    {
                        Mago2.Enabled = true;
                    }
                }
            }

            foreach (Personaggio p in squadraSelezionata.Squad)
            {
                if (p.Morto)
                {
                    if (p is Guerriero)
                    {
                        Guerriero1.Enabled = false;

                    }
                    else if (p is Cavaliere)
                    {
                        Cavaliere1.Enabled = false;


                    }
                    else if (p is Arciere)
                    {
                        Arciere1.Enabled = false;

                    }
                    else if (p is Mago)
                    {
                        Mago1.Enabled = false;

                    }
                }
                else
                {
                    if (p is Guerriero)
                    {
                        Guerriero1.Enabled = true;
                    }
                    else if (p is Cavaliere)
                    {
                        Cavaliere1.Enabled = true;
                    }
                    else if (p is Arciere)
                    {
                        Arciere1.Enabled = true;
                    }
                    else if (p is Mago)
                    {
                        Mago1.Enabled = true;
                    }
                }
            }
        }

        public Squadra Winner()
        {
            if (giocatoreVinto)
                return squadraSelezionata;
            else
                return squadraAvversaria;
        }

        public Squadra Loser()
        {
            if (giocatoreVinto)
                return squadraAvversaria;
            else
                return squadraSelezionata;
        }

        private void IsEndGame()
        {
            if (squadraSelezionata.Squad.All(p => p.Morto))
            {
                foreach (Personaggio p in squadraAvversaria.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il bot ha vinto");
                this.Close();
                TriggerFormClosed();
                chiusura = true;
            }
            else if (squadraAvversaria.Squad.All(p => p.Morto))
            {
                foreach (Personaggio p in squadraSelezionata.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il giocatore ha vinto!");
                giocatoreVinto = true;
                this.Close();
                TriggerFormClosed();
                chiusura = true;
            }

            else if (squadraSelezionata.Squad.Count(p => !p.Morto) == 1 && squadraSelezionata.Squad.Any(p => p is Mago && !p.Morto))
            {
                foreach (Personaggio p in squadraAvversaria.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il bot ha vinto");
                this.Close();
                TriggerFormClosed();
                chiusura = true;
            }
            else if (squadraAvversaria.Squad.Count(p => !p.Morto) == 1 && squadraAvversaria.Squad.Any(p => p is Mago && !p.Morto))
            {
                foreach (Personaggio p in squadraSelezionata.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il giocatore ha vinto!");
                giocatoreVinto = true;
                this.Close();
                TriggerFormClosed();
                chiusura = true;
            }
        }

        private void VerificaFerito()
        {
            foreach (Personaggio p in squadraAvversaria.Squad)
            {
                if (p.Ferito)
                {
                    p.PuntiVita -= 50;
                    p.Ferito = false;
                }
            }

            foreach (Personaggio p in squadraSelezionata.Squad)
            {
                if (p.Ferito)
                {
                    p.PuntiVita -= 50;
                    p.Ferito = false;
                }
            }
        }

        private void CaricaPuntiAzione()
        {
            foreach (Personaggio p in squadraAvversaria.Squad)
            {
                p.PuntiAzione += 5;
            }
            foreach (Personaggio p in squadraSelezionata.Squad)
            {
                p.PuntiAzione += 5;
            }

        }


        private void AggiornaStatGuerrierioGiocatore()
        {
            label18.Text = squadraSelezionata.Squad[0].PuntiVita.ToString();
            label19.Text = squadraSelezionata.Squad[0].PuntiAzione.ToString();
        }

        private void AggiornaStatCavaliereGiocatore()
        {
            label21.Text = squadraSelezionata.Squad[1].PuntiVita.ToString();
            label20.Text = squadraSelezionata.Squad[1].PuntiAzione.ToString();
        }

        private void AggiornaStatArciereGiocatore()
        {
            label23.Text = squadraSelezionata.Squad[2].PuntiVita.ToString();
            label22.Text = squadraSelezionata.Squad[2].PuntiAzione.ToString();
        }

        private void AggiornaStatMagoGiocatore()
        {
            label25.Text = squadraSelezionata.Squad[3].PuntiVita.ToString();
            label24.Text = squadraSelezionata.Squad[3].PuntiAzione.ToString();
        }

        private void AggiornaStatGuerrieroAvversario()
        {
            label33.Text = squadraAvversaria.Squad[0].PuntiVita.ToString();
            label32.Text = squadraAvversaria.Squad[0].PuntiAzione.ToString();
        }

        private void AggiornaStatCavaliereAvversario()
        {
            label31.Text = squadraAvversaria.Squad[1].PuntiVita.ToString();
            label30.Text = squadraAvversaria.Squad[1].PuntiAzione.ToString();
        }

        private void AggiornaStatArciereAvversario()
        {
            label29.Text = squadraAvversaria.Squad[2].PuntiVita.ToString();
            label28.Text = squadraAvversaria.Squad[2].PuntiAzione.ToString();
        }

        private void AggiornaStatMagoAvversario()
        {
            label27.Text = squadraAvversaria.Squad[3].PuntiVita.ToString();
            label26.Text = squadraAvversaria.Squad[3].PuntiAzione.ToString();
        }

        private void AggiornaStat()
        {
            AggiornaStatArciereAvversario();
            AggiornaStatArciereGiocatore();
            AggiornaStatCavaliereAvversario();
            AggiornaStatCavaliereGiocatore();
            AggiornaStatGuerrierioGiocatore();
            AggiornaStatGuerrieroAvversario();
            AggiornaStatMagoAvversario();
            AggiornaStatMagoGiocatore();
        }

        private void GestionePuslantiCuraMago()
        {
            DisabilitaPulsantiGiocatore();
            AbilitaPulsantiAttacco();
            DisattivaDifesaeGrafica();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DisabilitaPulsantiAvversari();
            DisabilitaPulsantiAttacco();
            DisattivaDifesaeGrafica();
            AggiornaStat();
        }

        private void Guerriero1_Click(object sender, EventArgs e)
        {
            if (attaccoMago)
            {
                GestionePuslantiCuraMago();
                personaggioScelto = squadraSelezionata.Squad[0];
            }
            else
            {
                personaggioScelto = squadraSelezionata.Squad[0];
                DisabilitaPulsantiGiocatore();
                AbilitaPulsantiAvversari();
                AttivaDifesaeGrafica();
            }
        }

        private void Cavaliere1_Click(object sender, EventArgs e)
        {
            if (attaccoMago)
            {
                GestionePuslantiCuraMago();
                personaggioScelto = squadraSelezionata.Squad[1];
            }
            else
            {
                personaggioScelto = squadraSelezionata.Squad[1];
                DisabilitaPulsantiGiocatore();
                AbilitaPulsantiAvversari();
                AttivaDifesaeGrafica();
            }
        }

        private void Arciere1_Click(object sender, EventArgs e)
        {
            if (attaccoMago)
            {
                GestionePuslantiCuraMago();
                personaggioScelto = squadraSelezionata.Squad[2];
            }
            else
            {
                personaggioScelto = squadraSelezionata.Squad[2];
                DisabilitaPulsantiGiocatore();
                AbilitaPulsantiAvversari();
                AttivaDifesaeGrafica();
            }
        }

        private void Mago1_Click(object sender, EventArgs e)
        {
            if (attaccoMago)
            {
                GestionePuslantiCuraMago();
                personaggioScelto = squadraSelezionata.Squad[3];
            }
            else
            {
                personaggioScelto = squadraSelezionata.Squad[3];
                AttivaDifesaeGrafica();
                attaccoMago = true;
            }
        }

        private void Guerriero2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[0];
            AbilitaPulsantiAttacco();
            DisattivaDifesaeGrafica();
        }

        private void Cavaliere2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[1];
            AbilitaPulsantiAttacco();
            DisattivaDifesaeGrafica();
        }

        private void Arciere2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[2];
            AbilitaPulsantiAttacco();
            DisattivaDifesaeGrafica();
        }

        private void Mago2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[3];
            AbilitaPulsantiAttacco();
            DisattivaDifesaeGrafica();
        }

        private void AttaccoBase_Click(object sender, EventArgs e)
        {
            try
            {
                if (attaccoMago)
                {
                    if (personaggioScelto != null)
                    {
                        squadraSelezionata.Squad[3].AttaccoBase(personaggioScelto);
                        MessageBox.Show("Cura minore eseguita!");
                        AggiornaStat();
                        AbilitaPulsantiGiocatore();
                        DisabilitaPulsantiAttacco();
                        DisattivaDifesaeGrafica();
                        attaccoMago = false;
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
                        if (chiusura)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (personaggioScelto != null && personaggioAvversarioScelto != null)
                    {
                        personaggioScelto.AttaccoBase(personaggioAvversarioScelto);
                        MessageBox.Show("Attacco base eseguito!");
                        AggiornaStat();
                        AbilitaPulsantiGiocatore();
                        DisabilitaPulsantiAttacco();
                        DisattivaDifesaeGrafica();
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
                        if (chiusura)
                        {
                            return;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                if (turno == false)
                {
                    MessageBox.Show($"Errore: {ex.Message}");
                }
                AbilitaPulsantiGiocatore();
                DisabilitaPulsantiAvversari();
                DisabilitaPulsantiAttacco();
            }
        }

        private void AttaccoPesante_Click(object sender, EventArgs e)
        {
            try
            {
                if (attaccoMago)
                {
                    if (personaggioScelto != null)
                    {
                        squadraSelezionata.Squad[3].AttaccoPesante(personaggioScelto);
                        MessageBox.Show("Cura maggiore eseguita!");
                        AggiornaStat();
                        AbilitaPulsantiGiocatore();
                        DisabilitaPulsantiAttacco();
                        DisattivaDifesaeGrafica();
                        attaccoMago = false;
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
                        if (chiusura)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (personaggioScelto != null && personaggioAvversarioScelto != null)
                    {
                        personaggioScelto.AttaccoPesante(personaggioAvversarioScelto);
                        MessageBox.Show("Attacco pesante eseguito!");
                        AggiornaStat();
                        AbilitaPulsantiGiocatore();
                        DisabilitaPulsantiAttacco();
                        DisattivaDifesaeGrafica();
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
                        if (chiusura)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (turno == false)
                {
                    MessageBox.Show($"Errore: {ex.Message}");
                }
                AbilitaPulsantiGiocatore();
                DisabilitaPulsantiAvversari();
                DisabilitaPulsantiAttacco();
            }
        }

        private void Difesa_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaggioScelto != null)
                {
                    personaggioScelto.AttivaDifesa();
                    MessageBox.Show("Difesa attivata");
                    DopoDifesa();
                    turno = false;
                    AlgoritmoBaseBot();
                    VerificaMorti();
                    CaricaPuntiAzione();
                    VerificaFerito();
                    DisabilitaPulsantiAvversari();
                }
            }
            catch (Exception ex)
            {
                if (turno == false)
                {
                    MessageBox.Show($"Errore: {ex.Message}");
                }
                AbilitaPulsantiGiocatore();
                DisabilitaPulsantiAvversari();
                DisabilitaPulsantiAttacco();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }
    }
}
