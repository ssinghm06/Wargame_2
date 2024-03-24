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
        private Squadra squadraSelezionata;
        private Squadra squadraAvversaria;

        private Personaggio personaggioScelto;
        private Personaggio personaggioAvversarioScelto;

        private bool attaccoMago = false;

        public Form3(Squadra squadraGiocatore, Squadra squadraAvversaria)
        {
            InitializeComponent();

            this.squadraSelezionata = squadraGiocatore;
            this.squadraAvversaria = squadraAvversaria;
        }

        private void AbilitaPulsantiAvversari()
        {
            Guerriero2.Enabled = true;
            Cavaliere2.Enabled = true;
            Arciere2.Enabled = true;
            Mago2.Enabled = true;
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
            Guerriero1.Enabled = true;
            Cavaliere1.Enabled = true;
            Arciere1.Enabled = true;
            Mago1.Enabled = true;
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
            if (attaccoMago)
            {
                if (personaggioScelto != null)
                {
                    personaggioScelto.AttaccoBase(personaggioScelto);
                    MessageBox.Show("Cura minore eseguita!");
                    AggiornaStat();
                    DisabilitaPulsantiAvversari();
                    AbilitaPulsantiGiocatore();
                    DisabilitaPulsantiAttacco();
                    Difesa.Enabled = false;
                    attaccoMago = false;
                }
            }
            else
            {
                if (personaggioScelto != null && personaggioAvversarioScelto != null)
                {
                    personaggioScelto.AttaccoBase(personaggioAvversarioScelto);
                    MessageBox.Show("Attacco base eseguito!");
                    AggiornaStat();
                    DisabilitaPulsantiAvversari();
                    AbilitaPulsantiGiocatore();
                    DisabilitaPulsantiAttacco();
                    Difesa.Enabled = false;
                }
            }
        }

        private void AttaccoPesante_Click(object sender, EventArgs e)
        {
            if (attaccoMago)
            {
                if (personaggioScelto != null)
                {
                    personaggioScelto.AttaccoPesante(personaggioScelto);
                    MessageBox.Show("Cura maggiore eseguita!");
                    AggiornaStat();
                    DisabilitaPulsantiAvversari();
                    AbilitaPulsantiGiocatore();
                    DisabilitaPulsantiAttacco();
                    Difesa.Enabled = false;
                    attaccoMago = false;
                }
            }
            else
            {
                if (personaggioScelto != null && personaggioAvversarioScelto != null)
                {
                    personaggioScelto.AttaccoPesante(personaggioAvversarioScelto);
                    MessageBox.Show("Attacco pesante eseguito!");
                    AggiornaStat();
                    DisabilitaPulsantiAvversari();
                    AbilitaPulsantiGiocatore();
                    DisabilitaPulsantiAttacco();
                    Difesa.Enabled = false;
                }
            }
        }

        private void Difesa_Click(object sender, EventArgs e)
        {
            if (personaggioScelto != null)
            {
                personaggioScelto.AttivaDifesa();
                MessageBox.Show("Difesa attivata");
                DopoDifesa();
            }
        }
    }
}
