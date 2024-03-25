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
        Form1 form1 = new Form1();

        private Squadra squadraSelezionata;
        private Squadra squadraAvversaria;

        private Personaggio personaggioScelto;
        private Personaggio personaggioAvversarioScelto;

        private bool attaccoMago = false;
        private bool turno = true;

        public Form3(Squadra squadraGiocatore, Squadra squadraAvversaria)
        {
            InitializeComponent();
            Guerriero1.BackgroundImageLayout = ImageLayout.Zoom;
            Guerriero1.BackgroundImage = form1.CaricaImmagine("CartaGuerriero.png");
            
            squadraSelezionata = squadraGiocatore;
            this.squadraAvversaria = squadraAvversaria;
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
            }
            else if (personaggio is Cavaliere)
            {
                Cavaliere2.Enabled = true;
            }
            else if (personaggio is Arciere)
            {
                Arciere2.Enabled = true;
            }
            else if (personaggio is Mago)
            {
                Mago2.Enabled = true;
            }
        }

        private void DisabilitaPulsantiAvversari()
        {
            Guerriero2.Enabled = false;
            Cavaliere2.Enabled = false;
            Arciere2.Enabled = false;
            Mago2.Enabled = false;
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
            }
            else if (personaggio is Cavaliere)
            {
                Cavaliere1.Enabled = true;
            }
            else if (personaggio is Arciere)
            {
                Arciere1.Enabled = true;
            }
            else if (personaggio is Mago)
            {
                Mago1.Enabled = true;
            }
        }

        private void DisabilitaPulsantiGiocatore()
        {
            Guerriero1.Enabled = false;
            Cavaliere1.Enabled = false;
            Arciere1.Enabled = false;
            Mago1.Enabled = false;
        }

        private void AbilitaPulsantiAttacco()
        {
            AttaccoBase.Enabled = true;
            AttaccoPesante.Enabled = true;
        }

        private void DisabilitaPulsantiAttacco()
        {
            AttaccoBase.Enabled = false;
            AttaccoPesante.Enabled = false;
        }

        private void DopoDifesa()
        {
            DisabilitaPulsantiAttacco();
            AbilitaPulsantiGiocatore();
            DisabilitaPulsantiAvversari();
            Difesa.Enabled = false;
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
            }
            else if (squadraAvversaria.Squad.All(p => p.Morto))
            {
                foreach (Personaggio p in squadraSelezionata.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il giocatore ha vinto!");
                this.Close();
            }

            else if (squadraSelezionata.Squad.Count(p => !p.Morto) == 1 && squadraSelezionata.Squad.Any(p => p is Mago && !p.Morto))
            {
                foreach (Personaggio p in squadraAvversaria.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il bot ha vinto");
            }
            else if (squadraAvversaria.Squad.Count(p => !p.Morto) == 1 && squadraAvversaria.Squad.Any(p => p is Mago && !p.Morto))
            {
                foreach (Personaggio p in squadraSelezionata.Squad)
                {
                    p.PuntiAzione = p.PuntiAzioneMassimi;
                    p.PuntiVita = p.PuntiVitaMassimi;
                }
                MessageBox.Show("Il giocatore ha vinto!");
                this.Close();
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
            Difesa.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DisabilitaPulsantiAvversari();
            DisabilitaPulsantiAttacco();
            Difesa.Enabled = false;
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
                Difesa.Enabled = true;
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
                Difesa.Enabled = true;
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
                Difesa.Enabled = true;
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
                Difesa.Enabled = true;
                attaccoMago = true;
            }
        }

        private void Guerriero2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[0];
            AbilitaPulsantiAttacco();
            Difesa.Enabled = false;
        }

        private void Cavaliere2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[1];
            AbilitaPulsantiAttacco();
            Difesa.Enabled = false;
        }

        private void Arciere2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[2];
            AbilitaPulsantiAttacco();
            Difesa.Enabled = false;
        }

        private void Mago2_Click(object sender, EventArgs e)
        {
            personaggioAvversarioScelto = squadraAvversaria.Squad[3];
            AbilitaPulsantiAttacco();
            Difesa.Enabled = false;
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
                        Difesa.Enabled = false;
                        attaccoMago = false;
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
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
                        Difesa.Enabled = false;
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
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
                        Difesa.Enabled = false;
                        attaccoMago = false;
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
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
                        Difesa.Enabled = false;
                        turno = false;
                        AlgoritmoBaseBot();
                        VerificaMorti();
                        CaricaPuntiAzione();
                        VerificaFerito();
                        DisabilitaPulsantiAvversari();
                        IsEndGame();
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
    }
}
